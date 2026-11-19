using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_control_interface.msg;

[Tool]
[GlobalClass]
public partial class MiningStatusMessage : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/MiningStatusMessage\",\"data\":{\"probe_temp_c\":0.0,\"probe_moisture\":0.0,\"probe_loss_tangent\":0.0,\"probe_soil_elec_cond\":0.0,\"probe_real_dielec_perm\":0.0,\"probe_imag_dielec_perm\":0.0,\"motor_current_position\":0,\"linear_current_position\":0,\"temp1\":0,\"temp2\":0,\"motor_current\":0.0,\"linear_current\":0.0,\"switch1_out\":false,\"switch2_out\":false,\"homing_needed\":false}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public double probe_temp_c{get; set; }= 0.0;
  [Export] public double probe_moisture{get; set; }= 0.0;
  [Export] public double probe_loss_tangent{get; set; }= 0.0;
  [Export] public double probe_soil_elec_cond{get; set; }= 0.0;
  [Export] public double probe_real_dielec_perm{get; set; }= 0.0;
  [Export] public double probe_imag_dielec_perm{get; set; }= 0.0;
  [Export] public int motor_current_position{get; set; }= 0;
  [Export] public int linear_current_position{get; set; }= 0;
  [Export] public int temp1{get; set; }= 0;
  [Export] public int temp2{get; set; }= 0;
  [Export] public double motor_current{get; set; }= 0.0;
  [Export] public double linear_current{get; set; }= 0.0;
  [Export] public bool switch1_out{get; set; }= false;
  [Export] public bool switch2_out{get; set; }= false;
  [Export] public bool homing_needed{get; set; }= false;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["probe_temp_c"] = probe_temp_c;
    returnValue["data"]["probe_moisture"] = probe_moisture;
    returnValue["data"]["probe_loss_tangent"] = probe_loss_tangent;
    returnValue["data"]["probe_soil_elec_cond"] = probe_soil_elec_cond;
    returnValue["data"]["probe_real_dielec_perm"] = probe_real_dielec_perm;
    returnValue["data"]["probe_imag_dielec_perm"] = probe_imag_dielec_perm;
    returnValue["data"]["motor_current_position"] = motor_current_position;
    returnValue["data"]["linear_current_position"] = linear_current_position;
    returnValue["data"]["temp1"] = temp1;
    returnValue["data"]["temp2"] = temp2;
    returnValue["data"]["motor_current"] = motor_current;
    returnValue["data"]["linear_current"] = linear_current;
    returnValue["data"]["switch1_out"] = switch1_out;
    returnValue["data"]["switch2_out"] = switch2_out;
    returnValue["data"]["homing_needed"] = homing_needed;
    return  returnValue;
  }
  public override MiningStatusMessage loadJson(JObject json) {
    probe_temp_c = (double)json["data"]["probe_temp_c"];
    probe_moisture = (double)json["data"]["probe_moisture"];
    probe_loss_tangent = (double)json["data"]["probe_loss_tangent"];
    probe_soil_elec_cond = (double)json["data"]["probe_soil_elec_cond"];
    probe_real_dielec_perm = (double)json["data"]["probe_real_dielec_perm"];
    probe_imag_dielec_perm = (double)json["data"]["probe_imag_dielec_perm"];
    motor_current_position = (int)json["data"]["motor_current_position"];
    linear_current_position = (int)json["data"]["linear_current_position"];
    temp1 = (int)json["data"]["temp1"];
    temp2 = (int)json["data"]["temp2"];
    motor_current = (double)json["data"]["motor_current"];
    linear_current = (double)json["data"]["linear_current"];
    switch1_out = (bool)json["data"]["switch1_out"];
    switch2_out = (bool)json["data"]["switch2_out"];
    homing_needed = (bool)json["data"]["homing_needed"];
    return  this;
  }
  public static explicit operator MiningStatusMessage(JObject json){
    return new MiningStatusMessage().loadJson(json);
  }
  MiningStatusMessage() {}
}
