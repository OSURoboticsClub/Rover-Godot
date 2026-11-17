using Godot;
using Gst;
using Gst.App;
using System;
using System.Runtime.InteropServices;
/** Code generated partially by Gemini */
public partial class CameraFeed : GodotCameraStream
{
    private OptionButton dropdown;
    public override void _Ready()
    {
        base._Ready();
        dropdown = GetNode<OptionButton>("Camera Selector");
        dropdown.ItemSelected += changeStream;
        StartStream(cameraPortMap[dropdown.GetIndex()]);
        
    }

    private void changeStream(long index)
    {
        StartStream(cameraPortMap[(int) index]);
    }

}
