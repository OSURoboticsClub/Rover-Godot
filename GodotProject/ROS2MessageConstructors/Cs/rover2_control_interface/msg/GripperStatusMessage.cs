using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_control_interface.msg;

[Tool]
[GlobalClass]
public partial class GripperStatusMessage : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/GripperStatusMessage\",\"data\":{\"position_raw\":0,\"current\":0,\"temp\":0,\"distance\":0,\"light_on\":false,\"laser_on\":false}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public int position_raw{get; set; }= 0;
  [Export] public int current{get; set; }= 0;
  [Export] public int temp{get; set; }= 0;
  [Export] public int distance{get; set; }= 0;
  [Export] public bool light_on{get; set; }= false;
  [Export] public bool laser_on{get; set; }= false;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["position_raw"] = position_raw;
    returnValue["data"]["current"] = current;
    returnValue["data"]["temp"] = temp;
    returnValue["data"]["distance"] = distance;
    returnValue["data"]["light_on"] = light_on;
    returnValue["data"]["laser_on"] = laser_on;
    return  returnValue;
  }
  public override GripperStatusMessage loadJson(JObject json) {
    position_raw = (int)json["data"]["position_raw"];
    current = (int)json["data"]["current"];
    temp = (int)json["data"]["temp"];
    distance = (int)json["data"]["distance"];
    light_on = (bool)json["data"]["light_on"];
    laser_on = (bool)json["data"]["laser_on"];
    return  this;
  }
  public static explicit operator GripperStatusMessage(JObject json){
    return new GripperStatusMessage().loadJson(json);
  }
  GripperStatusMessage() {}
}
