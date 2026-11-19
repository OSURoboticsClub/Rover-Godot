using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.sensor_msgs.msg;

[Tool]
[GlobalClass]
public partial class TimeReference : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/TimeReference\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"time_ref\":{\"sec\":0,\"nanosec\":0},\"source\":\"\"}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [ExportGroup("time_ref")]
  [Export] public int time_ref_sec{get; set; }= 0;
  [Export] public int time_ref_nanosec{get; set; }= 0;
  [Export] public string source{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["time_ref"]["sec"] = time_ref_sec;
    returnValue["data"]["time_ref"]["nanosec"] = time_ref_nanosec;
    returnValue["data"]["source"] = source;
    return  returnValue;
  }
  public override TimeReference loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    time_ref_sec = (int)json["data"]["time_ref"]["sec"];
    time_ref_nanosec = (int)json["data"]["time_ref"]["nanosec"];
    source = (string)json["data"]["source"];
    return  this;
  }
  public static explicit operator TimeReference(JObject json){
    return new TimeReference().loadJson(json);
  }
  TimeReference() {}
}
