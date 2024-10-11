using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using GameEngine.Core;
using GameEngine.Core.GameObject;

namespace GameEngine.Template;

public partial class MainWindow : Window
{
    private readonly Scene _scene;
    private EcsSceneAdapter _ecsSceneAdapter;
    private readonly Dictionary<int, Ellipse> _visualCircles;
    public MainWindow()
    {
        _scene = new Scene();
        _scene.Initialize();
        _ecsSceneAdapter = new EcsSceneAdapter(_scene);

        _visualCircles = new Dictionary<int, Ellipse>();

        InitializeVisualObjects();
        
        InitializeComponent();
    }

    private void InitializeVisualObjects()
    {
        foreach (var obj in _scene.Objects)
        {
            if (obj is Circle circle)
            {
                var visualCircle = new Ellipse()
                {
                    Width = circle.Radius * 2,
                    Height = circle.Radius * 2,
                    Fill = Brushes.Blue
                };
                
                Canvas.SetLeft(visualCircle, circle.Position.X - circle.Radius);
                Canvas.SetTop(visualCircle, circle.Position.Y - circle.Radius);

                GameCanvas.Children.Add(visualCircle);
                _visualCircles[circle.Id] = visualCircle;
            }
        }
    }

    private bool UpdateAndRender()
    {
        _ecsSceneAdapter.Run();

        foreach (var obj in _scene.Objects)
        {
            if (obj is Circle circle && _visualCircles.TryGetValue(circle.Id, out var visualCircle))
            {
                Canvas.SetLeft(visualCircle, circle.Position.X - circle.Radius);
                Canvas.SetTop(visualCircle, circle.Position.Y - circle.Radius);
            }
        }

        return true;
    }
}