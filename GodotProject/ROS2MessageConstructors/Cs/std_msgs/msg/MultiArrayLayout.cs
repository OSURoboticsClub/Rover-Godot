using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.std_msgs.msg;

[Tool]
[GlobalClass]
public partial class MultiArrayLayout : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/MultiArrayLayout\",\"data\":{\"dim\":{\"label\":\"\",\"size\":0,\"stride\":0},\"data_offset\":0}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("dim")]
  [Export] public string dim_label{get; set; }= "";
  [Export] public int dim_size{get; set; }= 0;
  [Export] public int dim_stride{get; set; }= 0;
  [Export] public int data_offset{get; set; }= 0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["dim"]["label"] = dim_label;
    returnValue["data"]["dim"]["size"] = dim_size;
    returnValue["data"]["dim"]["stride"] = dim_stride;
    returnValue["data"]["data_offset"] = data_offset;
    return  returnValue;
  }
  public override MultiArrayLayout loadJson(JObject json) {
    dim_label = (string)json["data"]["dim"]["label"];
    dim_size = (int)json["data"]["dim"]["size"];
    dim_stride = (int)json["data"]["dim"]["stride"];
    data_offset = (int)json["data"]["data_offset"];
    return  this;
  }
  public static explicit operator MultiArrayLayout(JObject json){
    return new MultiArrayLayout().loadJson(json);
  }
  MultiArrayLayout() {}
}
