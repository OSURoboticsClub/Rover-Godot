using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.std_msgs.msg;

[Tool]
[GlobalClass]
public partial class Float32 : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Float32\",\"data\":{\"data\":0.0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public double data{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["data"] = data;
    return  returnValue;
  }
  public override Float32 loadJson(JObject json) {
    data = (double)json["data"]["data"];
    return  this;
  }
  public static explicit operator Float32(JObject json){
    return new Float32().loadJson(json);
  }
  Float32() {}
}
