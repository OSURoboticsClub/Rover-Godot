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
  [ExportGroup("request")]
  [Export] public int request_command{get; set; }= 0;
  [Export] public string request_message{get; set; }= "";
  [ExportGroup("response")]
  [Export] public bool response_success{get; set; }= false;
  [Export] public string response_result_msg{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["request"]["command"] = request_command;
    returnValue["request"]["command"] = request_command;
    returnValue["request"]["message"] = request_message;
    returnValue["request"]["message"] = request_message;
    returnValue["response"]["success"] = response_success;
    returnValue["response"]["success"] = response_success;
    returnValue["response"]["result_msg"] = response_result_msg;
    returnValue["response"]["result_msg"] = response_result_msg;
    return  returnValue;
  }
  public override HeistMechanismService loadJson(JObject json) {
    request_command = (int)json["request"]["command"];
    request_message = (string)json["request"]["message"];
    response_success = (bool)json["response"]["success"];
    response_result_msg = (string)json["response"]["result_msg"];
    return  this;
  }
  HeistMechanismService() {}
}
