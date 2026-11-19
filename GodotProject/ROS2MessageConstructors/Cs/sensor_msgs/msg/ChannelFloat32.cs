using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.sensor_msgs.msg;

[Tool]
[GlobalClass]
public partial class ChannelFloat32 : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/ChannelFloat32\",\"data\":{\"name\":\"\",\"values\":[]}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public string name{get; set; }= "";
  [Export] public string values{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["name"] = name;
    returnValue["data"]["values"] = values;
    return  returnValue;
  }
  public override ChannelFloat32 loadJson(JObject json) {
    name = (string)json["data"]["name"];
    values = (string)json["data"]["values"];
    return  this;
  }
  public static explicit operator ChannelFloat32(JObject json){
    return new ChannelFloat32().loadJson(json);
  }
  ChannelFloat32() {}
}
