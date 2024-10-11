using GameEngine.Core.Ecs.Components;

namespace GameEngine.Core.GameObject;

public abstract class SceneObject2D
{
    public int Id { get; set; }
    public PositionComponent Position { get; set; }

    public SceneObject2D(int id, PositionComponent position)
    {
        Id = id;
        Position = position;
    }
}