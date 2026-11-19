using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.std_msgs.msg;

[Tool]
[GlobalClass]
public partial class Char : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Char\",\"data\":{\"data\":0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public int data{get; set; }= 0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["data"] = data;
    return  returnValue;
  }
  public override Char loadJson(JObject json) {
    data = (int)json["data"]["data"];
    return  this;
  }
  public static explicit operator Char(JObject json){
    return new Char().loadJson(json);
  }
  Char() {}
}
