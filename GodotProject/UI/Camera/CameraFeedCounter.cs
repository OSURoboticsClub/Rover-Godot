using GLib;
using Godot;
using Gst;
using Gst.App;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

/// <summary>
/// A static class so that different instances of CameraFeed can communicate which camera feeds they are looking at, so that one wont "close the door" on another which switching streams
/// </summary>
public class CameraFeedCounter
{
    public static CameraFeedCounter inst;
    public List<List<CameraFeed>> Listening= new List<List<CameraFeed>>();
    public static CameraFeedCounter getInst()
    {
        if(inst == null) {
            inst = new CameraFeedCounter();
            for(int i = 0; i < GodotCameraStream.cameraPortMap.Count; i++)
            {
                inst.Listening.Add(new List<CameraFeed>());
            }
        }
        return inst;
    }
    

}
