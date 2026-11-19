using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.std_msgs.msg;

[Tool]
[GlobalClass]
public partial class MultiArrayDimension : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/MultiArrayDimension\",\"data\":{\"label\":\"\",\"size\":0,\"stride\":0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public string label{get; set; }= "";
  [Export] public int size{get; set; }= 0;
  [Export] public int stride{get; set; }= 0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["label"] = label;
    returnValue["data"]["size"] = size;
    returnValue["data"]["stride"] = stride;
    return  returnValue;
  }
  public override MultiArrayDimension loadJson(JObject json) {
    label = (string)json["data"]["label"];
    size = (int)json["data"]["size"];
    stride = (int)json["data"]["stride"];
    return  this;
  }
  public static explicit operator MultiArrayDimension(JObject json){
    return new MultiArrayDimension().loadJson(json);
  }
  MultiArrayDimension() {}
}
