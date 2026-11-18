using Godot;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

// NOTE: this script uses an autoload! if it is removed using `free()` or `queue_free()`, Godot will crash!
// the reason autoloads are used here is because we need access to functions like _Ready() and _Process(), which would not be accessible with a static class

public partial class UdpController : Node
{
    public static UdpController inst { get; private set; }

    private PacketPeerUdp publishSend = new PacketPeerUdp();

    private PacketPeerUdp subscriptionSend = new PacketPeerUdp();
    private PacketPeerUdp subscriptionReceive = new PacketPeerUdp();

    private PacketPeerUdp serviceSend = new PacketPeerUdp();
    private PacketPeerUdp serviceReceive = new PacketPeerUdp();

    private PacketPeerUdp actionSend = new PacketPeerUdp();
    private PacketPeerUdp actionReceive = new PacketPeerUdp();

    private Dictionary<string, JObject> latestMessages         = new Dictionary<string, JObject>();
    private Dictionary<string, JObject> latestServiceResponses = new Dictionary<string, JObject>();
    private Dictionary<string, JObject> latestActionResponses  = new Dictionary<string, JObject>();

    [ExportCategory("UDP Configuration")]
    [Export] string serverIP = "127.0.0.1";

    [Export] int publishSendPort = 65434;

    [Export] int subscriptionSendPort    = 65436;
    [Export] int subscriptionReceivePort = 65435;

    [Export] int serviceSendPort = 65437;
    [Export] int serviceReceivePort = 65438;

    [Export] int actionSendPort = 65439;
    [Export] int actionReceivePort = 65440;

    [ExportCategory("Connection Status")]
    [Export] public bool showDebugLogs = true;

    public override void _Ready()
    {
        inst = this;

        Error? err = Error.Ok;

        err = publishSend.SetDestAddress(serverIP, publishSendPort);
        if(err != Error.Ok)
        {
            publishSend = null;
            GD.PrintErr($"Couldn't configure UDP client for publishing: {err}");
        }

        err = subscriptionSend.SetDestAddress(serverIP, subscriptionSendPort);
        if(err != Error.Ok)
        {
            subscriptionSend = null;
            GD.PrintErr($"Couldn't configure UDP client for configuring subscription: {err}");
        }

        err = subscriptionReceive.Bind(subscriptionReceivePort);
        if(err != Error.Ok)
        {
            subscriptionReceive = null;
            GD.PrintErr($"Couldn't configure UDP client for receiving subscription: {err}");
        }

        err = serviceSend.SetDestAddress(serverIP, serviceSendPort);
        if(err != Error.Ok)
        {
            serviceSend = null;
            GD.PrintErr($"Couldn't configure UDP client for sending service request: {err}");
        }

        err = serviceReceive.Bind(serviceReceivePort);
        if(err != Error.Ok)
        {
            serviceReceive = null;
            GD.PrintErr($"Couldn't configure UDP client for receiving service response: {err}");
        }

        err = actionSend.SetDestAddress(serverIP, actionSendPort);
        if(err != Error.Ok)
        {
            actionSend = null;
            GD.PrintErr($"Couldn't configure UDP client for sending action request: {err}");
        }

        err = actionReceive.Bind(actionReceivePort);
        if(err != Error.Ok)
        {
            actionReceive = null;
            GD.PrintErr($"Couldn't configure UDP client for receiving action response: {err}");
        }

        if(showDebugLogs)
            GD.Print("UDP Controller initialized!");
        
        PublishActionReq("{\"action\": \"fibonacci\", \"actionType\": \"action_tutorials_interfaces/action/Fibonacci\", \"request\": {\"order\": 6}}");
    }

    public override void _Process(double delta)
    {
        while(subscriptionReceive != null && subscriptionReceive.GetAvailablePacketCount() > 0)
        {
            try
            {
                byte[] data = subscriptionReceive.GetPacket();
                string jsonString = Encoding.UTF8.GetString(data);
                JObject message = JObject.Parse(jsonString);
                string topic = message["topic"]?.ToString();
                if(!string.IsNullOrEmpty(topic))
                {
                    if(showDebugLogs)
                        GD.Print($"Received new data for subscription to topic {topic}");
                    latestMessages[topic] = message;
                }
            }
            catch(System.Exception e)
            {
                GD.PrintErr($"Failed to receive/parse UDP message: {e.Message}");
            }
        }

        while(serviceReceive != null && serviceReceive.GetAvailablePacketCount() > 0)
        {
            try
            {
                byte[] data = serviceReceive.GetPacket();
                string jsonString = Encoding.UTF8.GetString(data);
                JObject message = JObject.Parse(jsonString);

                string serviceKey = message["service"]?.ToString();
                string topic = message["topic"]?.ToString();
                if(!string.IsNullOrEmpty(topic))
                {
                    if(showDebugLogs)
                        GD.Print($"Updated response for service {serviceKey}");
                    latestServiceResponses[topic] = message;
                }
            }
            catch(System.Exception e)
            {
                GD.PrintErr($"Failed to receive/parse UDP message: {e.Message}");
            }
        }

        while(actionReceive != null && actionReceive.GetAvailablePacketCount() > 0)
        {
            try
            {
                byte[] data = actionReceive.GetPacket();
                if (data == null || data.Length == 0)
                    continue;
                string jsonString = Encoding.UTF8.GetString(data);
                JObject message = JObject.Parse(jsonString);

                string actionName = message["action"]?.ToString();
                if(!string.IsNullOrEmpty(actionName))
                {
                    if(showDebugLogs)
                        GD.Print($"Updated response for action {actionName}");
                    latestActionResponses[actionName] = message;
                    GD.Print($"AAAA: {message.ToString()}");
                }
            }
            catch(System.Exception e)
            {
                GD.PrintErr($"Failed to receive/parse UDP message: {e.Message}");
            }
        }
    }

