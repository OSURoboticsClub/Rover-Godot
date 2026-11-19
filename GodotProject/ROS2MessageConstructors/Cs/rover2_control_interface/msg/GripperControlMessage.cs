using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_control_interface.msg;

[Tool]
[GlobalClass]
public partial class GripperControlMessage : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/GripperControlMessage\",\"data\":{\"target\":0,\"should_home\":false,\"toggle_light\":false,\"toggle_laser\":false}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public int target{get; set; }= 0;
  [Export] public bool should_home{get; set; }= false;
  [Export] public bool toggle_light{get; set; }= false;
  [Export] public bool toggle_laser{get; set; }= false;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["target"] = target;
    returnValue["data"]["should_home"] = should_home;
    returnValue["data"]["toggle_light"] = toggle_light;
    returnValue["data"]["toggle_laser"] = toggle_laser;
    return  returnValue;
  }
  public override GripperControlMessage loadJson(JObject json) {
    target = (int)json["data"]["target"];
    should_home = (bool)json["data"]["should_home"];
    toggle_light = (bool)json["data"]["toggle_light"];
    toggle_laser = (bool)json["data"]["toggle_laser"];
    return  this;
  }
  public static explicit operator GripperControlMessage(JObject json){
    return new GripperControlMessage().loadJson(json);
  }
  GripperControlMessage() {}
}
