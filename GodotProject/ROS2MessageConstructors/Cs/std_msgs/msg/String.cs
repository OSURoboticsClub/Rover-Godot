using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.std_msgs.msg;

[Tool]
[GlobalClass]
public partial class String : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/String\",\"data\":{\"data\":\"\"}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public string data{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["data"] = data;
    return  returnValue;
  }
  public override String loadJson(JObject json) {
    data = (string)json["data"]["data"];
    return  this;
  }
  public static explicit operator String(JObject json){
    return new String().loadJson(json);
  }
  String() {}
}
