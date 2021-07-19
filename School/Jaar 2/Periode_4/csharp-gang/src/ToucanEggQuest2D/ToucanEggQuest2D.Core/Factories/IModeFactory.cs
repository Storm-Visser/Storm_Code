using System.Collections.Generic;
using ToucanEggQuest2D.Core.Modes;
using ToucanEggQuest2D.Core.Objectives;

namespace ToucanEggQuest2D.Core.Factories
{
    public interface IModeFactory
    {
        Mode Create(ModeFactoryModel model);
        string[] Names();
    }

    public class ModeFactoryModel
    {
        public string Name { get; set; }
        public List<Objective> Objectives { get; set; }
        public Objective Goal { get; set; }
    }

    public class TimeModeFactoryModel : ModeFactoryModel
    {
        public int CompletionTimeInSeconds { get; set; }
    }
}