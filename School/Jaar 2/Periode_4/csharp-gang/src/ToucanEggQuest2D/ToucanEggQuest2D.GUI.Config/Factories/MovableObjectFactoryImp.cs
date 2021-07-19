using System;
using ToucanEggQuest2D.Core;
using ToucanEggQuest2D.Core.Factories;
using ToucanEggQuest2D.Core.MoveableObjects;

namespace ToucanEggQuest2D.GUI.Config.Factories
{
    public class MovableObjectFactoryImp : IMovableObjectFactory
    {
        private readonly string[] names;

        public MovableObjectFactoryImp()
        {
            names = new[]
            {
                nameof(Cloud),
                nameof(Platform)
            };
        }

        public MovableObject Create(MovableObjectFactoryModel model)
        {
            if ((model.StartCoordinates.X != model.EndCoordinates.X) &&
                (model.StartCoordinates.Y != model.EndCoordinates.Y))
                throw new Exception("Cannot move diagonally");

            switch (model.Name)
            {
                case nameof(Cloud):
                    return CreateCloud(model);
                case nameof(Platform):
                    return CreatePlatform(model);
                case nameof(FloatingPlatform):
                    return CreateFloatingPlatform(model);
                case nameof(SmallPlatform):
                    return CreateSmallPlatform(model);
                case nameof(TinyPlatform):
                    return CreateTinyPlatform(model);
            }

            throw new Exception("Specified name does not exist");
        }

        private MovableObject CreateCloud(MovableObjectFactoryModel model)
        {
            return new Cloud
            {
                StartCoordinates = model.StartCoordinates,
                EndCoordinates = model.EndCoordinates,
                Coordinates = model.StartCoordinates,
                Dimensions = new Dimensions
                {
                    Height = 50,
                    Width = 200
                },
                Texture = new Texture
                {
                    Dimensions = new Dimensions
                    {
                        Height = 80,
                        Width = 200
                    },
                    ImageKey = "ms-appx:///Assets/BigCloudPlatform.png"
                },
                Direction = InitialDirection(model.StartCoordinates, model.EndCoordinates)
            };
        }

        private MovableObject CreatePlatform(MovableObjectFactoryModel model)
        {
            return new Platform
            {
                StartCoordinates = model.StartCoordinates,
                EndCoordinates = model.EndCoordinates,
                Coordinates = model.StartCoordinates,
                Dimensions = new Dimensions
                {
                    Height = 50,
                    Width = 200
                },
                Texture = new Texture
                {
                    Dimensions = new Dimensions
                    {
                        Height = 50,
                        Width = 200
                    },
                    ImageKey = "ms-appx:///Assets/MiddlePlatform.png"
                },
                Direction = InitialDirection(model.StartCoordinates, model.EndCoordinates)
            };
        }

        private MovableObject CreateFloatingPlatform(MovableObjectFactoryModel model)
        {
            return new FloatingPlatform
            {
                StartCoordinates = model.StartCoordinates,
                EndCoordinates = model.EndCoordinates,
                Coordinates = model.StartCoordinates,
                Dimensions = new Dimensions
                {
                    Height = 50,
                    Width = 200
                },
                Texture = new Texture
                {
                    Dimensions = new Dimensions
                    {
                        Height = 50,
                        Width = 200
                    },
                    ImageKey = "ms-appx:///Assets/BigRoundPlatform.png"
                },
                Direction = InitialDirection(model.StartCoordinates, model.EndCoordinates)
            };
        }

        private MovableObject CreateSmallPlatform(MovableObjectFactoryModel model)
        {
            return new SmallPlatform
            {
                StartCoordinates = model.StartCoordinates,
                EndCoordinates = model.EndCoordinates,
                Coordinates = model.StartCoordinates,
                Dimensions = new Dimensions
                {
                    Height = 50,
                    Width = 100
                },
                Texture = new Texture
                {
                    Dimensions = new Dimensions
                    {
                        Height = 50,
                        Width = 100
                    },
                    ImageKey = "ms-appx:///Assets/RiggedPlatform.png"
                },
                Direction = InitialDirection(model.StartCoordinates, model.EndCoordinates)
            };
        }

        private MovableObject CreateTinyPlatform(MovableObjectFactoryModel model)
        {
            return new TinyPlatform
            {
                StartCoordinates = model.StartCoordinates,
                EndCoordinates = model.EndCoordinates,
                Coordinates = model.StartCoordinates,
                Dimensions = new Dimensions
                {
                    Height = 50,
                    Width = 50
                },
                Texture = new Texture
                {
                    Dimensions = new Dimensions
                    {
                        Height = 50,
                        Width = 50
                    },
                    ImageKey = "ms-appx:///Assets/RoundTile.png"
                },
                Direction = InitialDirection(model.StartCoordinates, model.EndCoordinates)
            };
        }

        private static Direction InitialDirection(Coordinates start, Coordinates end)
        {
            if (start.X <= end.X)
                return Direction.RIGHT;
            else if (start.X >= end.X)
                return Direction.LEFT;
            else if (start.Y <= end.Y)
                return Direction.DOWN;
            else
                return Direction.UP;
        }

        public string[] Names()
        {
            return names;
        }
    }
}