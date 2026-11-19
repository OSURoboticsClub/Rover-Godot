using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class AccelWithCovarianceStamped : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/AccelWithCovarianceStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"accel\":{\"accel\":{\"linear\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}},\"covariance\":[]}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [ExportGroup("accel")]
  [ExportSubgroup("accel")]
  [Export] public double accel_accel_linear_x{get; set; }= 0.0;
  [Export] public double accel_accel_linear_y{get; set; }= 0.0;
  [Export] public double accel_accel_linear_z{get; set; }= 0.0;
  [Export] public double accel_accel_angular_x{get; set; }= 0.0;
  [Export] public double accel_accel_angular_y{get; set; }= 0.0;
  [Export] public double accel_accel_angular_z{get; set; }= 0.0;
  [Export] public string accel_covariance{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["accel"]["accel"]["linear"]["x"] = accel_accel_linear_x;
    returnValue["data"]["accel"]["accel"]["linear"]["y"] = accel_accel_linear_y;
    returnValue["data"]["accel"]["accel"]["linear"]["z"] = accel_accel_linear_z;
    returnValue["data"]["accel"]["accel"]["angular"]["x"] = accel_accel_angular_x;
    returnValue["data"]["accel"]["accel"]["angular"]["y"] = accel_accel_angular_y;
    returnValue["data"]["accel"]["accel"]["angular"]["z"] = accel_accel_angular_z;
    returnValue["data"]["accel"]["covariance"] = accel_covariance;
    return  returnValue;
  }
  public override AccelWithCovarianceStamped loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    accel_accel_linear_x = (double)json["data"]["accel"]["accel"]["linear"]["x"];
    accel_accel_linear_y = (double)json["data"]["accel"]["accel"]["linear"]["y"];
    accel_accel_linear_z = (double)json["data"]["accel"]["accel"]["linear"]["z"];
    accel_accel_angular_x = (double)json["data"]["accel"]["accel"]["angular"]["x"];
    accel_accel_angular_y = (double)json["data"]["accel"]["accel"]["angular"]["y"];
    accel_accel_angular_z = (double)json["data"]["accel"]["accel"]["angular"]["z"];
    accel_covariance = (string)json["data"]["accel"]["covariance"];
    return  this;
  }
  public static explicit operator AccelWithCovarianceStamped(JObject json){
    return new AccelWithCovarianceStamped().loadJson(json);
  }
  AccelWithCovarianceStamped() {}
}
