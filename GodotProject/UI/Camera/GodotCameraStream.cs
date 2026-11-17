using Godot;
using Gst;
using Gst.App;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
public class CameraEntry
    {
        public string name;
        public int port;
        public string framerate;
        public string serviceNamespace;

        public CameraEntry(string name, int port, string framerate, string serviceNamespace)
        {
            this.name = name;
            this.port = port;
            this.framerate = framerate;
            this.serviceNamespace = serviceNamespace;
        }
    };


/** Code generated partially by Gemini */
public partial class GodotCameraStream : TextureRect
{
    private Pipeline _pipeline;
    private AppSink _appSink;
    private Image _image;
    private ImageTexture _texture;
    [Export] private Texture2D timeout_image { get; set; }

    [ExportCategory("Resolution")]
    [Export] private int Width = 640;
    [Export] private int Height = 480;
    [ExportCategory("Networking")]
    [Export] private string tcpAddr = "192.168.1.11";
    [Export] private ulong timeout = 5000;
    public int portNum = 5000;

    private ulong lastFixTime = 0;
    private int currentSizeX = 0;
    private int currentSizeY = 0;


    public static List<CameraEntry> cameraPortMap = new List<CameraEntry>()
    {
        new CameraEntry("IR",            42073, "30/1", "chassis_gimbal"), //0
        new CameraEntry("Tower",         42068, "30/1", "tower_gimbal"), //1
        new CameraEntry("Chassis Right", 42070, "25/1", "chassis_right"), //2
        new CameraEntry("Chassis Left",  42069, "25/1", "chassis_left"),
        new CameraEntry("Gripper",       42074, "30/1", "d405"),
        new CameraEntry("Back",          42071, "25/1", "back"),
        new CameraEntry("BEV",           42072, "25/1", "bev"),
        new CameraEntry("Chassis",       42075, "30/1", "d455"), //Not Used?
        new CameraEntry("Laptop",       5000, "30/1", "d455")
    };

    

    public override void _Ready()
    {
        // Initialize GStreamer
        Application.Init();

        // Prepare Godot Image and Texture
        _image = Image.CreateEmpty(Width, Height, false, Image.Format.Rgb8);
        _image.Resize((int)Size.X, (int)Size.Y, Image.Interpolation.Nearest);
        _texture = ImageTexture.CreateFromImage(_image);
        
        Texture = _texture;
        currentSizeX = (int)Size.X;
        currentSizeY = (int)Size.Y;
    }
    public override void _Process(double delta)
    {
        if(_pipeline == null) return;
        if(Time.GetTicksMsec()- lastFixTime > timeout)
        {
            Texture = timeout_image;
        }
        else
        {
            Texture = _texture;
            currentSizeX = (int)Size.X;
            currentSizeY = (int)Size.Y;
        }
    }
    
    public void StartStream(CameraEntry camera)
    {
        if(_pipeline != null)
        {
            StopGStreamer();
        }
        GD.Print("Listening on port:" + camera.port);
        // Build the pipeline
        string pipelineDesc = $"tcpclientsrc host={"127.0.0.1"} port={camera.port} ! " +
            "tsdemux ! h264parse ! avdec_h264 ! videoconvert ! " +
            "video/x-raw,format=RGB ! " +
            "appsink name=sink emit-signals=true max-buffers=1 drop=true sync=false";
        _pipeline = (Pipeline)Parse.Launch(pipelineDesc);

        Element sinkElement = _pipeline.GetByName("sink");
        _appSink = new AppSink(sinkElement.Handle);
        _appSink.NewSample += OnNewSample;

        // Start capturing
        _pipeline.SetState(State.Playing);
        lastFixTime = Time.GetTicksMsec();
    }

    private void OnNewSample(object sender, NewSampleArgs args)
    {
        GD.Print("Recieved");
        var sink = (AppSink)sender;

        using var buffer = sink.PullSample()?.Buffer;
        if (buffer == null) return;
        if (!buffer.Map(out MapInfo mapInfo, MapFlags.Read)) return;
        
        // Set the
        _image.SetData(Width, Height, false, Image.Format.Rgb8, mapInfo.Data);
        _image.Resize(currentSizeX, currentSizeY, Image.Interpolation.Nearest);
        if (_texture == null || _texture.GetWidth() != currentSizeX || _texture.GetHeight() != currentSizeY)
        {
            _texture = ImageTexture.CreateFromImage(_image);
        } else _texture.Update(_image);

        lastFixTime = Time.GetTicksMsec();
        
        // Unmap the data so that GStreamer knows we are done with it
        buffer.Unmap(mapInfo);
    }
    
    public void StopGStreamer()
    {
        if (_pipeline != null)
        {
            _pipeline.SetState(State.Null);
            _pipeline.Dispose();
            _pipeline = null;
            _appSink.NewSample -= OnNewSample;
            
        }
    }
    public override void _ExitTree()
    {
        StopGStreamer();
    }
}
