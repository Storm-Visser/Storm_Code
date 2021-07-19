using System;
using System.Collections.Generic;
using ToucanEggQuest2D.Core.Collisions.Models;
using ToucanEggQuest2D.Core.Objectives;

namespace ToucanEggQuest2D.Core.Modes
{
    public class Time : Mode<TreeCavity, EggsNest>
    {
        public int TimeToCompleteInSeconds { get; set; }

        public Time(List<TreeCavity> objectives, EggsNest goal) : base(objectives, goal)
        {
        }

        public void removeObjective(Collider @object)
        {
            throw new NotImplementedException();
        }
    }
}