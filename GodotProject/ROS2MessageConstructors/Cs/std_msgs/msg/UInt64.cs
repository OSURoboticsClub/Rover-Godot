using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.std_msgs.msg;

[Tool]
[GlobalClass]
public partial class UInt64 : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/UInt64\",\"data\":{\"data\":0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public int data{get; set; }= 0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["data"] = data;
    return  returnValue;
  }
  public override UInt64 loadJson(JObject json) {
    data = (int)json["data"]["data"];
    return  this;
  }
  public static explicit operator UInt64(JObject json){
    return new UInt64().loadJson(json);
  }
  UInt64() {}
}
