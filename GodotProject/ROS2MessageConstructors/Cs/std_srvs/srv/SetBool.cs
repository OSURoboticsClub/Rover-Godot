using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.std_srvs.srv;

[Tool]
[GlobalClass]
public partial class SetBool : ROS2Messages.BaseRequest {
  public static string jsonstring = "{\"service\":\"\",\"srvType\":\"std_srvs/srv/SetBool\",\"request\":{\"data\":false},\"response\":{\"success\":false,\"message\":\"\"}}";
  [Export]
  public string service {get; set; }= "";
  [Export]
  public bool data{get; set; }= false;
  public bool response_success;
  public string response_message;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["service"] = service;
    returnValue["request"]["data"] = data;
    return returnValue;
  }
  SetBool() {}
}
