using System;
using ToucanEggQuest2D.Core;
using ToucanEggQuest2D.Core.Factories;
using ToucanEggQuest2D.Core.Objectives;

namespace ToucanEggQuest2D.GUI.Config.Factories
{
    public class ObjectiveFactoryImp : IObjectiveFactory
    {
        private string[] names;

        public ObjectiveFactoryImp()
        {
            names = new[]
            {
                nameof(Egg),
                nameof(EggsNest),
                nameof(TreeCavity)
            };
        }

        public Objective Create(ObjectiveFactoryModel model)
        {
            switch (model.Name)
            {
                case nameof(Egg):
                    return CreateEgg(model);
                case nameof(EggsNest):
                    return CreateEggsNest(model);
                case nameof(TreeCavity):
                    return CreateTreeCavity(model);
            }

            throw new Exception("Specified name does not exist");
        }

        private Objective CreateEgg(ObjectiveFactoryModel model)
        {
            var egg = new Egg
            {
                Coordinates = model.Coordinates,
                Dimensions = new Dimensions
                {
                    Width = 50,
                    Height = 50
                }
            };

            egg.Texture = new Texture
            {
                Dimensions = new Dimensions
                {
                    Width = egg.Dimensions.Width,
                    Height = egg.Dimensions.Height
                },
                ImageKey = "ms-appx:///Assets/Egg.png"
            };

            return egg;
        }

        private Objective CreateEggsNest(ObjectiveFactoryModel model)
        {
            var eggsNest = new EggsNest
            {
                Coordinates = model.Coordinates,
                Dimensions = new Dimensions
                {
                    Width = 65,
                    Height = 50
                }
            };

            eggsNest.Texture = new Texture
            {
                Dimensions = new Dimensions
                {
                    Width = eggsNest.Dimensions.Width,
                    Height = eggsNest.Dimensions.Height
                },
                ImageKey = "ms-appx:///Assets/Nestgoal.png"
            };

            return eggsNest;
        }

        private Objective CreateTreeCavity(ObjectiveFactoryModel model)
        {
            var treeCavity = new TreeCavity
            {
                Coordinates = model.Coordinates,
                Dimensions = new Dimensions
                {
                    Height = 100,
                    Width = 100
                }
            };

            treeCavity.Texture = new Texture
            {
                Dimensions = new Dimensions
                {
                    Width = treeCavity.Dimensions.Width,
                    Height = treeCavity.Dimensions.Height
                },
                ImageKey = "ms-appx:///Assets/treeCavityHole.png"
            };

            return treeCavity;
        }

        public string[] Names()
        {
            return names;
        }
    }
}