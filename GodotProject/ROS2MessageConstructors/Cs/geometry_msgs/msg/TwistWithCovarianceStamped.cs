using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class TwistWithCovarianceStamped : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/TwistWithCovarianceStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"twist\":{\"twist\":{\"linear\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}},\"covariance\":[]}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [ExportGroup("twist")]
  [ExportSubgroup("twist")]
  [Export] public double twist_twist_linear_x{get; set; }= 0.0;
  [Export] public double twist_twist_linear_y{get; set; }= 0.0;
  [Export] public double twist_twist_linear_z{get; set; }= 0.0;
  [Export] public double twist_twist_angular_x{get; set; }= 0.0;
  [Export] public double twist_twist_angular_y{get; set; }= 0.0;
  [Export] public double twist_twist_angular_z{get; set; }= 0.0;
  [Export] public string twist_covariance{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["twist"]["twist"]["linear"]["x"] = twist_twist_linear_x;
    returnValue["data"]["twist"]["twist"]["linear"]["y"] = twist_twist_linear_y;
    returnValue["data"]["twist"]["twist"]["linear"]["z"] = twist_twist_linear_z;
    returnValue["data"]["twist"]["twist"]["angular"]["x"] = twist_twist_angular_x;
    returnValue["data"]["twist"]["twist"]["angular"]["y"] = twist_twist_angular_y;
    returnValue["data"]["twist"]["twist"]["angular"]["z"] = twist_twist_angular_z;
    returnValue["data"]["twist"]["covariance"] = twist_covariance;
    return  returnValue;
  }
  public override TwistWithCovarianceStamped loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    twist_twist_linear_x = (double)json["data"]["twist"]["twist"]["linear"]["x"];
    twist_twist_linear_y = (double)json["data"]["twist"]["twist"]["linear"]["y"];
    twist_twist_linear_z = (double)json["data"]["twist"]["twist"]["linear"]["z"];
    twist_twist_angular_x = (double)json["data"]["twist"]["twist"]["angular"]["x"];
    twist_twist_angular_y = (double)json["data"]["twist"]["twist"]["angular"]["y"];
    twist_twist_angular_z = (double)json["data"]["twist"]["twist"]["angular"]["z"];
    twist_covariance = (string)json["data"]["twist"]["covariance"];
    return  this;
  }
  public static explicit operator TwistWithCovarianceStamped(JObject json){
    return new TwistWithCovarianceStamped().loadJson(json);
  }
  TwistWithCovarianceStamped() {}
}
