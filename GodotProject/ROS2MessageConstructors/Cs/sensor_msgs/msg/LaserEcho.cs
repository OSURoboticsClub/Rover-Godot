using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.sensor_msgs.msg;

[Tool]
[GlobalClass]
public partial class LaserEcho : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/LaserEcho\",\"data\":{\"echoes\":[]}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public string echoes{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["echoes"] = echoes;
    return  returnValue;
  }
  public override LaserEcho loadJson(JObject json) {
    echoes = (string)json["data"]["echoes"];
    return  this;
  }
  public static explicit operator LaserEcho(JObject json){
    return new LaserEcho().loadJson(json);
  }
  LaserEcho() {}
}
