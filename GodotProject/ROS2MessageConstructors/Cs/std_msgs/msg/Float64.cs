using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.std_msgs.msg;

[Tool]
[GlobalClass]
public partial class Float64 : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Float64\",\"data\":{\"data\":0.0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public double data{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["data"] = data;
    return  returnValue;
  }
  public override Float64 loadJson(JObject json) {
    data = (double)json["data"]["data"];
    return  this;
  }
  public static explicit operator Float64(JObject json){
    return new Float64().loadJson(json);
  }
  Float64() {}
}
