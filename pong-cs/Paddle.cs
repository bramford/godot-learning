using Godot;
using System;

public class Paddle : Area2D
{

    private static readonly String INPUT_ROTATE_SUFFIX = "Rotate";
    private static readonly String INPUT_MOVE_UP_SUFFIX = "MoveUp";
    private static readonly String INPUT_MOVE_DOWN_SUFFIX = "MoveDown";
    [Export]
    private int speed = 500;
    [Export]
    private int ballDirection = 1;
    private RandomNumberGenerator randomNumberGenerator;

    public override void _Ready()
    {
        this.randomNumberGenerator = new RandomNumberGenerator();
    }

    public override void _Process(float delta)
    {
        String name = GetName();
        Vector2 currentPosition = GetPosition();
        var rotation = GetRotationDegrees();

        if (Input.IsActionJustReleased(name + INPUT_ROTATE_SUFFIX))
        {
            SetRotationDegrees((rotation + 45) % 360);
        }

        if (Input.IsActionPressed(name + INPUT_MOVE_UP_SUFFIX) && currentPosition.y > 40)
        {
            currentPosition = new Vector2(currentPosition.x, currentPosition.y - speed * delta);
        }

        if (Input.IsActionPressed(name + INPUT_MOVE_DOWN_SUFFIX) && currentPosition.y < 560)
        {
            currentPosition = new Vector2(currentPosition.x, currentPosition.y + speed * delta);
        }

        SetPosition(currentPosition);
    }

    public void OnPaddleAreaEntered(Area2D area)
    {
        if (area.GetName().Equals("ball"))
        {
            Ball ball = area as Ball;
            Vector2 newDirection = new Vector2(ballDirection, this.randomNumberGenerator.Randf() * 2 - 1).Normalized();
            ball.currentDirection = newDirection;
        }
    }

}
