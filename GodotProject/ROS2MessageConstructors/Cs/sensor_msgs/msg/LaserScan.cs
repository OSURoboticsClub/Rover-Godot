using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.sensor_msgs.msg;

[Tool]
[GlobalClass]
public partial class LaserScan : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/LaserScan\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"angle_min\":0.0,\"angle_max\":0.0,\"angle_increment\":0.0,\"time_increment\":0.0,\"scan_time\":0.0,\"range_min\":0.0,\"range_max\":0.0,\"ranges\":[],\"intensities\":[]}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [Export] public double angle_min{get; set; }= 0.0;
  [Export] public double angle_max{get; set; }= 0.0;
  [Export] public double angle_increment{get; set; }= 0.0;
  [Export] public double time_increment{get; set; }= 0.0;
  [Export] public double scan_time{get; set; }= 0.0;
  [Export] public double range_min{get; set; }= 0.0;
  [Export] public double range_max{get; set; }= 0.0;
  [Export] public string ranges{get; set; }= "";
  [Export] public string intensities{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["angle_min"] = angle_min;
    returnValue["data"]["angle_max"] = angle_max;
    returnValue["data"]["angle_increment"] = angle_increment;
    returnValue["data"]["time_increment"] = time_increment;
    returnValue["data"]["scan_time"] = scan_time;
    returnValue["data"]["range_min"] = range_min;
    returnValue["data"]["range_max"] = range_max;
    returnValue["data"]["ranges"] = ranges;
    returnValue["data"]["intensities"] = intensities;
    return  returnValue;
  }
  public override LaserScan loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    angle_min = (double)json["data"]["angle_min"];
    angle_max = (double)json["data"]["angle_max"];
    angle_increment = (double)json["data"]["angle_increment"];
    time_increment = (double)json["data"]["time_increment"];
    scan_time = (double)json["data"]["scan_time"];
    range_min = (double)json["data"]["range_min"];
    range_max = (double)json["data"]["range_max"];
    ranges = (string)json["data"]["ranges"];
    intensities = (string)json["data"]["intensities"];
    return  this;
  }
  public static explicit operator LaserScan(JObject json){
    return new LaserScan().loadJson(json);
  }
  LaserScan() {}
}
