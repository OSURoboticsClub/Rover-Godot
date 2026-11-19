using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class PointStamped : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/PointStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"point\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [ExportGroup("point")]
  [Export] public double point_x{get; set; }= 0.0;
  [Export] public double point_y{get; set; }= 0.0;
  [Export] public double point_z{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["point"]["x"] = point_x;
    returnValue["data"]["point"]["y"] = point_y;
    returnValue["data"]["point"]["z"] = point_z;
    return  returnValue;
  }
  public override PointStamped loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    point_x = (double)json["data"]["point"]["x"];
    point_y = (double)json["data"]["point"]["y"];
    point_z = (double)json["data"]["point"]["z"];
    return  this;
  }
  public static explicit operator PointStamped(JObject json){
    return new PointStamped().loadJson(json);
  }
  PointStamped() {}
}
