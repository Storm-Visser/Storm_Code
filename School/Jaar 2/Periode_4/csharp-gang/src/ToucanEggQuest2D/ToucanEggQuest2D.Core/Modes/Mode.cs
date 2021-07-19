using System.Collections.Generic;
using System.Linq;
using ToucanEggQuest2D.Core.Objectives;

namespace ToucanEggQuest2D.Core.Modes
{
    public abstract class Mode
    {
        public IEnumerable<Objective> Objectives { get; set; }
        public Objective Goal { get; set; }

        public Mode(IEnumerable<Objective> objectives, Objective goal)
        {
            Objectives = objectives;
            Goal = goal;
        }

        public void AddObjective(Objective objective)
        {
            var list = Objectives.ToList();
            list.Add(objective);
            Objectives = list;
        }
        public void removeObjective(Objective objective)
        {
            var list = Objectives.ToList();
            list.Remove(objective);
            Objectives = list;
        }
    }

    public abstract class Mode<ObjectiveT, GoalT> : Mode where ObjectiveT : Objective where GoalT : Objective
    {
        public Mode(List<ObjectiveT> objectives, GoalT goal) : base(objectives, goal)
        {
        }
    }
}