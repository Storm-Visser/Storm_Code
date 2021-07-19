using System.Collections.Generic;
using System.Linq;
using ToucanEggQuest2D.Core.Objectives;
using ToucanEggQuest2D.Core.Obstacles;
using ToucanEggQuest2D.GUI.Pages;

namespace ToucanEggQuest2D.GUI.Handlers.Collisions
{
    public class AboveCollisionHandler
    {
        private readonly PlayPage playPage;
        private readonly CollisionHandler collisionHandler;

        public AboveCollisionHandler(PlayPage playPage, CollisionHandler collisionHandler)
        {
            this.playPage = playPage;
            this.collisionHandler = collisionHandler;
        }

        public int Colliding()
        {
            var collisions = new List<int>
            {
                EnemyColliding(),
                ObjectiveColliding(),
                AbilityColliding(),
                SemiObstacleColliding(),
                MovableObjectColliding(),
                ObstacleColliding()
            };
            return Utilities.CollisionDistance(collisions);
        }

        private int EnemyColliding()
        {
            var collisions = new List<int>();
            foreach (var o in playPage.RenderHandler.EnemyUIs.ToList())
            {
                var collision = collisionHandler.Collision.CollidingFromAbove(playPage.RenderHandler.ToucanUI.Source, o.Source);
                if (collision == 0)
                {
                    if (playPage.Level.Toucan.Peck.Active)
                        playPage.InteractionHandler.RemoveEnemy(o);
                    else if (playPage.Level.Toucan.Immune.Active)
                        break;
                    else
                    {
                        playPage.ProgressionHandler.RespawnToucan();
                        playPage.InteractionHandler.HurtToucan();
                    }
                }
                collisions.Add(collision);
            }
            return Utilities.CollisionDistance(collisions);
        }

        private int ObjectiveColliding()
        {
            var collisions = new List<int>();
            foreach (var o in playPage.RenderHandler.ObjectiveUIs.ToList())
            {
                var collision = collisionHandler.Collision.CollidingFromAbove(playPage.RenderHandler.ToucanUI.Source, o.Source);
                if (collision == 0)
                {
                    if (o.Source is EggsNest)
                        playPage.ProgressionHandler.GoalIsReached();
                    if (o.Source is TreeCavity)
                    {
                        playPage.ProgressionHandler.UpdateRespawnCheckpoint((TreeCavity)o.Source);
                        break;
                    }
                }
                collisions.Add(collision);
            }
            return Utilities.CollisionDistance(collisions);
        }

        private int AbilityColliding()
        {
            var collisions = new List<int>();
            foreach (var o in playPage.RenderHandler.AbilityUIs.ToList())
            {
                var collision = collisionHandler.Collision.CollidingFromAbove(playPage.RenderHandler.ToucanUI.Source, o.Source);
                if (collision == 0)
                {
                    playPage.InteractionHandler.PickUpAbility(o);
                }
                collisions.Add(collision);
            }
            return Utilities.CollisionDistance(collisions);
        }

        private int SemiObstacleColliding()
        {
            var collisions = new List<int>();
            foreach (var o in playPage.RenderHandler.SemiObstacleUIs.ToList())
            {
                var collision = collisionHandler.Collision.CollidingFromAbove(playPage.RenderHandler.ToucanUI.Source, o.Source);
                if (collision == 0)
                {
                    if (playPage.Level.Toucan.WaterResistant.Active)
                    {
                        break;
                    }
                    else if (playPage.Level.Toucan.Immune.Active)
                        break;
                    else
                    {
                        playPage.ProgressionHandler.RespawnToucan();
                        playPage.InteractionHandler.HurtToucan();
                        collisions.Add(collision);
                    }
                }
            }
            return Utilities.CollisionDistance(collisions);
        }

        private int MovableObjectColliding()
        {
            var collisions = new List<int>();
            foreach (var o in playPage.RenderHandler.MovableObjectUIs.ToList())
                collisions.Add(collisionHandler.Collision.CollidingFromAbove(playPage.RenderHandler.ToucanUI.Source, o.Source));
            return Utilities.CollisionDistance(collisions);
        }

        private int ObstacleColliding()
        {
            var collisions = new List<int>();
            foreach (var o in playPage.RenderHandler.ObstacleUIs.ToList())
            {
                var collision = collisionHandler.Collision.CollidingFromAbove(playPage.RenderHandler.ToucanUI.Source, o.Source);
                if (collision == 0 && o.Source is Tree)
                    break;
                collisions.Add(collision);
            }
            return Utilities.CollisionDistance(collisions);
        }
    }
}