using GLib;
using Godot;
using Gst;
using Gst.App;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Collections.Generic;
/** Code generated partially by Gemini */
public partial class CameraFeed : GodotCameraStream
{
    private OptionButton dropdown;
    [Export] private Json set_bool_service;
    CameraFeedHandler handler;
    long lastIndex = -1;
    public void sendCameraEnableMessage(CameraEntry entry, bool state)
    {
        JObject msg = JObject.Parse(Json.Stringify(set_bool_service.Data));

        msg["service"] = ToggleServiceName(entry);
        msg["request"]["data"] = state;

        GD.Print($"[{entry.serviceNamespace}] toggle_camera({state}) sent (no wait).");
        UdpController.inst.SendClientReq(msg.ToString());
    }

    public override void _Ready()
    {
        base._Ready();
        handler = (CameraFeedHandler)GetParent();        

        dropdown = GetNode<OptionButton>("Camera Selector");
        dropdown.ItemSelected += changeStream;
        changeStream(dropdown.GetIndex());
        
    }

    private void changeStream(long index)
    {
        CameraEntry entry = cameraPortMap[(int) index];
        StartStream(entry);
        if(handler == null) return;
        if(index < 0 || index >= handler.Listening.Count) return;    
        GD.Print(handler.Listening.Count, index);   

        if(handler.Listening[(int)index].Count == 0)
        {
            sendCameraEnableMessage(entry, true);
        }
        handler.Listening[(int)index].Add(this);
        
        if(lastIndex != -1) {
            GD.Print(handler.Listening[(int)lastIndex].Count);
            handler.Listening[(int)lastIndex].Remove(this);
            if(handler.Listening[(int)lastIndex].Count == 0) {
                sendCameraEnableMessage(entry, false);
            }
        }
        lastIndex = index;
    }
}