    public async Task<JObject> WaitForServiceResponse(string serviceKey, int maxAttempts = 50, float delayBetweenAttempts = 0.1f)
    {
        for(int i = 0; i < maxAttempts; i++)
        {
            if(latestServiceResponses.TryGetValue(serviceKey, out JObject response))
            {
                latestServiceResponses.Remove(serviceKey);
                if(showDebugLogs)
                    GD.Print($"Found service response for {serviceKey}");
                return response;
            }
            await ToSignal(GetTree().CreateTimer(delayBetweenAttempts), SceneTreeTimer.SignalName.Timeout);
        }

        GD.PrintErr($"WaitForServiceResponse timed out for {serviceKey}");
        return new JObject();
    }

    public void ConfigureSubscription(string topic, string msgType)
    {
        string message = topic + ";" + msgType;

        if(subscriptionSend == null)
        {
            GD.PrintErr($"Connection for configuring subscriptions not established");
            return;
        }

        try
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            subscriptionSend.PutPacket(data);
            
            if(showDebugLogs)
                GD.Print($"Configured subscription for {topic}");
        }
        catch(System.Exception e)
        {
            GD.PrintErr($"Failed to configure subscription for {topic}: {e.Message}");
        }
    }

    public void PublishMessage(string message)
    {
        if(publishSend == null)
        {
            GD.PrintErr($"Connection for publishing not established");
            return;
        }

        try
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            publishSend.PutPacket(data);

            if(showDebugLogs)
                GD.Print($"Published: {message}");
        }
        catch(System.Exception e)
        {
            GD.PrintErr($"Failed to publish data: {e.Message}");
        }
    }

    public async Task<JObject> PublishClientReq(string message, string serviceKey = null)
    {
        JObject response = new JObject();

        if(serviceSend == null)
        {
            GD.PrintErr("Connection for making service requests not established");
            return response;
        }

        try
        {
            if(string.IsNullOrEmpty(serviceKey))
            {
                JObject messageObject = JObject.Parse(message);
                serviceKey = messageObject["service"].ToString();
            }

            byte[] data = Encoding.UTF8.GetBytes(message);
            serviceSend.PutPacket(data);

            if(showDebugLogs)
                GD.Print($"Made service request for {serviceKey} (will wait for response)");

            response = await WaitForServiceResponse(serviceKey);
        }
        catch(System.Exception e)
        {
            GD.PrintErr($"Failed to make service request: {e.Message}");
        }

        return response;
    }

    public void SendClientReq(string message)
    {
        if(serviceSend == null)
        {
            GD.PrintErr("Connection for making service requests not established");
            return;
        }

        try
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            serviceSend.PutPacket(data);
        }
        catch(System.Exception e)
        {
            GD.PrintErr($"Failed to make service request: {e.Message}");
        }
    }

    public void PublishActionReq(string message, string actionName = null)
    {
        if(actionSend == null)
        {
            GD.PrintErr("Connection for making service requests not established");
            return;
        }

        try
        {
            if(string.IsNullOrEmpty(actionName))
            {
                JObject messageObject = JObject.Parse(message);
                actionName = messageObject["action"].ToString();
            }

            byte[] data = Encoding.UTF8.GetBytes(message);
            actionSend.PutPacket(data);

            if(showDebugLogs)
                GD.Print($"Made action request for {actionName}");
        }
        catch(System.Exception e)
        {
            GD.PrintErr($"Failed to make action request: {e.Message}");
        }
    }

    public JObject GetLatestMessage(string topic)
    {
        latestMessages.TryGetValue(topic, out JObject msg);
        return msg;
    }

    public JObject GetLatestServiceResponse(string serviceKey)
    {
        latestServiceResponses.TryGetValue(serviceKey, out JObject msg);
        return msg;
    }

    public JObject GetLatestActionResponse(string actionName)
    {
        latestActionResponses.TryGetValue(actionName, out JObject msg);
        return msg;
    }

    public void _Exit_Tree()
    {
        if(publishSend != null)
            publishSend.Close();
        if(subscriptionSend != null)
            subscriptionSend.Close();
        if(subscriptionReceive != null)
            subscriptionReceive.Close();
        if(serviceSend != null)
            serviceSend.Close();
        if(serviceReceive != null)
            serviceReceive.Close();
        if(actionSend != null)
            actionSend.Close();
        if(actionReceive != null)
            actionReceive.Close();

        if(showDebugLogs)
            GD.Print("UdpController closed");
    }
}
