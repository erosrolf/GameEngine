namespace GameEngine.Core.Ecs.Components;

public struct PositionComponent
{
    public float X;
    public float Y;

    public PositionComponent(float x, float y)
    {
        this.X = x;
        this.Y = y;
    }
}