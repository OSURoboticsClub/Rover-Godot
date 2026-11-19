using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.sensor_msgs.msg;

[Tool]
[GlobalClass]
public partial class Range : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/Range\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"ULTRASOUND=0\":0,\"INFRARED=1\":0,\"radiation_type\":0,\"field_of_view\":0.0,\"min_range\":0.0,\"max_range\":0.0,\"range\":0.0}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [Export] public int ULTRASOUND=0{get; set; }= 0;
  [Export] public int INFRARED=1{get; set; }= 0;
  [Export] public int radiation_type{get; set; }= 0;
  [Export] public double field_of_view{get; set; }= 0.0;
  [Export] public double min_range{get; set; }= 0.0;
  [Export] public double max_range{get; set; }= 0.0;
  [Export] public double range{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["ULTRASOUND=0"] = ULTRASOUND=0;
    returnValue["data"]["INFRARED=1"] = INFRARED=1;
    returnValue["data"]["radiation_type"] = radiation_type;
    returnValue["data"]["field_of_view"] = field_of_view;
    returnValue["data"]["min_range"] = min_range;
    returnValue["data"]["max_range"] = max_range;
    returnValue["data"]["range"] = range;
    return  returnValue;
  }
  public override Range loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    ULTRASOUND=0 = (int)json["data"]["ULTRASOUND=0"];
    INFRARED=1 = (int)json["data"]["INFRARED=1"];
    radiation_type = (int)json["data"]["radiation_type"];
    field_of_view = (double)json["data"]["field_of_view"];
    min_range = (double)json["data"]["min_range"];
    max_range = (double)json["data"]["max_range"];
    range = (double)json["data"]["range"];
    return  this;
  }
  public static explicit operator Range(JObject json){
    return new Range().loadJson(json);
  }
  Range() {}
}
