using ToucanEggQuest2D.Core.Objectives;

namespace ToucanEggQuest2D.Core.Factories
{
    public interface IObjectiveFactory
    {
        Objective Create(ObjectiveFactoryModel model);
        string[] Names();
    }

    public class ObjectiveFactoryModel
    {
        public string Name { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}