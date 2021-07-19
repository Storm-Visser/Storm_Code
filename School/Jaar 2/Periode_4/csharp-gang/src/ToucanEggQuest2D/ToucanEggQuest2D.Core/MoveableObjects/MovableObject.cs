using ToucanEggQuest2D.Core.Collisions.Models;

namespace ToucanEggQuest2D.Core.MoveableObjects
{
    public abstract class MovableObject : Collider
    {
        public Coordinates StartCoordinates { get; set; }
        public Coordinates EndCoordinates { get; set; }
        public Direction Direction { get; set; }
        public Texture Texture { get; set; }

        public bool Update()
        {
            var horizontalMovement = StartCoordinates.Y == EndCoordinates.Y;
            if (horizontalMovement)
            {
                if (StartCoordinates.X < EndCoordinates.X)
                {
                    switch (Direction)
                    {
                        case Direction.RIGHT:
                            if (Coordinates.X >= EndCoordinates.X)
                                Direction = Direction.LEFT;
                            break;
                        case Direction.LEFT:
                            if (Coordinates.X <= StartCoordinates.X)
                                Direction = Direction.RIGHT;
                            break;
                    }
                }
                else
                {
                    switch (Direction)
                    {
                        case Direction.RIGHT:
                            if (Coordinates.X >= StartCoordinates.X)
                                Direction = Direction.LEFT;
                            break;
                        case Direction.LEFT:
                            if (Coordinates.X <= EndCoordinates.X)
                                Direction = Direction.RIGHT;
                            break;
                    }
                }
            }

            var verticalMovement = StartCoordinates.X == EndCoordinates.X;
            if (verticalMovement)
            {
                if (StartCoordinates.Y < EndCoordinates.Y)
                {
                    switch (Direction)
                    {
                        case Direction.DOWN:
                            if (Coordinates.Y >= EndCoordinates.Y)
                                Direction = Direction.UP;
                            break;
                        case Direction.UP:
                            if (Coordinates.Y <= StartCoordinates.Y)
                                Direction = Direction.DOWN;
                            break;
                    }
                }
                else
                {
                    switch (Direction)
                    {
                        case Direction.DOWN:
                            if (Coordinates.Y >= StartCoordinates.Y)
                                Direction = Direction.UP;
                            break;
                        case Direction.UP:
                            if (Coordinates.Y <= EndCoordinates.Y)
                                Direction = Direction.DOWN;
                            break;
                    }
                }
            }

            var c = Coordinates;

            switch (Direction)
            {
                case Direction.UP:
                    c.Y--;
                    break;
                case Direction.DOWN:
                    c.Y++;
                    break;
                case Direction.LEFT:
                    c.X--;
                    break;
                case Direction.RIGHT:
                    c.X++;
                    break;
            }

            Coordinates = c;

            if (verticalMovement && horizontalMovement)
                return false;
            else
                return true;
        }
    }
}