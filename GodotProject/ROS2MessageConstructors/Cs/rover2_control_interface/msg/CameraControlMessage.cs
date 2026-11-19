using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_control_interface.msg;

[Tool]
[GlobalClass]
public partial class CameraControlMessage : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/CameraControlMessage\",\"data\":{\"cam_shoot\":false,\"cam_zoom_in_full\":false,\"cam_zoom_out_full\":false,\"cam_zoom_in\":false,\"cam_zoom_out\":false,\"cam_change_view\":0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public bool cam_shoot{get; set; }= false;
  [Export] public bool cam_zoom_in_full{get; set; }= false;
  [Export] public bool cam_zoom_out_full{get; set; }= false;
  [Export] public bool cam_zoom_in{get; set; }= false;
  [Export] public bool cam_zoom_out{get; set; }= false;
  [Export] public int cam_change_view{get; set; }= 0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["cam_shoot"] = cam_shoot;
    returnValue["data"]["cam_zoom_in_full"] = cam_zoom_in_full;
    returnValue["data"]["cam_zoom_out_full"] = cam_zoom_out_full;
    returnValue["data"]["cam_zoom_in"] = cam_zoom_in;
    returnValue["data"]["cam_zoom_out"] = cam_zoom_out;
    returnValue["data"]["cam_change_view"] = cam_change_view;
    return  returnValue;
  }
  public override CameraControlMessage loadJson(JObject json) {
    cam_shoot = (bool)json["data"]["cam_shoot"];
    cam_zoom_in_full = (bool)json["data"]["cam_zoom_in_full"];
    cam_zoom_out_full = (bool)json["data"]["cam_zoom_out_full"];
    cam_zoom_in = (bool)json["data"]["cam_zoom_in"];
    cam_zoom_out = (bool)json["data"]["cam_zoom_out"];
    cam_change_view = (int)json["data"]["cam_change_view"];
    return  this;
  }
  public static explicit operator CameraControlMessage(JObject json){
    return new CameraControlMessage().loadJson(json);
  }
  CameraControlMessage() {}
}
