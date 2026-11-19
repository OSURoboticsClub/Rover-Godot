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
  [ExportGroup("request")]
  [Export] public int request_mode{get; set; }= 0;
  [ExportGroup("response")]
  [Export] public bool response_success{get; set; }= false;
  [Export] public string response_msg{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["request"]["mode"] = request_mode;
    returnValue["request"]["mode"] = request_mode;
    returnValue["response"]["success"] = response_success;
    returnValue["response"]["success"] = response_success;
    returnValue["response"]["msg"] = response_msg;
    returnValue["response"]["msg"] = response_msg;
    return  returnValue;
  }
  public override AntennaControlService loadJson(JObject json) {
    request_mode = (int)json["request"]["mode"];
    response_success = (bool)json["response"]["success"];
    response_msg = (string)json["response"]["msg"];
    return  this;
  }
  AntennaControlService() {}
}
