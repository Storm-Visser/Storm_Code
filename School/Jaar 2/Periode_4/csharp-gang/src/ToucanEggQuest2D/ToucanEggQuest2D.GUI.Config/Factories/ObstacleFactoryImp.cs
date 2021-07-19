using System;
using ToucanEggQuest2D.Core;
using ToucanEggQuest2D.Core.Factories;
using ToucanEggQuest2D.Core.Obstacles;

namespace ToucanEggQuest2D.GUI.Config.Factories
{
    public class ObstacleFactoryImp : IObstacleFactory
    {
        private readonly string[] names;

        public ObstacleFactoryImp()
        {
            names = new[]
            {
                nameof(Branch),
                nameof(Tree),
                nameof(Rock)
            };
        }

        public Obstacle Create(ObstacleFactoryModel model)
        {
            switch (model.Name)
            {
                case nameof(Branch):
                    return CreateBranch(model);
                case nameof(Tree):
                    return CreateTree(model);
                case nameof(Rock):
                    return CreateRock(model);
            }

            throw new Exception("The specified name does not exist");
        }

        private Obstacle CreateRock(ObstacleFactoryModel model)
        {
            return new Rock
            {
                Coordinates = model.Coordinates,
                Dimensions = new Dimensions
                {
                    Height = 100,
                    Width = 100
                },
                Texture = new Texture
                {
                    Dimensions = new Dimensions
                    {
                        Height = 100,
                        Width = 100
                    },
                    ImageKey = "ms-appx:///Assets/BigRock.png"
                }
            };
        }

        private Obstacle CreateTree(ObstacleFactoryModel model)
        {
            return new Tree
            {
                Coordinates = model.Coordinates,
                Dimensions = new Dimensions
                {
                    Height = 450,
                    Width = 450
                },
                Texture = new Texture
                {
                    Dimensions = new Dimensions
                    {
                        Height = 450,
                        Width = 450
                    },
                    ImageKey = "ms-appx:///Assets/Tree.png"
                }
            };
        }

        private Obstacle CreateBranch(ObstacleFactoryModel model)
        {
            return new Branch
            {
                Coordinates = model.Coordinates,
                Dimensions = new Dimensions
                {
                    Height = 20,
                    Width = 100
                },
                Texture = new Texture
                {
                    Dimensions = new Dimensions
                    {
                        Height = 20,
                        Width = 100
                    },
                    ImageKey = "ms-appx:///Assets/Branch.png"
                }
            };
        }

        public string[] Names()
        {
            return names;
        }
    }
}