using ToucanEggQuest2D.Core.SemiObstacles;

namespace ToucanEggQuest2D.Core.Factories
{
    public interface ISemiObstacleFactory
    {
        SemiObstacle Create(SemiObstacleFactoryModel model);
        string[] Names();
    }

    public class SemiObstacleFactoryModel
    {
        public string Name { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}