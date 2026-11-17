using GLib;
using Godot;
using Gst;
using Gst.App;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
public partial class CameraFeedHandler : Node
{
    public List<List<CameraFeed>> Listening= new List<List<CameraFeed>>();
    public override void _EnterTree()
    {
        for(int i = 0; i < GodotCameraStream.cameraPortMap.Count; i++)
        {
            Listening.Add(new List<CameraFeed>());
        }
    }
    

}
