using ToucanEggQuest2D.Core.Abilities;

namespace ToucanEggQuest2D.Core.Interactions
{
    public interface IPickUpAbility
    {
        void PickUp(Level level, Ability ability);
    }
}