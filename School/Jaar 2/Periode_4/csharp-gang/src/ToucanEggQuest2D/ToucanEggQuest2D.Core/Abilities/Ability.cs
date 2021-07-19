using ToucanEggQuest2D.Core.Collisions.Models;

namespace ToucanEggQuest2D.Core.Abilities
{
    public abstract class Ability : Collider
    {
        public bool Active { get; set; }
        public int DurationInSeconds { get; set; }
        public int CurrentDurationInMiliseconds { get; set; }
        public Texture Texture { get; set; }
    }
}