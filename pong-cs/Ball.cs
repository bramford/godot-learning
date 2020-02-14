using Godot;

public class Ball : Area2D
{

    [Export]
    private int speed = 250;
    [Export]
    private Vector2 initialPosition = new Vector2(512, 300);
    [Export]
    private Vector2 initialDirection = new Vector2(-1, 0);
    private Vector2 currentPosition;
    public Vector2 currentDirection { get; set; }

    public override void _Ready()
    {
        Reset();
    }

    public void Reset()
    {
        this.currentPosition = initialPosition;
        this.currentDirection = initialDirection;
    }

    public override void _Process(float delta)
    {
        this.currentPosition += currentDirection * speed * delta;

        SetPosition(this.currentPosition);
    }

}
