using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.rover2_status_interface.srv;

[Tool]
[GlobalClass]
public partial class LatencySize : ROS2Messages.BaseRequest {
  public static string jsonstring = "{\"service\":\"\",\"srvType\":\"rover2_status_interface/srv/LatencySize\",\"request\":{\"dummydata\":[]},\"response\":{\"receivetime\":{\"sec\":0,\"nanosec\":0}}}";
  [Export]
  public string service {get; set; }= "";
  [ExportGroup("request")]
  [Export] public string request_dummydata{get; set; }= "";
  [ExportGroup("response")]
  [ExportSubgroup("receivetime")]
  [Export] public int response_receivetime_sec{get; set; }= 0;
  [Export] public int response_receivetime_nanosec{get; set; }= 0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["request"]["dummydata"] = request_dummydata;
    returnValue["request"]["dummydata"] = request_dummydata;
    returnValue["response"]["receivetime"]["sec"] = response_receivetime_sec;
    returnValue["response"]["receivetime"]["sec"] = response_receivetime_sec;
    returnValue["response"]["receivetime"]["nanosec"] = response_receivetime_nanosec;
    returnValue["response"]["receivetime"]["nanosec"] = response_receivetime_nanosec;
    return  returnValue;
  }
  public override LatencySize loadJson(JObject json) {
    request_dummydata = (string)json["request"]["dummydata"];
    response_receivetime_sec = (int)json["response"]["receivetime"]["sec"];
    response_receivetime_nanosec = (int)json["response"]["receivetime"]["nanosec"];
    return  this;
  }
  LatencySize() {}
}
