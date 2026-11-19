using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class AccelStamped : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/AccelStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"accel\":{\"linear\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [ExportGroup("accel")]
  [ExportSubgroup("linear")]
  [Export] public double accel_linear_x{get; set; }= 0.0;
  [Export] public double accel_linear_y{get; set; }= 0.0;
  [Export] public double accel_linear_z{get; set; }= 0.0;
  [ExportSubgroup("angular")]
  [Export] public double accel_angular_x{get; set; }= 0.0;
  [Export] public double accel_angular_y{get; set; }= 0.0;
  [Export] public double accel_angular_z{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["accel"]["linear"]["x"] = accel_linear_x;
    returnValue["data"]["accel"]["linear"]["y"] = accel_linear_y;
    returnValue["data"]["accel"]["linear"]["z"] = accel_linear_z;
    returnValue["data"]["accel"]["angular"]["x"] = accel_angular_x;
    returnValue["data"]["accel"]["angular"]["y"] = accel_angular_y;
    returnValue["data"]["accel"]["angular"]["z"] = accel_angular_z;
    return  returnValue;
  }
  public override AccelStamped loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    accel_linear_x = (double)json["data"]["accel"]["linear"]["x"];
    accel_linear_y = (double)json["data"]["accel"]["linear"]["y"];
    accel_linear_z = (double)json["data"]["accel"]["linear"]["z"];
    accel_angular_x = (double)json["data"]["accel"]["angular"]["x"];
    accel_angular_y = (double)json["data"]["accel"]["angular"]["y"];
    accel_angular_z = (double)json["data"]["accel"]["angular"]["z"];
    return  this;
  }
  public static explicit operator AccelStamped(JObject json){
    return new AccelStamped().loadJson(json);
  }
  AccelStamped() {}
}
