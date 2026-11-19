import json
from pathlib import Path

getsetstr = "{" + "get; set; }"

def getHeaderFromPath(folder):
    header = """using Godot;\nusing Newtonsoft.Json.Linq;\nusing System;\n\nnamespace ROS2Messages."""
    namespace = getNamespaceFromPath(folder)
    header += namespace + ";\n\n"
    return header, namespace

def getNamespaceFromPath(path):
    namespace = ""
    for subfolder in str(path).split("/")[1:]:
        namespace += str(subfolder) + "."
    return namespace[:-1]

def csPathFromJsonPath(jsonPath):
    return Path("./Cs/" + str(jsonPath).split("/",1)[1])

def tabs(num):
    returnVal = ""
    for i in range(num):
        returnVal += "  "
    return returnVal

def csTypeFromItem(item):
    if(type(item) == int):
        return "int"
    if(type(item) == float):
        return "double"
    if(type(item) == bool):
        return "bool"
    if(type(item) == dict):
        return "dict"
    return "string"