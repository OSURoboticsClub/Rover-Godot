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
  public bool response_success;
  public string response_message;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["service"] = service;
    return returnValue;
  }
  Trigger() {}
}
