namespace GameEngine.Core.Ecs.Components;

public struct VelocityComponent
{
    public float x, y;

    public VelocityComponent(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
}