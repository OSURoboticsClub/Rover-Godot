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
  [ExportGroup("request")]
  [Export] public bool request_data{get; set; }= false;
  [ExportGroup("response")]
  [Export] public bool response_success{get; set; }= false;
  [Export] public string response_message{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["service"] = service;
    returnValue["request"]["data"] = request_data;
    returnValue["response"]["success"] = response_success;
    returnValue["response"]["message"] = response_message;
    return  returnValue;
  }
  public override SetBool loadJson(JObject json) {
    service = (string)json["service"];
    request_data = (bool)json["request"]["data"];
    response_success = (bool)json["response"]["success"];
    response_message = (string)json["response"]["message"];
    return  this;
  }
  public static explicit operator SetBool(JObject json){
    return new SetBool().loadJson(json);
  }
  SetBool() {}
}
