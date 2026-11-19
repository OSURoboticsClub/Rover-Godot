using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class QuaternionStamped : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/QuaternionStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"quaternion\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [ExportGroup("quaternion")]
  [Export] public double quaternion_x{get; set; }= 0.0;
  [Export] public double quaternion_y{get; set; }= 0.0;
  [Export] public double quaternion_z{get; set; }= 0.0;
  [Export] public double quaternion_w{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["quaternion"]["x"] = quaternion_x;
    returnValue["data"]["quaternion"]["y"] = quaternion_y;
    returnValue["data"]["quaternion"]["z"] = quaternion_z;
    returnValue["data"]["quaternion"]["w"] = quaternion_w;
    return  returnValue;
  }
  public override QuaternionStamped loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    quaternion_x = (double)json["data"]["quaternion"]["x"];
    quaternion_y = (double)json["data"]["quaternion"]["y"];
    quaternion_z = (double)json["data"]["quaternion"]["z"];
    quaternion_w = (double)json["data"]["quaternion"]["w"];
    return  this;
  }
  public static explicit operator QuaternionStamped(JObject json){
    return new QuaternionStamped().loadJson(json);
  }
  QuaternionStamped() {}
}
