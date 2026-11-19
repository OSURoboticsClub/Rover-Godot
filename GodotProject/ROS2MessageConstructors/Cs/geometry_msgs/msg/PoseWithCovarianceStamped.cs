using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class PoseWithCovarianceStamped : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/PoseWithCovarianceStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"pose\":{\"pose\":{\"position\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"orientation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0}},\"covariance\":[]}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [ExportGroup("pose")]
  [ExportSubgroup("pose")]
  [Export] public double pose_pose_position_x{get; set; }= 0.0;
  [Export] public double pose_pose_position_y{get; set; }= 0.0;
  [Export] public double pose_pose_position_z{get; set; }= 0.0;
  [Export] public double pose_pose_orientation_x{get; set; }= 0.0;
  [Export] public double pose_pose_orientation_y{get; set; }= 0.0;
  [Export] public double pose_pose_orientation_z{get; set; }= 0.0;
  [Export] public double pose_pose_orientation_w{get; set; }= 0.0;
  [Export] public string pose_covariance{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["pose"]["pose"]["position"]["x"] = pose_pose_position_x;
    returnValue["data"]["pose"]["pose"]["position"]["y"] = pose_pose_position_y;
    returnValue["data"]["pose"]["pose"]["position"]["z"] = pose_pose_position_z;
    returnValue["data"]["pose"]["pose"]["orientation"]["x"] = pose_pose_orientation_x;
    returnValue["data"]["pose"]["pose"]["orientation"]["y"] = pose_pose_orientation_y;
    returnValue["data"]["pose"]["pose"]["orientation"]["z"] = pose_pose_orientation_z;
    returnValue["data"]["pose"]["pose"]["orientation"]["w"] = pose_pose_orientation_w;
    returnValue["data"]["pose"]["covariance"] = pose_covariance;
    return  returnValue;
  }
  public override PoseWithCovarianceStamped loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    pose_pose_position_x = (double)json["data"]["pose"]["pose"]["position"]["x"];
    pose_pose_position_y = (double)json["data"]["pose"]["pose"]["position"]["y"];
    pose_pose_position_z = (double)json["data"]["pose"]["pose"]["position"]["z"];
    pose_pose_orientation_x = (double)json["data"]["pose"]["pose"]["orientation"]["x"];
    pose_pose_orientation_y = (double)json["data"]["pose"]["pose"]["orientation"]["y"];
    pose_pose_orientation_z = (double)json["data"]["pose"]["pose"]["orientation"]["z"];
    pose_pose_orientation_w = (double)json["data"]["pose"]["pose"]["orientation"]["w"];
    pose_covariance = (string)json["data"]["pose"]["covariance"];
    return  this;
  }
  public static explicit operator PoseWithCovarianceStamped(JObject json){
    return new PoseWithCovarianceStamped().loadJson(json);
  }
  PoseWithCovarianceStamped() {}
}
