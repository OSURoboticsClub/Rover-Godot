using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class Quaternion : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Quaternion\",\"data\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public double x{get; set; }= 0.0;
  [Export] public double y{get; set; }= 0.0;
  [Export] public double z{get; set; }= 0.0;
  [Export] public double w{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["x"] = x;
    returnValue["data"]["y"] = y;
    returnValue["data"]["z"] = z;
    returnValue["data"]["w"] = w;
    return  returnValue;
  }
  public override Quaternion loadJson(JObject json) {
    x = (double)json["data"]["x"];
    y = (double)json["data"]["y"];
    z = (double)json["data"]["z"];
    w = (double)json["data"]["w"];
    return  this;
  }
  public static explicit operator Quaternion(JObject json){
    return new Quaternion().loadJson(json);
  }
  Quaternion() {}
}
