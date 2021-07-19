using System;
using ToucanEggQuest2D.Core;
using ToucanEggQuest2D.Core.Abilities;
using ToucanEggQuest2D.Core.Factories;

namespace ToucanEggQuest2D.GUI.Config.Factories
{
    public class AbilityFactoryImp : IAbilityFactory
    {
        private readonly string[] names;

        public AbilityFactoryImp()
        {
            names = new[]
            {
                nameof(DoubleJump),
                nameof(Float),
                nameof(Peck),
                nameof(WaterResistant)
            };
        }

        public Ability Create(AbilityFactoryModel model)
        {
            switch (model.Name)
            {
                case nameof(DoubleJump):
                    return CreateDoubleJump(model);
                case nameof(Float):
                    return CreateFloat(model);
                case nameof(Peck):
                    return CreatePeck(model);
                case nameof(WaterResistant):
                    return CreateWaterResistant(model);
            }

            throw new Exception("The specified name does not exist");
        }

        private Ability CreateDoubleJump(AbilityFactoryModel model)
        {
            return new DoubleJump
            {
                Active = false,
                DurationInSeconds = 10,
                CurrentDurationInMiliseconds = 0,
                JumpStage = 0,
                Coordinates = model.Coordinates,
                Dimensions = new Dimensions
                {
                    Height = 40,
                    Width = 40
                },
                Texture = new Texture
                {
                    Dimensions = new Dimensions
                    {
                        Height = 40,
                        Width = 40
                    },
                    ImageKey = "ms-appx:///Assets/PurplePowerUp.png"
                }
            };
        }

        private Ability CreateFloat(AbilityFactoryModel model)
        {
            return new Float
            {
                Active = false,
                DurationInSeconds = 15,
                CurrentDurationInMiliseconds = 0,
                Coordinates = model.Coordinates,
                Dimensions = new Dimensions
                {
                    Height = 40,
                    Width = 40
                },
                Texture = new Texture
                {
                    Dimensions = new Dimensions
                    {
                        Height = 40,
                        Width = 40
                    },
                    ImageKey = "ms-appx:///Assets/GreyPowerUp.png"
                }
            };
        }

        private Ability CreatePeck(AbilityFactoryModel model)
        {
            return new Peck
            {
                Active = false,
                DurationInSeconds = 30,
                CurrentDurationInMiliseconds = 0,
                Coordinates = model.Coordinates,
                Dimensions = new Dimensions
                {
                    Height = 40,
                    Width = 40
                },
                Texture = new Texture
                {
                    Dimensions = new Dimensions
                    {
                        Height = 40,
                        Width = 40
                    },
                    ImageKey = "ms-appx:///Assets/RedPowerUp.png"
                }
            };
        }

        private Ability CreateWaterResistant(AbilityFactoryModel model)
        {
            return new WaterResistant
            {
                Active = false,
                DurationInSeconds = 5,
                CurrentDurationInMiliseconds = 0,
                Coordinates = model.Coordinates,
                Dimensions = new Dimensions
                {
                    Height = 40,
                    Width = 40
                },
                Texture = new Texture
                {
                    Dimensions = new Dimensions
                    {
                        Height = 40,
                        Width = 40
                    },
                    ImageKey = "ms-appx:///Assets/BluePowerUp.png"
                }
            };
        }

        public string[] Names()
        {
            return names;
        }
    }
}