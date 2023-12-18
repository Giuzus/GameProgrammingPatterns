using game_programming_patterns.Command;
using Godot;

class JumpCommand : ICommand
{
    public const float JumpVelocity = -600.0f;

    private readonly CharacterBody2D actor;

    public JumpCommand(CharacterBody2D actor)
    {
        this.actor = actor;
    }

    public void Execute()
    {
        Vector2 velocity = actor.Velocity;

        // Handle Jump.
        if (actor.IsOnFloor())
            velocity.Y = JumpVelocity;

        actor.Velocity = velocity;
    }


}