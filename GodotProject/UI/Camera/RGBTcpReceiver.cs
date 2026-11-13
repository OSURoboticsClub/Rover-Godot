using System.Net;
using System.Net.Sockets;
using System;
using Godot;

public partial class RGBTcpReceiver : TextureRect
{
    public int listenPort = 5000;
    public int frameWidth = 640;
    public int frameHeight = 480;
    public int timeoutCount = 120;
    public Texture timeoutTexture;
    private int count = 0;
    private TcpListener tcpListener;
    private TcpClient tcpClient;
    private NetworkStream stream;
    private ImageTexture receivedTexture;
    private byte[] frameBuffer;
    private int frameSize;
    private int bytesReceived = 0;
    private bool isListening = false;
    private Image _image;

    void Start()
    {
        // RGB = 3 bytes per pixel
        frameSize = frameWidth * frameHeight * 3;
        frameBuffer = new byte[frameSize];
        Image _image = Image.CreateEmpty(frameWidth, frameHeight, false, Image.Format.Rgb8);
        receivedTexture.Update(_image);
        Texture = receivedTexture;
        

        StartListening();
    }

    void applyNewTexture()
    {
        _image.SetData(frameWidth, frameHeight, false, Image.Format.Rgb8, frameBuffer);
        receivedTexture = ImageTexture.CreateFromImage(_image);
        Texture = receivedTexture;
        // Reset for next frame.
        bytesReceived = 0;
    }
    void Update()
    {
        try
        {
            if (!isListening)
            {
                // Restart the listener if Unity disabled it or a socket error stopped it.
                StartListening();
                return;
            }

            // Accept new connections if we don't have one.
            if (tcpClient == null || !tcpClient.Connected)
            {
                if (tcpListener.Pending())
                {
                    tcpClient = tcpListener.AcceptTcpClient();
                    stream = tcpClient.GetStream();
                    // 1 ms timeout keeps Unity's main thread from hanging on reads.
                    stream.ReadTimeout = 1;
                    bytesReceived = 0;
                    GD.Print($"Camera TCP client connected on port {listenPort}");
                }
                else
                {
                    return;
                }
            }

            if (stream != null && stream.DataAvailable)
            {
                count = 0;

                // Read as much data as is available for the current RGB frame.
                int bytesToRead = frameSize - bytesReceived;
                int read = stream.Read(frameBuffer, bytesReceived, bytesToRead);
                bytesReceived += read;

                // If we have a complete frame, load the raw RGB data into the texture.
                if (bytesReceived >= frameSize)
                {
                    applyNewTexture();
                    
                }
            }
            else if (tcpClient != null && !tcpClient.Connected)
            {
                // Connection lost; keep the listener alive for the next GStreamer process.
                GD.Print("Camera TCP client disconnected");
                CloseClient();
            }

            count++;
            if (count >= timeoutCount)
            {
                if (Texture != timeoutTexture)
                {
                    Texture = (Texture2D)timeoutTexture;
                }

                count = 0;
                CloseClient();
            }
        }
        catch (System.IO.IOException)
        {
            // Timeout or short read; keep the connection alive.
        }
        catch (ObjectDisposedException)
        {
            CloseClient();
        }
        catch (InvalidOperationException e)
        {
            GD.PushWarning($"TCP listener on port {listenPort} was not active: {e.Message}");
            StopListening();
        }
        catch (SocketException e)
        {
            GD.PushWarning($"Socket exception on camera port {listenPort}: {e.Message}");
            CloseClient();
        }
    }

    void StartListening()
    {
        if (isListening)
        {
            return;
        }

        try
        {
            tcpListener = new TcpListener(IPAddress.Any, listenPort);
            tcpListener.Start();
            isListening = true;
            GD.Print($"TCP listener started on port {listenPort}");
        }
        catch (SocketException e)
        {
            isListening = false;
            tcpListener = null;
            GD.Print($"Could not start TCP listener on port {listenPort}: {e.Message}");
        }
    }

    void CloseClient()
    {
        // Close just the active TCP client; the listener remains available.
        stream?.Close();
        tcpClient?.Close();
        stream = null;
        tcpClient = null;
        bytesReceived = 0;
    }

    void StopListening()
    {
        // Full shutdown for Unity lifecycle events.
        CloseClient();

        if (tcpListener != null)
        {
            try { tcpListener.Stop(); } catch (Exception) { }
            tcpListener = null;
        }

        isListening = false;
    }

    void OnDisable()
    {
        StopListening();
    }

    void OnApplicationQuit()
    {
        StopListening();
    }
}
