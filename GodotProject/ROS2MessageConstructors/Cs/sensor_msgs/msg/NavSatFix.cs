using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.sensor_msgs.msg;

[Tool]
[GlobalClass]
public partial class NavSatFix : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/NavSatFix\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"status\":{\"STATUS_NO_FIX\":0,\"STATUS_FIX\":0,\"STATUS_SBAS_FIX\":0,\"STATUS_GBAS_FIX\":0,\"status\":0,\"SERVICE_GPS\":0,\"SERVICE_GLONASS\":0,\"SERVICE_COMPASS\":0,\"SERVICE_GALILEO\":0,\"service\":0},\"latitude\":0.0,\"longitude\":0.0,\"altitude\":0.0,\"position_covariance\":[],\"COVARIANCE_TYPE_UNKNOWN\":0,\"COVARIANCE_TYPE_APPROXIMATED\":0,\"COVARIANCE_TYPE_DIAGONAL_KNOWN\":0,\"COVARIANCE_TYPE_KNOWN\":0,\"position_covariance_type\":0}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [ExportGroup("status")]
  [Export] public int status_STATUS_NO_FIX{get; set; }= 0;
  [Export] public int status_STATUS_FIX{get; set; }= 0;
  [Export] public int status_STATUS_SBAS_FIX{get; set; }= 0;
  [Export] public int status_STATUS_GBAS_FIX{get; set; }= 0;
  [Export] public int status_status{get; set; }= 0;
  [Export] public int status_SERVICE_GPS{get; set; }= 0;
  [Export] public int status_SERVICE_GLONASS{get; set; }= 0;
  [Export] public int status_SERVICE_COMPASS{get; set; }= 0;
  [Export] public int status_SERVICE_GALILEO{get; set; }= 0;
  [Export] public int status_service{get; set; }= 0;
  [Export] public double latitude{get; set; }= 0.0;
  [Export] public double longitude{get; set; }= 0.0;
  [Export] public double altitude{get; set; }= 0.0;
  [Export] public string position_covariance{get; set; }= "";
  [Export] public int COVARIANCE_TYPE_UNKNOWN{get; set; }= 0;
  [Export] public int COVARIANCE_TYPE_APPROXIMATED{get; set; }= 0;
  [Export] public int COVARIANCE_TYPE_DIAGONAL_KNOWN{get; set; }= 0;
  [Export] public int COVARIANCE_TYPE_KNOWN{get; set; }= 0;
  [Export] public int position_covariance_type{get; set; }= 0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["status"]["STATUS_NO_FIX"] = status_STATUS_NO_FIX;
    returnValue["data"]["status"]["STATUS_FIX"] = status_STATUS_FIX;
    returnValue["data"]["status"]["STATUS_SBAS_FIX"] = status_STATUS_SBAS_FIX;
    returnValue["data"]["status"]["STATUS_GBAS_FIX"] = status_STATUS_GBAS_FIX;
    returnValue["data"]["status"]["status"] = status_status;
    returnValue["data"]["status"]["SERVICE_GPS"] = status_SERVICE_GPS;
    returnValue["data"]["status"]["SERVICE_GLONASS"] = status_SERVICE_GLONASS;
    returnValue["data"]["status"]["SERVICE_COMPASS"] = status_SERVICE_COMPASS;
    returnValue["data"]["status"]["SERVICE_GALILEO"] = status_SERVICE_GALILEO;
    returnValue["data"]["status"]["service"] = status_service;
    returnValue["data"]["latitude"] = latitude;
    returnValue["data"]["longitude"] = longitude;
    returnValue["data"]["altitude"] = altitude;
    returnValue["data"]["position_covariance"] = position_covariance;
    returnValue["data"]["COVARIANCE_TYPE_UNKNOWN"] = COVARIANCE_TYPE_UNKNOWN;
    returnValue["data"]["COVARIANCE_TYPE_APPROXIMATED"] = COVARIANCE_TYPE_APPROXIMATED;
    returnValue["data"]["COVARIANCE_TYPE_DIAGONAL_KNOWN"] = COVARIANCE_TYPE_DIAGONAL_KNOWN;
    returnValue["data"]["COVARIANCE_TYPE_KNOWN"] = COVARIANCE_TYPE_KNOWN;
    returnValue["data"]["position_covariance_type"] = position_covariance_type;
    return  returnValue;
  }
  public override NavSatFix loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    status_STATUS_NO_FIX = (int)json["data"]["status"]["STATUS_NO_FIX"];
    status_STATUS_FIX = (int)json["data"]["status"]["STATUS_FIX"];
    status_STATUS_SBAS_FIX = (int)json["data"]["status"]["STATUS_SBAS_FIX"];
    status_STATUS_GBAS_FIX = (int)json["data"]["status"]["STATUS_GBAS_FIX"];
    status_status = (int)json["data"]["status"]["status"];
    status_SERVICE_GPS = (int)json["data"]["status"]["SERVICE_GPS"];
    status_SERVICE_GLONASS = (int)json["data"]["status"]["SERVICE_GLONASS"];
    status_SERVICE_COMPASS = (int)json["data"]["status"]["SERVICE_COMPASS"];
    status_SERVICE_GALILEO = (int)json["data"]["status"]["SERVICE_GALILEO"];
    status_service = (int)json["data"]["status"]["service"];
    latitude = (double)json["data"]["latitude"];
    longitude = (double)json["data"]["longitude"];
    altitude = (double)json["data"]["altitude"];
    position_covariance = (string)json["data"]["position_covariance"];
    COVARIANCE_TYPE_UNKNOWN = (int)json["data"]["COVARIANCE_TYPE_UNKNOWN"];
    COVARIANCE_TYPE_APPROXIMATED = (int)json["data"]["COVARIANCE_TYPE_APPROXIMATED"];
    COVARIANCE_TYPE_DIAGONAL_KNOWN = (int)json["data"]["COVARIANCE_TYPE_DIAGONAL_KNOWN"];
    COVARIANCE_TYPE_KNOWN = (int)json["data"]["COVARIANCE_TYPE_KNOWN"];
    position_covariance_type = (int)json["data"]["position_covariance_type"];
    return  this;
  }
  public static explicit operator NavSatFix(JObject json){
    return new NavSatFix().loadJson(json);
  }
  NavSatFix() {}
}
