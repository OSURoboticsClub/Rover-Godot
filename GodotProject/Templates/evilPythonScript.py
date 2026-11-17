import json
from pathlib import Path



# separators=(",", ":") removes extra whitespace after commas and colons

superString = """using Godot;\n
using Newtonsoft.Json.Linq;\n
using System;\n

public static class Jason\n
{\n"""



firstFolder = Path("./")
def tabs(num):
    returnVal = ""
    for i in range(num):
        returnVal += "  "
    return returnVal
def iterThroughFolder(folder, recursion = 0):
    global superString
    for item in folder.iterdir():
        if item.is_dir():
            superString += tabs(recursion +1) + f"public static class {item.name}"+ "{\n"
            iterThroughFolder(Path(str(folder) +f"/{item.name}"), recursion + 1)
            superString += tabs(recursion +1) +"}\n"
            print(f"Subfolder: {item.name}")
        elif item.is_file() and recursion != 0 and item.name.endswith(".json"):
            with open("./"+str(folder)+"/" + item.name , "r", encoding="utf-8") as file:
                data = json.load(file)
            single_line_json = json.dumps(data, separators=(",", ":"))
            single_line_json = single_line_json.replace('"', "\\\"")
            superString += tabs(recursion +1) + f"public static string {item.name[:-5]} = " + "\"" + single_line_json + "\"" + ";" + "\n" 

iterThroughFolder(firstFolder)

superString += "}"

with open("./Jason.cs", "w", encoding="utf-8") as file:
    file.write(superString)


