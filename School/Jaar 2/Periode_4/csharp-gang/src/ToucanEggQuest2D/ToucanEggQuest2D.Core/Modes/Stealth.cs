using System.Collections.Generic;
using ToucanEggQuest2D.Core.Objectives;

namespace ToucanEggQuest2D.Core.Modes
{
    public class Stealth : Mode<Egg, EggsNest>
    {
        public Stealth(List<Egg> objectives, EggsNest goal) : base(objectives, goal)
        {
        }
    }
}