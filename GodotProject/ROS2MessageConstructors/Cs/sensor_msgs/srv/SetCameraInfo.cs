using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.sensor_msgs.srv;

[Tool]
[GlobalClass]
public partial class SetCameraInfo : ROS2Messages.BaseRequest {
  public static string jsonstring = "{\"service\":\"\",\"srvType\":\"sensor_msgs/srv/SetCameraInfo\",\"request\":{\"camera_info\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"height\":0,\"width\":0,\"distortion_model\":\"\",\"d\":[],\"k\":[],\"r\":[],\"p\":[],\"binning_x\":0,\"binning_y\":0,\"roi\":{\"x_offset\":0,\"y_offset\":0,\"height\":0,\"width\":0,\"do_rectify\":false}}},\"response\":{\"success\":false,\"status_message\":\"\"}}";
  [Export]
  public string service {get; set; }= "";
  [ExportGroup("request")]
  [ExportSubgroup("camera_info")]
  [Export] public int request_camera_info_header_stamp_sec{get; set; }= 0;
  [Export] public int request_camera_info_header_stamp_nanosec{get; set; }= 0;
  [Export] public string request_camera_info_header_frame_id{get; set; }= "";
  [Export] public int request_camera_info_height{get; set; }= 0;
  [Export] public int request_camera_info_width{get; set; }= 0;
  [Export] public string request_camera_info_distortion_model{get; set; }= "";
  [Export] public string request_camera_info_d{get; set; }= "";
  [Export] public string request_camera_info_k{get; set; }= "";
  [Export] public string request_camera_info_r{get; set; }= "";
  [Export] public string request_camera_info_p{get; set; }= "";
  [Export] public int request_camera_info_binning_x{get; set; }= 0;
  [Export] public int request_camera_info_binning_y{get; set; }= 0;
  [Export] public int request_camera_info_roi_x_offset{get; set; }= 0;
  [Export] public int request_camera_info_roi_y_offset{get; set; }= 0;
  [Export] public int request_camera_info_roi_height{get; set; }= 0;
  [Export] public int request_camera_info_roi_width{get; set; }= 0;
  [Export] public bool request_camera_info_roi_do_rectify{get; set; }= false;
  [ExportGroup("response")]
  [Export] public bool response_success{get; set; }= false;
  [Export] public string response_status_message{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["service"] = service;
    returnValue["request"]["camera_info"]["header"]["stamp"]["sec"] = request_camera_info_header_stamp_sec;
    returnValue["request"]["camera_info"]["header"]["stamp"]["nanosec"] = request_camera_info_header_stamp_nanosec;
    returnValue["request"]["camera_info"]["header"]["frame_id"] = request_camera_info_header_frame_id;
    returnValue["request"]["camera_info"]["height"] = request_camera_info_height;
    returnValue["request"]["camera_info"]["width"] = request_camera_info_width;
    returnValue["request"]["camera_info"]["distortion_model"] = request_camera_info_distortion_model;
    returnValue["request"]["camera_info"]["d"] = request_camera_info_d;
    returnValue["request"]["camera_info"]["k"] = request_camera_info_k;
    returnValue["request"]["camera_info"]["r"] = request_camera_info_r;
    returnValue["request"]["camera_info"]["p"] = request_camera_info_p;
    returnValue["request"]["camera_info"]["binning_x"] = request_camera_info_binning_x;
    returnValue["request"]["camera_info"]["binning_y"] = request_camera_info_binning_y;
    returnValue["request"]["camera_info"]["roi"]["x_offset"] = request_camera_info_roi_x_offset;
    returnValue["request"]["camera_info"]["roi"]["y_offset"] = request_camera_info_roi_y_offset;
    returnValue["request"]["camera_info"]["roi"]["height"] = request_camera_info_roi_height;
    returnValue["request"]["camera_info"]["roi"]["width"] = request_camera_info_roi_width;
    returnValue["request"]["camera_info"]["roi"]["do_rectify"] = request_camera_info_roi_do_rectify;
    returnValue["response"]["success"] = response_success;
    returnValue["response"]["status_message"] = response_status_message;
    return  returnValue;
  }
  public override SetCameraInfo loadJson(JObject json) {
    service = (string)json["service"];
    request_camera_info_header_stamp_sec = (int)json["request"]["camera_info"]["header"]["stamp"]["sec"];
    request_camera_info_header_stamp_nanosec = (int)json["request"]["camera_info"]["header"]["stamp"]["nanosec"];
    request_camera_info_header_frame_id = (string)json["request"]["camera_info"]["header"]["frame_id"];
    request_camera_info_height = (int)json["request"]["camera_info"]["height"];
    request_camera_info_width = (int)json["request"]["camera_info"]["width"];
    request_camera_info_distortion_model = (string)json["request"]["camera_info"]["distortion_model"];
    request_camera_info_d = (string)json["request"]["camera_info"]["d"];
    request_camera_info_k = (string)json["request"]["camera_info"]["k"];
    request_camera_info_r = (string)json["request"]["camera_info"]["r"];
    request_camera_info_p = (string)json["request"]["camera_info"]["p"];
    request_camera_info_binning_x = (int)json["request"]["camera_info"]["binning_x"];
    request_camera_info_binning_y = (int)json["request"]["camera_info"]["binning_y"];
    request_camera_info_roi_x_offset = (int)json["request"]["camera_info"]["roi"]["x_offset"];
    request_camera_info_roi_y_offset = (int)json["request"]["camera_info"]["roi"]["y_offset"];
    request_camera_info_roi_height = (int)json["request"]["camera_info"]["roi"]["height"];
    request_camera_info_roi_width = (int)json["request"]["camera_info"]["roi"]["width"];
    request_camera_info_roi_do_rectify = (bool)json["request"]["camera_info"]["roi"]["do_rectify"];
    response_success = (bool)json["response"]["success"];
    response_status_message = (string)json["response"]["status_message"];
    return  this;
  }
  public static explicit operator SetCameraInfo(JObject json){
    return new SetCameraInfo().loadJson(json);
  }
  SetCameraInfo() {}
}
