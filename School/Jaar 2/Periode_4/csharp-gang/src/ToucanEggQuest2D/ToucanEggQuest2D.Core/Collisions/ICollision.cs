using ToucanEggQuest2D.Core.Collisions.Models;

namespace ToucanEggQuest2D.Core.Collisions
{
    public interface ICollision
    {
        bool CollidingFromLeft(Collider source, Collider target);
        bool CollidingFromRight(Collider source, Collider target);
        /// <summary>
        /// Checks if the source is colliding from above.
        /// </summary>
        /// <returns>
        ///  -1: Source is not colliding
        ///   0: Source has collided
        /// > 0: Source is this far away from the colliding object
        /// </returns>
        int CollidingFromAbove(Collider source, Collider target);
    }
}