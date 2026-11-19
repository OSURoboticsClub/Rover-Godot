using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_control_interface.msg;

[Tool]
[GlobalClass]
public partial class DriveControlMessage : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/DriveControlMessage\",\"data\":{\"first_motor_direction\":false,\"first_motor_sleep\":false,\"first_motor_speed\":0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public bool first_motor_direction{get; set; }= false;
  [Export] public bool first_motor_sleep{get; set; }= false;
  [Export] public int first_motor_speed{get; set; }= 0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["first_motor_direction"] = first_motor_direction;
    returnValue["data"]["first_motor_sleep"] = first_motor_sleep;
    returnValue["data"]["first_motor_speed"] = first_motor_speed;
    return  returnValue;
  }
  public override DriveControlMessage loadJson(JObject json) {
    first_motor_direction = (bool)json["data"]["first_motor_direction"];
    first_motor_sleep = (bool)json["data"]["first_motor_sleep"];
    first_motor_speed = (int)json["data"]["first_motor_speed"];
    return  this;
  }
  public static explicit operator DriveControlMessage(JObject json){
    return new DriveControlMessage().loadJson(json);
  }
  DriveControlMessage() {}
}
