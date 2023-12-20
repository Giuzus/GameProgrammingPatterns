using Godot;
using System;

public partial class back : Node2D
{
	public void OnButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://main.tscn");
	}
}
