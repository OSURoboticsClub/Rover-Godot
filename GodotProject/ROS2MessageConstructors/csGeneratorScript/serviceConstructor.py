import json
from pathlib import Path
import shutil
from csGeneratorScript.common import *

_jsonFunBase = tabs(1) + "public override JObject toJson() {\n" + tabs(2) + "JObject returnValue = JObject.Parse(jsonstring);\n"


def variableDef(indent, type, name, default = None, getset = False, export = True):
    """Returns a constructed variable string given the inputs"""
    returnValue = ""
    if(export):
        returnValue += tabs(indent) + f"[Export] public {type} {name}"
        if(getset):
            returnValue += getsetstr
        if(default != None): returnValue += f"{default};\n"
        else: 
            if(getset): returnValue += "\n"
            else: returnValue += ";\n"
    return returnValue

def buildVariables(data : json, idx : list[str]):
    """Given an index for the dictionary data, returns the variables section, and all required function sections, as strings"""
    variables = ""
    toJsonFun = ""
    fromJsonFun = ""
    dictToUse : dict = data
    for i in idx:
        print(i)
        dictToUse = dictToUse[i]
    if(len(dictToUse.keys()) == 0):
        return "", "", ""
        
    name_prefix = ""
    for i in idx:
        name_prefix += i + "_"
    if len(idx) == 1:
        variables += tabs(1) + f"[ExportGroup(\"{idx[0]}\")]\n"
    elif len(idx) == 2:
        variables += tabs(1) + f"[ExportSubgroup(\"{idx[-1]}\")]\n"
    for key in dictToUse.keys():
        if(type(dictToUse[key]) == dict):
            # If it is a dictionary, recursively
            v1, tjf2, fjf2 = buildVariables(data, idx + [key])
            variables += v1
            toJsonFun += tjf2
            fromJsonFun += fjf2
            continue

        typeOfVar = csTypeFromItem(dictToUse[key])

        
        # Get what the default value should be in CSharp
        if(dictToUse[key] == [] or dictToUse[key] == ""):
            defVal = "= \"\""
        else: 
            defVal = f"= {str(dictToUse[key]).lower()}"

        # Add the request to the variables as a export
        variables += variableDef(1, typeOfVar, name_prefix + key, defVal, True)

        # Make sure that the request is set to the class values when called
        toJsonFun += tabs(2) + f"returnValue"
        for i in idx:
            toJsonFun += f"[\"{i}\"]"
        toJsonFun += f"[\"{key}\"] = {name_prefix + key};\n"

        toJsonFun += tabs(2) + f"returnValue"
        for i in idx:
            toJsonFun += f"[\"{i}\"]"
        toJsonFun += f"[\"{key}\"] = {name_prefix + key};\n"

        fromJsonFun += tabs(2) + f"{name_prefix + key} = ({typeOfVar})json"
        for i in idx:
            fromJsonFun += f"[\"{i}\"]"
        fromJsonFun += f"[\"{key}\"];\n"
    
    return variables, toJsonFun, fromJsonFun
          
def getClassFile(data: json, item : Path):
    variables = ""
    toJsonFun = ""
    fromJsonFun = ""

    v2, tjf2, fjf2 = buildVariables(data, ["request"])
    variables += v2
    toJsonFun += tjf2
    fromJsonFun += fjf2
    v2, tjf2, fjf2 = buildVariables(data, ["response"])
    variables += v2
    toJsonFun += tjf2
    fromJsonFun += fjf2

    toJsonFun += tabs(2) + "return  returnValue;\n" + tabs(1) + "}\n"
    fromJsonFun += tabs(2) + "return  this;\n" + tabs(1) + "}\n"
    return variables, toJsonFun, fromJsonFun

     
requests = {}
def parseServices(folder : Path, recursion = 0):
    """Given a folder full of services, will create a Service CsClass for each json entry"""

    header, namespace = getHeaderFromPath(folder)

    for item in folder.iterdir():
        if item.is_dir(): continue
        if(not item.name.endswith(".json")): continue
        className = item.name[:-5]
        newClass = ""
        toJsonFun = tabs(1) + "public override JObject toJson() {\n" + tabs(2) + "JObject returnValue = JObject.Parse(jsonstring);\n"
        fromJsonFun = tabs(1) + f"public override {className} loadJson(JObject json) "+"{\n"
        # Open the json
        with open("./"+str(folder)+"/" + item.name , "r", encoding="utf-8") as file:
                data = json.load(file)
        single_line_json = json.dumps(data, separators=(",", ":"))
        single_line_json = single_line_json.replace('"', "\\\"")
        
        requests[className] = namespace + "." + className
        
        newClass += f"[Tool]\n[GlobalClass]\npublic partial class {className} : ROS2Messages.BaseRequest " + "{\n" 
        newClass += tabs(1) + f"public static string jsonstring = " + "\"" + single_line_json + "\"" + ";" + "\n" 
        newClass += tabs(1) + "[Export]" + "\n" + tabs(1) + "public string service " + getsetstr + "= \"\";\n"
        
        variables, tjf, fjf = getClassFile(data, folder)
        toJsonFun += tjf
        fromJsonFun += fjf
        newClass += variables + toJsonFun + fromJsonFun
        
        
        newClass += tabs(1) + f"{className}() " + "{" + "}" +"\n"
        newClass += "}" + "\n"
        with open(Path(str(csPathFromJsonPath(folder))+"/" + className + ".cs"), "w", encoding="utf-8") as file:
            file.write(header + newClass)