using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class AccelWithCovariance : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/AccelWithCovariance\",\"data\":{\"accel\":{\"linear\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}},\"covariance\":[]}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("accel")]
  [ExportSubgroup("linear")]
  [Export] public double accel_linear_x{get; set; }= 0.0;
  [Export] public double accel_linear_y{get; set; }= 0.0;
  [Export] public double accel_linear_z{get; set; }= 0.0;
  [ExportSubgroup("angular")]
  [Export] public double accel_angular_x{get; set; }= 0.0;
  [Export] public double accel_angular_y{get; set; }= 0.0;
  [Export] public double accel_angular_z{get; set; }= 0.0;
  [Export] public string covariance{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["accel"]["linear"]["x"] = accel_linear_x;
    returnValue["data"]["accel"]["linear"]["y"] = accel_linear_y;
    returnValue["data"]["accel"]["linear"]["z"] = accel_linear_z;
    returnValue["data"]["accel"]["angular"]["x"] = accel_angular_x;
    returnValue["data"]["accel"]["angular"]["y"] = accel_angular_y;
    returnValue["data"]["accel"]["angular"]["z"] = accel_angular_z;
    returnValue["data"]["covariance"] = covariance;
    return  returnValue;
  }
  public override AccelWithCovariance loadJson(JObject json) {
    accel_linear_x = (double)json["data"]["accel"]["linear"]["x"];
    accel_linear_y = (double)json["data"]["accel"]["linear"]["y"];
    accel_linear_z = (double)json["data"]["accel"]["linear"]["z"];
    accel_angular_x = (double)json["data"]["accel"]["angular"]["x"];
    accel_angular_y = (double)json["data"]["accel"]["angular"]["y"];
    accel_angular_z = (double)json["data"]["accel"]["angular"]["z"];
    covariance = (string)json["data"]["covariance"];
    return  this;
  }
  public static explicit operator AccelWithCovariance(JObject json){
    return new AccelWithCovariance().loadJson(json);
  }
  AccelWithCovariance() {}
}
