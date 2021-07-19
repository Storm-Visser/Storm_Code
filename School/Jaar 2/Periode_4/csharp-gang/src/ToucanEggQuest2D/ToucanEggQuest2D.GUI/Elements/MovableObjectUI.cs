using ToucanEggQuest2D.Core.MoveableObjects;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace ToucanEggQuest2D.GUI.Elements
{
    public class MovableObjectUI
    {
        public MovableObject Source { get; set; }
        public Rectangle Rectangle { get; set; }
        public Image Image { get; set; }
    }
}