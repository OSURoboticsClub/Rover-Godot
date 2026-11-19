using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_status_interface.msg;

[Tool]
[GlobalClass]
public partial class ODriveStatus : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"rover2_status_interface/msg/ODriveStatus\",\"data\":{\"timestamp\":{\"sec\":0,\"nanosec\":0},\"bus\":\"\",\"id\":[],\"disarm_reason\":[],\"t_fet\":[],\"t_motor\":[],\"velocity\":[],\"position\":[],\"iq_set\":[],\"iq_measured\":[],\"bus_voltage\":[],\"bus_current\":[]}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("timestamp")]
  [Export] public int timestamp_sec{get; set; }= 0;
  [Export] public int timestamp_nanosec{get; set; }= 0;
  [Export] public string bus{get; set; }= "";
  [Export] public string id{get; set; }= "";
  [Export] public string disarm_reason{get; set; }= "";
  [Export] public string t_fet{get; set; }= "";
  [Export] public string t_motor{get; set; }= "";
  [Export] public string velocity{get; set; }= "";
  [Export] public string position{get; set; }= "";
  [Export] public string iq_set{get; set; }= "";
  [Export] public string iq_measured{get; set; }= "";
  [Export] public string bus_voltage{get; set; }= "";
  [Export] public string bus_current{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["timestamp"]["sec"] = timestamp_sec;
    returnValue["data"]["timestamp"]["nanosec"] = timestamp_nanosec;
    returnValue["data"]["bus"] = bus;
    returnValue["data"]["id"] = id;
    returnValue["data"]["disarm_reason"] = disarm_reason;
    returnValue["data"]["t_fet"] = t_fet;
    returnValue["data"]["t_motor"] = t_motor;
    returnValue["data"]["velocity"] = velocity;
    returnValue["data"]["position"] = position;
    returnValue["data"]["iq_set"] = iq_set;
    returnValue["data"]["iq_measured"] = iq_measured;
    returnValue["data"]["bus_voltage"] = bus_voltage;
    returnValue["data"]["bus_current"] = bus_current;
    return  returnValue;
  }
  public override ODriveStatus loadJson(JObject json) {
    timestamp_sec = (int)json["data"]["timestamp"]["sec"];
    timestamp_nanosec = (int)json["data"]["timestamp"]["nanosec"];
    bus = (string)json["data"]["bus"];
    id = (string)json["data"]["id"];
    disarm_reason = (string)json["data"]["disarm_reason"];
    t_fet = (string)json["data"]["t_fet"];
    t_motor = (string)json["data"]["t_motor"];
    velocity = (string)json["data"]["velocity"];
    position = (string)json["data"]["position"];
    iq_set = (string)json["data"]["iq_set"];
    iq_measured = (string)json["data"]["iq_measured"];
    bus_voltage = (string)json["data"]["bus_voltage"];
    bus_current = (string)json["data"]["bus_current"];
    return  this;
  }
  public static explicit operator ODriveStatus(JObject json){
    return new ODriveStatus().loadJson(json);
  }
  ODriveStatus() {}
}
