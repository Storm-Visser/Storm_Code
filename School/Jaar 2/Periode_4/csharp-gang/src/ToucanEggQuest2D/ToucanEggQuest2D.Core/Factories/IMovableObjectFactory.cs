using ToucanEggQuest2D.Core.MoveableObjects;

namespace ToucanEggQuest2D.Core.Factories
{
    public interface IMovableObjectFactory
    {
        MovableObject Create(MovableObjectFactoryModel model);
        string[] Names();
    }

    public class MovableObjectFactoryModel
    {
        public string Name { get; set; }
        public Coordinates StartCoordinates { get; set; }
        public Coordinates EndCoordinates { get; set; }
    }
}