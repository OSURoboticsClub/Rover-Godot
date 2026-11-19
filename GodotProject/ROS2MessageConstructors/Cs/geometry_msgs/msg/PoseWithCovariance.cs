using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class PoseWithCovariance : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/PoseWithCovariance\",\"data\":{\"pose\":{\"position\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"orientation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0}},\"covariance\":[]}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("pose")]
  [ExportSubgroup("position")]
  [Export] public double pose_position_x{get; set; }= 0.0;
  [Export] public double pose_position_y{get; set; }= 0.0;
  [Export] public double pose_position_z{get; set; }= 0.0;
  [ExportSubgroup("orientation")]
  [Export] public double pose_orientation_x{get; set; }= 0.0;
  [Export] public double pose_orientation_y{get; set; }= 0.0;
  [Export] public double pose_orientation_z{get; set; }= 0.0;
  [Export] public double pose_orientation_w{get; set; }= 0.0;
  [Export] public string covariance{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["pose"]["position"]["x"] = pose_position_x;
    returnValue["data"]["pose"]["position"]["y"] = pose_position_y;
    returnValue["data"]["pose"]["position"]["z"] = pose_position_z;
    returnValue["data"]["pose"]["orientation"]["x"] = pose_orientation_x;
    returnValue["data"]["pose"]["orientation"]["y"] = pose_orientation_y;
    returnValue["data"]["pose"]["orientation"]["z"] = pose_orientation_z;
    returnValue["data"]["pose"]["orientation"]["w"] = pose_orientation_w;
    returnValue["data"]["covariance"] = covariance;
    return  returnValue;
  }
  public override PoseWithCovariance loadJson(JObject json) {
    pose_position_x = (double)json["data"]["pose"]["position"]["x"];
    pose_position_y = (double)json["data"]["pose"]["position"]["y"];
    pose_position_z = (double)json["data"]["pose"]["position"]["z"];
    pose_orientation_x = (double)json["data"]["pose"]["orientation"]["x"];
    pose_orientation_y = (double)json["data"]["pose"]["orientation"]["y"];
    pose_orientation_z = (double)json["data"]["pose"]["orientation"]["z"];
    pose_orientation_w = (double)json["data"]["pose"]["orientation"]["w"];
    covariance = (string)json["data"]["covariance"];
    return  this;
  }
  public static explicit operator PoseWithCovariance(JObject json){
    return new PoseWithCovariance().loadJson(json);
  }
  PoseWithCovariance() {}
}
