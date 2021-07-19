using System.Linq;
using ToucanEggQuest2D.Core.Abilities;

namespace ToucanEggQuest2D.Core.Interactions
{
    public class PickUpAbility : IPickUpAbility
    {
        public void PickUp(Level level, Ability ability)
        {
            if (ability is Peck)
            {
                level.Toucan.Peck.Active = true;
                level.Toucan.Peck.DurationInSeconds = ability.DurationInSeconds;
            }

            if (ability is DoubleJump)
            {
                level.Toucan.DoubleJump.Active = true;
                level.Toucan.DoubleJump.DurationInSeconds = ability.DurationInSeconds;
            }

            if (ability is Float)
            {
                level.Toucan.ToucanFloat.Active = true;
                level.Toucan.ToucanFloat.DurationInSeconds = ability.DurationInSeconds;
            }

            if (ability is WaterResistant)
            {
                level.Toucan.WaterResistant.Active = true;
                level.Toucan.WaterResistant.DurationInSeconds = ability.DurationInSeconds;
            }

            var abilities = level.Abilities.ToList();
            abilities.Remove(ability);
            level.Abilities = abilities;
        }
    }
}