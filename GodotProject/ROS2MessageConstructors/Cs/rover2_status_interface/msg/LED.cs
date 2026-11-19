using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_status_interface.msg;

[Tool]
[GlobalClass]
public partial class LED : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"rover2_status_interface/msg/LED\",\"data\":{\"red\":0,\"green\":0,\"blue\":0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public int red{get; set; }= 0;
  [Export] public int green{get; set; }= 0;
  [Export] public int blue{get; set; }= 0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["red"] = red;
    returnValue["data"]["green"] = green;
    returnValue["data"]["blue"] = blue;
    return  returnValue;
  }
  public override LED loadJson(JObject json) {
    red = (int)json["data"]["red"];
    green = (int)json["data"]["green"];
    blue = (int)json["data"]["blue"];
    return  this;
  }
  public static explicit operator LED(JObject json){
    return new LED().loadJson(json);
  }
  LED() {}
}
