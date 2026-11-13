# Gettting Godot Net Setup

## Step One:
Dowload the .Net Version of Godot from https://godotengine.org/download/linux/ (The download below the inviting big blue button)

You might want to look up how to make a .desktop file so that you can open Godot easier

## Step Two:
Download the .Net SDK from https://dotnet.microsoft.com/en-us/download
Run `dotnet --list-sdks` in the terminal to make sure that you installed correctly

## Step Three:
In .vscode/launch.json, change the value of "program" to the path to your .Net godot executable

## Step Four:
Open the GodotProject folder inside this directory in Godot

This project is a bit different from the Unity, as Godot sees everything in its base directory, rather than Unity, which only sees inside it's Assets folder, thus to keep the Godot code and backend python code seperate to avoid confusion, we are putting the Godot project in its own folder.