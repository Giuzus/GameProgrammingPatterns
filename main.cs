using Godot;
using System;

public partial class main : Node2D
{
	public void OnButtonPressed(string scene)
	{
		switch (scene)
		{
			case "command":
				GetTree().ChangeSceneToFile("res://Command/command.tscn");
				break;
			case "state":
				GetTree().ChangeSceneToFile("res://State/state.tscn");
				break;

		}

	}
}
