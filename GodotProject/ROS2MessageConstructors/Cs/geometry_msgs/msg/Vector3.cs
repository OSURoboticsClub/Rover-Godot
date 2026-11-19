using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class Vector3 : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Vector3\",\"data\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public double x{get; set; }= 0.0;
  [Export] public double y{get; set; }= 0.0;
  [Export] public double z{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["x"] = x;
    returnValue["data"]["y"] = y;
    returnValue["data"]["z"] = z;
    return  returnValue;
  }
  public override Vector3 loadJson(JObject json) {
    x = (double)json["data"]["x"];
    y = (double)json["data"]["y"];
    z = (double)json["data"]["z"];
    return  this;
  }
  public static explicit operator Vector3(JObject json){
    return new Vector3().loadJson(json);
  }
  Vector3() {}
}
