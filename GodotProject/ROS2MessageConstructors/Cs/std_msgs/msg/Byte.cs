using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.std_msgs.msg;

[Tool]
[GlobalClass]
public partial class Byte : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Byte\",\"data\":{\"data\":0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public int data{get; set; }= 0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["data"] = data;
    return  returnValue;
  }
  public override Byte loadJson(JObject json) {
    data = (int)json["data"]["data"];
    return  this;
  }
  public static explicit operator Byte(JObject json){
    return new Byte().loadJson(json);
  }
  Byte() {}
}
