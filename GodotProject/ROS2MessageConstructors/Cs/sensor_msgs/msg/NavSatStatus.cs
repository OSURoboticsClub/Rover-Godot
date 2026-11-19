using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.sensor_msgs.msg;

[Tool]
[GlobalClass]
public partial class NavSatStatus : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/NavSatStatus\",\"data\":{\"STATUS_NO_FIX\":0,\"STATUS_FIX\":0,\"STATUS_SBAS_FIX\":0,\"STATUS_GBAS_FIX\":0,\"status\":0,\"SERVICE_GPS\":0,\"SERVICE_GLONASS\":0,\"SERVICE_COMPASS\":0,\"SERVICE_GALILEO\":0,\"service\":0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public int STATUS_NO_FIX{get; set; }= 0;
  [Export] public int STATUS_FIX{get; set; }= 0;
  [Export] public int STATUS_SBAS_FIX{get; set; }= 0;
  [Export] public int STATUS_GBAS_FIX{get; set; }= 0;
  [Export] public int status{get; set; }= 0;
  [Export] public int SERVICE_GPS{get; set; }= 0;
  [Export] public int SERVICE_GLONASS{get; set; }= 0;
  [Export] public int SERVICE_COMPASS{get; set; }= 0;
  [Export] public int SERVICE_GALILEO{get; set; }= 0;
  [Export] public int service{get; set; }= 0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["STATUS_NO_FIX"] = STATUS_NO_FIX;
    returnValue["data"]["STATUS_FIX"] = STATUS_FIX;
    returnValue["data"]["STATUS_SBAS_FIX"] = STATUS_SBAS_FIX;
    returnValue["data"]["STATUS_GBAS_FIX"] = STATUS_GBAS_FIX;
    returnValue["data"]["status"] = status;
    returnValue["data"]["SERVICE_GPS"] = SERVICE_GPS;
    returnValue["data"]["SERVICE_GLONASS"] = SERVICE_GLONASS;
    returnValue["data"]["SERVICE_COMPASS"] = SERVICE_COMPASS;
    returnValue["data"]["SERVICE_GALILEO"] = SERVICE_GALILEO;
    returnValue["data"]["service"] = service;
    return  returnValue;
  }
  public override NavSatStatus loadJson(JObject json) {
    STATUS_NO_FIX = (int)json["data"]["STATUS_NO_FIX"];
    STATUS_FIX = (int)json["data"]["STATUS_FIX"];
    STATUS_SBAS_FIX = (int)json["data"]["STATUS_SBAS_FIX"];
    STATUS_GBAS_FIX = (int)json["data"]["STATUS_GBAS_FIX"];
    status = (int)json["data"]["status"];
    SERVICE_GPS = (int)json["data"]["SERVICE_GPS"];
    SERVICE_GLONASS = (int)json["data"]["SERVICE_GLONASS"];
    SERVICE_COMPASS = (int)json["data"]["SERVICE_COMPASS"];
    SERVICE_GALILEO = (int)json["data"]["SERVICE_GALILEO"];
    service = (int)json["data"]["service"];
    return  this;
  }
  public static explicit operator NavSatStatus(JObject json){
    return new NavSatStatus().loadJson(json);
  }
  NavSatStatus() {}
}
