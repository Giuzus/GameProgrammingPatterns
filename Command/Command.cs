using Godot;

public partial class Command : Node2D
{
	[Export]
	public Godot.Collections.Array<CharacterBody2D> actors;

	private CharacterBody2D selectedActor;


	private Color darkened;
	private Color original;


	public override void _Ready()
	{
		actors = new Godot.Collections.Array<CharacterBody2D>();

		darkened = Modulate.Darkened(0.5f);
		original = Modulate;
	}
	public override void _PhysicsProcess(double delta)
	{

		if (selectedActor == null)
			return;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		new MoveCommand(selectedActor, direction).Execute();

		if (Input.IsActionJustPressed("ui_accept"))
		{
			new JumpCommand(selectedActor).Execute();
		}
	}

	public void OnItemSelected(int index)
	{

		GetNode<ItemList>("CanvasLayer/ItemList").ReleaseFocus();


		if (index < 0 || index >= actors.Count)
			return;

		ChangeActiveActor(actors[index]);
	}

	public void OnButtonPressed()
	{
		PackedScene actor = GD.Load<PackedScene>("res://Command/actor.tscn");
		var instance = actor.Instantiate<CharacterBody2D>();
		instance.Position = GetNode<Node2D>("SpawnPoint").Position;
		instance.Name = "Actor " + actors.Count;
		AddChild(instance);
		actors.Add(instance);
		UpdateActorList();
		ChangeActiveActor(instance);
		GetNode<Button>("CanvasLayer/Button").ReleaseFocus();
	}

	private void UpdateActorList()
	{
		ItemList list = GetNode<ItemList>("CanvasLayer/ItemList");
		list.Clear();
		foreach (var actor in actors)
		{
			list.AddItem(actor.Name);
		}
		list.Select(actors.Count - 1);
	}

	private void ChangeActiveActor(CharacterBody2D actor)
	{
		if (selectedActor != null)
		{
			selectedActor.Modulate = darkened;
			actor.Modulate = original;
		}

		selectedActor = actor;
	}
}
