using ToucanEggQuest2D.Core.Obstacles;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace ToucanEggQuest2D.GUI.Elements
{
    public class ObstacleUI
    {
        public Obstacle Source { get; set; }
        public Rectangle Rectangle { get; set; }
        public Image Image { get; set; }
    }
}