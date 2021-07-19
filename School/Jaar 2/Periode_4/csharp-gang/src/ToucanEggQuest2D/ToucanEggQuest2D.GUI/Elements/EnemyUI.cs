using ToucanEggQuest2D.Core.Enemies;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace ToucanEggQuest2D.GUI.Models
{
    public class EnemyUI
    {
        public Enemy Source { get; set; }
        public Rectangle Rectangle { get; set; }
        public Image Image { get; set; }
    }
}