using Godot;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;

public partial class ControllerManager : Node
{
    public enum ControlMode
    {
        Off,
        Drive,
        Arm
    }

    public ControlMode mode = ControlMode.Off;

    public float driveSpeed = 0.5f;
    public float armSpeed = 0.5f;
    public double gimbalSpeedScale = 0.3;

    public float publishRate = 1f/30f; // 30 hz

    bool useChassisPanTilt = false;
    private JObject driveMessage;

    private JObject tiltMessage;

    private JObject joyMessage;

    private JObject joy2Message;

    [Export] private NodePath driveButtonPath;
    private Node driveButton;
    [Export] private NodePath armButtonPath;
    private Node armButton;
    [Export] private NodePath offButtonPath;
    private Node offButton;
    [Export] private NodePath timerPath;
    private Timer timer;

    public override void _Ready() {
        driveButton = GetNode<Node>(driveButtonPath);
        armButton = GetNode<Node>(armButtonPath);
        offButton = GetNode<Node>(offButtonPath);
        timer = GetNode<Timer>(timerPath);

        timer.Autostart = true;
        timer.OneShot = false;
        timer.WaitTime = publishRate;
        timer.Timeout += PublishInputs; 
    }

    public override void _Process(double delta)
    {
        // TODO synchronize drive speed sliders
        // TODO synchronize arm speed sliders

        Vector2 leftJoystick = Input.GetVector("leftJoystickLeft", "leftJoystickRight", "leftJoystickUp", "leftJoystickDown");
        Vector2 rightJoystick = Input.GetVector("rightJoystickright", "rightJoystickRight", "rightJoystickUp", "rightJoystickDown");

        float leftTrigger = Input.GetActionStrength("leftTrigger");
        float rightTrigger = Input.GetActionStrength("rightTrigger");

        bool buttonEast = Input.IsActionPressed("buttonEast");
        bool buttonWest = Input.IsActionPressed("buttonWest");
        bool buttonSouth = Input.IsActionPressed("buttonSouth");
        bool buttonNorth = Input.IsActionPressed("buttonNorth");

        bool dpadEast = Input.IsActionPressed("dpadEast");
        bool dpadWest = Input.IsActionPressed("dpadWest");
        bool dpadSouth = Input.IsActionPressed("dpadSouth");
        bool dpadNorth = Input.IsActionPressed("dpadNorth");

        bool start = Input.IsActionPressed("start");
        bool select = Input.IsActionJustPressed("select");
        bool shoulderLeft = Input.IsActionPressed("leftShoulder");
        bool shoulderRight = Input.IsActionPressed("rightShoulder");

        bool rightJoystickButton = Input.IsActionPressed("rightJoystickButton");

        if(rightJoystickButton)
        {
            float[] axes = new float[]{
                0.0f
            };
            int[] buttons = new int[]{
                0,0,0,0,0,0,0,0,0,0,0
            };

            joy2Message = new()
            {
                ["topic"] = "joy",
                ["msgType"] = "sensor_msgs/msg/Joy",
                    ["data"] = {
                    ["axes"] = new JArray(axes),
                    ["button"] = new JArray(buttons)
                }
            };
            UdpController.inst.PublishMessage(joy2Message.ToString());

            buttons = new int[]{
                0,0,0,0,0,0,0,0,1,0,0
            };
            joy2Message["topic"] = "joy2";
            joy2Message["data"]["buttons"] = new JArray(buttons);
            UdpController.inst.PublishMessage(joy2Message.ToString());
        }
    }

    public void PublishInputs()
    {
        Vector2 leftJoystick = Input.GetVector("leftJoystickLeft", "leftJoystickRight", "leftJoystickUp", "leftJoystickDown");
        Vector2 rightJoystick = Input.GetVector("rightJoystickright", "rightJoystickRight", "rightJoystickUp", "rightJoystickDown");

        float leftTrigger = Input.GetActionStrength("leftTrigger");
        float rightTrigger = Input.GetActionStrength("rightTrigger");

        bool buttonEast = Input.IsActionPressed("buttonEast");
        bool buttonWest = Input.IsActionPressed("buttonWest");
        bool buttonSouth = Input.IsActionPressed("buttonSouth");
        bool buttonNorth = Input.IsActionPressed("buttonNorth");

        bool dpadEast = Input.IsActionPressed("dpadEast");
        bool dpadWest = Input.IsActionPressed("dpadWest");
        bool dpadSouth = Input.IsActionPressed("dpadSouth");
        bool dpadNorth = Input.IsActionPressed("dpadNorth");

        bool start = Input.IsActionPressed("start");
        bool select = Input.IsActionJustPressed("select");
        bool shoulderLeft = Input.IsActionPressed("leftShoulder");
        bool shoulderRight = Input.IsActionPressed("rightShoulder");

        switch(mode)
        {
            case ControlMode.Drive:
            {
                HandleDrive(leftJoystick, rightJoystick,
                            leftTrigger, rightTrigger,
                            buttonSouth, buttonEast, buttonWest, buttonNorth,
                            dpadEast, dpadWest, dpadNorth, dpadSouth,
                            start, select,
                            shoulderLeft, shoulderRight);
                break;
            }
            case ControlMode.Arm:
            {
                HandleArm(leftJoystick, rightJoystick,
                            leftTrigger, rightTrigger,
                            buttonSouth, buttonEast, buttonWest, buttonNorth,
                            dpadEast, dpadWest, dpadNorth, dpadSouth,
                            start, select,
                            shoulderLeft, shoulderRight);
                break;
            }
        }
    }

