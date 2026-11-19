using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.sensor_msgs.srv;

[Tool]
[GlobalClass]
public partial class SetCameraInfo : ROS2Messages.BaseRequest {
  public static string jsonstring = "{\"service\":\"\",\"srvType\":\"sensor_msgs/srv/SetCameraInfo\",\"request\":{\"camera_info\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"height\":0,\"width\":0,\"distortion_model\":\"\",\"d\":[],\"k\":[],\"r\":[],\"p\":[],\"binning_x\":0,\"binning_y\":0,\"roi\":{\"x_offset\":0,\"y_offset\":0,\"height\":0,\"width\":0,\"do_rectify\":false}}},\"response\":{\"success\":false,\"status_message\":\"\"}}";
  [Export]
  public string service {get; set; }= "";
  [Export]
  public bool response_success;
  public string response_status_message;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["service"] = service;
    return returnValue;
  }
  SetCameraInfo() {}
}
