using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class Inertia : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Inertia\",\"data\":{\"m\":0.0,\"com\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"ixx\":0.0,\"ixy\":0.0,\"ixz\":0.0,\"iyy\":0.0,\"iyz\":0.0,\"izz\":0.0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public double m{get; set; }= 0.0;
  [ExportGroup("com")]
  [Export] public double com_x{get; set; }= 0.0;
  [Export] public double com_y{get; set; }= 0.0;
  [Export] public double com_z{get; set; }= 0.0;
  [Export] public double ixx{get; set; }= 0.0;
  [Export] public double ixy{get; set; }= 0.0;
  [Export] public double ixz{get; set; }= 0.0;
  [Export] public double iyy{get; set; }= 0.0;
  [Export] public double iyz{get; set; }= 0.0;
  [Export] public double izz{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["m"] = m;
    returnValue["data"]["com"]["x"] = com_x;
    returnValue["data"]["com"]["y"] = com_y;
    returnValue["data"]["com"]["z"] = com_z;
    returnValue["data"]["ixx"] = ixx;
    returnValue["data"]["ixy"] = ixy;
    returnValue["data"]["ixz"] = ixz;
    returnValue["data"]["iyy"] = iyy;
    returnValue["data"]["iyz"] = iyz;
    returnValue["data"]["izz"] = izz;
    return  returnValue;
  }
  public override Inertia loadJson(JObject json) {
    m = (double)json["data"]["m"];
    com_x = (double)json["data"]["com"]["x"];
    com_y = (double)json["data"]["com"]["y"];
    com_z = (double)json["data"]["com"]["z"];
    ixx = (double)json["data"]["ixx"];
    ixy = (double)json["data"]["ixy"];
    ixz = (double)json["data"]["ixz"];
    iyy = (double)json["data"]["iyy"];
    iyz = (double)json["data"]["iyz"];
    izz = (double)json["data"]["izz"];
    return  this;
  }
  public static explicit operator Inertia(JObject json){
    return new Inertia().loadJson(json);
  }
  Inertia() {}
}
