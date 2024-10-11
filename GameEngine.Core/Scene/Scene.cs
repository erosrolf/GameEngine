using GameEngine.Core.GameObject;
using Leopotam.EcsLite;

namespace GameEngine.Core.Scene;

public class Scene
{
    public List<SceneObject> Objects = new List<SceneObject>();

    public void Initialize()
    {
    }

    public void InitializeEntities(EcsWorld ecsWorld)
    {
        foreach (var obj in Objects)
        {
            
        }
    }
}