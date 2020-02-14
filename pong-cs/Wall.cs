using Godot;

public class Wall : Area2D
{

    [Export]
    private int yDirection = 1;
    public void OnWallAreaEntered(Area2D area)
    {
        if (area.GetName().Equals("ball"))
        {
            Ball ball = area as Ball;
            ball.currentDirection = new Vector2(ball.currentDirection.x, yDirection);
        }
    }

}
