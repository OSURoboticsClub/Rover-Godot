using Godot;
using Gst;
using System;

public partial class test : Node
{
	[Export]
	public ROS2Messages.std_srvs.srv.SetBool Hello;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
