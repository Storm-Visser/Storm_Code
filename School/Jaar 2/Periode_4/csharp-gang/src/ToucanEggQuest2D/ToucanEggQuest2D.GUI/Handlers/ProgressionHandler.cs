using System.Threading;
using ToucanEggQuest2D.Core.Abilities;
using ToucanEggQuest2D.Core.Interactions;
using ToucanEggQuest2D.Core.Objectives;
using ToucanEggQuest2D.GUI.Pages;

namespace ToucanEggQuest2D.GUI.Handlers
{
    public class ProgressionHandler
    {
        private readonly PlayPage playPage;

        private readonly IRespawnToucan respawnToucan;
        private readonly IUpdateToucanCheckpoint updateToucanCheckpoint;

        public ProgressionHandler(PlayPage playPage)
        {
            this.playPage = playPage;
            respawnToucan = new RespawnToucan();
            updateToucanCheckpoint = new UpdateToucanCheckpoint();
        }

        public async void RespawnToucan()
        {
            respawnToucan.Respawn(playPage.Level);
            await playPage.RenderHandler.RedrawVertical();
            await playPage.RenderHandler.RedrawHorizontal();
        }

        public void UpdateRespawnCheckpoint(TreeCavity treeCavity)
        {
            updateToucanCheckpoint.Set(playPage.Level, treeCavity);
        }

        public void CheckAbilityExpired(Ability a, int interval, ref bool isToucanImmuneGold)
        {
            if (a.Active)
            {
                a.CurrentDurationInMiliseconds += interval;
                if (a.DurationInSeconds * 1000 <= a.CurrentDurationInMiliseconds)
                {
                    a.Active = false;
                    a.CurrentDurationInMiliseconds = 0;

                    if (a is Immune)
                    {
                        playPage.RenderHandler.ToucanUI.Image.Opacity = 1;
                        isToucanImmuneGold = false;
                    }
                }
            }
        }

        public void CheckIfTimeExpired(int interval)
        {
            playPage.Level.TimeInMilliSeconds += interval;
            if (playPage.Level.Mode.TimeToCompleteInSeconds * 1000 <= playPage.Level.TimeInMilliSeconds)
            {
                playPage.InitialiseGameOver();
                playPage.GoToMainMenu();
            }
        }

        public void CheckIfOutOfLives()
        {
            if (playPage.Level.Toucan.Lives <= 0)
            {
                playPage.InitialiseGameOver();
                playPage.GoToMainMenu();
            }
        }

        public void GoalIsReached()
        {
            playPage.InitialiseGameWon();
            playPage.GoToMainMenu();
        }
    }
}
