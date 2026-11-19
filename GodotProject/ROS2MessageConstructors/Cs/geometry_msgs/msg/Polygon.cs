using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class Polygon : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Polygon\",\"data\":{\"points\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("points")]
  [Export] public double points_x{get; set; }= 0.0;
  [Export] public double points_y{get; set; }= 0.0;
  [Export] public double points_z{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["points"]["x"] = points_x;
    returnValue["data"]["points"]["y"] = points_y;
    returnValue["data"]["points"]["z"] = points_z;
    return  returnValue;
  }
  public override Polygon loadJson(JObject json) {
    points_x = (double)json["data"]["points"]["x"];
    points_y = (double)json["data"]["points"]["y"];
    points_z = (double)json["data"]["points"]["z"];
    return  this;
  }
  public static explicit operator Polygon(JObject json){
    return new Polygon().loadJson(json);
  }
  Polygon() {}
}
