using game_programming_patterns.Command;
using Godot;

public class MoveCommand : ICommand
{
    public const float Speed = 300.0f;
    private readonly CharacterBody2D actor;
    private readonly Vector2 direction;


    public MoveCommand(CharacterBody2D actor, Vector2 direction)
    {
        this.actor = actor;
        this.direction = direction;
    }

    public void Execute()
    {
        Vector2 velocity = actor.Velocity;

        if (direction != Vector2.Zero)
        {
            velocity.X = direction.X * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(actor.Velocity.X, 0, Speed);
        }

        actor.Velocity = velocity;
    }
}