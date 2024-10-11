using GameEngine.Core.Ecs.Components;

namespace GameEngine.Core.GameObject;

public class Line : SceneObject2D
{
    public (float x, float y) StartPoint { get; set; }
    public (float x, float y) EndPoint { get; set; }

    public Line(int id, (float X, float Y) startPoint, (float X, float Y) endPoint)
        : base(id, new PositionComponent((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2)) {
        StartPoint = startPoint;
        EndPoint = endPoint;
    }
}