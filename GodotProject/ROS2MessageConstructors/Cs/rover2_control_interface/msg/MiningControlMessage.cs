using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_control_interface.msg;

[Tool]
[GlobalClass]
public partial class MiningControlMessage : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/MiningControlMessage\",\"data\":{\"motor_set_position_positive\":0,\"motor_set_position_negative\":0,\"motor_set_position_absolute\":0,\"motor_go_home\":false,\"motor_stop\":false,\"linear_set_position_positive\":0,\"linear_set_position_negative\":0,\"linear_set_position_absolute\":0,\"linear_stop\":false,\"servo1_target\":0,\"servo2_target\":0,\"probe_take_reading\":false,\"overtravel\":false,\"compartment\":0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public int motor_set_position_positive{get; set; }= 0;
  [Export] public int motor_set_position_negative{get; set; }= 0;
  [Export] public int motor_set_position_absolute{get; set; }= 0;
  [Export] public bool motor_go_home{get; set; }= false;
  [Export] public bool motor_stop{get; set; }= false;
  [Export] public int linear_set_position_positive{get; set; }= 0;
  [Export] public int linear_set_position_negative{get; set; }= 0;
  [Export] public int linear_set_position_absolute{get; set; }= 0;
  [Export] public bool linear_stop{get; set; }= false;
  [Export] public int servo1_target{get; set; }= 0;
  [Export] public int servo2_target{get; set; }= 0;
  [Export] public bool probe_take_reading{get; set; }= false;
  [Export] public bool overtravel{get; set; }= false;
  [Export] public int compartment{get; set; }= 0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["motor_set_position_positive"] = motor_set_position_positive;
    returnValue["data"]["motor_set_position_negative"] = motor_set_position_negative;
    returnValue["data"]["motor_set_position_absolute"] = motor_set_position_absolute;
    returnValue["data"]["motor_go_home"] = motor_go_home;
    returnValue["data"]["motor_stop"] = motor_stop;
    returnValue["data"]["linear_set_position_positive"] = linear_set_position_positive;
    returnValue["data"]["linear_set_position_negative"] = linear_set_position_negative;
    returnValue["data"]["linear_set_position_absolute"] = linear_set_position_absolute;
    returnValue["data"]["linear_stop"] = linear_stop;
    returnValue["data"]["servo1_target"] = servo1_target;
    returnValue["data"]["servo2_target"] = servo2_target;
    returnValue["data"]["probe_take_reading"] = probe_take_reading;
    returnValue["data"]["overtravel"] = overtravel;
    returnValue["data"]["compartment"] = compartment;
    return  returnValue;
  }
  public override MiningControlMessage loadJson(JObject json) {
    motor_set_position_positive = (int)json["data"]["motor_set_position_positive"];
    motor_set_position_negative = (int)json["data"]["motor_set_position_negative"];
    motor_set_position_absolute = (int)json["data"]["motor_set_position_absolute"];
    motor_go_home = (bool)json["data"]["motor_go_home"];
    motor_stop = (bool)json["data"]["motor_stop"];
    linear_set_position_positive = (int)json["data"]["linear_set_position_positive"];
    linear_set_position_negative = (int)json["data"]["linear_set_position_negative"];
    linear_set_position_absolute = (int)json["data"]["linear_set_position_absolute"];
    linear_stop = (bool)json["data"]["linear_stop"];
    servo1_target = (int)json["data"]["servo1_target"];
    servo2_target = (int)json["data"]["servo2_target"];
    probe_take_reading = (bool)json["data"]["probe_take_reading"];
    overtravel = (bool)json["data"]["overtravel"];
    compartment = (int)json["data"]["compartment"];
    return  this;
  }
  public static explicit operator MiningControlMessage(JObject json){
    return new MiningControlMessage().loadJson(json);
  }
  MiningControlMessage() {}
}
