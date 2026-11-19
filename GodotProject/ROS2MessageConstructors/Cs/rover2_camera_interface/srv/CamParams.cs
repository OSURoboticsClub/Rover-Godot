using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_camera_interface.srv;

[Tool]
[GlobalClass]
public partial class CamParams : ROS2Messages.BaseRequest {
  public static string jsonstring = "{\"service\":\"\",\"srvType\":\"rover2_camera_interface/srv/CamParams\",\"request\":{\"preset_level\":0,\"bitrate\":0,\"stream_width\":0,\"stream_height\":0,\"fec_percentage\":0},\"response\":{\"ack\":\"\"}}";
  [Export]
  public string service {get; set; }= "";
  [Export]
  public int preset_level{get; set; }= 0;
  [Export]
  public int bitrate{get; set; }= 0;
  [Export]
  public int stream_width{get; set; }= 0;
  [Export]
  public int stream_height{get; set; }= 0;
  [Export]
  public int fec_percentage{get; set; }= 0;
  public string response_ack;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["service"] = service;
    returnValue["request"]["preset_level"] = preset_level;
    returnValue["request"]["bitrate"] = bitrate;
    returnValue["request"]["stream_width"] = stream_width;
    returnValue["request"]["stream_height"] = stream_height;
    returnValue["request"]["fec_percentage"] = fec_percentage;
    return returnValue;
  }
  CamParams() {}
}
