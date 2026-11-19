using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.std_srvs.srv;

[Tool]
[GlobalClass]
public partial class Trigger : ROS2Messages.BaseRequest {
  public static string jsonstring = "{\"service\":\"\",\"srvType\":\"std_srvs/srv/Trigger\",\"request\":{},\"response\":{\"success\":false,\"message\":\"\"}}";
  [Export]
  public string service {get; set; }= "";
  [ExportGroup("response")]
  [Export] public bool response_success{get; set; }= false;
  [Export] public string response_message{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["response"]["success"] = response_success;
    returnValue["response"]["success"] = response_success;
    returnValue["response"]["message"] = response_message;
    returnValue["response"]["message"] = response_message;
    return  returnValue;
  }
  public override Trigger loadJson(JObject json) {
    response_success = (bool)json["response"]["success"];
    response_message = (string)json["response"]["message"];
    return  this;
  }
  Trigger() {}
}
