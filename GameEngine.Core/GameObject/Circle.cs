using GameEngine.Core.Ecs.Components;

namespace GameEngine.Core.GameObject;

public class Circle : SceneObject2D
{
    public float Radius { get; set; }
    public VelocityComponent Velocity { get; set; }

    public Circle(int id, PositionComponent position, float radius) : base(id, position)
    {
        Radius = radius;
    }
}