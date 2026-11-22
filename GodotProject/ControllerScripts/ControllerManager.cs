using Godot;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Linq;

public partial class ControllerManager : Node
{
    public enum ControlMode
    {
        Off,
        Drive,
        Arm
    }

    public ControlMode mode = ControlMode.Off;

    public double driveSpeed = 0.5f;
    public double armSpeed = 0.5f;
    public double gimbalSpeedScale = 0.3;

    public float publishRate = 1f/30f; // 30 hz

    bool useChassisPanTilt = false;
    private JObject driveMessage = [];

    private JObject tiltMessage = [];

    private JObject joyMessage = [];

    private JObject joy2Message = [];

    [ExportCategory("UI Elements")]
    [Export] public NodePath modeButtonPath;
    private OptionButton modeButton;
    [Export] public NodePath timerPath;
    private Timer timer;
    [Export] public NodePath[] driveSpeedSliderPaths;
    private Godot.Collections.Array<Slider> driveSpeedSliders = [];
    [Export] public NodePath[] armSpeedSliderPaths;
    private Godot.Collections.Array<Slider> armSpeedSliders = [];


    public override void _Ready() {
        modeButton = GetNode<OptionButton>(modeButtonPath);
        timer = GetNode<Timer>(timerPath);

        foreach(NodePath i in driveSpeedSliderPaths)
        {
            try
            {
                Slider slider = GetNode<Slider>(i);
                slider.MinValue = 0f;
                slider.MaxValue = 1f;
                slider.Step = 0.05f;
                slider.Value = driveSpeed;
                driveSpeedSliders.Add(slider);
            }
            catch(Exception e)
            {
                GD.PrintErr($"{i} could not be loaded as a slider: {e.Message}");
            }
        }

        foreach(NodePath i in armSpeedSliderPaths)
        {
            try
            {
                Slider slider = GetNode<Slider>(i);
                slider.MinValue = 0f;
                slider.MaxValue = 1f;
                slider.Step = 0.05f;
                slider.Value = armSpeed;
                armSpeedSliders.Add(slider);
            }
            catch(Exception e)
            {
                GD.PrintErr($"{i} could not be loaded as a slider: {e.Message}");
            }
        }

        modeButton.ItemSelected += UpdateMode;

        timer.Autostart = true;
        timer.OneShot = false;
        timer.WaitTime = publishRate;
        timer.Timeout += PublishInputs; 
    }

    public override void _Process(double delta)
    {
        Vector2 leftJoystick = Input.GetVector("leftJoystickLeft", "leftJoystickRight", "leftJoystickDown", "leftJoystickUp");
        Vector2 rightJoystick = Input.GetVector("rightJoystickLeft", "rightJoystickRight", "rightJoystickDown", "rightJoystickUp");

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

        foreach(Slider i in driveSpeedSliders)
        {
            if(i.Value != driveSpeed)
            {
                driveSpeed = i.Value;
                foreach(Slider j in driveSpeedSliders)
                {
                    j.Value = driveSpeed;
                }
                break;
            }
        }
        foreach(Slider i in armSpeedSliders)
        {
            if(i.Value != armSpeed)
            {
                armSpeed = i.Value;
                foreach(Slider j in armSpeedSliders)
                {
                    j.Value = armSpeed;
                }
                break;
            }
        }

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
                {"topic", "joy"},
                {"msgType", "sensor_msgs/msg/Joy"},
                {
                    "data", new JObject
                    {
                        {"axes", new JArray(axes)},
                        {"buttons", new JArray(buttons)}
                    }
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
        Vector2 rightJoystick = Input.GetVector("rightJoystickLeft", "rightJoystickRight", "rightJoystickUp", "rightJoystickDown");

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
        foreach(Slider i in driveSpeedSliders)
        {
            i.Value += (leftTrigger - rightTrigger) * 0.025;
        }
        driveSpeed = driveSpeedSliders[0].Value;

        driveMessage = new JObject
        {
            { "topic", "cmd_vel" },
            { "msgType", "geometry_msgs/msg/Twist" },
            {
                "data", new JObject
                {
                    {
                        "linear", new JObject
                        {
                            {"x", leftJoy.Y * driveSpeed},
                            {"y", 0.0},
                            {"z", 0.0}
                        }
                    },
                    {
                        "angular", new JObject
                        {
                            {"x", 0.0},
                            {"y", 0.0},
                            {"z", rightJoy.X * driveSpeed * -1}
                        }
                    }
                }
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
            tiltMessage = new JObject
            {
                {"topic", useChassisPanTilt ? "chassis_pan_tilt/control" : "tower_gimbal/control"},
                {
                    "data", new JObject
                    {
                        {"go_home", start},
                        {"is_angle", false},
                        {"stabalize", false},
                        {"yaw", gimbalSpeedScale * yaw},
                        {"pitch", gimbalSpeedScale * pitch},
                        {"roll", gimbalSpeedScale * roll}
                    }
                }
            };
            UdpController.inst.PublishMessage(tiltMessage.ToString());
        }

        if(dpadNorth)
        {
            JObject msg = new JObject
            {
                {"topic", "/tower/light/control"},
                {"msgType", "std_msgs/msg/UInt8"},
                {
                    "data", new JObject
                    {
                        {"data", 2}
                    }
                }
            };
            UdpController.inst.PublishMessage(msg.ToString());
        }
        else if(dpadSouth)
        {
            JObject msg = new JObject
            {
                {"topic", "/tower/light/control"},
                {"msgType", "std_msgs/msg/UInt8"},
                {
                    "data", new JObject
                    {
                        {"data", 0}
                    }
                }
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
        foreach(Slider i in armSpeedSliders)
        {
            i.Value += ((buttonNorth ? 1.0f : 0.0f) - (buttonSouth ? 1.0f : 0.0f)) * 0.025;
        }
        armSpeed = armSpeedSliders[0].Value;

        // we add the very tiny float because if we sending a 0 joint velocity for every joint after switching controllers
        // and moving, the arm would rapidly swing back to the pose the original controller put it in
        float[] axes = new float[] {
            -leftJoy.X * (float)armSpeed, leftJoy.Y * (float)armSpeed, leftTrigger * (float)armSpeed,
            -rightJoy.X * (float)armSpeed, rightJoy.Y * (float)armSpeed, rightTrigger * (float)armSpeed,
            ((dpadEast ? 1.0f : 0.0f) * (float)armSpeed) - ((dpadWest ? 1.0f : 0.0f) * (float)armSpeed + 0.0000000000001f),
            ((dpadNorth ? 1.0f : 0.0f) * (float)armSpeed) - ((dpadSouth ? 1.0f : 0.0f) * (float)armSpeed)
        };

        int[] buttons = new int[] {
            buttonSouth ? 1 : 0, buttonEast ? 1 : 0, buttonWest ? 1 : 0, buttonNorth ? 1 : 0,
            0, 0,
            start ? 1 : 0, select ? 1 : 0,
            0, 0, shoulderEast ? 1 : 0, shoulderWest ? 1 : 0, shoulderWest ? 1 : 0,
        };

        joyMessage = new JObject
        {
            {"topic", "joy"},
            {"msgType", "sensor_msgs/msg/Joy"},
            {
                "data", new JObject
                {
                    {"axes", new JArray(axes)},
                    {"buttons", new JArray(buttons)},
                }
            }
        };

        UdpController.inst.PublishMessage(joyMessage.ToString());
    }

    void UpdateMode(long index)
    {
        // bounds check against the size of the modes enum
        if(index > 2)
            return;

        mode = (ControlMode)index;
        GD.Print($"Switch to {mode.ToString().ToUpper()} mode");
    }
}