using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_status_interface.srv;

[Tool]
[GlobalClass]
public partial class NodeInfo : ROS2Messages.BaseRequest {
  public static string jsonstring = "{\"service\":\"\",\"srvType\":\"rover2_status_interface/srv/NodeInfo\",\"request\":{\"node\":\"\",\"nodenamespace\":\"\"},\"response\":{\"pub_topics\":[],\"sub_topics\":[],\"services\":[]}}";
  [Export]
  public string service {get; set; }= "";
  [Export]
  public string node{get; set; }= "";
  [Export]
  public string nodenamespace{get; set; }= "";
  public string response_pub_topics;
  public string response_sub_topics;
  public string response_services;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["service"] = service;
    returnValue["request"]["node"] = node;
    returnValue["request"]["nodenamespace"] = nodenamespace;
    return returnValue;
  }
  NodeInfo() {}
}
