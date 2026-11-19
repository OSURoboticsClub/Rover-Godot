using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.sensor_msgs.msg;

[Tool]
[GlobalClass]
public partial class RegionOfInterest : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/RegionOfInterest\",\"data\":{\"x_offset\":0,\"y_offset\":0,\"height\":0,\"width\":0,\"do_rectify\":false}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public int x_offset{get; set; }= 0;
  [Export] public int y_offset{get; set; }= 0;
  [Export] public int height{get; set; }= 0;
  [Export] public int width{get; set; }= 0;
  [Export] public bool do_rectify{get; set; }= false;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["x_offset"] = x_offset;
    returnValue["data"]["y_offset"] = y_offset;
    returnValue["data"]["height"] = height;
    returnValue["data"]["width"] = width;
    returnValue["data"]["do_rectify"] = do_rectify;
    return  returnValue;
  }
  public override RegionOfInterest loadJson(JObject json) {
    x_offset = (int)json["data"]["x_offset"];
    y_offset = (int)json["data"]["y_offset"];
    height = (int)json["data"]["height"];
    width = (int)json["data"]["width"];
    do_rectify = (bool)json["data"]["do_rectify"];
    return  this;
  }
  public static explicit operator RegionOfInterest(JObject json){
    return new RegionOfInterest().loadJson(json);
  }
  RegionOfInterest() {}
}
