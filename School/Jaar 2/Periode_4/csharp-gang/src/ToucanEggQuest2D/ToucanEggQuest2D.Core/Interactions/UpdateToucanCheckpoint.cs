using ToucanEggQuest2D.Core.Objectives;

namespace ToucanEggQuest2D.Core.Interactions
{
    public class UpdateToucanCheckpoint : IUpdateToucanCheckpoint
    {
        public void Set(Level level, Objective objective)
        {
            var coordinates = new Coordinates
            {
                X = objective.Coordinates.X,
                Y = objective.Coordinates.Y
            };

            level.ToucanStartCoordinates = coordinates;
        }
    }
}