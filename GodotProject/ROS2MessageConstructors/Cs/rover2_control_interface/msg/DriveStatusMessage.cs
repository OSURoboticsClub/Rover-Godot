using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_control_interface.msg;

[Tool]
[GlobalClass]
public partial class DriveStatusMessage : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/DriveStatusMessage\",\"data\":{\"first_motor_connected\":false,\"second_motor_connected\":false,\"third_motor_connected\":false,\"first_motor_current\":0.0,\"second_motor_current\":0.0,\"third_motor_current\":0.0,\"first_motor_fault\":false,\"second_motor_fault\":false,\"third_motor_fault\":false,\"first_motor_temp\":0.0,\"second_motor_temp\":0.0,\"third_motor_temp\":0.0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public bool first_motor_connected{get; set; }= false;
  [Export] public bool second_motor_connected{get; set; }= false;
  [Export] public bool third_motor_connected{get; set; }= false;
  [Export] public double first_motor_current{get; set; }= 0.0;
  [Export] public double second_motor_current{get; set; }= 0.0;
  [Export] public double third_motor_current{get; set; }= 0.0;
  [Export] public bool first_motor_fault{get; set; }= false;
  [Export] public bool second_motor_fault{get; set; }= false;
  [Export] public bool third_motor_fault{get; set; }= false;
  [Export] public double first_motor_temp{get; set; }= 0.0;
  [Export] public double second_motor_temp{get; set; }= 0.0;
  [Export] public double third_motor_temp{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["first_motor_connected"] = first_motor_connected;
    returnValue["data"]["second_motor_connected"] = second_motor_connected;
    returnValue["data"]["third_motor_connected"] = third_motor_connected;
    returnValue["data"]["first_motor_current"] = first_motor_current;
    returnValue["data"]["second_motor_current"] = second_motor_current;
    returnValue["data"]["third_motor_current"] = third_motor_current;
    returnValue["data"]["first_motor_fault"] = first_motor_fault;
    returnValue["data"]["second_motor_fault"] = second_motor_fault;
    returnValue["data"]["third_motor_fault"] = third_motor_fault;
    returnValue["data"]["first_motor_temp"] = first_motor_temp;
    returnValue["data"]["second_motor_temp"] = second_motor_temp;
    returnValue["data"]["third_motor_temp"] = third_motor_temp;
    return  returnValue;
  }
  public override DriveStatusMessage loadJson(JObject json) {
    first_motor_connected = (bool)json["data"]["first_motor_connected"];
    second_motor_connected = (bool)json["data"]["second_motor_connected"];
    third_motor_connected = (bool)json["data"]["third_motor_connected"];
    first_motor_current = (double)json["data"]["first_motor_current"];
    second_motor_current = (double)json["data"]["second_motor_current"];
    third_motor_current = (double)json["data"]["third_motor_current"];
    first_motor_fault = (bool)json["data"]["first_motor_fault"];
    second_motor_fault = (bool)json["data"]["second_motor_fault"];
    third_motor_fault = (bool)json["data"]["third_motor_fault"];
    first_motor_temp = (double)json["data"]["first_motor_temp"];
    second_motor_temp = (double)json["data"]["second_motor_temp"];
    third_motor_temp = (double)json["data"]["third_motor_temp"];
    return  this;
  }
  public static explicit operator DriveStatusMessage(JObject json){
    return new DriveStatusMessage().loadJson(json);
  }
  DriveStatusMessage() {}
}
