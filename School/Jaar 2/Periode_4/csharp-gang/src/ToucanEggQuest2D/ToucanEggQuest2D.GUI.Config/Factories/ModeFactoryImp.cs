using System;
using System.Collections.Generic;
using System.Linq;
using ToucanEggQuest2D.Core.Factories;
using ToucanEggQuest2D.Core.Modes;
using ToucanEggQuest2D.Core.Objectives;

namespace ToucanEggQuest2D.GUI.Config.Factories
{
    public class ModeFactoryImp : IModeFactory
    {
        private string[] names;

        public ModeFactoryImp()
        {
            names = new[]
            {
                nameof(Time)
            };
        }

        public Mode Create(ModeFactoryModel model)
        {
            switch (model.Name)
            {
                case nameof(Time):
                    return CreateTime(model);
            }

            throw new Exception("Specified name does not exist");
        }

        private Mode CreateTime(ModeFactoryModel model)
        {
            if (!(model is TimeModeFactoryModel))
                throw new Exception("Creating the time mode requires the type TimeModeFactoryModel");

            var timeModel = model as TimeModeFactoryModel;

            List<TreeCavity> treeCavities;
            try
            {
                treeCavities = timeModel.Objectives.Cast<TreeCavity>().ToList();
            }
            catch
            {
                throw new Exception("Objectives are not of the type TreeCavity");
            }

            if (!(timeModel.Goal is EggsNest))
                throw new Exception("Goal is not of the type EggsNest");

            return new Time(treeCavities, (EggsNest)timeModel.Goal)
            {
                TimeToCompleteInSeconds = timeModel.CompletionTimeInSeconds
            };
        }

        public string[] Names()
        {
            return names;
        }
    }
}