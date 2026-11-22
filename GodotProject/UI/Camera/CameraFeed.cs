using GLib;
using Godot;
using Gst;
using Gst.App;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
/** Code generated partially by Gemini */
/// <summary>
/// A CameraStream variant for reading from Gstreamer, with additional functionality for the CameraFeed scene, like switching streams, pausing, and taking photos
/// </summary>
public partial class CameraFeed : GodotCameraStream
{
    private OptionButton dropdown;
    private Label latencyLabel;
    [Export] private Json set_bool_service;
    [ExportCategory("Button Icons")]
    [Export] Texture2D PlayIcon;
    [Export] Texture2D PauseIcon;
    CameraFeedCounter handler;
    Button PausePlayButton;
    Button PhotoButton;

    long lastIndex = -1;
    [Export] bool playing = false;

    /// <summary>
    /// Function for sending a service to the UDP controller to turn off the camera
    /// </summary>
    /// <param name="entry"> The camera entry to toggle</param>
    /// <param name="state"> Whether to enable or disable the camera</param>
    public void sendCameraToggleMessage(CameraEntry entry, bool state)
    {
        JObject msg = JObject.Parse(Json.Stringify(set_bool_service.Data));

        msg["service"] = ToggleServiceName(entry);
        msg["request"]["data"] = state;

        GD.Print($"[{entry.serviceNamespace}] toggle_camera({state}) sent (no wait).");
        try {UdpController.inst.SendClientReq(msg.ToString());}
        finally {}
    }

    public override void _Ready()
    {
        base._Ready();
        handler = CameraFeedCounter.getInst();      
        dropdown = GetNode<OptionButton>("Camera Selector");
        latencyLabel = GetNode<Label>("Latency Label");
        PausePlayButton = GetNode<Button>("Pause_Play");
        PhotoButton = GetNode<Button>("Photo");



        dropdown.ItemSelected += changeStream;
        PausePlayButton.Pressed += Pause_Play_Fun;
        PhotoButton.Pressed += Photo;

        if(playing) {
            changeStream(dropdown.GetIndex());
            PausePlayButton.Icon = PauseIcon;
        } else
        {
            PausePlayButton.Icon = PlayIcon;
        }
    }
    /// <summary>
    /// Save the current _image on the attached GodotCameraStream object
    /// </summary>
    public void Photo()
    {
        _image.SavePng("/home/ozy/Documents/Programenheimer/Github/rover-godot/ScreenShots/screenshot.png");
        GD.Print("Image Saved !");
    }
    /// <summary>
    /// Toggle whether the camera should be paused or playing
    /// </summary>
    public void Pause_Play_Fun()
    {
        if(playing)
        {
            playing = false;
            PausePlayButton.Icon = PlayIcon;
            pauseStream();
            
            return;
        }
        
        playing = true;
        if(Texture != timeout_image) _texture.Update(_image);
        PausePlayButton.Icon = PauseIcon;
        changeStream(dropdown.Selected);
    }
    /// <summary>
    /// Sets the image to grayscale when the camera is paused, TODO: handle latency
    /// </summary>
    /// <param name="delta"></param>
    public override void _Process(double delta)
    {
        base._Process(delta);
        if(!playing)
        {
            Image newImage = (Image)_image.Duplicate();
            if (_image.IsCompressed())
            {
                newImage.Decompress();
            }
            newImage.AdjustBcs(0.8f, 1.0f, 0.0f);
            if(Texture != timeout_image) _texture.Update(newImage);
        }
        if(latencyMs == null)
        {
            latencyLabel.Text = $"No Video";
            return;
        }
        else if(latencyMs < 9999)
        {
            latencyLabel.Text = $"Latency: {(int) Math.Round((decimal)latencyMs)} ms";
        } else
        {
            latencyLabel.Text = $"Latency: {Math.Round((decimal)latencyMs/1000, 1)} s";
        }
    }
    /// <summary>
    /// Stop the GStreamer, and tell the CameraCounter that wed have stopped listening
    /// </summary>
    private void pauseStream()
    {
        
        StopGStreamer();
        handler.Listening[(int)lastIndex].Remove(this);
        if(handler.Listening[(int)lastIndex].Count == 0) {
            sendCameraToggleMessage(cameraPortMap[(int)lastIndex], false);
        }
        lastIndex = -1;
        return;
        
    }

    /// <summary>
    /// Stop the previus GStreamer, and tell the CameraCounter that wed have stopped listening, then start the new GSTreamer, and tell the counter we have started listening
    /// </summary>
    private void changeStream(long index)
    {
        if(!playing) return;
        CameraEntry entry = cameraPortMap[(int) index];
        StartStream(entry);
        if(handler == null) return;
        if(index < 0 || index >= handler.Listening.Count) return;    
        GD.Print(handler.Listening.Count, index);   

        if(handler.Listening[(int)index].Count == 0)
        {
            sendCameraToggleMessage(entry, true);
        }
        handler.Listening[(int)index].Add(this);
        
        if(lastIndex != -1) {
            GD.Print(handler.Listening[(int)lastIndex].Count);
            handler.Listening[(int)lastIndex].Remove(this);
            if(handler.Listening[(int)lastIndex].Count == 0) {
                sendCameraToggleMessage(cameraPortMap[(int)lastIndex], false);
            }
        }
        lastIndex = index;
    }
}
