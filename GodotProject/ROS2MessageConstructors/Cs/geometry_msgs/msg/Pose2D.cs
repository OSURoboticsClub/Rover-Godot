using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class Pose2D : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Pose2D\",\"data\":{\"x\":0.0,\"y\":0.0,\"theta\":0.0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public double x{get; set; }= 0.0;
  [Export] public double y{get; set; }= 0.0;
  [Export] public double theta{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["x"] = x;
    returnValue["data"]["y"] = y;
    returnValue["data"]["theta"] = theta;
    return  returnValue;
  }
  public override Pose2D loadJson(JObject json) {
    x = (double)json["data"]["x"];
    y = (double)json["data"]["y"];
    theta = (double)json["data"]["theta"];
    return  this;
  }
  public static explicit operator Pose2D(JObject json){
    return new Pose2D().loadJson(json);
  }
  Pose2D() {}
}
