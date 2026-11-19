using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_control_interface.srv;

[Tool]
[GlobalClass]
public partial class HeistMechanismService : ROS2Messages.BaseRequest {
  public static string jsonstring = "{\"service\":\"\",\"srvType\":\"rover2_control_interface/srv/HeistMechanismService\",\"request\":{\"command\":0,\"message\":\"\"},\"response\":{\"success\":false,\"result_msg\":\"\"}}";
  [Export]
  public string service {get; set; }= "";
  [Export]
  public int command{get; set; }= 0;
  [Export]
  public string message{get; set; }= "";
  public bool response_success;
  public string response_result_msg;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["service"] = service;
    returnValue["request"]["command"] = command;
    returnValue["request"]["message"] = message;
    return returnValue;
  }
  HeistMechanismService() {}
}
