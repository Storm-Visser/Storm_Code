namespace ToucanEggQuest2D.Core.Interactions
{
    public class RespawnToucan : IRespawnToucan
    {
        public void Respawn(Level level)
        {
            var coordinates = new Coordinates
            {
                X = level.ToucanStartCoordinates.X,
                Y = level.ToucanStartCoordinates.Y
            };

            level.Toucan.Coordinates = coordinates;
        }
    }
}