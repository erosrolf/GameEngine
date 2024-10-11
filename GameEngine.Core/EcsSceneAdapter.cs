using GameEngine.Core.Ecs.Components;
using GameEngine.Core.Ecs.Systems;
using GameEngine.Core.GameObject;
using Leopotam.EcsLite;

namespace GameEngine.Core;

public class EcsSceneAdapter
{
    private readonly EcsWorld _world;
    private readonly EcsSystems _systems;

    public EcsSceneAdapter(Scene scene)
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        _systems
            .Add(new MovementSystem(scene))
            .Init();

        InitializeEntities(scene);
    }

    private void InitializeEntities(Scene scene)
    {
        var positionPool = _world.GetPool<PositionComponent>();
        var velocityPool = _world.GetPool<VelocityComponent>();
        var circlePool = _world.GetPool<CircleComponent>();
        var linePool = _world.GetPool<LineComponent>();

        foreach (var obj in scene.Objects)
        {
            if (obj is Circle circle)
            {
                var entity = _world.NewEntity();
                ref var ecsPosition = ref positionPool.Add(entity);
                ref var ecsVelocity = ref velocityPool.Add(entity);
                ref var ecsCircle = ref circlePool.Add(entity);

                ecsPosition = circle.Position;
                ecsVelocity = circle.Velocity;
                ecsCircle.Radius = circle.Radius;
            }
            else if (obj is Line line)
            {
                var entity = _world.NewEntity();
                ref var ecsLine = ref linePool.Add(entity);
                
                ecsLine.StartPoint = line.StartPoint;
                ecsLine.EndPoint = line.EndPoint;
            }
        }
    }
    
    public void Run()
    {
        _systems.Run();
    }

    public void Destroy()
    {
        _systems.Destroy();
        _world.Destroy();
    }
}