using Godot;
using Godot.Collections;
using ROS2Messages;

[Tool]
[GlobalClass]
public partial class ServiceSelector : Resource
{
    private Enums.Services _type = Enums.Services.SetBool;
    [Export]
    public Enums.Services Type
    {
        get => _type;
        set
        {
            if (_type == value) return;
            _type = value;
            
            // Optional: Clear incompatible resource when switching enum
            // Config = null; 
            NotifyPropertyListChanged();
        }
    }

    // Store the active global class instance here
    public BaseRequest Message { get; set; }

    public override Array<Dictionary> _GetPropertyList()
    {
        var properties = new Array<Dictionary>();

        // Pick the GlobalClass name based on the current enum
        string targetGlobalClass = ROS2Messages.Enums.GetServiceGlobalClassFromEnum(Type);
        GD.Print($"[ServiceSelector] Looking for GlobalClass: '{targetGlobalClass}'");

        properties.Add(new Dictionary
        {
            { "name", nameof(Message) },
            { "type", (int)Variant.Type.Object },
            { "hint", (int)PropertyHint.ResourceType },
            { "hint_string", targetGlobalClass },
            { "usage", (int)PropertyUsageFlags.Default }
        });

        return properties;
    }

    public override Variant _Get(StringName property)
    {
        if (property == nameof(Message))
            return Message;

        return default;
    }

    public override bool _Set(StringName property, Variant value)
    {
        GD.Print(property, "  ", nameof(Message));
        if (property == nameof(Message))
        {
            Message = value.As<BaseRequest>();
            return true;
        }
        return false;
    }
}
