using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class PolygonStamped : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/PolygonStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"polygon\":{\"points\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [ExportGroup("polygon")]
  [ExportSubgroup("points")]
  [Export] public double polygon_points_x{get; set; }= 0.0;
  [Export] public double polygon_points_y{get; set; }= 0.0;
  [Export] public double polygon_points_z{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["polygon"]["points"]["x"] = polygon_points_x;
    returnValue["data"]["polygon"]["points"]["y"] = polygon_points_y;
    returnValue["data"]["polygon"]["points"]["z"] = polygon_points_z;
    return  returnValue;
  }
  public override PolygonStamped loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    polygon_points_x = (double)json["data"]["polygon"]["points"]["x"];
    polygon_points_y = (double)json["data"]["polygon"]["points"]["y"];
    polygon_points_z = (double)json["data"]["polygon"]["points"]["z"];
    return  this;
  }
  public static explicit operator PolygonStamped(JObject json){
    return new PolygonStamped().loadJson(json);
  }
  PolygonStamped() {}
}
