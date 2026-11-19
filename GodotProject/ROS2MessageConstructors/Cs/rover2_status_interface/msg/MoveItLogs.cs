using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_status_interface.msg;

[Tool]
[GlobalClass]
public partial class MoveItLogs : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"rover2_status_interface/msg/MoveItLogs\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"name\":[],\"position\":[],\"velocity\":[],\"effort\":[],\"status\":0}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [Export] public string name{get; set; }= "";
  [Export] public string position{get; set; }= "";
  [Export] public string velocity{get; set; }= "";
  [Export] public string effort{get; set; }= "";
  [Export] public int status{get; set; }= 0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["name"] = name;
    returnValue["data"]["position"] = position;
    returnValue["data"]["velocity"] = velocity;
    returnValue["data"]["effort"] = effort;
    returnValue["data"]["status"] = status;
    return  returnValue;
  }
  public override MoveItLogs loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    name = (string)json["data"]["name"];
    position = (string)json["data"]["position"];
    velocity = (string)json["data"]["velocity"];
    effort = (string)json["data"]["effort"];
    status = (int)json["data"]["status"];
    return  this;
  }
  public static explicit operator MoveItLogs(JObject json){
    return new MoveItLogs().loadJson(json);
  }
  MoveItLogs() {}
}
