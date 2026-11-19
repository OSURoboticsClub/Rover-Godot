using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class PoseStamped : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/PoseStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"pose\":{\"position\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"orientation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0}}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
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
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["pose"]["position"]["x"] = pose_position_x;
    returnValue["data"]["pose"]["position"]["y"] = pose_position_y;
    returnValue["data"]["pose"]["position"]["z"] = pose_position_z;
    returnValue["data"]["pose"]["orientation"]["x"] = pose_orientation_x;
    returnValue["data"]["pose"]["orientation"]["y"] = pose_orientation_y;
    returnValue["data"]["pose"]["orientation"]["z"] = pose_orientation_z;
    returnValue["data"]["pose"]["orientation"]["w"] = pose_orientation_w;
    return  returnValue;
  }
  public override PoseStamped loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    pose_position_x = (double)json["data"]["pose"]["position"]["x"];
    pose_position_y = (double)json["data"]["pose"]["position"]["y"];
    pose_position_z = (double)json["data"]["pose"]["position"]["z"];
    pose_orientation_x = (double)json["data"]["pose"]["orientation"]["x"];
    pose_orientation_y = (double)json["data"]["pose"]["orientation"]["y"];
    pose_orientation_z = (double)json["data"]["pose"]["orientation"]["z"];
    pose_orientation_w = (double)json["data"]["pose"]["orientation"]["w"];
    return  this;
  }
  public static explicit operator PoseStamped(JObject json){
    return new PoseStamped().loadJson(json);
  }
  PoseStamped() {}
}
