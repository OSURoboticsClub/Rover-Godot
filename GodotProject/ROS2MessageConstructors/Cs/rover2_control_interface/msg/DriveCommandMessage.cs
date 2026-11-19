using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_control_interface.msg;

[Tool]
[GlobalClass]
public partial class DriveCommandMessage : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/DriveCommandMessage\",\"data\":{\"controller_present\":false,\"ignore_drive_control\":false,\"drive_twist\":{\"linear\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public bool controller_present{get; set; }= false;
  [Export] public bool ignore_drive_control{get; set; }= false;
  [ExportGroup("drive_twist")]
  [ExportSubgroup("linear")]
  [Export] public double drive_twist_linear_x{get; set; }= 0.0;
  [Export] public double drive_twist_linear_y{get; set; }= 0.0;
  [Export] public double drive_twist_linear_z{get; set; }= 0.0;
  [ExportSubgroup("angular")]
  [Export] public double drive_twist_angular_x{get; set; }= 0.0;
  [Export] public double drive_twist_angular_y{get; set; }= 0.0;
  [Export] public double drive_twist_angular_z{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["controller_present"] = controller_present;
    returnValue["data"]["ignore_drive_control"] = ignore_drive_control;
    returnValue["data"]["drive_twist"]["linear"]["x"] = drive_twist_linear_x;
    returnValue["data"]["drive_twist"]["linear"]["y"] = drive_twist_linear_y;
    returnValue["data"]["drive_twist"]["linear"]["z"] = drive_twist_linear_z;
    returnValue["data"]["drive_twist"]["angular"]["x"] = drive_twist_angular_x;
    returnValue["data"]["drive_twist"]["angular"]["y"] = drive_twist_angular_y;
    returnValue["data"]["drive_twist"]["angular"]["z"] = drive_twist_angular_z;
    return  returnValue;
  }
  public override DriveCommandMessage loadJson(JObject json) {
    controller_present = (bool)json["data"]["controller_present"];
    ignore_drive_control = (bool)json["data"]["ignore_drive_control"];
    drive_twist_linear_x = (double)json["data"]["drive_twist"]["linear"]["x"];
    drive_twist_linear_y = (double)json["data"]["drive_twist"]["linear"]["y"];
    drive_twist_linear_z = (double)json["data"]["drive_twist"]["linear"]["z"];
    drive_twist_angular_x = (double)json["data"]["drive_twist"]["angular"]["x"];
    drive_twist_angular_y = (double)json["data"]["drive_twist"]["angular"]["y"];
    drive_twist_angular_z = (double)json["data"]["drive_twist"]["angular"]["z"];
    return  this;
  }
  public static explicit operator DriveCommandMessage(JObject json){
    return new DriveCommandMessage().loadJson(json);
  }
  DriveCommandMessage() {}
}
