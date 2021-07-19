using ToucanEggQuest2D.Core.Enemies;

namespace ToucanEggQuest2D.Core.Factories
{
    public interface IEnemyFactory
    {
        Enemy Create(EnemyFactoryModel model);
        string[] Names();
    }

    public class EnemyFactoryModel
    {
        public string Name { get; set; }
        public Coordinates StartCoordinates { get; set; }
        public Coordinates EndCoordinates { get; set; }
    }
}