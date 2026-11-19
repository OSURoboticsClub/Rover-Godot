using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class PoseArray : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/PoseArray\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"poses\":{\"position\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"orientation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0}}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [ExportGroup("poses")]
  [ExportSubgroup("position")]
  [Export] public double poses_position_x{get; set; }= 0.0;
  [Export] public double poses_position_y{get; set; }= 0.0;
  [Export] public double poses_position_z{get; set; }= 0.0;
  [ExportSubgroup("orientation")]
  [Export] public double poses_orientation_x{get; set; }= 0.0;
  [Export] public double poses_orientation_y{get; set; }= 0.0;
  [Export] public double poses_orientation_z{get; set; }= 0.0;
  [Export] public double poses_orientation_w{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["poses"]["position"]["x"] = poses_position_x;
    returnValue["data"]["poses"]["position"]["y"] = poses_position_y;
    returnValue["data"]["poses"]["position"]["z"] = poses_position_z;
    returnValue["data"]["poses"]["orientation"]["x"] = poses_orientation_x;
    returnValue["data"]["poses"]["orientation"]["y"] = poses_orientation_y;
    returnValue["data"]["poses"]["orientation"]["z"] = poses_orientation_z;
    returnValue["data"]["poses"]["orientation"]["w"] = poses_orientation_w;
    return  returnValue;
  }
  public override PoseArray loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    poses_position_x = (double)json["data"]["poses"]["position"]["x"];
    poses_position_y = (double)json["data"]["poses"]["position"]["y"];
    poses_position_z = (double)json["data"]["poses"]["position"]["z"];
    poses_orientation_x = (double)json["data"]["poses"]["orientation"]["x"];
    poses_orientation_y = (double)json["data"]["poses"]["orientation"]["y"];
    poses_orientation_z = (double)json["data"]["poses"]["orientation"]["z"];
    poses_orientation_w = (double)json["data"]["poses"]["orientation"]["w"];
    return  this;
  }
  public static explicit operator PoseArray(JObject json){
    return new PoseArray().loadJson(json);
  }
  PoseArray() {}
}
