using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_control_interface.msg;

[Tool]
[GlobalClass]
public partial class IrisStatusMessage : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/IrisStatusMessage\",\"data\":{\"iris_connected\":false,\"voltage_24v\":0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public bool iris_connected{get; set; }= false;
  [Export] public int voltage_24v{get; set; }= 0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["iris_connected"] = iris_connected;
    returnValue["data"]["voltage_24v"] = voltage_24v;
    return  returnValue;
  }
  public override IrisStatusMessage loadJson(JObject json) {
    iris_connected = (bool)json["data"]["iris_connected"];
    voltage_24v = (int)json["data"]["voltage_24v"];
    return  this;
  }
  public static explicit operator IrisStatusMessage(JObject json){
    return new IrisStatusMessage().loadJson(json);
  }
  IrisStatusMessage() {}
}
