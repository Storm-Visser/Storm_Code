using ToucanEggQuest2D.Core.Objectives;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace ToucanEggQuest2D.GUI.Elements
{
    public class ObjectiveUI
    {
        public Objective Source { get; set; }
        public Rectangle Rectangle { get; set; }
        public Image Image { get; set; }
    }
}