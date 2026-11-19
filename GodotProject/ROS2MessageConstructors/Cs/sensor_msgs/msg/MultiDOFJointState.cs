using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.sensor_msgs.msg;

[Tool]
[GlobalClass]
public partial class MultiDOFJointState : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/MultiDOFJointState\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"joint_names\":[],\"transforms\":{\"translation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"rotation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0}},\"twist\":{\"linear\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}},\"wrench\":{\"force\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"torque\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [Export] public string joint_names{get; set; }= "";
  [ExportGroup("transforms")]
  [ExportSubgroup("translation")]
  [Export] public double transforms_translation_x{get; set; }= 0.0;
  [Export] public double transforms_translation_y{get; set; }= 0.0;
  [Export] public double transforms_translation_z{get; set; }= 0.0;
  [ExportSubgroup("rotation")]
  [Export] public double transforms_rotation_x{get; set; }= 0.0;
  [Export] public double transforms_rotation_y{get; set; }= 0.0;
  [Export] public double transforms_rotation_z{get; set; }= 0.0;
  [Export] public double transforms_rotation_w{get; set; }= 0.0;
  [ExportGroup("twist")]
  [ExportSubgroup("linear")]
  [Export] public double twist_linear_x{get; set; }= 0.0;
  [Export] public double twist_linear_y{get; set; }= 0.0;
  [Export] public double twist_linear_z{get; set; }= 0.0;
  [ExportSubgroup("angular")]
  [Export] public double twist_angular_x{get; set; }= 0.0;
  [Export] public double twist_angular_y{get; set; }= 0.0;
  [Export] public double twist_angular_z{get; set; }= 0.0;
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
    returnValue["data"]["joint_names"] = joint_names;
    returnValue["data"]["transforms"]["translation"]["x"] = transforms_translation_x;
    returnValue["data"]["transforms"]["translation"]["y"] = transforms_translation_y;
    returnValue["data"]["transforms"]["translation"]["z"] = transforms_translation_z;
    returnValue["data"]["transforms"]["rotation"]["x"] = transforms_rotation_x;
    returnValue["data"]["transforms"]["rotation"]["y"] = transforms_rotation_y;
    returnValue["data"]["transforms"]["rotation"]["z"] = transforms_rotation_z;
    returnValue["data"]["transforms"]["rotation"]["w"] = transforms_rotation_w;
    returnValue["data"]["twist"]["linear"]["x"] = twist_linear_x;
    returnValue["data"]["twist"]["linear"]["y"] = twist_linear_y;
    returnValue["data"]["twist"]["linear"]["z"] = twist_linear_z;
    returnValue["data"]["twist"]["angular"]["x"] = twist_angular_x;
    returnValue["data"]["twist"]["angular"]["y"] = twist_angular_y;
    returnValue["data"]["twist"]["angular"]["z"] = twist_angular_z;
    returnValue["data"]["wrench"]["force"]["x"] = wrench_force_x;
    returnValue["data"]["wrench"]["force"]["y"] = wrench_force_y;
    returnValue["data"]["wrench"]["force"]["z"] = wrench_force_z;
    returnValue["data"]["wrench"]["torque"]["x"] = wrench_torque_x;
    returnValue["data"]["wrench"]["torque"]["y"] = wrench_torque_y;
    returnValue["data"]["wrench"]["torque"]["z"] = wrench_torque_z;
    return  returnValue;
  }
  public override MultiDOFJointState loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    joint_names = (string)json["data"]["joint_names"];
    transforms_translation_x = (double)json["data"]["transforms"]["translation"]["x"];
    transforms_translation_y = (double)json["data"]["transforms"]["translation"]["y"];
    transforms_translation_z = (double)json["data"]["transforms"]["translation"]["z"];
    transforms_rotation_x = (double)json["data"]["transforms"]["rotation"]["x"];
    transforms_rotation_y = (double)json["data"]["transforms"]["rotation"]["y"];
    transforms_rotation_z = (double)json["data"]["transforms"]["rotation"]["z"];
    transforms_rotation_w = (double)json["data"]["transforms"]["rotation"]["w"];
    twist_linear_x = (double)json["data"]["twist"]["linear"]["x"];
    twist_linear_y = (double)json["data"]["twist"]["linear"]["y"];
    twist_linear_z = (double)json["data"]["twist"]["linear"]["z"];
    twist_angular_x = (double)json["data"]["twist"]["angular"]["x"];
    twist_angular_y = (double)json["data"]["twist"]["angular"]["y"];
    twist_angular_z = (double)json["data"]["twist"]["angular"]["z"];
    wrench_force_x = (double)json["data"]["wrench"]["force"]["x"];
    wrench_force_y = (double)json["data"]["wrench"]["force"]["y"];
    wrench_force_z = (double)json["data"]["wrench"]["force"]["z"];
    wrench_torque_x = (double)json["data"]["wrench"]["torque"]["x"];
    wrench_torque_y = (double)json["data"]["wrench"]["torque"]["y"];
    wrench_torque_z = (double)json["data"]["wrench"]["torque"]["z"];
    return  this;
  }
  public static explicit operator MultiDOFJointState(JObject json){
    return new MultiDOFJointState().loadJson(json);
  }
  MultiDOFJointState() {}
}
