using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.std_srvs.srv;

[Tool]
[GlobalClass]
public partial class AntennaControlService : ROS2Messages.BaseRequest {
  public static string jsonstring = "{\"service\":\"\",\"srvType\":\"gs_tower_interfaces/srv/AntennaControlService\",\"request\":{\"mode\":0},\"response\":{\"success\":false,\"msg\":[]}}";
  [Export]
  public string service {get; set; }= "";
  [Export]
  public int mode{get; set; }= 0;
  public bool response_success;
  public string response_msg;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["service"] = service;
    returnValue["request"]["mode"] = mode;
    return returnValue;
  }
  AntennaControlService() {}
}
