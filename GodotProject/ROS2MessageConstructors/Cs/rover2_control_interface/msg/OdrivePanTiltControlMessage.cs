using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_control_interface.msg;

[Tool]
[GlobalClass]
public partial class OdrivePanTiltControlMessage : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/OdrivePanTiltControlMessage\",\"data\":{\"go_home\":false,\"is_angle\":false,\"stabalize\":false,\"pitch\":0.0,\"yaw\":0.0,\"roll\":0.0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public bool go_home{get; set; }= false;
  [Export] public bool is_angle{get; set; }= false;
  [Export] public bool stabalize{get; set; }= false;
  [Export] public double pitch{get; set; }= 0.0;
  [Export] public double yaw{get; set; }= 0.0;
  [Export] public double roll{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["go_home"] = go_home;
    returnValue["data"]["is_angle"] = is_angle;
    returnValue["data"]["stabalize"] = stabalize;
    returnValue["data"]["pitch"] = pitch;
    returnValue["data"]["yaw"] = yaw;
    returnValue["data"]["roll"] = roll;
    return  returnValue;
  }
  public override OdrivePanTiltControlMessage loadJson(JObject json) {
    go_home = (bool)json["data"]["go_home"];
    is_angle = (bool)json["data"]["is_angle"];
    stabalize = (bool)json["data"]["stabalize"];
    pitch = (double)json["data"]["pitch"];
    yaw = (double)json["data"]["yaw"];
    roll = (double)json["data"]["roll"];
    return  this;
  }
  public static explicit operator OdrivePanTiltControlMessage(JObject json){
    return new OdrivePanTiltControlMessage().loadJson(json);
  }
  OdrivePanTiltControlMessage() {}
}
