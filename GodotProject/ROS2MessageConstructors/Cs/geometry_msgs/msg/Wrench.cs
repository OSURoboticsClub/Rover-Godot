using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class Wrench : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Wrench\",\"data\":{\"force\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"torque\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("force")]
  [Export] public double force_x{get; set; }= 0.0;
  [Export] public double force_y{get; set; }= 0.0;
  [Export] public double force_z{get; set; }= 0.0;
  [ExportGroup("torque")]
  [Export] public double torque_x{get; set; }= 0.0;
  [Export] public double torque_y{get; set; }= 0.0;
  [Export] public double torque_z{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["force"]["x"] = force_x;
    returnValue["data"]["force"]["y"] = force_y;
    returnValue["data"]["force"]["z"] = force_z;
    returnValue["data"]["torque"]["x"] = torque_x;
    returnValue["data"]["torque"]["y"] = torque_y;
    returnValue["data"]["torque"]["z"] = torque_z;
    return  returnValue;
  }
  public override Wrench loadJson(JObject json) {
    force_x = (double)json["data"]["force"]["x"];
    force_y = (double)json["data"]["force"]["y"];
    force_z = (double)json["data"]["force"]["z"];
    torque_x = (double)json["data"]["torque"]["x"];
    torque_y = (double)json["data"]["torque"]["y"];
    torque_z = (double)json["data"]["torque"]["z"];
    return  this;
  }
  public static explicit operator Wrench(JObject json){
    return new Wrench().loadJson(json);
  }
  Wrench() {}
}
