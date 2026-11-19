import json
from pathlib import Path



# separators=(",", ":") removes extra whitespace after commas and colons


getsetstr = "{" + "get; set; }"
import shutil



def csClassFromItem(item):
    if(type(item) == int):
        return "int"
    if(type(item) == float):
        return "double"
    if(type(item) == bool):
        return "bool"
    return "string"

firstFolder = Path("./Json/")
def deleteExisting(path = Path("./Cs/")):
    for item in path.iterdir():
        if item.is_dir() and not item.is_symlink():
            shutil.rmtree(item)
        else:
            item.unlink()

def csPathFromJsonPath(jsonPath):
    return Path("./Cs/" + str(jsonPath).split("/",1)[1])
def tabs(num):
    returnVal = ""
    for i in range(num):
        returnVal += "  "
    return returnVal
def iterThroughFolder(folder, recursion = 0):
    global superString
    for item in folder.iterdir():
        if item.is_dir():
            Path(csPathFromJsonPath(item)).mkdir(exist_ok=True)
            if(item.name == "srv"):
                parseServices(Path(str(folder) +f"/{item.name}"), recursion + 1)
            else:
                iterThroughFolder(Path(str(folder) +f"/{item.name}"), recursion + 1)
            print(f"Subfolder: {item.name}")
        elif item.is_file():
            if recursion != 0 and item.name.endswith(".json"):
                with open("./"+str(folder)+"/" + item.name , "r", encoding="utf-8") as file:
                    data = json.load(file)
                pass
            elif(item.name.endswith(".cs")): 
                item.unlink(missing_ok=True)
                continue
def getNamespaceFromPath(path):
    namespace = ""
    for subfolder in str(path).split("/")[1:]:
        namespace += str(subfolder) + "."
    return namespace[:-1]
requests = {}
def parseServices(folder, recursion = 0):
    header = """using Godot;\nusing Newtonsoft.Json.Linq;\nusing System;\n\nnamespace ROS2Messages."""
    namespace = getNamespaceFromPath(folder)
    header += namespace + ";\n\n"

    for item in folder.iterdir():
        if item.is_dir(): continue
        if(not item.name.endswith(".json")): continue
        newClass = ""
        toJsonFun = tabs(1) + "public override JObject toJson() {\n" + tabs(2) + "JObject returnValue = JObject.Parse(jsonstring);\n"
        # Open the json
        with open("./"+str(folder)+"/" + item.name , "r", encoding="utf-8") as file:
                data = json.load(file)
        single_line_json = json.dumps(data, separators=(",", ":"))
        single_line_json = single_line_json.replace('"', "\\\"")
        className = item.name[:-5]
        requests[className] = namespace + "." + className
        
        newClass += "[Tool]\n"
        newClass += "[GlobalClass]" + "\n" + f"public partial class {className} : ROS2Messages.BaseRequest " + "{" + "\n"
        newClass += tabs(1) + f"public static string jsonstring = " + "\"" + single_line_json + "\"" + ";" + "\n" 
        newClass += tabs(1) + "[Export]" + "\n" + tabs(1) + "public string service " + getsetstr + "= \"\";\n"

        toJsonFun += tabs(2) + f"returnValue[\"service\"] = service;\n"

        for key in data["request"].keys():
            typeOfVar = csClassFromItem(data["request"][key])
            newClass += tabs(1) + "[Export]" + "\n" + tabs(1) + f"public {typeOfVar} {key}" + getsetstr
            if(data["request"][key] == [] or data["request"][key] == ""):
                newClass += "= \"\";\n"
            else: newClass += f"= {str(data["request"][key]).lower()};\n"
            toJsonFun += tabs(2) + f"returnValue[\"request\"][\"{key}\"] = {key};\n" # if({key} != null)
        for key in data["response"].keys():
            typeOfVar = csClassFromItem(data["response"][key])
            newClass += tabs(1) + f"public {typeOfVar} {"response_" + key};" + "\n"

        toJsonFun += tabs(2) + "return returnValue;\n" + tabs(1) + "}\n"
        newClass += toJsonFun 
        
        newClass += tabs(1) + f"{className}() " + "{" + "}" +"\n"
        newClass += "}" + "\n"
        with open(Path(str(csPathFromJsonPath(folder))+"/" + className + ".cs"), "w", encoding="utf-8") as file:
            file.write(header + newClass)


deleteExisting()
iterThroughFolder(firstFolder)

header = """using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages;

public static class Enums
{\n"""

header += tabs(1) + "public enum Services {"
for i in requests:
    header += i + ", "
header = header[:-2]
header += tabs(1)+ "}\n"
header += tabs(1) + "public static string GetServiceGlobalClassFromEnum(Services service) {\n" + tabs(2) + "return service switch {\n"
for i in requests:
    header += tabs(3) + f"Services.{i} => nameof({requests[i]}),\n"
header += tabs(3) + "_ => nameof(BaseRequest)\n" + tabs(2) + "};\n" + tabs(1) + "}\n"

    
header += "}"
with open("./ROS2Messages.cs", "w", encoding="utf-8") as file:
    file.write(header)