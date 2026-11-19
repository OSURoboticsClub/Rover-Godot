using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_status_interface.srv;

[Tool]
[GlobalClass]
public partial class LatencySize : ROS2Messages.BaseRequest {
  public static string jsonstring = "{\"service\":\"\",\"srvType\":\"rover2_status_interface/srv/LatencySize\",\"request\":{\"dummydata\":[]},\"response\":{\"receivetime\":{\"sec\":0,\"nanosec\":0}}}";
  [Export]
  public string service {get; set; }= "";
  [Export]
  public string dummydata{get; set; }= "";
  public string response_receivetime;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["service"] = service;
    returnValue["request"]["dummydata"] = dummydata;
    return returnValue;
  }
  LatencySize() {}
}
