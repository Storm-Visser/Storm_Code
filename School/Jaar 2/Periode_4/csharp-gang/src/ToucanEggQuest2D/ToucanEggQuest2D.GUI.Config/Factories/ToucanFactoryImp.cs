using System;
using ToucanEggQuest2D.Core;
using ToucanEggQuest2D.Core.Abilities;
using ToucanEggQuest2D.Core.Factories;

namespace ToucanEggQuest2D.GUI.Config.Factories
{
    public class ToucanFactoryImp : IToucanFactory
    {
        public Toucan Create(ToucanFactoryModel model)
        {
            if (model.Lives <= 0)
                throw new Exception("The toucan needs some lives");

            switch (model.Name)
            {
                case nameof(Toucan):
                    return CreateToucan(model);
            }

            throw new Exception("The specified name does not exist");
        }

        private Toucan CreateToucan(ToucanFactoryModel model)
        {
            return new Toucan
            {
                Coordinates = model.Coordinates,
                Dimensions = new Dimensions
                {
                    Height = 60,
                    Width = 60
                },
                DoubleJump = new DoubleJump(),
                Lives = model.Lives,
                Peck = new Peck(),
                Texture = new Texture
                {
                    Dimensions = new Dimensions
                    {
                        Height = 60,
                        Width = 60
                    },
                    ImageKey = "ms-appx:///Assets/Toucan.png"
                },
                ToucanFloat = new Float(),
                WaterResistant = new WaterResistant(),
                Immune = new Immune()
            };
        }

        public string[] Names()
        {
            return new[] { nameof(Toucan) };
        }
    }
}