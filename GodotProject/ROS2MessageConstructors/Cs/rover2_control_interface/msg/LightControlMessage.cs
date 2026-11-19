using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_control_interface.msg;

[Tool]
[GlobalClass]
public partial class LightControlMessage : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/LightControlMessage\",\"data\":{\"light_mode\":0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public int light_mode{get; set; }= 0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["light_mode"] = light_mode;
    return  returnValue;
  }
  public override LightControlMessage loadJson(JObject json) {
    light_mode = (int)json["data"]["light_mode"];
    return  this;
  }
  public static explicit operator LightControlMessage(JObject json){
    return new LightControlMessage().loadJson(json);
  }
  LightControlMessage() {}
}
