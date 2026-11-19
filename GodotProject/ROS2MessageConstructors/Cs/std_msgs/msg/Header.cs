using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages.std_msgs.msg;

[Tool]
[GlobalClass]
public partial class Header : ROS2Messages.BaseMessage {
  public static string jsonstring = "{\"topic\":\"\",\"msgType\":\"std_msgs/msg/Header\",\"data\":{\"stamp\":{\"sec\":0,\"nanosec\":0},\"frame_id\":\"\"}}";
  [Export]
  public string topic {get; set; }= "";
  [ExportGroup("stamp")]
  [Export] public int stamp_sec{get; set; }= 0;
  [Export] public int stamp_nanosec{get; set; }= 0;
  [Export] public string frame_id{get; set; }= "";
  public override JObject toJson() {
    JObject returnValue = JObject.Parse(jsonstring);
    returnValue["data"]["stamp"]["sec"] = stamp_sec;
    returnValue["data"]["stamp"]["nanosec"] = stamp_nanosec;
    returnValue["data"]["frame_id"] = frame_id;
    return  returnValue;
  }
  public override Header loadJson(JObject json) {
    stamp_sec = (int)json["data"]["stamp"]["sec"];
    stamp_nanosec = (int)json["data"]["stamp"]["nanosec"];
    frame_id = (string)json["data"]["frame_id"];
    return  this;
  }
  public static explicit operator Header(JObject json){
    return new Header().loadJson(json);
  }
  Header() {}
}
