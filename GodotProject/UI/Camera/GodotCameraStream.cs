using Godot;
using Gst;
using Gst.App;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using GLib;
public class CameraEntry
    {
        public string name;
        public int port;
        public string framerate;
        public string serviceNamespace;
        public bool fromJetson;

        public CameraEntry(string name, int port, string framerate, string serviceNamespace, bool fromJetson = true)
        {
            this.name = name;
            this.port = port;
            this.framerate = framerate;
            this.serviceNamespace = serviceNamespace;
            this.fromJetson = fromJetson;
        }
    };


/** Code generated partially by Gemini */
/// <summary>
/// A TextureRect nodew for connecting to H265 encoded GStreamstream, reading it and displaying it as a texture on itself
/// </summary>
public partial class GodotCameraStream : TextureRect
{
    private Pipeline _pipeline;
    private AppSink _appSink;
    public Image _image;
    public ImageTexture _texture;
    [Export] public Texture2D timeout_image { get; set; }

    [ExportCategory("Resolution")]
    [Export] private int Width = 640;
    [Export] private int Height = 480;
    [ExportCategory("Networking")]
    [Export] private ulong timeout = 5000;
    // We store the last sample recieved to determine if the stream has timed out
    private ulong lastFixTime = 0;
    // TODO: find some way to calculate latency (Might not be possible without sending more informatin which we dont want to do.)
    public double? latencyMs = null;

    private readonly object _bufferLock = new object();
    byte[] _frameBuffer;

    /// <summary>
    /// A list of all CameraEntries that we want to listen to on the robot (In order of how they appear on the dropdown)
    /// </summary>
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
        new CameraEntry("Laptop",       5000, "30/1", "laptop", true)
    };
    public static string ToggleServiceName(CameraEntry entry) => $"/{entry.serviceNamespace}/toggle_camera";

    
    /// <summary>
    /// Setup the image and texture, GST, and the delegate variables for reading current size when not on main thread
    /// </summary>
    public override void _Ready()
    {
        // Initialize GStreamer
        Gst.Application.Init();

        // Prepare Godot Image and Texture
        _image = Image.CreateEmpty(Width, Height, false, Image.Format.Rgb8);
        _image.Resize((int)Size.X, (int)Size.Y, Image.Interpolation.Nearest);
        _texture = ImageTexture.CreateFromImage(_image);
        
        Texture = _texture;

        _frameBuffer = new byte[Width * Height * 3];
    }
    /// <summary>
    /// Check whether a timeout has occured
    /// </summary>
    /// <param name="delta"></param>
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
        }
    }
    /// <summary>
    /// Starts a GStreamer to listen to a given CameraEntry
    /// </summary>
    /// <param name="camera">  </param>
    public virtual void StartStream(CameraEntry camera)
    {
        // If another pipeline is currently running, kill it
        if(_pipeline != null)
        {
            StopGStreamer();
        }
        GD.Print("Listening on port:" + camera.port);
        // Configure pipeline (TODO: Once we get it on working on rover, just use fromJetson always )
        string pipelineDesc;

        string rtpCaps = "application/x-rtp,media=(string)video,clock-rate=(int)90000,encoding-name=(string)RAW,sampling=(string)BGR,depth=(string)8,width=(string)640,height=(string)480,colorimetry=(string)SMPTE240M,payload=(int)96";
     
        pipelineDesc = $"udpsrc port={camera.port} caps=\"{rtpCaps}\" ! " +
            $"rtpvrawdepay ! " +
            $"videoconvert ! " +
            $"video/x-raw,format=RGB,width={Width},height={Height} ! " +
            $"appsink name=sink emit-signals=true max-buffers=1 drop=true";
                
        // $"udpsrc port={camera.port} caps=\"{rtpCaps}\" ! " +
        // //"rtpjitterbuffer latency=50 drop-on-latency=true ! " +
        // //$"rtph265depay ! h265parse ! avdec_h265 ! videoconvert ! " +
        // "rtpvrawdepay" +
        // $"video/x-raw,format=RGB,width={Width},height={Height} ! " +
        // $"appsink name=sink emit-signals=true sync=false max-buffers=1 drop=true";

        // pipelineDesc = $"udpsrc port={camera.port} ! application/x-rtp,encoding-name=JPEG,payload=26 ! " +
        // $"rtpjpegdepay ! jpegdec ! videoconvert ! video/x-raw,format=RGB,width={Width},height={Height} ! " +
        // $"appsink name=sink emit-signals=true sync=false max-buffers=1 drop=true";
        
            
        _pipeline = (Pipeline)Parse.Launch(pipelineDesc);

        Element sinkElement = _pipeline.GetByName("sink");
        _appSink = new AppSink(sinkElement.Handle);
        // Set it to call our function when we recieve a new gstreamer sampl
        _appSink.NewSample += OnNewSample;

        // Start capturing
        _pipeline.SetState(State.Playing);
        lastFixTime = Time.GetTicksMsec();
    }
    
    
    /// <summary>
    /// On recieving a new GSTreamer sample, update the texture
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void OnNewSample(object sender, NewSampleArgs args)
    {
        var sink = (AppSink)sender;

        using var buffer = sink.PullSample()?.Buffer;
        
        if (buffer == null) return;
        if (!buffer.Map(out MapInfo mapInfo, MapFlags.Read)) return;
        
        int copyLen = Math.Min((int)mapInfo.Size, _frameBuffer.Length);

        // Lock the buffer to ensure we are not reading and writing at the same time
        lock (_bufferLock)
        {
            // Copy the new frame onto our buffer
            Marshal.Copy(mapInfo.DataPtr, _frameBuffer, 0, copyLen);
        }
        // Call the update texture function later on the main thread
        CallDeferred(MethodName.UpdateTextureDeferred);
        
        lastFixTime = Time.GetTicksMsec();
        
        // Unmap the data so that GStreamer knows we are done with it
        buffer.Unmap(mapInfo);
    }

    /// <summary>
    /// Loads the current _frameBuffer as a texture on the node
    /// </summary>
    private void UpdateTextureDeferred()
    {
        if (!IsInsideTree() || _texture == null) return;
        lock (_bufferLock) {
            _image.SetData(Width, Height, false, Image.Format.Rgb8, _frameBuffer);
        }
        _image.Resize((int)Size.X, (int)Size.Y, Image.Interpolation.Nearest);
        if (_texture == null || _texture.GetWidth() != (int)Size.X || _texture.GetHeight() != (int)Size.Y)
        {
            _texture = ImageTexture.CreateFromImage(_image);
        } else _texture.Update(_image);
    }
    
    /// <summary>
    /// Kills the current pipeline
    /// </summary>
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
    /// <summary>
    /// Kill the gstreamer on program exit (or scene exit)
    /// </summary>
    public override void _ExitTree()
    {
        StopGStreamer();
    }
}
