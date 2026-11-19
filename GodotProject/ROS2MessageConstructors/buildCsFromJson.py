import json
from pathlib import Path
import shutil
from csGeneratorScript.common import csTypeFromItem, csPathFromJsonPath, getNamespaceFromPath, tabs
from csGeneratorScript.serviceConstructor import requests, parseServices
from csGeneratorScript.messageConstructor import messages, parseMessages


# separators=(",", ":") removes extra whitespace after commas and colons







firstFolder = Path("./Json/")
def deleteExisting(path = Path("./Cs/")):
    for item in path.iterdir():
        if item.is_dir() and not item.is_symlink():
            shutil.rmtree(item)
        else:
            item.unlink()

def iterThroughFolder(folder, recursion = 0):
    global superString
    for item in folder.iterdir():
        if item.is_dir():
            Path(csPathFromJsonPath(item)).mkdir(exist_ok=True)
            if(item.name == "srv"):
                parseServices(Path(str(folder) +f"/{item.name}"), recursion + 1)
            elif(item.name == "msg"):
                parseMessages(Path(str(folder) +f"/{item.name}"), recursion + 1)
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