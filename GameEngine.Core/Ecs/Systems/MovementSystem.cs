using GameEngine.Core.Ecs.Components;
using GameEngine.Core.GameObject;
using Leopotam.EcsLite;

namespace GameEngine.Core.Ecs.Systems;

public class MovementSystem : IEcsRunSystem
{
    private readonly Scene _scene;

    public MovementSystem(Scene scene)
    {
        _scene = scene;
    }
    
    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();

        var positionPool = world.GetPool<PositionComponent>();
        var velocityPool = world.GetPool<VelocityComponent>();
        var circlePool = world.GetPool<CircleComponent>();

        var filter = world
            .Filter<PositionComponent>()
            .Inc<VelocityComponent>()
            .Inc<CircleComponent>()
            .End();

        foreach (var entity in filter)
        {
            ref var position = ref positionPool.Get(entity);
            ref var velocity = ref velocityPool.Get(entity);
            
            position.X += velocity.x;
            position.Y += velocity.y;

            var sceneObject = _scene.Objects.Find(o => o.Id == entity);
            if (sceneObject is Circle circle)
            {
                circle.Position = position;
            }
        }
    }
}