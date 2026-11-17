# Gettting Godot Net Setup

## Step One:
Dowload the .Net Version of Godot from https://godotengine.org/download/linux/ (The download below the inviting big blue button)

You might want to look up how to make a .desktop file so that you can open Godot easier

## Step Two:
Download the .Net SDK from https://dotnet.microsoft.com/en-us/download
Run `dotnet --list-sdks` in the terminal to make sure that you installed correctly

## Step Three:
Create a .vscode/launch.json, change the value of "program" to the path to your .Net godot executable
{
    "version": "0.2.0",
    "configurations": [
        {
            "name": "Play",
            "type": "coreclr",
            "request": "launch",
            "preLaunchTask": "build",
            "program": "YOUR PATH HERE",
            "args": [],
            "cwd": "${workspaceFolder}",
            "stopAtEntry": false,
        }
    ]
}

## Step Four:
Open the GodotProject folder inside this directory in Godot

This project is a bit different from the Unity, as Godot sees everything in its base directory, rather than Unity, which only sees inside it's Assets folder, thus to keep the Godot code and backend python code seperate to avoid confusion, we are putting the Godot project in its own folder.

## Step Five:
Install GST Streamer
`sudo apt update`
`sudo apt install libgstreamer1.0-dev libgstreamer-plugins-base1.0-dev gstreamer1.0-plugins-base gstreamer1.0-plugins-good gstreamer1.0-plugins-bad gstreamer1.0-plugins-ugly gstreamer1.0-libav`
