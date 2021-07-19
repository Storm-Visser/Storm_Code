using ToucanEggQuest2D.Core.Collisions.Models;

namespace ToucanEggQuest2D.Core.Collisions
{
    public class Collision : ICollision
    {
        public bool CollidingFromLeft(Collider source, Collider target)
        {
            var sourceLeftSide = source.Coordinates.X;
            var sourceRightSide = sourceLeftSide + source.Dimensions.Width;
            var sourceTopSide = source.Coordinates.Y;
            var sourceBottomSide = sourceTopSide + source.Dimensions.Height;
            var targetLeftSide = target.Coordinates.X;
            var targetTopSide = target.Coordinates.Y;
            var targetBottomSide = targetTopSide + target.Dimensions.Height;

            if ((sourceTopSide > targetTopSide && sourceTopSide < targetBottomSide) ||
                (sourceBottomSide > targetTopSide && sourceBottomSide < targetBottomSide) ||
                (sourceTopSide <= targetTopSide && sourceBottomSide >= targetBottomSide))
            {
                if (sourceRightSide >= targetLeftSide && sourceLeftSide <= targetLeftSide)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CollidingFromRight(Collider source, Collider target)
        {
            var sourceLeftSide = source.Coordinates.X;
            var sourceRightSide = sourceLeftSide + source.Dimensions.Width;
            var sourceTopSide = source.Coordinates.Y;
            var sourceBottomSide = sourceTopSide + source.Dimensions.Height;
            var targetLeftSide = target.Coordinates.X;
            var targetRightSide = targetLeftSide + target.Dimensions.Width;
            var targetTopSide = target.Coordinates.Y;
            var targetBottomSide = targetTopSide + target.Dimensions.Height;

            if ((sourceTopSide > targetTopSide && sourceTopSide < targetBottomSide) ||
                (sourceBottomSide > targetTopSide && sourceBottomSide < targetBottomSide) ||
                (sourceTopSide <= targetTopSide && sourceBottomSide >= targetBottomSide))
            {
                if (sourceLeftSide <= targetRightSide && sourceRightSide >= targetRightSide)
                {
                    return true;
                }
            }

            return false;
        }

        public int CollidingFromAbove(Collider source, Collider target)
        {
            var sourceLeftSide = source.Coordinates.X;
            var sourceRightSide = sourceLeftSide + source.Dimensions.Width;
            var sourceTopSide = source.Coordinates.Y;
            var sourceBottomSide = sourceTopSide + source.Dimensions.Height;
            var targetLeftSide = target.Coordinates.X;
            var targetRightSide = targetLeftSide + target.Dimensions.Width;
            var targetTopSide = target.Coordinates.Y;

            if ((sourceLeftSide >= targetLeftSide && sourceLeftSide <= targetRightSide) ||
                (sourceRightSide >= targetLeftSide && sourceRightSide <= targetRightSide) ||
                (sourceLeftSide <= targetLeftSide && sourceRightSide >= targetRightSide))
            {
                var diff = targetTopSide - sourceBottomSide;
                var diffTreshold = diff <= 20;
                if (sourceTopSide < targetTopSide &&
                    (sourceBottomSide >= targetTopSide || diffTreshold))
                {
                    if (diffTreshold && diff != 0)
                        return diff;
                    return 0;
                }
            }

            return -1;
        }
    }
}