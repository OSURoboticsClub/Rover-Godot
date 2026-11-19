using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_status_interface.srv;

[Tool]
[GlobalClass]
public partial class NodeLog : ROS2Messages.BaseRequest {
  public static string jsonstring = "{\"service\":\"\",\"srvType\":\"rover2_status_interface/srv/NodeLog\",\"request\":{\"enable\":false,\"hz\":0.0,\"node\":\"\"},\"response\":{\"acknowledge\":false}}";
  [Export]
  public string service {get; set; }= "";
  [Export]
  public bool enable{get; set; }= false;
  [Export]
  public double hz{get; set; }= 0.0;
  [Export]
  public string node{get; set; }= "";
  public bool response_acknowledge;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["service"] = service;
    returnValue["request"]["enable"] = enable;
    returnValue["request"]["hz"] = hz;
    returnValue["request"]["node"] = node;
    return returnValue;
  }
  NodeLog() {}
}
