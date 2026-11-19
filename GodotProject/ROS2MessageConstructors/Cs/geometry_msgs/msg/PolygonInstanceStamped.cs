using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class PolygonInstanceStamped : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/PolygonInstanceStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"polygon\":{\"polygon\":{\"points\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}},\"id\":0}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [ExportGroup("polygon")]
  [ExportSubgroup("polygon")]
  [Export] public double polygon_polygon_points_x{get; set; }= 0.0;
  [Export] public double polygon_polygon_points_y{get; set; }= 0.0;
  [Export] public double polygon_polygon_points_z{get; set; }= 0.0;
  [Export] public int polygon_id{get; set; }= 0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["polygon"]["polygon"]["points"]["x"] = polygon_polygon_points_x;
    returnValue["data"]["polygon"]["polygon"]["points"]["y"] = polygon_polygon_points_y;
    returnValue["data"]["polygon"]["polygon"]["points"]["z"] = polygon_polygon_points_z;
    returnValue["data"]["polygon"]["id"] = polygon_id;
    return  returnValue;
  }
  public override PolygonInstanceStamped loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    polygon_polygon_points_x = (double)json["data"]["polygon"]["polygon"]["points"]["x"];
    polygon_polygon_points_y = (double)json["data"]["polygon"]["polygon"]["points"]["y"];
    polygon_polygon_points_z = (double)json["data"]["polygon"]["polygon"]["points"]["z"];
    polygon_id = (int)json["data"]["polygon"]["id"];
    return  this;
  }
  public static explicit operator PolygonInstanceStamped(JObject json){
    return new PolygonInstanceStamped().loadJson(json);
  }
  PolygonInstanceStamped() {}
}
