using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages;

[Tool]
[GlobalClass]
public abstract partial class BaseRequest : Resource {
    public abstract JObject toJson();
    public abstract BaseRequest loadJson(JObject json);
}
