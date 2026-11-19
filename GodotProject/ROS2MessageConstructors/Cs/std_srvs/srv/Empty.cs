using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.std_srvs.srv;

[Tool]
[GlobalClass]
public partial class Empty : ROS2Messages.BaseRequest {
  public static string jsonstring = "{\"service\":\"\",\"srvType\":\"std_srvs/srv/Empty\",\"request\":{},\"response\":{}}";
  [Export]
  public string service {get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["service"] = service;
    return  returnValue;
  }
  public override Empty loadJson(JObject json) {
    service = (string)json["service"];
    return  this;
  }
  public static explicit operator Empty(JObject json){
    return new Empty().loadJson(json);
  }
  Empty() {}
}
