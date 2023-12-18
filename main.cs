using Godot;
using System;

public partial class main : Node2D
{
	public void OnButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://Command/command.tscn");
	}
}
