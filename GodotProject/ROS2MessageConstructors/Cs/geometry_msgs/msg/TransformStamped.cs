using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class TransformStamped : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/TransformStamped\",\"data\":{\"header\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"},\"child_frame_id\":\"\",\"transform\":{\"translation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"rotation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0}}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("header")]
  [ExportSubgroup("stamp")]
  [Export] public int header_stamp_sec{get; set; }= 0;
  [Export] public int header_stamp_nanosec{get; set; }= 0;
  [Export] public string header_frame_id{get; set; }= "";
  [Export] public string child_frame_id{get; set; }= "";
  [ExportGroup("transform")]
  [ExportSubgroup("translation")]
  [Export] public double transform_translation_x{get; set; }= 0.0;
  [Export] public double transform_translation_y{get; set; }= 0.0;
  [Export] public double transform_translation_z{get; set; }= 0.0;
  [ExportSubgroup("rotation")]
  [Export] public double transform_rotation_x{get; set; }= 0.0;
  [Export] public double transform_rotation_y{get; set; }= 0.0;
  [Export] public double transform_rotation_z{get; set; }= 0.0;
  [Export] public double transform_rotation_w{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["header"]["stamp"]["sec"] = header_stamp_sec;
    returnValue["data"]["header"]["stamp"]["nanosec"] = header_stamp_nanosec;
    returnValue["data"]["header"]["frame_id"] = header_frame_id;
    returnValue["data"]["child_frame_id"] = child_frame_id;
    returnValue["data"]["transform"]["translation"]["x"] = transform_translation_x;
    returnValue["data"]["transform"]["translation"]["y"] = transform_translation_y;
    returnValue["data"]["transform"]["translation"]["z"] = transform_translation_z;
    returnValue["data"]["transform"]["rotation"]["x"] = transform_rotation_x;
    returnValue["data"]["transform"]["rotation"]["y"] = transform_rotation_y;
    returnValue["data"]["transform"]["rotation"]["z"] = transform_rotation_z;
    returnValue["data"]["transform"]["rotation"]["w"] = transform_rotation_w;
    return  returnValue;
  }
  public override TransformStamped loadJson(JObject json) {
    header_stamp_sec = (int)json["data"]["header"]["stamp"]["sec"];
    header_stamp_nanosec = (int)json["data"]["header"]["stamp"]["nanosec"];
    header_frame_id = (string)json["data"]["header"]["frame_id"];
    child_frame_id = (string)json["data"]["child_frame_id"];
    transform_translation_x = (double)json["data"]["transform"]["translation"]["x"];
    transform_translation_y = (double)json["data"]["transform"]["translation"]["y"];
    transform_translation_z = (double)json["data"]["transform"]["translation"]["z"];
    transform_rotation_x = (double)json["data"]["transform"]["rotation"]["x"];
    transform_rotation_y = (double)json["data"]["transform"]["rotation"]["y"];
    transform_rotation_z = (double)json["data"]["transform"]["rotation"]["z"];
    transform_rotation_w = (double)json["data"]["transform"]["rotation"]["w"];
    return  this;
  }
  public static explicit operator TransformStamped(JObject json){
    return new TransformStamped().loadJson(json);
  }
  TransformStamped() {}
}
