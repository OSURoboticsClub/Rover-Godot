using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.std_msgs.msg;

[Tool]
[GlobalClass]
public partial class Bool : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Bool\",\"data\":{\"data\":false}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public bool data{get; set; }= false;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["data"] = data;
    return  returnValue;
  }
  public override Bool loadJson(JObject json) {
    data = (bool)json["data"]["data"];
    return  this;
  }
  public static explicit operator Bool(JObject json){
    return new Bool().loadJson(json);
  }
  Bool() {}
}
