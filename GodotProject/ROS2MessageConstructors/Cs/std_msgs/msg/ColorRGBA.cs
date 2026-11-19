using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.std_msgs.msg;

[Tool]
[GlobalClass]
public partial class ColorRGBA : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/ColorRGBA\",\"data\":{\"r\":0.0,\"g\":0.0,\"b\":0.0,\"a\":0.0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public double r{get; set; }= 0.0;
  [Export] public double g{get; set; }= 0.0;
  [Export] public double b{get; set; }= 0.0;
  [Export] public double a{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["r"] = r;
    returnValue["data"]["g"] = g;
    returnValue["data"]["b"] = b;
    returnValue["data"]["a"] = a;
    return  returnValue;
  }
  public override ColorRGBA loadJson(JObject json) {
    r = (double)json["data"]["r"];
    g = (double)json["data"]["g"];
    b = (double)json["data"]["b"];
    a = (double)json["data"]["a"];
    return  this;
  }
  public static explicit operator ColorRGBA(JObject json){
    return new ColorRGBA().loadJson(json);
  }
  ColorRGBA() {}
}
