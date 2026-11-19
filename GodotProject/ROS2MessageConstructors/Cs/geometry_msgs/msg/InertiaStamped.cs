using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class InertiaStamped : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/InertiaStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"inertia\":{\"m\":0.0,\"com\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"ixx\":0.0,\"ixy\":0.0,\"ixz\":0.0,\"iyy\":0.0,\"iyz\":0.0,\"izz\":0.0}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [ExportGroup("inertia")]
  [Export] public double inertia_m{get; set; }= 0.0;
  [ExportSubgroup("com")]
  [Export] public double inertia_com_x{get; set; }= 0.0;
  [Export] public double inertia_com_y{get; set; }= 0.0;
  [Export] public double inertia_com_z{get; set; }= 0.0;
  [Export] public double inertia_ixx{get; set; }= 0.0;
  [Export] public double inertia_ixy{get; set; }= 0.0;
  [Export] public double inertia_ixz{get; set; }= 0.0;
  [Export] public double inertia_iyy{get; set; }= 0.0;
  [Export] public double inertia_iyz{get; set; }= 0.0;
  [Export] public double inertia_izz{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["inertia"]["m"] = inertia_m;
    returnValue["data"]["inertia"]["com"]["x"] = inertia_com_x;
    returnValue["data"]["inertia"]["com"]["y"] = inertia_com_y;
    returnValue["data"]["inertia"]["com"]["z"] = inertia_com_z;
    returnValue["data"]["inertia"]["ixx"] = inertia_ixx;
    returnValue["data"]["inertia"]["ixy"] = inertia_ixy;
    returnValue["data"]["inertia"]["ixz"] = inertia_ixz;
    returnValue["data"]["inertia"]["iyy"] = inertia_iyy;
    returnValue["data"]["inertia"]["iyz"] = inertia_iyz;
    returnValue["data"]["inertia"]["izz"] = inertia_izz;
    return  returnValue;
  }
  public override InertiaStamped loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    inertia_m = (double)json["data"]["inertia"]["m"];
    inertia_com_x = (double)json["data"]["inertia"]["com"]["x"];
    inertia_com_y = (double)json["data"]["inertia"]["com"]["y"];
    inertia_com_z = (double)json["data"]["inertia"]["com"]["z"];
    inertia_ixx = (double)json["data"]["inertia"]["ixx"];
    inertia_ixy = (double)json["data"]["inertia"]["ixy"];
    inertia_ixz = (double)json["data"]["inertia"]["ixz"];
    inertia_iyy = (double)json["data"]["inertia"]["iyy"];
    inertia_iyz = (double)json["data"]["inertia"]["iyz"];
    inertia_izz = (double)json["data"]["inertia"]["izz"];
    return  this;
  }
  public static explicit operator InertiaStamped(JObject json){
    return new InertiaStamped().loadJson(json);
  }
  InertiaStamped() {}
}
