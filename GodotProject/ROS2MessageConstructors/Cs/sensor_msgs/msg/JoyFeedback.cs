using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.sensor_msgs.msg;

[Tool]
[GlobalClass]
public partial class JoyFeedback : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/JoyFeedback\",\"data\":{\"TYPE_LED\":0,\"TYPE_RUMBLE\":0,\"TYPE_BUZZER\":0,\"type\":0,\"id\":0,\"intensity\":0.0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public int TYPE_LED{get; set; }= 0;
  [Export] public int TYPE_RUMBLE{get; set; }= 0;
  [Export] public int TYPE_BUZZER{get; set; }= 0;
  [Export] public int type{get; set; }= 0;
  [Export] public int id{get; set; }= 0;
  [Export] public double intensity{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["TYPE_LED"] = TYPE_LED;
    returnValue["data"]["TYPE_RUMBLE"] = TYPE_RUMBLE;
    returnValue["data"]["TYPE_BUZZER"] = TYPE_BUZZER;
    returnValue["data"]["type"] = type;
    returnValue["data"]["id"] = id;
    returnValue["data"]["intensity"] = intensity;
    return  returnValue;
  }
  public override JoyFeedback loadJson(JObject json) {
    TYPE_LED = (int)json["data"]["TYPE_LED"];
    TYPE_RUMBLE = (int)json["data"]["TYPE_RUMBLE"];
    TYPE_BUZZER = (int)json["data"]["TYPE_BUZZER"];
    type = (int)json["data"]["type"];
    id = (int)json["data"]["id"];
    intensity = (double)json["data"]["intensity"];
    return  this;
  }
  public static explicit operator JoyFeedback(JObject json){
    return new JoyFeedback().loadJson(json);
  }
  JoyFeedback() {}
}
