using System.Collections.Generic;
using System.Linq;

namespace ToucanEggQuest2D.GUI
{
    public class Utilities
    {
        /// <summary>
        /// Checks if the source is colliding from above.
        /// </summary>
        /// <returns>
        ///  -1: Source is not colliding
        ///   0: Source has collided
        /// > 0: Source is this far away from the colliding object
        /// </returns>
        public static int CollisionDistance(List<int> collisions)
        {
            if (collisions.Any(x => x == 0))
                return 0;

            var minCollisionDistance =
            (
                from int c in collisions
                where c > 0
                select (int?)c
            ).Min();

            if (minCollisionDistance == null)
                return -1;
            else
                return (int)minCollisionDistance;
        }
    }
}