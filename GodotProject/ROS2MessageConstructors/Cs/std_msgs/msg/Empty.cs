using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.std_msgs.msg;

[Tool]
[GlobalClass]
public partial class Empty : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Empty\",\"data\":{}}";
  [Export]
  public string topic {get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    return  returnValue;
  }
  public override Empty loadJson(JObject json) {
    return  this;
  }
  public static explicit operator Empty(JObject json){
    return new Empty().loadJson(json);
  }
  Empty() {}
}
