using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.sensor_msgs.msg;

[Tool]
[GlobalClass]
public partial class MagneticField : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/MagneticField\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"magnetic_field\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"magnetic_field_covariance\":[]}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [ExportGroup("magnetic_field")]
  [Export] public double magnetic_field_x{get; set; }= 0.0;
  [Export] public double magnetic_field_y{get; set; }= 0.0;
  [Export] public double magnetic_field_z{get; set; }= 0.0;
  [Export] public string magnetic_field_covariance{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["magnetic_field"]["x"] = magnetic_field_x;
    returnValue["data"]["magnetic_field"]["y"] = magnetic_field_y;
    returnValue["data"]["magnetic_field"]["z"] = magnetic_field_z;
    returnValue["data"]["magnetic_field_covariance"] = magnetic_field_covariance;
    return  returnValue;
  }
  public override MagneticField loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    magnetic_field_x = (double)json["data"]["magnetic_field"]["x"];
    magnetic_field_y = (double)json["data"]["magnetic_field"]["y"];
    magnetic_field_z = (double)json["data"]["magnetic_field"]["z"];
    magnetic_field_covariance = (string)json["data"]["magnetic_field_covariance"];
    return  this;
  }
  public static explicit operator MagneticField(JObject json){
    return new MagneticField().loadJson(json);
  }
  MagneticField() {}
}
