using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.sensor_msgs.msg;

[Tool]
[GlobalClass]
public partial class CameraInfo : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/CameraInfo\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"height\":0,\"width\":0,\"distortion_model\":\"\",\"d\":[],\"k\":[],\"r\":[],\"p\":[],\"binning_x\":0,\"binning_y\":0,\"roi\":{\"x_offset\":0,\"y_offset\":0,\"height\":0,\"width\":0,\"do_rectify\":false}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [Export] public int height{get; set; }= 0;
  [Export] public int width{get; set; }= 0;
  [Export] public string distortion_model{get; set; }= "";
  [Export] public string d{get; set; }= "";
  [Export] public string k{get; set; }= "";
  [Export] public string r{get; set; }= "";
  [Export] public string p{get; set; }= "";
  [Export] public int binning_x{get; set; }= 0;
  [Export] public int binning_y{get; set; }= 0;
  [ExportGroup("roi")]
  [Export] public int roi_x_offset{get; set; }= 0;
  [Export] public int roi_y_offset{get; set; }= 0;
  [Export] public int roi_height{get; set; }= 0;
  [Export] public int roi_width{get; set; }= 0;
  [Export] public bool roi_do_rectify{get; set; }= false;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["height"] = height;
    returnValue["data"]["width"] = width;
    returnValue["data"]["distortion_model"] = distortion_model;
    returnValue["data"]["d"] = d;
    returnValue["data"]["k"] = k;
    returnValue["data"]["r"] = r;
    returnValue["data"]["p"] = p;
    returnValue["data"]["binning_x"] = binning_x;
    returnValue["data"]["binning_y"] = binning_y;
    returnValue["data"]["roi"]["x_offset"] = roi_x_offset;
    returnValue["data"]["roi"]["y_offset"] = roi_y_offset;
    returnValue["data"]["roi"]["height"] = roi_height;
    returnValue["data"]["roi"]["width"] = roi_width;
    returnValue["data"]["roi"]["do_rectify"] = roi_do_rectify;
    return  returnValue;
  }
  public override CameraInfo loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    height = (int)json["data"]["height"];
    width = (int)json["data"]["width"];
    distortion_model = (string)json["data"]["distortion_model"];
    d = (string)json["data"]["d"];
    k = (string)json["data"]["k"];
    r = (string)json["data"]["r"];
    p = (string)json["data"]["p"];
    binning_x = (int)json["data"]["binning_x"];
    binning_y = (int)json["data"]["binning_y"];
    roi_x_offset = (int)json["data"]["roi"]["x_offset"];
    roi_y_offset = (int)json["data"]["roi"]["y_offset"];
    roi_height = (int)json["data"]["roi"]["height"];
    roi_width = (int)json["data"]["roi"]["width"];
    roi_do_rectify = (bool)json["data"]["roi"]["do_rectify"];
    return  this;
  }
  public static explicit operator CameraInfo(JObject json){
    return new CameraInfo().loadJson(json);
  }
  CameraInfo() {}
}
