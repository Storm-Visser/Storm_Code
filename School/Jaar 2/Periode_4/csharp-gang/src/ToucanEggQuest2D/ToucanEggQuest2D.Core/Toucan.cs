using ToucanEggQuest2D.Core.Abilities;
using ToucanEggQuest2D.Core.Collisions.Models;

namespace ToucanEggQuest2D.Core
{
    public class Toucan : Collider
    {
        public int Lives { get; set; }
        public Texture Texture { get; set; }
        public DoubleJump DoubleJump { get; set; }
        public Peck Peck { get; set; }
        public Float ToucanFloat { get; set; }
        public WaterResistant WaterResistant { get; set; }
        public Immune Immune { get; set; }

        public void MoveLeft(int units)
        {
            var coordinates = new Coordinates
            {
                X = Coordinates.X - units,
                Y = Coordinates.Y
            };

            Coordinates = coordinates;
        }

        public void MoveRight(int units)
        {
            var coordinates = new Coordinates
            {
                X = Coordinates.X + units,
                Y = Coordinates.Y
            };

            Coordinates = coordinates;
        }

        /// <summary>
        /// Initiates a JumpMovement
        /// </summary>
        public void Jump(bool colliding)
        {
            if ((colliding && DoubleJump.JumpStage <= 0) ||
                (DoubleJump.CanJumpOnceMore && DoubleJump.JumpStage > 10))
            {
                DoubleJump.JumpStage = 1;

                if (DoubleJump.CanJumpOnceMore)
                {
                    DoubleJump.CanJumpOnceMore = false;
                }
                else
                {
                    if (DoubleJump.Active)
                        DoubleJump.CanJumpOnceMore = true;
                }
            }
        }

        /// <summary>
        /// Updates the active JumpMovement
        /// The jump will follow the following Formula; Y = -0.5X² + 4.5X
        /// </summary>
        /// <returns>True when a JumpMovement is active, false otherwise</returns>
        public int UpdateJump()
        {
            if (DoubleJump.JumpStage == 0)
                return 0;

            var jumpHeight = CalculateHeight(DoubleJump.JumpStage) - CalculateHeight(DoubleJump.JumpStage - 1);

            int jumpHeightAsInt;
            if (jumpHeight > 0)
                jumpHeightAsInt = System.Convert.ToInt32(System.Math.Ceiling(jumpHeight));
            else
                jumpHeightAsInt = System.Convert.ToInt32(System.Math.Floor(jumpHeight));

            if (DoubleJump.JumpStage >= 30)
                DoubleJump.JumpStage = 0;
            else
                DoubleJump.JumpStage++;

            return jumpHeightAsInt;
        }

        private double CalculateHeight(int jumpStage)
        {
            var X = jumpStage / 3.33;
            var sqrt = X * X;
            var a = -4 * sqrt;
            var b = 36 * X;
            var Y = a + b;
            return Y;
        }
    }
}