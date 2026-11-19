using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class Transform : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Transform\",\"data\":{\"translation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"rotation\":{\"x\":0.0,\"y\":0.0,\"z\":0.0,\"w\":0.0}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("translation")]
  [Export] public double translation_x{get; set; }= 0.0;
  [Export] public double translation_y{get; set; }= 0.0;
  [Export] public double translation_z{get; set; }= 0.0;
  [ExportGroup("rotation")]
  [Export] public double rotation_x{get; set; }= 0.0;
  [Export] public double rotation_y{get; set; }= 0.0;
  [Export] public double rotation_z{get; set; }= 0.0;
  [Export] public double rotation_w{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["translation"]["x"] = translation_x;
    returnValue["data"]["translation"]["y"] = translation_y;
    returnValue["data"]["translation"]["z"] = translation_z;
    returnValue["data"]["rotation"]["x"] = rotation_x;
    returnValue["data"]["rotation"]["y"] = rotation_y;
    returnValue["data"]["rotation"]["z"] = rotation_z;
    returnValue["data"]["rotation"]["w"] = rotation_w;
    return  returnValue;
  }
  public override Transform loadJson(JObject json) {
    translation_x = (double)json["data"]["translation"]["x"];
    translation_y = (double)json["data"]["translation"]["y"];
    translation_z = (double)json["data"]["translation"]["z"];
    rotation_x = (double)json["data"]["rotation"]["x"];
    rotation_y = (double)json["data"]["rotation"]["y"];
    rotation_z = (double)json["data"]["rotation"]["z"];
    rotation_w = (double)json["data"]["rotation"]["w"];
    return  this;
  }
  public static explicit operator Transform(JObject json){
    return new Transform().loadJson(json);
  }
  Transform() {}
}
