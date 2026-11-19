using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.sensor_msgs.msg;

[Tool]
[GlobalClass]
public partial class PointCloud : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/PointCloud\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"points\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"channels\":{\"name\":\"\",\"values\":[]}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [ExportGroup("points")]
  [Export] public double points_x{get; set; }= 0.0;
  [Export] public double points_y{get; set; }= 0.0;
  [Export] public double points_z{get; set; }= 0.0;
  [ExportGroup("channels")]
  [Export] public string channels_name{get; set; }= "";
  [Export] public string channels_values{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["points"]["x"] = points_x;
    returnValue["data"]["points"]["y"] = points_y;
    returnValue["data"]["points"]["z"] = points_z;
    returnValue["data"]["channels"]["name"] = channels_name;
    returnValue["data"]["channels"]["values"] = channels_values;
    return  returnValue;
  }
  public override PointCloud loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    points_x = (double)json["data"]["points"]["x"];
    points_y = (double)json["data"]["points"]["y"];
    points_z = (double)json["data"]["points"]["z"];
    channels_name = (string)json["data"]["channels"]["name"];
    channels_values = (string)json["data"]["channels"]["values"];
    return  this;
  }
  public static explicit operator PointCloud(JObject json){
    return new PointCloud().loadJson(json);
  }
  PointCloud() {}
}
