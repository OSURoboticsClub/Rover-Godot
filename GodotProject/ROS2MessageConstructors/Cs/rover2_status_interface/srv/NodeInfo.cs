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
  [ExportGroup("request")]
  [Export] public string request_node{get; set; }= "";
  [Export] public string request_nodenamespace{get; set; }= "";
  [ExportGroup("response")]
  [Export] public string response_pub_topics{get; set; }= "";
  [Export] public string response_sub_topics{get; set; }= "";
  [Export] public string response_services{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["request"]["node"] = request_node;
    returnValue["request"]["node"] = request_node;
    returnValue["request"]["nodenamespace"] = request_nodenamespace;
    returnValue["request"]["nodenamespace"] = request_nodenamespace;
    returnValue["response"]["pub_topics"] = response_pub_topics;
    returnValue["response"]["pub_topics"] = response_pub_topics;
    returnValue["response"]["sub_topics"] = response_sub_topics;
    returnValue["response"]["sub_topics"] = response_sub_topics;
    returnValue["response"]["services"] = response_services;
    returnValue["response"]["services"] = response_services;
    return  returnValue;
  }
  public override NodeInfo loadJson(JObject json) {
    request_node = (string)json["request"]["node"];
    request_nodenamespace = (string)json["request"]["nodenamespace"];
    response_pub_topics = (string)json["response"]["pub_topics"];
    response_sub_topics = (string)json["response"]["sub_topics"];
    response_services = (string)json["response"]["services"];
    return  this;
  }
  NodeInfo() {}
}
