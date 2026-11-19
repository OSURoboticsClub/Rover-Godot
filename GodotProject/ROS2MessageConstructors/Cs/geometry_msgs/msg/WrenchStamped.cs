using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class WrenchStamped : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/WrenchStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"wrench\":{\"force\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"torque\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [ExportGroup("wrench")]
  [ExportSubgroup("force")]
  [Export] public double wrench_force_x{get; set; }= 0.0;
  [Export] public double wrench_force_y{get; set; }= 0.0;
  [Export] public double wrench_force_z{get; set; }= 0.0;
  [ExportSubgroup("torque")]
  [Export] public double wrench_torque_x{get; set; }= 0.0;
  [Export] public double wrench_torque_y{get; set; }= 0.0;
  [Export] public double wrench_torque_z{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["wrench"]["force"]["x"] = wrench_force_x;
    returnValue["data"]["wrench"]["force"]["y"] = wrench_force_y;
    returnValue["data"]["wrench"]["force"]["z"] = wrench_force_z;
    returnValue["data"]["wrench"]["torque"]["x"] = wrench_torque_x;
    returnValue["data"]["wrench"]["torque"]["y"] = wrench_torque_y;
    returnValue["data"]["wrench"]["torque"]["z"] = wrench_torque_z;
    return  returnValue;
  }
  public override WrenchStamped loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    wrench_force_x = (double)json["data"]["wrench"]["force"]["x"];
    wrench_force_y = (double)json["data"]["wrench"]["force"]["y"];
    wrench_force_z = (double)json["data"]["wrench"]["force"]["z"];
    wrench_torque_x = (double)json["data"]["wrench"]["torque"]["x"];
    wrench_torque_y = (double)json["data"]["wrench"]["torque"]["y"];
    wrench_torque_z = (double)json["data"]["wrench"]["torque"]["z"];
    return  this;
  }
  public static explicit operator WrenchStamped(JObject json){
    return new WrenchStamped().loadJson(json);
  }
  WrenchStamped() {}
}
