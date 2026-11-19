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
  [ExportGroup("request")]
  [Export] public bool request_enable{get; set; }= false;
  [Export] public double request_hz{get; set; }= 0.0;
  [Export] public string request_node{get; set; }= "";
  [ExportGroup("response")]
  [Export] public bool response_acknowledge{get; set; }= false;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["request"]["enable"] = request_enable;
    returnValue["request"]["enable"] = request_enable;
    returnValue["request"]["hz"] = request_hz;
    returnValue["request"]["hz"] = request_hz;
    returnValue["request"]["node"] = request_node;
    returnValue["request"]["node"] = request_node;
    returnValue["response"]["acknowledge"] = response_acknowledge;
    returnValue["response"]["acknowledge"] = response_acknowledge;
    return  returnValue;
  }
  public override NodeLog loadJson(JObject json) {
    request_enable = (bool)json["request"]["enable"];
    request_hz = (double)json["request"]["hz"];
    request_node = (string)json["request"]["node"];
    response_acknowledge = (bool)json["response"]["acknowledge"];
    return  this;
  }
  NodeLog() {}
}
