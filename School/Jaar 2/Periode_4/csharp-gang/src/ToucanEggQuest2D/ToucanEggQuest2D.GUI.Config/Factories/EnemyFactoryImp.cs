using System;
using ToucanEggQuest2D.Core;
using ToucanEggQuest2D.Core.Enemies;
using ToucanEggQuest2D.Core.Factories;

namespace ToucanEggQuest2D.GUI.Config.Factories
{
    public class EnemyFactoryImp : IEnemyFactory
    {
        private readonly string[] names;

        public EnemyFactoryImp()
        {
            names = new[]
            {
                nameof(Raptor),
                nameof(Jaguar),
                nameof(Snake)
            };
        }

        public Enemy Create(EnemyFactoryModel model)
        {
            if ((model.StartCoordinates.X != model.EndCoordinates.X) &&
                (model.StartCoordinates.Y != model.EndCoordinates.Y))
                throw new Exception("Cannot move diagonally");

            switch (model.Name)
            {
                case nameof(Raptor):
                    return CreateRaptor(model);
                case nameof(Jaguar):
                    return CreateJaguar(model);
                case nameof(Snake):
                    return CreateSnake(model);
            }

            throw new Exception("Specified name does not exist");
        }

        private static Enemy CreateRaptor(EnemyFactoryModel model)
        {
            var e = new Raptor
            {
                Dimensions = new Dimensions
                {
                    Height = 80,
                    Width = 100
                },
                StartCoordinates = model.StartCoordinates,
                EndCoordinates = model.EndCoordinates,
                Coordinates = model.StartCoordinates
            };

            e.Texture = new Texture
            {
                Dimensions = e.Dimensions,
                ImageKey = "ms-appx:///Assets/Raptor.png"
            };

            DetermineInitialDirection(e);

            return e;
        }

        private static Enemy CreateJaguar(EnemyFactoryModel model)
        {
            var e = new Jaguar
            {
                Dimensions = new Dimensions
                {
                    Height = 80,
                    Width = 150
                },
                StartCoordinates = model.StartCoordinates,
                EndCoordinates = model.EndCoordinates,
                Coordinates = model.StartCoordinates
            };

            e.Texture = new Texture
            {
                Dimensions = e.Dimensions,
                ImageKey = "ms-appx:///Assets/Jaguar.png"
            };

            DetermineInitialDirection(e);

            return e;
        }

        private static Enemy CreateSnake(EnemyFactoryModel model)
        {
            var e = new Snake
            {
                Dimensions = new Dimensions
                {
                    Height = 50,
                    Width = 80
                },
                StartCoordinates = model.StartCoordinates,
                EndCoordinates = model.EndCoordinates,
                Coordinates = model.StartCoordinates
            };

            e.Texture = new Texture
            {
                Dimensions = e.Dimensions,
                ImageKey = "ms-appx:///Assets/Snake.png"
            };

            DetermineInitialDirection(e);

            return e;
        }

        private static void DetermineInitialDirection(Enemy e)
        {
            if (e.StartCoordinates.X < e.EndCoordinates.X)
                e.Direction = Direction.RIGHT;
            else if (e.StartCoordinates.X > e.EndCoordinates.X)
                e.Direction = Direction.LEFT;
            else if (e.StartCoordinates.Y < e.EndCoordinates.Y)
                e.Direction = Direction.DOWN;
            else
                e.Direction = Direction.UP;
        }

        public string[] Names()
        {
            return names;
        }
    }
}