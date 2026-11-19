using Godot;
using Newtonsoft.Json.Linq;
using System;

namespace ROS2Messages;

[Tool]
[GlobalClass]
public abstract partial class BaseMessage : Resource {
    public abstract JObject toJson();
    public abstract BaseMessage loadJson(JObject json);
}
