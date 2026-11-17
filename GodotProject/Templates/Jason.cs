using Godot;

using Newtonsoft.Json.Linq;

using System;


public static class Jason

{
  public static class geometry_msgs{
    public static class msg{
      public static string Accel = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Accel\",\"data\":{\"linear\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}";
      public static string AccelStamped = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/AccelStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"accel\":{\"linear\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}}";
      public static string AccelWithCovariance = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/AccelWithCovariance\",\"data\":{\"accel\":{\"linear\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}},\"covariance\":[]}}";
      public static string AccelWithCovarianceStamped = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/AccelWithCovarianceStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"accel\":{\"accel\":{\"linear\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}},\"covariance\":[]}}}";
      public static string Inertia = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Inertia\",\"data\":{\"m\":0.0,\"com\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"ixx\":0.0,\"ixy\":0.0,\"ixz\":0.0,\"iyy\":0.0,\"iyz\":0.0,\"izz\":0.0}}";
      public static string InertiaStamped = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/InertiaStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"inertia\":{\"m\":0.0,\"com\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"ixx\":0.0,\"ixy\":0.0,\"ixz\":0.0,\"iyy\":0.0,\"iyz\":0.0,\"izz\":0.0}}}";
      public static string Point = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Point\",\"data\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}";
      public static string Point32 = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Point32\",\"data\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}";
      public static string PointStamped = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/PointStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"point\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}";
      public static string Polygon = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Polygon\",\"data\":{\"points\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}";
      public static string PolygonInstance = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/PolygonInstance\",\"data\":{\"polygon\":{\"points\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}},\"id\":0}}";
      public static string PolygonInstanceStamped = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/PolygonInstanceStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"polygon\":{\"polygon\":{\"points\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}},\"id\":0}}}";
      public static string PolygonStamped = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/PolygonStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"polygon\":{\"points\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}}";
      public static string Pose = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Pose\",\"data\":{\"position\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"orientation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0}}}";
      public static string Pose2D = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Pose2D\",\"data\":{\"x\":0.0,\"y\":0.0,\"theta\":0.0}}";
      public static string PoseArray = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/PoseArray\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"poses\":{\"position\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"orientation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0}}}}";
      public static string PoseStamped = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/PoseStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"pose\":{\"position\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"orientation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0}}}}";
      public static string PoseWithCovariance = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/PoseWithCovariance\",\"data\":{\"pose\":{\"position\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"orientation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0}},\"covariance\":[]}}";
      public static string PoseWithCovarianceStamped = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/PoseWithCovarianceStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"pose\":{\"pose\":{\"position\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"orientation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0}},\"covariance\":[]}}}";
      public static string Quaternion = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Quaternion\",\"data\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0}}";
      public static string QuaternionStamped = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/QuaternionStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"quaternion\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0}}}";
      public static string Transform = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Transform\",\"data\":{\"translation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"rotation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0}}}";
      public static string TransformStamped = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/TransformStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"child_frame_id\":\"\",\"transform\":{\"translation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"rotation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0}}}}";
      public static string Twist = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Twist\",\"data\":{\"linear\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}";
      public static string TwistStamped = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/TwistStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"twist\":{\"linear\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}}";
      public static string TwistWithCovariance = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/TwistWithCovariance\",\"data\":{\"twist\":{\"linear\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}},\"covariance\":[]}}";
      public static string TwistWithCovarianceStamped = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/TwistWithCovarianceStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"twist\":{\"twist\":{\"linear\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}},\"covariance\":[]}}}";
      public static string Vector3 = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Vector3\",\"data\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}";
      public static string Vector3Stamped = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Vector3Stamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"vector\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}";
      public static string VelocityStamped = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/VelocityStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"body_frame_id\":\"\",\"reference_frame_id\":\"\",\"velocity\":{\"linear\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}}";
      public static string Wrench = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Wrench\",\"data\":{\"force\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"torque\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}";
      public static string WrenchStamped = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/WrenchStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"wrench\":{\"force\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"torque\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}}";
    }
  }
  public static class rover2_camera_interface{
    public static class srv{
      public static string CamParams = "{\"service\":\"\",\"srvType\":\"rover2_camera_interface/srv/CamParams\",\"request\":{\"preset_level\":0,\"bitrate\":0,\"stream_width\":0,\"stream_height\":0,\"fec_percentage\":0},\"response\":{\"ack\":\"\"}}";
    }
  }
  public static class rover2_control_interface{
    public static class msg{
      public static string CameraControlMessage = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/CameraControlMessage\",\"data\":{\"cam_shoot\":false,\"cam_zoom_in_full\":false,\"cam_zoom_out_full\":false,\"cam_zoom_in\":false,\"cam_zoom_out\":false,\"cam_change_view\":0}}";
      public static string DrillControlMessage = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/DrillControlMessage\",\"data\":{\"direction\":false,\"speed\":0}}";
      public static string DriveCommandMessage = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/DriveCommandMessage\",\"data\":{\"controller_present\":false,\"ignore_drive_control\":false,\"drive_twist\":{\"linear\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}}";
      public static string DriveControlMessage = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/DriveControlMessage\",\"data\":{\"first_motor_direction\":false,\"first_motor_sleep\":false,\"first_motor_speed\":0}}";
      public static string DriveStatusMessage = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/DriveStatusMessage\",\"data\":{\"first_motor_connected\":false,\"second_motor_connected\":false,\"third_motor_connected\":false,\"first_motor_current\":0.0,\"second_motor_current\":0.0,\"third_motor_current\":0.0,\"first_motor_fault\":false,\"second_motor_fault\":false,\"third_motor_fault\":false,\"first_motor_temp\":0.0,\"second_motor_temp\":0.0,\"third_motor_temp\":0.0}}";
      public static string GPSStatusMessage = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/GPSStatusMessage\",\"data\":{\"rover_latitude\":0.0,\"rover_longitude\":0.0,\"astronaut_latitude\":0.0,\"astronaut_longitude\":0.0}}";
      public static string GripperControlMessage = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/GripperControlMessage\",\"data\":{\"target\":0,\"should_home\":false,\"toggle_light\":false,\"toggle_laser\":false}}";
      public static string GripperStatusMessage = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/GripperStatusMessage\",\"data\":{\"position_raw\":0,\"current\":0,\"temp\":0,\"distance\":0,\"light_on\":false,\"laser_on\":false}}";
      public static string IrisStatusMessage = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/IrisStatusMessage\",\"data\":{\"iris_connected\":false,\"voltage_24v\":0}}";
      public static string LightControlMessage = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/LightControlMessage\",\"data\":{\"light_mode\":0}}";
      public static string MiningControlMessage = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/MiningControlMessage\",\"data\":{\"motor_set_position_positive\":0,\"motor_set_position_negative\":0,\"motor_set_position_absolute\":0,\"motor_go_home\":false,\"motor_stop\":false,\"linear_set_position_positive\":0,\"linear_set_position_negative\":0,\"linear_set_position_absolute\":0,\"linear_stop\":false,\"servo1_target\":0,\"servo2_target\":0,\"probe_take_reading\":false,\"overtravel\":false,\"compartment\":0}}";
      public static string MiningStatusMessage = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/MiningStatusMessage\",\"data\":{\"probe_temp_c\":0.0,\"probe_moisture\":0.0,\"probe_loss_tangent\":0.0,\"probe_soil_elec_cond\":0.0,\"probe_real_dielec_perm\":0.0,\"probe_imag_dielec_perm\":0.0,\"motor_current_position\":0,\"linear_current_position\":0,\"temp1\":0,\"temp2\":0,\"motor_current\":0.0,\"linear_current\":0.0,\"switch1_out\":false,\"switch2_out\":false,\"homing_needed\":false}}";
      public static string OdrivePanTiltControlMessage = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/OdrivePanTiltControlMessage\",\"data\":{\"go_home\":false,\"is_angle\":false,\"stabalize\":false,\"pitch\":0.0,\"yaw\":0.0,\"roll\":0.0}}";
      public static string TowerPanTiltControlMessage = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/TowerPanTiltControlMessage\",\"data\":{\"should_center\":false,\"relative_pan_adjustment\":0,\"relative_tilt_adjustment\":0,\"hitch_servo_positive\":false,\"hitch_servo_negative\":false}}";
    }
    public static class srv{
      public static string HeistMechanismService = "{\"service\":\"\",\"srvType\":\"rover2_control_interface/srv/HeistMechanismService\",\"request\":{\"command\":0,\"message\":\"\"},\"response\":{\"success\":false,\"result_msg\":\"\"}}";
    }
  }
  public static class rover2_status_interface{
    public static class msg{
      public static string FilteredLog = "{\"topic\":\"\",\"msgType\":\"rover2_status_interface/msg/FilteredLog\",\"data\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"name\":\"\",\"level\":0,\"msg\":\"\"}}";
      public static string LED = "{\"topic\":\"\",\"msgType\":\"rover2_status_interface/msg/LED\",\"data\":{\"red\":0,\"green\":0,\"blue\":0}}";
      public static string MoveItLogs = "{\"topic\":\"\",\"msgType\":\"rover2_status_interface/msg/MoveItLogs\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"name\":[],\"position\":[],\"velocity\":[],\"effort\":[],\"status\":0}}";
      public static string NodesTopics = "{\"topic\":\"\",\"msgType\":\"rover2_status_interface/msg/NodesTopics\",\"data\":{\"topic_name\":[],\"topic_status\":[],\"node_name\":[],\"node_status\":[]}}";
      public static string ODriveStatus = "{\"topic\":\"\",\"msgType\":\"rover2_status_interface/msg/ODriveStatus\",\"data\":{\"timestamp\":{\"sec\":0,\"nanosec\":0},\"bus\":\"\",\"id\":[],\"disarm_reason\":[],\"t_fet\":[],\"t_motor\":[],\"velocity\":[],\"position\":[],\"iq_set\":[],\"iq_measured\":[],\"bus_voltage\":[],\"bus_current\":[]}}";
      public static string TractionStatus = "{\"topic\":\"\",\"msgType\":\"rover2_status_interface/msg/TractionStatus\",\"data\":{\"timestamp\":{\"sec\":0,\"nanosec\":0},\"id\":[],\"names\":[],\"slipstate\":[]}}";
    }
    public static class srv{
      public static string LatencySize = "{\"service\":\"\",\"srvType\":\"rover2_status_interface/srv/LatencySize\",\"request\":{\"dummydata\":[]},\"response\":{\"receivetime\":{\"sec\":0,\"nanosec\":0}}}";
      public static string NodeInfo = "{\"service\":\"\",\"srvType\":\"rover2_status_interface/srv/NodeInfo\",\"request\":{\"node\":\"\",\"nodenamespace\":\"\"},\"response\":{\"pub_topics\":[],\"sub_topics\":[],\"services\":[]}}";
      public static string NodeLog = "{\"service\":\"\",\"srvType\":\"rover2_status_interface/srv/NodeLog\",\"request\":{\"enable\":false,\"hz\":0.0,\"node\":\"\"},\"response\":{\"acknowledge\":false}}";
    }
  }
  public static class sensor_msgs{
    public static class msg{
      public static string BatteryState = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/BatteryState\",\"data\":{\"POWER_SUPPLY_STATUS_UNKNOWN\":0,\"POWER_SUPPLY_STATUS_CHARGING\":0,\"POWER_SUPPLY_STATUS_DISCHARGING\":0,\"POWER_SUPPLY_STATUS_NOT_CHARGING\":0,\"POWER_SUPPLY_STATUS_FULL\":0,\"POWER_SUPPLY_HEALTH_UNKNOWN\":0,\"POWER_SUPPLY_HEALTH_GOOD\":0,\"POWER_SUPPLY_HEALTH_OVERHEAT\":0,\"POWER_SUPPLY_HEALTH_DEAD\":0,\"POWER_SUPPLY_HEALTH_OVERVOLTAGE\":0,\"POWER_SUPPLY_HEALTH_UNSPEC_FAILURE\":0,\"POWER_SUPPLY_HEALTH_COLD\":0,\"POWER_SUPPLY_HEALTH_WATCHDOG_TIMER_EXPIRE\":0,\"POWER_SUPPLY_HEALTH_SAFETY_TIMER_EXPIRE\":0,\"POWER_SUPPLY_TECHNOLOGY_UNKNOWN\":0,\"POWER_SUPPLY_TECHNOLOGY_NIMH\":0,\"POWER_SUPPLY_TECHNOLOGY_LION\":0,\"POWER_SUPPLY_TECHNOLOGY_LIPO\":0,\"POWER_SUPPLY_TECHNOLOGY_LIFE\":0,\"POWER_SUPPLY_TECHNOLOGY_NICD\":0,\"POWER_SUPPLY_TECHNOLOGY_LIMN\":0,\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"voltage\":0.0,\"temperature\":0.0,\"current\":0.0,\"charge\":0.0,\"capacity\":0.0,\"design_capacity\":0.0,\"percentage\":0.0,\"power_supply_status\":0,\"power_supply_health\":0,\"power_supply_technology\":0,\"present\":false,\"cell_voltage\":[],\"cell_temperature\":[],\"location\":\"\",\"serial_number\":\"\"}}";
      public static string CameraInfo = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/CameraInfo\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"height\":0,\"width\":0,\"distortion_model\":\"\",\"d\":[],\"k\":[],\"r\":[],\"p\":[],\"binning_x\":0,\"binning_y\":0,\"roi\":{\"x_offset\":0,\"y_offset\":0,\"height\":0,\"width\":0,\"do_rectify\":false}}}";
      public static string ChannelFloat32 = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/ChannelFloat32\",\"data\":{\"name\":\"\",\"values\":[]}}";
      public static string CompressedImage = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/CompressedImage\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"format\":\"\",\"data\":[]}}";
      public static string FluidPressure = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/FluidPressure\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"fluid_pressure\":0.0,\"variance\":0.0}}";
      public static string Illuminance = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/Illuminance\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"illuminance\":0.0,\"variance\":0.0}}";
      public static string Image = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/Image\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"height\":0,\"width\":0,\"encoding\":\"\",\"is_bigendian\":0,\"step\":0,\"data\":[]}}";
      public static string Imu = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/Imu\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"orientation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0},\"orientation_covariance\":[],\"angular_velocity\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular_velocity_covariance\":[],\"linear_acceleration\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"linear_acceleration_covariance\":[]}}";
      public static string JointState = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/JointState\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"name\":[],\"position\":[],\"velocity\":[],\"effort\":[]}}";
      public static string Joy = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/Joy\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"axes\":[],\"buttons\":[]}}";
      public static string JoyFeedback = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/JoyFeedback\",\"data\":{\"TYPE_LED\":0,\"TYPE_RUMBLE\":0,\"TYPE_BUZZER\":0,\"type\":0,\"id\":0,\"intensity\":0.0}}";
      public static string JoyFeedbackArray = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/JoyFeedbackArray\",\"data\":{\"array\":{\"TYPE_LED\":0,\"TYPE_RUMBLE\":0,\"TYPE_BUZZER\":0,\"type\":0,\"id\":0,\"intensity\":0.0}}}";
      public static string LaserEcho = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/LaserEcho\",\"data\":{\"echoes\":[]}}";
      public static string LaserScan = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/LaserScan\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"angle_min\":0.0,\"angle_max\":0.0,\"angle_increment\":0.0,\"time_increment\":0.0,\"scan_time\":0.0,\"range_min\":0.0,\"range_max\":0.0,\"ranges\":[],\"intensities\":[]}}";
      public static string MagneticField = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/MagneticField\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"magnetic_field\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"magnetic_field_covariance\":[]}}";
      public static string MultiDOFJointState = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/MultiDOFJointState\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"joint_names\":[],\"transforms\":{\"translation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"rotation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0}},\"twist\":{\"linear\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}},\"wrench\":{\"force\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"torque\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}}";
      public static string MultiEchoLaserScan = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/MultiEchoLaserScan\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"angle_min\":0.0,\"angle_max\":0.0,\"angle_increment\":0.0,\"time_increment\":0.0,\"scan_time\":0.0,\"range_min\":0.0,\"range_max\":0.0,\"ranges\":{\"echoes\":[]},\"intensities\":{\"echoes\":[]}}}";
      public static string NavSatFix = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/NavSatFix\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"status\":{\"STATUS_NO_FIX\":0,\"STATUS_FIX\":0,\"STATUS_SBAS_FIX\":0,\"STATUS_GBAS_FIX\":0,\"status\":0,\"SERVICE_GPS\":0,\"SERVICE_GLONASS\":0,\"SERVICE_COMPASS\":0,\"SERVICE_GALILEO\":0,\"service\":0},\"latitude\":0.0,\"longitude\":0.0,\"altitude\":0.0,\"position_covariance\":[],\"COVARIANCE_TYPE_UNKNOWN\":0,\"COVARIANCE_TYPE_APPROXIMATED\":0,\"COVARIANCE_TYPE_DIAGONAL_KNOWN\":0,\"COVARIANCE_TYPE_KNOWN\":0,\"position_covariance_type\":0}}";
      public static string NavSatStatus = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/NavSatStatus\",\"data\":{\"STATUS_NO_FIX\":0,\"STATUS_FIX\":0,\"STATUS_SBAS_FIX\":0,\"STATUS_GBAS_FIX\":0,\"status\":0,\"SERVICE_GPS\":0,\"SERVICE_GLONASS\":0,\"SERVICE_COMPASS\":0,\"SERVICE_GALILEO\":0,\"service\":0}}";
      public static string PointCloud = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/PointCloud\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"points\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"channels\":{\"name\":\"\",\"values\":[]}}}";
      public static string PointCloud2 = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/PointCloud2\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"height\":0,\"width\":0,\"fields\":{\"INT8\":0,\"UINT8\":0,\"INT16\":0,\"UINT16\":0,\"INT32\":0,\"UINT32\":0,\"FLOAT32\":0,\"FLOAT64\":0,\"name\":\"\",\"offset\":0,\"datatype\":0,\"count\":0},\"is_bigendian\":false,\"point_step\":0,\"row_step\":0,\"data\":[],\"is_dense\":false}}";
      public static string PointField = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/PointField\",\"data\":{\"INT8\":0,\"UINT8\":0,\"INT16\":0,\"UINT16\":0,\"INT32\":0,\"UINT32\":0,\"FLOAT32\":0,\"FLOAT64\":0,\"name\":\"\",\"offset\":0,\"datatype\":0,\"count\":0}}";
      public static string Range = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/Range\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"ULTRASOUND=0\":0,\"INFRARED=1\":0,\"radiation_type\":0,\"field_of_view\":0.0,\"min_range\":0.0,\"max_range\":0.0,\"range\":0.0}}";
      public static string RegionOfInterest = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/RegionOfInterest\",\"data\":{\"x_offset\":0,\"y_offset\":0,\"height\":0,\"width\":0,\"do_rectify\":false}}";
      public static string RelativeHumidity = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/RelativeHumidity\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"relative_humidity\":0.0,\"variance\":0.0}}";
      public static string Temperature = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/Temperature\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"temperature\":0.0,\"variance\":0.0}}";
      public static string TimeReference = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/TimeReference\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"time_ref\":{\"sec\":0,\"nanosec\":0},\"source\":\"\"}}";
    }
    public static class srv{
      public static string SetCameraInfo = "{\"service\":\"\",\"srvType\":\"sensor_msgs/srv/SetCameraInfo\",\"request\":{\"camera_info\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"height\":0,\"width\":0,\"distortion_model\":\"\",\"d\":[],\"k\":[],\"r\":[],\"p\":[],\"binning_x\":0,\"binning_y\":0,\"roi\":{\"x_offset\":0,\"y_offset\":0,\"height\":0,\"width\":0,\"do_rectify\":false}}},\"response\":{\"success\":false,\"status_message\":\"\"}}";
    }
  }
  public static class std_msgs{
    public static class msg{
      public static string Bool = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Bool\",\"data\":{\"data\":false}}";
      public static string Byte = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Byte\",\"data\":{\"data\":0}}";
      public static string ByteMultiArray = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/ByteMultiArray\",\"data\":{\"layout\":{\"dim\":{\"label\":\"\",\"size\":0,\"stride\":0},\"data_offset\":0},\"data\":[]}}";
      public static string Char = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Char\",\"data\":{\"data\":0}}";
      public static string ColorRGBA = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/ColorRGBA\",\"data\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0}}";
      public static string Empty = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Empty\",\"data\":{}}";
      public static string Float32 = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Float32\",\"data\":{\"data\":0.0}}";
      public static string Float32MultiArray = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Float32MultiArray\",\"data\":{\"layout\":{\"dim\":[],\"data_offset\":0},\"data\":[]}}";
      public static string Float64 = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Float64\",\"data\":{\"data\":0.0}}";
      public static string Float64MultiArray = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Float64MultiArray\",\"data\":{\"layout\":{\"dim\":{\"label\":\"\",\"size\":0,\"stride\":0},\"data_offset\":0},\"data\":[]}}";
      public static string Header = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Header\",\"data\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"}}";
      public static string Int16 = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Int16\",\"data\":{\"data\":0}}";
      public static string Int16MultiArray = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Int16MultiArray\",\"data\":{\"layout\":{\"dim\":{\"label\":\"\",\"size\":0,\"stride\":0},\"data_offset\":0},\"data\":[]}}";
      public static string Int32 = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Int32\",\"data\":{\"data\":0}}";
      public static string Int32MultiArray = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Int32MultiArray\",\"data\":{\"layout\":{\"dim\":{\"label\":\"\",\"size\":0,\"stride\":0},\"data_offset\":0},\"data\":[]}}";
      public static string Int64 = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Int64\",\"data\":{\"data\":0}}";
      public static string Int64MultiArray = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Int64MultiArray\",\"data\":{\"layout\":{\"dim\":{\"label\":\"\",\"size\":0,\"stride\":0},\"data_offset\":0},\"data\":[]}}";
      public static string Int8 = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Int8\",\"data\":{\"data\":0}}";
      public static string Int8MultiArray = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Int8MultiArray\",\"data\":{\"layout\":{\"dim\":{\"label\":\"\",\"size\":0,\"stride\":0},\"data_offset\":0},\"data\":[]}}";
      public static string MultiArrayDimension = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/MultiArrayDimension\",\"data\":{\"label\":\"\",\"size\":0,\"stride\":0}}";
      public static string MultiArrayLayout = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/MultiArrayLayout\",\"data\":{\"dim\":{\"label\":\"\",\"size\":0,\"stride\":0},\"data_offset\":0}}";
      public static string String = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/String\",\"data\":{\"data\":\"\"}}";
      public static string UInt16 = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/UInt16\",\"data\":{\"data\":0}}";
      public static string UInt16MultiArray = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/UInt16MultiArray\",\"data\":{\"layout\":{\"dim\":{\"label\":\"\",\"size\":0,\"stride\":0},\"data_offset\":0},\"data\":[]}}";
      public static string UInt32 = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/UInt32\",\"data\":{\"data\":0}}";
      public static string UInt32MultiArray = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/UInt32MultiArray\",\"data\":{\"layout\":{\"dim\":{\"label\":\"\",\"size\":0,\"stride\":0},\"data_offset\":0},\"data\":[]}}";
      public static string UInt64 = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/UInt64\",\"data\":{\"data\":0}}";
      public static string UInt64MultiArray = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/UInt64MultiArray\",\"data\":{\"layout\":{\"dim\":{\"label\":\"\",\"size\":0,\"stride\":0},\"data_offset\":0},\"data\":[]}}";
      public static string UInt8 = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/UInt8\",\"data\":{\"data\":0}}";
      public static string UInt8MultiArray = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/UInt8MultiArray\",\"data\":{\"layout\":{\"dim\":{\"label\":\"\",\"size\":0,\"stride\":0},\"data_offset\":0},\"data\":[]}}";
    }
  }
  public static class std_srvs{
    public static class srv{
      public static string AntennaControlService = "{\"service\":\"\",\"srvType\":\"gs_tower_interfaces/srv/AntennaControlService\",\"request\":{\"mode\":0},\"response\":{\"success\":false,\"msg\":[]}}";
      public static string Empty = "{\"service\":\"\",\"srvType\":\"std_srvs/srv/Empty\",\"request\":{},\"response\":{}}";
      public static string SetBool = "{\"service\":\"\",\"srvType\":\"std_srvs/srv/SetBool\",\"request\":{\"data\":false},\"response\":{\"success\":false,\"message\":\"\"}}";
      public static string Trigger = "{\"service\":\"\",\"srvType\":\"std_srvs/srv/Trigger\",\"request\":{},\"response\":{\"success\":false,\"message\":\"\"}}";
    }
  }
}