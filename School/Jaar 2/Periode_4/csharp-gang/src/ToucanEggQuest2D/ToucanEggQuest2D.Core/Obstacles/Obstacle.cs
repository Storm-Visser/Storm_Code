using ToucanEggQuest2D.Core.Collisions.Models;

namespace ToucanEggQuest2D.Core.Obstacles
{
    public abstract class Obstacle : Collider
    {
        public Texture Texture { get; set; }
    }
}