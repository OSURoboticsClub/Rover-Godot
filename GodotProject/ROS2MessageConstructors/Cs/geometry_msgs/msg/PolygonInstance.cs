using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class PolygonInstance : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/PolygonInstance\",\"data\":{\"polygon\":{\"points\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}},\"id\":0}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("polygon")]
  [ExportSubgroup("points")]
  [Export] public double polygon_points_x{get; set; }= 0.0;
  [Export] public double polygon_points_y{get; set; }= 0.0;
  [Export] public double polygon_points_z{get; set; }= 0.0;
  [Export] public int id{get; set; }= 0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["polygon"]["points"]["x"] = polygon_points_x;
    returnValue["data"]["polygon"]["points"]["y"] = polygon_points_y;
    returnValue["data"]["polygon"]["points"]["z"] = polygon_points_z;
    returnValue["data"]["id"] = id;
    return  returnValue;
  }
  public override PolygonInstance loadJson(JObject json) {
    polygon_points_x = (double)json["data"]["polygon"]["points"]["x"];
    polygon_points_y = (double)json["data"]["polygon"]["points"]["y"];
    polygon_points_z = (double)json["data"]["polygon"]["points"]["z"];
    id = (int)json["data"]["id"];
    return  this;
  }
  public static explicit operator PolygonInstance(JObject json){
    return new PolygonInstance().loadJson(json);
  }
  PolygonInstance() {}
}
