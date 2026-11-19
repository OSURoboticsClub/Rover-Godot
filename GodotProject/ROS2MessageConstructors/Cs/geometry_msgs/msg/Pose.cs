using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class Pose : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Pose\",\"data\":{\"position\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"orientation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("position")]
  [Export] public double position_x{get; set; }= 0.0;
  [Export] public double position_y{get; set; }= 0.0;
  [Export] public double position_z{get; set; }= 0.0;
  [ExportGroup("orientation")]
  [Export] public double orientation_x{get; set; }= 0.0;
  [Export] public double orientation_y{get; set; }= 0.0;
  [Export] public double orientation_z{get; set; }= 0.0;
  [Export] public double orientation_w{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["position"]["x"] = position_x;
    returnValue["data"]["position"]["y"] = position_y;
    returnValue["data"]["position"]["z"] = position_z;
    returnValue["data"]["orientation"]["x"] = orientation_x;
    returnValue["data"]["orientation"]["y"] = orientation_y;
    returnValue["data"]["orientation"]["z"] = orientation_z;
    returnValue["data"]["orientation"]["w"] = orientation_w;
    return  returnValue;
  }
  public override Pose loadJson(JObject json) {
    position_x = (double)json["data"]["position"]["x"];
    position_y = (double)json["data"]["position"]["y"];
    position_z = (double)json["data"]["position"]["z"];
    orientation_x = (double)json["data"]["orientation"]["x"];
    orientation_y = (double)json["data"]["orientation"]["y"];
    orientation_z = (double)json["data"]["orientation"]["z"];
    orientation_w = (double)json["data"]["orientation"]["w"];
    return  this;
  }
  public static explicit operator Pose(JObject json){
    return new Pose().loadJson(json);
  }
  Pose() {}
}
