using System.Collections.Generic;
using ToucanEggQuest2D.Core.Objectives;

namespace ToucanEggQuest2D.Core.Modes
{
    public class Gather : Mode<Egg, EggsNest>
    {
        public Gather(List<Egg> objectives, EggsNest goal) : base(objectives, goal)
        {
        }
    }
}