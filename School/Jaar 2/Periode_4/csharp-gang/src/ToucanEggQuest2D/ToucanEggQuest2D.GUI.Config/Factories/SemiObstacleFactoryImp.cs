using System;
using ToucanEggQuest2D.Core;
using ToucanEggQuest2D.Core.Factories;
using ToucanEggQuest2D.Core.SemiObstacles;

namespace ToucanEggQuest2D.GUI.Config.Factories
{
    public class SemiObstacleFactoryImp : ISemiObstacleFactory
    {
        private readonly string[] names;

        public SemiObstacleFactoryImp()
        {
            names = new[]
            {
                //nameof(Waterfall) NO ASSET,
                nameof(Waterpool)
            };
        }

        public SemiObstacle Create(SemiObstacleFactoryModel model)
        {
            switch (model.Name)
            {
                case nameof(Waterfall):
                    return CreateWaterfall(model);
                case nameof(Waterpool):
                    return CreateWaterpool(model);
            }

            throw new Exception("The specified name does not exist");
        }

        private Waterfall CreateWaterfall(SemiObstacleFactoryModel model)
        {
            return new Waterfall
            {
                Coordinates = model.Coordinates,
                Dimensions = new Dimensions
                {
                    Height = 100,
                    Width = 80
                },
                Texture = new Texture
                {
                    Dimensions = new Dimensions
                    {
                        Height = 100,
                        Width = 80
                    },
                    ImageKey = "ms-appx:///Assets/"
                }
            };
        }

        private Waterpool CreateWaterpool(SemiObstacleFactoryModel model)
        {
            return new Waterpool
            {
                Coordinates = model.Coordinates,
                Dimensions = new Dimensions
                {
                    Height = 10,
                    Width = 100
                },
                Texture = new Texture
                {
                    Dimensions = new Dimensions
                    {
                        Height = 10,
                        Width = 100
                    },
                    ImageKey = "ms-appx:///Assets/Water.png"
                }
            };
        }

        public string[] Names()
        {
            return names;
        }
    }
}