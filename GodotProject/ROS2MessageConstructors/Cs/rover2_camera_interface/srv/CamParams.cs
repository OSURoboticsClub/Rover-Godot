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
  [ExportGroup("request")]
  [Export] public int request_preset_level{get; set; }= 0;
  [Export] public int request_bitrate{get; set; }= 0;
  [Export] public int request_stream_width{get; set; }= 0;
  [Export] public int request_stream_height{get; set; }= 0;
  [Export] public int request_fec_percentage{get; set; }= 0;
  [ExportGroup("response")]
  [Export] public string response_ack{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["service"] = service;
    returnValue["request"]["preset_level"] = request_preset_level;
    returnValue["request"]["bitrate"] = request_bitrate;
    returnValue["request"]["stream_width"] = request_stream_width;
    returnValue["request"]["stream_height"] = request_stream_height;
    returnValue["request"]["fec_percentage"] = request_fec_percentage;
    returnValue["response"]["ack"] = response_ack;
    return  returnValue;
  }
  public override CamParams loadJson(JObject json) {
    service = (string)json["service"];
    request_preset_level = (int)json["request"]["preset_level"];
    request_bitrate = (int)json["request"]["bitrate"];
    request_stream_width = (int)json["request"]["stream_width"];
    request_stream_height = (int)json["request"]["stream_height"];
    request_fec_percentage = (int)json["request"]["fec_percentage"];
    response_ack = (string)json["response"]["ack"];
    return  this;
  }
  public static explicit operator CamParams(JObject json){
    return new CamParams().loadJson(json);
  }
  CamParams() {}
}
