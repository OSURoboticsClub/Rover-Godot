using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.sensor_msgs.msg;

[Tool]
[GlobalClass]
public partial class PointField : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/PointField\",\"data\":{\"INT8\":0,\"UINT8\":0,\"INT16\":0,\"UINT16\":0,\"INT32\":0,\"UINT32\":0,\"FLOAT32\":0,\"FLOAT64\":0,\"name\":\"\",\"offset\":0,\"datatype\":0,\"count\":0}}";
  [Export]
  public string topic {get; set; }= "";
  [Export] public int INT8{get; set; }= 0;
  [Export] public int UINT8{get; set; }= 0;
  [Export] public int INT16{get; set; }= 0;
  [Export] public int UINT16{get; set; }= 0;
  [Export] public int INT32{get; set; }= 0;
  [Export] public int UINT32{get; set; }= 0;
  [Export] public int FLOAT32{get; set; }= 0;
  [Export] public int FLOAT64{get; set; }= 0;
  [Export] public string name{get; set; }= "";
  [Export] public int offset{get; set; }= 0;
  [Export] public int datatype{get; set; }= 0;
  [Export] public int count{get; set; }= 0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["INT8"] = INT8;
    returnValue["data"]["UINT8"] = UINT8;
    returnValue["data"]["INT16"] = INT16;
    returnValue["data"]["UINT16"] = UINT16;
    returnValue["data"]["INT32"] = INT32;
    returnValue["data"]["UINT32"] = UINT32;
    returnValue["data"]["FLOAT32"] = FLOAT32;
    returnValue["data"]["FLOAT64"] = FLOAT64;
    returnValue["data"]["name"] = name;
    returnValue["data"]["offset"] = offset;
    returnValue["data"]["datatype"] = datatype;
    returnValue["data"]["count"] = count;
    return  returnValue;
  }
  public override PointField loadJson(JObject json) {
    INT8 = (int)json["data"]["INT8"];
    UINT8 = (int)json["data"]["UINT8"];
    INT16 = (int)json["data"]["INT16"];
    UINT16 = (int)json["data"]["UINT16"];
    INT32 = (int)json["data"]["INT32"];
    UINT32 = (int)json["data"]["UINT32"];
    FLOAT32 = (int)json["data"]["FLOAT32"];
    FLOAT64 = (int)json["data"]["FLOAT64"];
    name = (string)json["data"]["name"];
    offset = (int)json["data"]["offset"];
    datatype = (int)json["data"]["datatype"];
    count = (int)json["data"]["count"];
    return  this;
  }
  public static explicit operator PointField(JObject json){
    return new PointField().loadJson(json);
  }
  PointField() {}
}
