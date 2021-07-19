using System.Linq;
using ToucanEggQuest2D.Core.Objectives;
using ToucanEggQuest2D.Core.Obstacles;
using ToucanEggQuest2D.GUI.Pages;

namespace ToucanEggQuest2D.GUI.Handlers.Collisions
{
    public class LeftCollisionHandler
    {
        private readonly PlayPage playPage;
        private readonly CollisionHandler collisionHandler;

        public LeftCollisionHandler(PlayPage playPage, CollisionHandler collisionHandler)
        {
            this.playPage = playPage;
            this.collisionHandler = collisionHandler;
        }

        public bool Colliding()
        {
            if (EnemyColliding() ||
                ObjectiveColliding() ||
                AbilityColliding() ||
                SemiObstacleColliding() ||
                MovableObjectColliding() ||
                ObstacleColliding())
                return true;
            return false;
        }

        private bool EnemyColliding()
        {
            foreach (var o in playPage.RenderHandler.EnemyUIs.ToList())
            {
                if (collisionHandler.Collision.CollidingFromLeft(playPage.RenderHandler.ToucanUI.Source, o.Source))
                {
                    if (playPage.Level.Toucan.Peck.Active)
                    {
                        playPage.InteractionHandler.RemoveEnemy(o);
                    }
                    else if (playPage.Level.Toucan.Immune.Active)
                    {
                        return false;
                    }
                    else
                    {
                        playPage.ProgressionHandler.RespawnToucan();
                        playPage.InteractionHandler.HurtToucan();
                    }
                    return true;
                }
            }
            return false;
        }

        private bool ObjectiveColliding()
        {
            foreach (var o in playPage.RenderHandler.ObjectiveUIs.ToList())
            {
                if (collisionHandler.Collision.CollidingFromLeft(playPage.RenderHandler.ToucanUI.Source, o.Source))
                {
                    if (o.Source is EggsNest)
                        playPage.ProgressionHandler.GoalIsReached();
                    if (o.Source is TreeCavity)
                    {
                        playPage.ProgressionHandler.UpdateRespawnCheckpoint((TreeCavity)o.Source);
                        continue;
                    }
                    return true;
                }
            }
            return false;
        }

        private bool AbilityColliding()
        {
            foreach (var o in playPage.RenderHandler.AbilityUIs.ToList())
            {
                if (collisionHandler.Collision.CollidingFromLeft(playPage.RenderHandler.ToucanUI.Source, o.Source))
                {
                    playPage.InteractionHandler.PickUpAbility(o);
                    return true;
                }
            }
            return false;
        }

        private bool SemiObstacleColliding()
        {
            foreach (var o in playPage.RenderHandler.SemiObstacleUIs.ToList())
            {
                if (collisionHandler.Collision.CollidingFromLeft(playPage.RenderHandler.ToucanUI.Source, o.Source))
                {
                    if (playPage.Level.Toucan.WaterResistant.Active)
                        return false;
                    else if (playPage.Level.Toucan.Immune.Active)
                        return false;
                    playPage.ProgressionHandler.RespawnToucan();
                    playPage.InteractionHandler.HurtToucan();
                    return true;
                }
            }
            return false;
        }

        private bool MovableObjectColliding()
        {
            foreach (var o in playPage.RenderHandler.MovableObjectUIs.ToList())
                if (collisionHandler.Collision.CollidingFromLeft(playPage.RenderHandler.ToucanUI.Source, o.Source))
                    return true;
            return false;
        }

        private bool ObstacleColliding()
        {
            foreach (var o in playPage.RenderHandler.ObstacleUIs.ToList())
                if (collisionHandler.Collision.CollidingFromLeft(playPage.RenderHandler.ToucanUI.Source, o.Source))
                {
                    if (o.Source is Tree)
                        return false;
                    return true;
                }
            return false;
        }
    }
}