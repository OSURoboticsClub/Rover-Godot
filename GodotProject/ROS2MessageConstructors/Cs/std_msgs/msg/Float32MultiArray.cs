using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.std_msgs.msg;

[Tool]
[GlobalClass]
public partial class Float32MultiArray : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Float32MultiArray\",\"data\":{\"layout\":{\"dim\":[],\"data_offset\":0},\"data\":[]}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("layout")]
  [Export] public string layout_dim{get; set; }= "";
  [Export] public int layout_data_offset{get; set; }= 0;
  [Export] public string data{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["layout"]["dim"] = layout_dim;
    returnValue["data"]["layout"]["data_offset"] = layout_data_offset;
    returnValue["data"]["data"] = data;
    return  returnValue;
  }
  public override Float32MultiArray loadJson(JObject json) {
    layout_dim = (string)json["data"]["layout"]["dim"];
    layout_data_offset = (int)json["data"]["layout"]["data_offset"];
    data = (string)json["data"]["data"];
    return  this;
  }
  public static explicit operator Float32MultiArray(JObject json){
    return new Float32MultiArray().loadJson(json);
  }
  Float32MultiArray() {}
}
