using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.sensor_msgs.msg;

[Tool]
[GlobalClass]
public partial class JoyFeedbackArray : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/JoyFeedbackArray\",\"data\":{\"array\":{\"TYPE_LED\":0,\"TYPE_RUMBLE\":0,\"TYPE_BUZZER\":0,\"type\":0,\"id\":0,\"intensity\":0.0}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("array")]
  [Export] public int array_TYPE_LED{get; set; }= 0;
  [Export] public int array_TYPE_RUMBLE{get; set; }= 0;
  [Export] public int array_TYPE_BUZZER{get; set; }= 0;
  [Export] public int array_type{get; set; }= 0;
  [Export] public int array_id{get; set; }= 0;
  [Export] public double array_intensity{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["array"]["TYPE_LED"] = array_TYPE_LED;
    returnValue["data"]["array"]["TYPE_RUMBLE"] = array_TYPE_RUMBLE;
    returnValue["data"]["array"]["TYPE_BUZZER"] = array_TYPE_BUZZER;
    returnValue["data"]["array"]["type"] = array_type;
    returnValue["data"]["array"]["id"] = array_id;
    returnValue["data"]["array"]["intensity"] = array_intensity;
    return  returnValue;
  }
  public override JoyFeedbackArray loadJson(JObject json) {
    array_TYPE_LED = (int)json["data"]["array"]["TYPE_LED"];
    array_TYPE_RUMBLE = (int)json["data"]["array"]["TYPE_RUMBLE"];
    array_TYPE_BUZZER = (int)json["data"]["array"]["TYPE_BUZZER"];
    array_type = (int)json["data"]["array"]["type"];
    array_id = (int)json["data"]["array"]["id"];
    array_intensity = (double)json["data"]["array"]["intensity"];
    return  this;
  }
  public static explicit operator JoyFeedbackArray(JObject json){
    return new JoyFeedbackArray().loadJson(json);
  }
  JoyFeedbackArray() {}
}
