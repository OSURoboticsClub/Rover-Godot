using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.geometry_msgs.msg;

[Tool]
[GlobalClass]
public partial class Twist : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"geometry_msgs/msg/Twist\",\"data\":{\"linear\":{\"x\":0.0,\"y\":0.0,\"z\":0.0},\"angular\":{\"x\":0.0,\"y\":0.0,\"z\":0.0}}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("linear")]
  [Export] public double linear_x{get; set; }= 0.0;
  [Export] public double linear_y{get; set; }= 0.0;
  [Export] public double linear_z{get; set; }= 0.0;
  [ExportGroup("angular")]
  [Export] public double angular_x{get; set; }= 0.0;
  [Export] public double angular_y{get; set; }= 0.0;
  [Export] public double angular_z{get; set; }= 0.0;
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["linear"]["x"] = linear_x;
    returnValue["data"]["linear"]["y"] = linear_y;
    returnValue["data"]["linear"]["z"] = linear_z;
    returnValue["data"]["angular"]["x"] = angular_x;
    returnValue["data"]["angular"]["y"] = angular_y;
    returnValue["data"]["angular"]["z"] = angular_z;
    return  returnValue;
  }
  public override Twist loadJson(JObject json) {
    linear_x = (double)json["data"]["linear"]["x"];
    linear_y = (double)json["data"]["linear"]["y"];
    linear_z = (double)json["data"]["linear"]["z"];
    angular_x = (double)json["data"]["angular"]["x"];
    angular_y = (double)json["data"]["angular"]["y"];
    angular_z = (double)json["data"]["angular"]["z"];
    return  this;
  }
  public static explicit operator Twist(JObject json){
    return new Twist().loadJson(json);
  }
  Twist() {}
}
