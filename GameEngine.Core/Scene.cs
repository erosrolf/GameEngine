using GameEngine.Core.Ecs.Components;
using GameEngine.Core.GameObject;
using Leopotam.EcsLite;

namespace GameEngine.Core;

public class Scene
{
    public List<SceneObject2D> Objects = new List<SceneObject2D>();

    public void Initialize()
    {
        Objects.Add(new Line(1, (0, 0), (10, 0)));
        Objects.Add(new Line(2, (10, 0), (10, 10)));
        Objects.Add(new Line(3, (10, 10), (0, 10)));
        Objects.Add(new Line(4, (0, 10), (0, 0)));
        
        Objects.Add(new Circle(5, new PositionComponent(5, 4), 1.0f));
    }
}