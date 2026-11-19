using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class TwistWithCovariance : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/TwistWithCovariance\",\"data\":{\"twist\":{\"linear\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}},\"covariance\":[]}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("twist")]
  [ExportSubgroup("linear")]
  [Export] public double twist_linear_x{get; set; }= 0.0;
  [Export] public double twist_linear_y{get; set; }= 0.0;
  [Export] public double twist_linear_z{get; set; }= 0.0;
  [ExportSubgroup("angular")]
  [Export] public double twist_angular_x{get; set; }= 0.0;
  [Export] public double twist_angular_y{get; set; }= 0.0;
  [Export] public double twist_angular_z{get; set; }= 0.0;
  [Export] public string covariance{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["twist"]["linear"]["x"] = twist_linear_x;
    returnValue["data"]["twist"]["linear"]["y"] = twist_linear_y;
    returnValue["data"]["twist"]["linear"]["z"] = twist_linear_z;
    returnValue["data"]["twist"]["angular"]["x"] = twist_angular_x;
    returnValue["data"]["twist"]["angular"]["y"] = twist_angular_y;
    returnValue["data"]["twist"]["angular"]["z"] = twist_angular_z;
    returnValue["data"]["covariance"] = covariance;
    return  returnValue;
  }
  public override TwistWithCovariance loadJson(JObject json) {
    twist_linear_x = (double)json["data"]["twist"]["linear"]["x"];
    twist_linear_y = (double)json["data"]["twist"]["linear"]["y"];
    twist_linear_z = (double)json["data"]["twist"]["linear"]["z"];
    twist_angular_x = (double)json["data"]["twist"]["angular"]["x"];
    twist_angular_y = (double)json["data"]["twist"]["angular"]["y"];
    twist_angular_z = (double)json["data"]["twist"]["angular"]["z"];
    covariance = (string)json["data"]["covariance"];
    return  this;
  }
  public static explicit operator TwistWithCovariance(JObject json){
    return new TwistWithCovariance().loadJson(json);
  }
  TwistWithCovariance() {}
}
