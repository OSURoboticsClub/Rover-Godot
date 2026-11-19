using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_control_interface.msg;

[Tool]
[GlobalClass]
public partial class GPSStatusMessage : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"rover2_control_interface/msg/GPSStatusMessage\",\"data\":{\"rover_latitude\":0.0,\"rover_longitude\":0.0,\"astronaut_latitude\":0.0,\"astronaut_longitude\":0.0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public double rover_latitude{get; set; }= 0.0;
  [Export] public double rover_longitude{get; set; }= 0.0;
  [Export] public double astronaut_latitude{get; set; }= 0.0;
  [Export] public double astronaut_longitude{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["rover_latitude"] = rover_latitude;
    returnValue["data"]["rover_longitude"] = rover_longitude;
    returnValue["data"]["astronaut_latitude"] = astronaut_latitude;
    returnValue["data"]["astronaut_longitude"] = astronaut_longitude;
    return  returnValue;
  }
  public override GPSStatusMessage loadJson(JObject json) {
    rover_latitude = (double)json["data"]["rover_latitude"];
    rover_longitude = (double)json["data"]["rover_longitude"];
    astronaut_latitude = (double)json["data"]["astronaut_latitude"];
    astronaut_longitude = (double)json["data"]["astronaut_longitude"];
    return  this;
  }
  public static explicit operator GPSStatusMessage(JObject json){
    return new GPSStatusMessage().loadJson(json);
  }
  GPSStatusMessage() {}
}
