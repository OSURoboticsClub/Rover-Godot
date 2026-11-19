using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class VelocityStamped : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/VelocityStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"body_frame_id\":\"\",\"reference_frame_id\":\"\",\"velocity\":{\"linear\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [Export] public string body_frame_id{get; set; }= "";
  [Export] public string reference_frame_id{get; set; }= "";
  [ExportGroup("velocity")]
  [ExportSubgroup("linear")]
  [Export] public double velocity_linear_x{get; set; }= 0.0;
  [Export] public double velocity_linear_y{get; set; }= 0.0;
  [Export] public double velocity_linear_z{get; set; }= 0.0;
  [ExportSubgroup("angular")]
  [Export] public double velocity_angular_x{get; set; }= 0.0;
  [Export] public double velocity_angular_y{get; set; }= 0.0;
  [Export] public double velocity_angular_z{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["body_frame_id"] = body_frame_id;
    returnValue["data"]["reference_frame_id"] = reference_frame_id;
    returnValue["data"]["velocity"]["linear"]["x"] = velocity_linear_x;
    returnValue["data"]["velocity"]["linear"]["y"] = velocity_linear_y;
    returnValue["data"]["velocity"]["linear"]["z"] = velocity_linear_z;
    returnValue["data"]["velocity"]["angular"]["x"] = velocity_angular_x;
    returnValue["data"]["velocity"]["angular"]["y"] = velocity_angular_y;
    returnValue["data"]["velocity"]["angular"]["z"] = velocity_angular_z;
    return  returnValue;
  }
  public override VelocityStamped loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    body_frame_id = (string)json["data"]["body_frame_id"];
    reference_frame_id = (string)json["data"]["reference_frame_id"];
    velocity_linear_x = (double)json["data"]["velocity"]["linear"]["x"];
    velocity_linear_y = (double)json["data"]["velocity"]["linear"]["y"];
    velocity_linear_z = (double)json["data"]["velocity"]["linear"]["z"];
    velocity_angular_x = (double)json["data"]["velocity"]["angular"]["x"];
    velocity_angular_y = (double)json["data"]["velocity"]["angular"]["y"];
    velocity_angular_z = (double)json["data"]["velocity"]["angular"]["z"];
    return  this;
  }
  public static explicit operator VelocityStamped(JObject json){
    return new VelocityStamped().loadJson(json);
  }
  VelocityStamped() {}
}
