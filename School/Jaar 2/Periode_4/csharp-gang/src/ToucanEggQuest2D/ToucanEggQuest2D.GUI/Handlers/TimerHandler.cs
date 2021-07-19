using System;
using System.Threading.Tasks;
using ToucanEggQuest2D.Core;
using ToucanEggQuest2D.GUI.Pages;
using Windows.UI.Xaml;

namespace ToucanEggQuest2D.GUI.Handlers
{
    public class TimerHandler
    {
        private readonly PlayPage playPage;

        public DispatcherTimer InteractionTimer;
        public DispatcherTimer ProgressionTimer;
        public DispatcherTimer ToucanTimer;
        public DispatcherTimer ToucanJumpAndFallTimer;
        public DispatcherTimer DynamicObjectsTimer;

        private const int interactionTimerInterval = 13;
        private const int progressionTimerInterval = 5;
        private const int toucanTimerInterval = 14;
        private const int toucanJumpAndFallTimerInterval = 15;
        private const int dynamicObjectsTimerInterval = 16;

        private bool isToucanImmuneGold = false;

        public TimerHandler(PlayPage playPage)
        {
            this.playPage = playPage;

            InteractionTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(interactionTimerInterval)
            };
            InteractionTimer.Tick += InteractionOnTick;

            ProgressionTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(interactionTimerInterval)
            };
            InteractionTimer.Tick += ProgressionOnTick;

            ToucanTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(toucanTimerInterval)
            };
            ToucanTimer.Tick += ToucanOnTick;

            ToucanJumpAndFallTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(toucanJumpAndFallTimerInterval)
            };
            ToucanJumpAndFallTimer.Tick += ToucanJumpAndFallOnTick;

            DynamicObjectsTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(dynamicObjectsTimerInterval)
            };
            DynamicObjectsTimer.Tick += DynamicObjectsOnTick;
        }

        public async void InteractionOnTick(object sender, object e)
        {
            if (playPage.Level.Toucan.Immune.Active)
            {
                if (isToucanImmuneGold)
                {
                    playPage.RenderHandler.ToucanUI.Image.Opacity = 0;
                    isToucanImmuneGold = false;
                }
                else
                {
                    playPage.RenderHandler.ToucanUI.Image.Opacity = 1;
                    isToucanImmuneGold = true;
                }
            }
            await Task.CompletedTask;
        }

        public async void ProgressionOnTick(object sender, object e)
        {
            var interval = (int) (progressionTimerInterval * 6.8);

            playPage.ProgressionHandler.CheckAbilityExpired(playPage.Level.Toucan.Peck, interval, ref isToucanImmuneGold);
            playPage.ProgressionHandler.CheckAbilityExpired(playPage.Level.Toucan.DoubleJump, interval, ref isToucanImmuneGold);
            playPage.ProgressionHandler.CheckAbilityExpired(playPage.Level.Toucan.ToucanFloat, interval, ref isToucanImmuneGold);
            playPage.ProgressionHandler.CheckAbilityExpired(playPage.Level.Toucan.WaterResistant, interval, ref isToucanImmuneGold);
            playPage.ProgressionHandler.CheckAbilityExpired(playPage.Level.Toucan.Immune, interval, ref isToucanImmuneGold);

            playPage.ProgressionHandler.CheckIfTimeExpired(interval);
            playPage.ProgressionHandler.CheckIfOutOfLives();

            playPage.LivesTextBlock.Text = $"Lives: {playPage.Level.Toucan.Lives}/{playPage.Level.Lives}";
            playPage.TimeTextBlock.Text = $"Time: {(double) (playPage.Level.TimeInMilliSeconds / 1000)}/{playPage.Level.Mode.TimeToCompleteInSeconds} Seconden";

            await Task.CompletedTask;
        }

        public async void ToucanOnTick(object sender, object e)
        {
            if (playPage.KeyHandler.MoveLeft)
            {
                if (playPage.CollisionHandler.RightCollisionHandler.Colliding())
                {
                    await Task.CompletedTask;
                    return;
                }
                playPage.Level.Toucan.MoveLeft(5);
                await playPage.RenderHandler.RedrawHorizontal();
            }
            if (playPage.KeyHandler.MoveRight)
            {
                if (playPage.CollisionHandler.LeftCollisionHandler.Colliding())
                {
                    await Task.CompletedTask;
                    return;
                }
                playPage.Level.Toucan.MoveRight(5);
                await playPage.RenderHandler.RedrawHorizontal();
            }
        }

        public async void ToucanJumpAndFallOnTick(object sender, object e)
        {
            var isFalling = false;
            var isJumping = false;
            var collisionDistance = playPage.CollisionHandler.AboveCollisionHandler.Colliding();
            var colliding = collisionDistance == 0;

            //Updates the jump and sets isjumping on true when jumping
            var unitsToJump = playPage.Level.Toucan.UpdateJump();            
            if (unitsToJump != 0)
                isJumping = true;

            //Reset canjumponcemore when toucan has collided
            if (unitsToJump == 0 && colliding)
                if (playPage.Level.Toucan.DoubleJump.Active)
                    playPage.Level.Toucan.DoubleJump.CanJumpOnceMore = false;

            //Set falling coordinates when toucan is falling
            if (!colliding && unitsToJump == 0)
            {
                isFalling = true;

                if (collisionDistance > 0)
                    //Set falling distance based on distance away from colliding object
                    //Otherwise will go over the collision border and ignore it.
                    OverwriteFall(collisionDistance);
                else
                    await Fall();
            }

            if (collisionDistance > 0 && unitsToJump < 0)
                //Overwrite falling coordinates when toucan is falling from the update jump
                //otherwise will ignore collision
                OverwriteFall(collisionDistance);
            else if (unitsToJump != 0 && (!colliding || unitsToJump > 0))
                UpdateToucanUnitsToJump(unitsToJump);

            //Only rerender objects if toucan is falling or jumping
            if (isJumping || isFalling)
                await playPage.RenderHandler.RedrawVertical();

            if (playPage.KeyHandler.Jump)
                playPage.Level.Toucan.Jump(colliding);
        }

        private void UpdateToucanUnitsToJump(int unitsToJump)
        {
            var coordinates = new Coordinates
            {
                X = playPage.Level.Toucan.Coordinates.X,
                Y = playPage.Level.Toucan.Coordinates.Y + (unitsToJump - unitsToJump * 2)
            };

            playPage.Level.Toucan.Coordinates = coordinates;
        }

        //Overwrites the jumpfall or fall if the toucan is close to the colliding object.
        private void OverwriteFall(int collisionDistance)
        {
            var coordinates = new Coordinates
            {
                X = playPage.Level.Toucan.Coordinates.X,
                Y = playPage.Level.Toucan.Coordinates.Y + (int)Math.Ceiling((double)collisionDistance / 2)
            };
            playPage.Level.Toucan.Coordinates = coordinates;
        }

        private async Task Fall()
        {
            Coordinates coordinates;
            if (playPage.Level.Toucan.ToucanFloat.Active)
            {
                coordinates = new Coordinates
                {
                    X = playPage.Level.Toucan.Coordinates.X,
                    Y = playPage.Level.Toucan.Coordinates.Y + 5
                };
            }
            else
            {
                coordinates = new Coordinates
                {
                    X = playPage.Level.Toucan.Coordinates.X,
                    Y = playPage.Level.Toucan.Coordinates.Y + 15
                };
            }
            playPage.Level.Toucan.Coordinates = coordinates;
            await Task.CompletedTask;
        }

        public async void DynamicObjectsOnTick(object sender, object e)
        {
            await playPage.RenderHandler.RedrawEnemies();
            await playPage.RenderHandler.RedrawMovableObjects();
        }
    }
}