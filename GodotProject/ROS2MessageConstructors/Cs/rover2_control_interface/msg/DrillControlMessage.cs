using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_control_interface.msg;

[Tool]
[GlobalClass]
public partial class DrillControlMessage : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/DrillControlMessage\",\"data\":{\"direction\":false,\"speed\":0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public bool direction{get; set; }= false;
  [Export] public int speed{get; set; }= 0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["direction"] = direction;
    returnValue["data"]["speed"] = speed;
    return  returnValue;
  }
  public override DrillControlMessage loadJson(JObject json) {
    direction = (bool)json["data"]["direction"];
    speed = (int)json["data"]["speed"];
    return  this;
  }
  public static explicit operator DrillControlMessage(JObject json){
    return new DrillControlMessage().loadJson(json);
  }
  DrillControlMessage() {}
}