    void HandleDrive(
        Vector2 leftJoy, Vector2 rightJoy,
        float leftTrigger, float rightTrigger,
        bool buttonSouth, bool buttonEast, bool buttonWest, bool buttonNorth,
        bool dpadEast, bool dpadWest, bool dpadNorth, bool dpadSouth,
        bool start, bool select,
        bool shoulderWest, bool shoulderEast
    )
    {
        // TODO: update / check drive speed slider
        // TOOD: update drive speed

        driveMessage = new()
        {
            ["topic"] = "cmd_vel",
            ["msgType"] = "geometry_msgs/msg/Twist",
            ["data"] = {
                ["linear"] = {
                    ["x"] = leftJoy.Y * driveSpeed,
                    ["y"] = 0.0,
                    ["z"] = 0.0,
                },
                ["angular"] = {
                    ["x"] = 0.0,
                    ["y"] = 0.0,
                    ["z"] = rightJoy.X * driveSpeed * -1,
                },
            }
        };
        UdpController.inst.PublishMessage(driveMessage.ToString());

        if(select)
        {
            useChassisPanTilt = !useChassisPanTilt;
        }

        bool panTiltHasInput = (start) ||
                    (buttonWest || buttonEast) ||
                    (shoulderWest || shoulderEast) ||
                    (buttonNorth || buttonSouth) ||
                    (dpadEast || dpadWest);
        if(panTiltHasInput)
        {
            float yaw = ((buttonWest ? 1.0f : 0.0f) - (buttonEast ? 1.0f : 0.0f)) + ((shoulderWest ? 1.0f : 0.0f) - (shoulderEast ? 1.0f : 0.0f));
            float pitch = (buttonNorth ? 1.0f : 0.0f) - (buttonSouth ? 1.0f : 0.0f);
            float roll = (dpadEast ? 1.0f : 0.0f) - (dpadWest ? 1.0f : 0.0f);
            tiltMessage = new(){
                ["topic"] = useChassisPanTilt ? "chassis_pan_tilt/control" : "tower_gimbal/control",
                ["data"] = {
                    ["go_home"] = start,
                    ["is_angle"] = false,
                    ["stabalize"] = false,
                    ["yaw"] = gimbalSpeedScale * yaw,
                    ["pitch"] = gimbalSpeedScale * pitch,
                    ["roll"] = gimbalSpeedScale * roll,
                },
            };
            UdpController.inst.PublishMessage(tiltMessage.ToString());
        }

        if(dpadNorth)
        {
            JObject msg = new()
            {
                ["topic"] = "/tower/light/control",
                ["msgType"] = "std_msgs/msg/UInt8",
                ["data"] = {
                    ["data"] = 2,
                },
            };
            UdpController.inst.PublishMessage(msg.ToString());
        }
        else if(dpadSouth)
        {
            JObject msg = new()
            {
                ["topic"] = "/tower/light/control",
                ["msgType"] = "std_msgs/msg/UInt8",
                ["data"] = {
                    ["data"] = 0,
                },
            };
            UdpController.inst.PublishMessage(msg.ToString());
        }
    }

    void HandleArm(
        Vector2 leftJoy, Vector2 rightJoy,
        float leftTrigger, float rightTrigger,
        bool buttonSouth, bool buttonEast, bool buttonWest, bool buttonNorth,
        bool dpadEast, bool dpadWest, bool dpadNorth, bool dpadSouth,
        bool start, bool select,
        bool shoulderWest, bool shoulderEast)
    {
        // TODO: update / check arm speed slider
        // TOOD: update arm speed

        // we add the very tiny float because if we sending a 0 joint velocity for every joint after switching controllers
        // and moving, the arm would rapidly swing back to the pose the original controller put it in
        float[] axes = new float[] {
            -leftJoy.X * armSpeed, leftJoy.Y * armSpeed, leftTrigger * armSpeed,
            -rightJoy.X * armSpeed, rightJoy.Y * armSpeed, rightTrigger * armSpeed,
            ((dpadEast ? 1.0f : 0.0f) * armSpeed) - ((dpadWest ? 1.0f : 0.0f) * armSpeed + 0.0000000000001f),
            ((dpadNorth ? 1.0f : 0.0f) * armSpeed) - ((dpadSouth ? 1.0f : 0.0f) * armSpeed)
        };

        int[] buttons = new int[] {
            buttonSouth ? 1 : 0, buttonEast ? 1 : 0, buttonWest ? 1 : 0, buttonNorth ? 1 : 0,
            0, 0,
            start ? 1 : 0, select ? 1 : 0,
            0, 0, shoulderEast ? 1 : 0, shoulderWest ? 1 : 0, shoulderWest ? 1 : 0,
        };

        joyMessage = new(){
            ["topic"] = "joy",
            ["msgType"] = "sensor_msgs/msg/Joy",
            ["data"] = {
                ["axes"] = new JArray(axes),
                ["button"] = new JArray(buttons)
            }
        };
        UdpController.inst.PublishMessage(joyMessage.ToString());
    }

    void SetOffMode()
    {
        mode = ControlMode.Off;
        GD.Print("Switched to OFF mode");
        UpdateButtonColors();
    }
    void SetDriveMode()
    {
        mode = ControlMode.Drive;
        GD.Print("Switched to DRIVE mode");
        UpdateButtonColors();
    }
    void SetArmMode()
    {
        mode = ControlMode.Arm;
        GD.Print("Switched to ARM mode");
        UpdateButtonColors();
    }

    void UpdateButtonColors()
    {
        // TODO update button colors once the buttons exist
    }
}