using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class Vector3Stamped : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Vector3Stamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"vector\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [ExportGroup("vector")]
  [Export] public double vector_x{get; set; }= 0.0;
  [Export] public double vector_y{get; set; }= 0.0;
  [Export] public double vector_z{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["vector"]["x"] = vector_x;
    returnValue["data"]["vector"]["y"] = vector_y;
    returnValue["data"]["vector"]["z"] = vector_z;
    return  returnValue;
  }
  public override Vector3Stamped loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    vector_x = (double)json["data"]["vector"]["x"];
    vector_y = (double)json["data"]["vector"]["y"];
    vector_z = (double)json["data"]["vector"]["z"];
    return  this;
  }
  public static explicit operator Vector3Stamped(JObject json){
    return new Vector3Stamped().loadJson(json);
  }
  Vector3Stamped() {}
}
