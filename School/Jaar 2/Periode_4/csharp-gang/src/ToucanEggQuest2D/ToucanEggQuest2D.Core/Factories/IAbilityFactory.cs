using ToucanEggQuest2D.Core.Abilities;

namespace ToucanEggQuest2D.Core.Factories
{
    public interface IAbilityFactory
    {
        Ability Create(AbilityFactoryModel model);
        string[] Names();
    }

    public class AbilityFactoryModel
    {
        public string Name { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}