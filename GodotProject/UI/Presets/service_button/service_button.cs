using Godot;
using System;

public partial class service_button : Button
{
	[Export]
    public ServiceSelector ServiceConfig { get; set; }
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Pressed += on_press_fun;
		GD.Print(((ROS2Messages.rover2_status_interface.srv.NodeLog)ServiceConfig.Message).request_enable);
		string msg = ServiceConfig.Message.toJson().ToString();
		GD.Print(msg);
	}
	public void on_press_fun()
	{
		string msg = ServiceConfig.Message.toJson().ToString();
		GD.Print(msg);
		
		UdpController.inst.SendClientReq(msg);
	}
}
