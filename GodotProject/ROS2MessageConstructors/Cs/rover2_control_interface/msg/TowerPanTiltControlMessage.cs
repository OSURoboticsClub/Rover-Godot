using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_control_interface.msg;

[Tool]
[GlobalClass]
public partial class TowerPanTiltControlMessage : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/TowerPanTiltControlMessage\",\"data\":{\"should_center\":false,\"relative_pan_adjustment\":0,\"relative_tilt_adjustment\":0,\"hitch_servo_positive\":false,\"hitch_servo_negative\":false}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public bool should_center{get; set; }= false;
  [Export] public int relative_pan_adjustment{get; set; }= 0;
  [Export] public int relative_tilt_adjustment{get; set; }= 0;
  [Export] public bool hitch_servo_positive{get; set; }= false;
  [Export] public bool hitch_servo_negative{get; set; }= false;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["should_center"] = should_center;
    returnValue["data"]["relative_pan_adjustment"] = relative_pan_adjustment;
    returnValue["data"]["relative_tilt_adjustment"] = relative_tilt_adjustment;
    returnValue["data"]["hitch_servo_positive"] = hitch_servo_positive;
    returnValue["data"]["hitch_servo_negative"] = hitch_servo_negative;
    return  returnValue;
  }
  public override TowerPanTiltControlMessage loadJson(JObject json) {
    should_center = (bool)json["data"]["should_center"];
    relative_pan_adjustment = (int)json["data"]["relative_pan_adjustment"];
    relative_tilt_adjustment = (int)json["data"]["relative_tilt_adjustment"];
    hitch_servo_positive = (bool)json["data"]["hitch_servo_positive"];
    hitch_servo_negative = (bool)json["data"]["hitch_servo_negative"];
    return  this;
  }
  public static explicit operator TowerPanTiltControlMessage(JObject json){
    return new TowerPanTiltControlMessage().loadJson(json);
  }
  TowerPanTiltControlMessage() {}
}
