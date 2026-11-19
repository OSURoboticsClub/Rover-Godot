using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_status_interface.msg;

[Tool]
[GlobalClass]
public partial class FilteredLog : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"rover2_status_interface/msg/FilteredLog\",\"data\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"name\":\"\",\"level\":0,\"msg\":\"\"}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("stamp")]
  [Export] public int stamp_sec{get; set; }= 0;
  [Export] public int stamp_nanosec{get; set; }= 0;
  [Export] public string name{get; set; }= "";
  [Export] public int level{get; set; }= 0;
  [Export] public string msg{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["stamp"]["sec"] = stamp_sec;
    returnValue["data"]["stamp"]["nanosec"] = stamp_nanosec;
    returnValue["data"]["name"] = name;
    returnValue["data"]["level"] = level;
    returnValue["data"]["msg"] = msg;
    return  returnValue;
  }
  public override FilteredLog loadJson(JObject json) {
    stamp_sec = (int)json["data"]["stamp"]["sec"];
    stamp_nanosec = (int)json["data"]["stamp"]["nanosec"];
    name = (string)json["data"]["name"];
    level = (int)json["data"]["level"];
    msg = (string)json["data"]["msg"];
    return  this;
  }
  public static explicit operator FilteredLog(JObject json){
    return new FilteredLog().loadJson(json);
  }
  FilteredLog() {}
}
