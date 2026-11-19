using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.std_msgs.msg;

[Tool]
[GlobalClass]
public partial class Int8MultiArray : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Int8MultiArray\",\"data\":{\"layout\":{\"dim\":{\"label\":\"\",\"size\":0,\"stride\":0},\"data_offset\":0},\"data\":[]}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("layout")]
  [ExportSubgroup("dim")]
  [Export] public string layout_dim_label{get; set; }= "";
  [Export] public int layout_dim_size{get; set; }= 0;
  [Export] public int layout_dim_stride{get; set; }= 0;
  [Export] public int layout_data_offset{get; set; }= 0;
  [Export] public string data{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["layout"]["dim"]["label"] = layout_dim_label;
    returnValue["data"]["layout"]["dim"]["size"] = layout_dim_size;
    returnValue["data"]["layout"]["dim"]["stride"] = layout_dim_stride;
    returnValue["data"]["layout"]["data_offset"] = layout_data_offset;
    returnValue["data"]["data"] = data;
    return  returnValue;
  }
  public override Int8MultiArray loadJson(JObject json) {
    layout_dim_label = (string)json["data"]["layout"]["dim"]["label"];
    layout_dim_size = (int)json["data"]["layout"]["dim"]["size"];
    layout_dim_stride = (int)json["data"]["layout"]["dim"]["stride"];
    layout_data_offset = (int)json["data"]["layout"]["data_offset"];
    data = (string)json["data"]["data"];
    return  this;
  }
  public static explicit operator Int8MultiArray(JObject json){
    return new Int8MultiArray().loadJson(json);
  }
  Int8MultiArray() {}
}
