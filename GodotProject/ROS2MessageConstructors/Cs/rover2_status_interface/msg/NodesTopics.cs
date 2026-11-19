using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_status_interface.msg;

[Tool]
[GlobalClass]
public partial class NodesTopics : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"rover2_status_interface/msg/NodesTopics\",\"data\":{\"topic_name\":[],\"topic_status\":[],\"node_name\":[],\"node_status\":[]}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public string topic_name{get; set; }= "";
  [Export] public string topic_status{get; set; }= "";
  [Export] public string node_name{get; set; }= "";
  [Export] public string node_status{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["topic_name"] = topic_name;
    returnValue["data"]["topic_status"] = topic_status;
    returnValue["data"]["node_name"] = node_name;
    returnValue["data"]["node_status"] = node_status;
    return  returnValue;
  }
  public override NodesTopics loadJson(JObject json) {
    topic_name = (string)json["data"]["topic_name"];
    topic_status = (string)json["data"]["topic_status"];
    node_name = (string)json["data"]["node_name"];
    node_status = (string)json["data"]["node_status"];
    return  this;
  }
  public static explicit operator NodesTopics(JObject json){
    return new NodesTopics().loadJson(json);
  }
  NodesTopics() {}
}
