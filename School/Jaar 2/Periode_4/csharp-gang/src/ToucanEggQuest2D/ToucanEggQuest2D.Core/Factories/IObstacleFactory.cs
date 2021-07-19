using ToucanEggQuest2D.Core.Obstacles;

namespace ToucanEggQuest2D.Core.Factories
{
    public interface IObstacleFactory
    {
        Obstacle Create(ObstacleFactoryModel model);
        string[] Names();
    }

    public class ObstacleFactoryModel
    {
        public string Name { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}