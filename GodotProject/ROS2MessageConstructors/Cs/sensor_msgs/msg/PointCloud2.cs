using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.sensor_msgs.msg;

[Tool]
[GlobalClass]
public partial class PointCloud2 : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"sensor_msgs/msg/PointCloud2\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"height\":0,\"width\":0,\"fields\":{\"INT8\":0,\"UINT8\":0,\"INT16\":0,\"UINT16\":0,\"INT32\":0,\"UINT32\":0,\"FLOAT32\":0,\"FLOAT64\":0,\"name\":\"\",\"offset\":0,\"datatype\":0,\"count\":0},\"is_bigendian\":false,\"point_step\":0,\"row_step\":0,\"data\":[],\"is_dense\":false}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [Export] public int height{get; set; }= 0;
  [Export] public int width{get; set; }= 0;
  [ExportGroup("fields")]
  [Export] public int fields_INT8{get; set; }= 0;
  [Export] public int fields_UINT8{get; set; }= 0;
  [Export] public int fields_INT16{get; set; }= 0;
  [Export] public int fields_UINT16{get; set; }= 0;
  [Export] public int fields_INT32{get; set; }= 0;
  [Export] public int fields_UINT32{get; set; }= 0;
  [Export] public int fields_FLOAT32{get; set; }= 0;
  [Export] public int fields_FLOAT64{get; set; }= 0;
  [Export] public string fields_name{get; set; }= "";
  [Export] public int fields_offset{get; set; }= 0;
  [Export] public int fields_datatype{get; set; }= 0;
  [Export] public int fields_count{get; set; }= 0;
  [Export] public bool is_bigendian{get; set; }= false;
  [Export] public int point_step{get; set; }= 0;
  [Export] public int row_step{get; set; }= 0;
  [Export] public string data{get; set; }= "";
  [Export] public bool is_dense{get; set; }= false;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["height"] = height;
    returnValue["data"]["width"] = width;
    returnValue["data"]["fields"]["INT8"] = fields_INT8;
    returnValue["data"]["fields"]["UINT8"] = fields_UINT8;
    returnValue["data"]["fields"]["INT16"] = fields_INT16;
    returnValue["data"]["fields"]["UINT16"] = fields_UINT16;
    returnValue["data"]["fields"]["INT32"] = fields_INT32;
    returnValue["data"]["fields"]["UINT32"] = fields_UINT32;
    returnValue["data"]["fields"]["FLOAT32"] = fields_FLOAT32;
    returnValue["data"]["fields"]["FLOAT64"] = fields_FLOAT64;
    returnValue["data"]["fields"]["name"] = fields_name;
    returnValue["data"]["fields"]["offset"] = fields_offset;
    returnValue["data"]["fields"]["datatype"] = fields_datatype;
    returnValue["data"]["fields"]["count"] = fields_count;
    returnValue["data"]["is_bigendian"] = is_bigendian;
    returnValue["data"]["point_step"] = point_step;
    returnValue["data"]["row_step"] = row_step;
    returnValue["data"]["data"] = data;
    returnValue["data"]["is_dense"] = is_dense;
    return  returnValue;
  }
  public override PointCloud2 loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    height = (int)json["data"]["height"];
    width = (int)json["data"]["width"];
    fields_INT8 = (int)json["data"]["fields"]["INT8"];
    fields_UINT8 = (int)json["data"]["fields"]["UINT8"];
    fields_INT16 = (int)json["data"]["fields"]["INT16"];
    fields_UINT16 = (int)json["data"]["fields"]["UINT16"];
    fields_INT32 = (int)json["data"]["fields"]["INT32"];
    fields_UINT32 = (int)json["data"]["fields"]["UINT32"];
    fields_FLOAT32 = (int)json["data"]["fields"]["FLOAT32"];
    fields_FLOAT64 = (int)json["data"]["fields"]["FLOAT64"];
    fields_name = (string)json["data"]["fields"]["name"];
    fields_offset = (int)json["data"]["fields"]["offset"];
    fields_datatype = (int)json["data"]["fields"]["datatype"];
    fields_count = (int)json["data"]["fields"]["count"];
    is_bigendian = (bool)json["data"]["is_bigendian"];
    point_step = (int)json["data"]["point_step"];
    row_step = (int)json["data"]["row_step"];
    data = (string)json["data"]["data"];
    is_dense = (bool)json["data"]["is_dense"];
    return  this;
  }
  public static explicit operator PointCloud2(JObject json){
    return new PointCloud2().loadJson(json);
  }
  PointCloud2() {}
}
