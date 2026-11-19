using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.sensor_msgs.msg;

[Tool]
[GlobalClass]
public partial class Image : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/Image\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"height\":0,\"width\":0,\"encoding\":\"\",\"is_bigendian\":0,\"step\":0,\"data\":[]}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [Export] public int height{get; set; }= 0;
  [Export] public int width{get; set; }= 0;
  [Export] public string encoding{get; set; }= "";
  [Export] public int is_bigendian{get; set; }= 0;
  [Export] public int step{get; set; }= 0;
  [Export] public string data{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["height"] = height;
    returnValue["data"]["width"] = width;
    returnValue["data"]["encoding"] = encoding;
    returnValue["data"]["is_bigendian"] = is_bigendian;
    returnValue["data"]["step"] = step;
    returnValue["data"]["data"] = data;
    return  returnValue;
  }
  public override Image loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    height = (int)json["data"]["height"];
    width = (int)json["data"]["width"];
    encoding = (string)json["data"]["encoding"];
    is_bigendian = (int)json["data"]["is_bigendian"];
    step = (int)json["data"]["step"];
    data = (string)json["data"]["data"];
    return  this;
  }
  public static explicit operator Image(JObject json){
    return new Image().loadJson(json);
  }
  Image() {}
}
