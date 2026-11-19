using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.sensor_msgs.msg;

[Tool]
[GlobalClass]
public partial class Imu : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/Imu\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"orientation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0},\"orientation_covariance\":[],\"angular_velocity\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular_velocity_covariance\":[],\"linear_acceleration\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"linear_acceleration_covariance\":[]}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [ExportGroup("orientation")]
  [Export] public double orientation_x{get; set; }= 0.0;
  [Export] public double orientation_y{get; set; }= 0.0;
  [Export] public double orientation_z{get; set; }= 0.0;
  [Export] public double orientation_w{get; set; }= 0.0;
  [Export] public string orientation_covariance{get; set; }= "";
  [ExportGroup("angular_velocity")]
  [Export] public double angular_velocity_x{get; set; }= 0.0;
  [Export] public double angular_velocity_y{get; set; }= 0.0;
  [Export] public double angular_velocity_z{get; set; }= 0.0;
  [Export] public string angular_velocity_covariance{get; set; }= "";
  [ExportGroup("linear_acceleration")]
  [Export] public double linear_acceleration_x{get; set; }= 0.0;
  [Export] public double linear_acceleration_y{get; set; }= 0.0;
  [Export] public double linear_acceleration_z{get; set; }= 0.0;
  [Export] public string linear_acceleration_covariance{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["orientation"]["x"] = orientation_x;
    returnValue["data"]["orientation"]["y"] = orientation_y;
    returnValue["data"]["orientation"]["z"] = orientation_z;
    returnValue["data"]["orientation"]["w"] = orientation_w;
    returnValue["data"]["orientation_covariance"] = orientation_covariance;
    returnValue["data"]["angular_velocity"]["x"] = angular_velocity_x;
    returnValue["data"]["angular_velocity"]["y"] = angular_velocity_y;
    returnValue["data"]["angular_velocity"]["z"] = angular_velocity_z;
    returnValue["data"]["angular_velocity_covariance"] = angular_velocity_covariance;
    returnValue["data"]["linear_acceleration"]["x"] = linear_acceleration_x;
    returnValue["data"]["linear_acceleration"]["y"] = linear_acceleration_y;
    returnValue["data"]["linear_acceleration"]["z"] = linear_acceleration_z;
    returnValue["data"]["linear_acceleration_covariance"] = linear_acceleration_covariance;
    return  returnValue;
  }
  public override Imu loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    orientation_x = (double)json["data"]["orientation"]["x"];
    orientation_y = (double)json["data"]["orientation"]["y"];
    orientation_z = (double)json["data"]["orientation"]["z"];
    orientation_w = (double)json["data"]["orientation"]["w"];
    orientation_covariance = (string)json["data"]["orientation_covariance"];
    angular_velocity_x = (double)json["data"]["angular_velocity"]["x"];
    angular_velocity_y = (double)json["data"]["angular_velocity"]["y"];
    angular_velocity_z = (double)json["data"]["angular_velocity"]["z"];
    angular_velocity_covariance = (string)json["data"]["angular_velocity_covariance"];
    linear_acceleration_x = (double)json["data"]["linear_acceleration"]["x"];
    linear_acceleration_y = (double)json["data"]["linear_acceleration"]["y"];
    linear_acceleration_z = (double)json["data"]["linear_acceleration"]["z"];
    linear_acceleration_covariance = (string)json["data"]["linear_acceleration_covariance"];
    return  this;
  }
  public static explicit operator Imu(JObject json){
    return new Imu().loadJson(json);
  }
  Imu() {}
}
