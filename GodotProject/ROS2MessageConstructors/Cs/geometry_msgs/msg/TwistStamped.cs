using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class TwistStamped : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/TwistStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"twist\":{\"linear\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [ExportGroup("twist")]
  [ExportSubgroup("linear")]
  [Export] public double twist_linear_x{get; set; }= 0.0;
  [Export] public double twist_linear_y{get; set; }= 0.0;
  [Export] public double twist_linear_z{get; set; }= 0.0;
  [ExportSubgroup("angular")]
  [Export] public double twist_angular_x{get; set; }= 0.0;
  [Export] public double twist_angular_y{get; set; }= 0.0;
  [Export] public double twist_angular_z{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["twist"]["linear"]["x"] = twist_linear_x;
    returnValue["data"]["twist"]["linear"]["y"] = twist_linear_y;
    returnValue["data"]["twist"]["linear"]["z"] = twist_linear_z;
    returnValue["data"]["twist"]["angular"]["x"] = twist_angular_x;
    returnValue["data"]["twist"]["angular"]["y"] = twist_angular_y;
    returnValue["data"]["twist"]["angular"]["z"] = twist_angular_z;
    return  returnValue;
  }
  public override TwistStamped loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    twist_linear_x = (double)json["data"]["twist"]["linear"]["x"];
    twist_linear_y = (double)json["data"]["twist"]["linear"]["y"];
    twist_linear_z = (double)json["data"]["twist"]["linear"]["z"];
    twist_angular_x = (double)json["data"]["twist"]["angular"]["x"];
    twist_angular_y = (double)json["data"]["twist"]["angular"]["y"];
    twist_angular_z = (double)json["data"]["twist"]["angular"]["z"];
    return  this;
  }
  public static explicit operator TwistStamped(JObject json){
    return new TwistStamped().loadJson(json);
  }
  TwistStamped() {}
}
