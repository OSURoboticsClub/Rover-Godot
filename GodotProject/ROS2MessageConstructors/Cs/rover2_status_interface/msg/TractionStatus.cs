using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_status_interface.msg;

[Tool]
[GlobalClass]
public partial class TractionStatus : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"rover2_status_interface/msg/TractionStatus\",\"data\":{\"timestamp\":{\"sec\":0,\"nanosec\":0},\"id\":[],\"names\":[],\"slipstate\":[]}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("timestamp")]
  [Export] public int timestamp_sec{get; set; }= 0;
  [Export] public int timestamp_nanosec{get; set; }= 0;
  [Export] public string id{get; set; }= "";
  [Export] public string names{get; set; }= "";
  [Export] public string slipstate{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["timestamp"]["sec"] = timestamp_sec;
    returnValue["data"]["timestamp"]["nanosec"] = timestamp_nanosec;
    returnValue["data"]["id"] = id;
    returnValue["data"]["names"] = names;
    returnValue["data"]["slipstate"] = slipstate;
    return  returnValue;
  }
  public override TractionStatus loadJson(JObject json) {
    timestamp_sec = (int)json["data"]["timestamp"]["sec"];
    timestamp_nanosec = (int)json["data"]["timestamp"]["nanosec"];
    id = (string)json["data"]["id"];
    names = (string)json["data"]["names"];
    slipstate = (string)json["data"]["slipstate"];
    return  this;
  }
  public static explicit operator TractionStatus(JObject json){
    return new TractionStatus().loadJson(json);
  }
  TractionStatus() {}
}
