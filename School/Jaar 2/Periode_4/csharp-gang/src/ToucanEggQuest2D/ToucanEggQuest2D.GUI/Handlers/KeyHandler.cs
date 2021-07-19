using ToucanEggQuest2D.GUI.Pages;
using Windows.System;
using Windows.UI.Core;

namespace ToucanEggQuest2D.GUI.Handlers
{
    public class KeyHandler
    {
        private readonly PlayPage playPage;

        public bool Running;

        public bool MoveLeft;
        public bool MoveRight;
        public bool Jump;

        public KeyHandler(PlayPage playPage)
        {
            this.playPage = playPage;
        }

        public void MenuOnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.VirtualKey)
            {
                case VirtualKey.Escape:
                    if (Running)
                    {
                        playPage.Pause();
                        playPage.ShowMenu();
                    }
                    else
                    {
                        playPage.Play();
                        playPage.HideMenu();
                    }
                break;
            }
        }

        public void GameOnKeyDown(object sender, KeyEventArgs e)
        {
            if (!Running)
                return;

            if ((MoveLeft && e.VirtualKey == VirtualKey.A) ||
            (MoveRight && e.VirtualKey == VirtualKey.D) ||
            (Jump && e.VirtualKey == VirtualKey.Space))
                return;

            switch (e.VirtualKey)
            {
                case VirtualKey.A:
                    MoveLeft = true;
                    break;
                case VirtualKey.D:
                    MoveRight = true;
                    break;
                case VirtualKey.Space:
                    Jump = true;
                    break;
            }

            if (MoveLeft || MoveRight)
            {
                playPage.TimerHandler.ToucanOnTick(null, null);
                playPage.TimerHandler.ToucanTimer.Start();
            }
        }

        public void GameOnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.VirtualKey)
            {
                case VirtualKey.A:
                    MoveLeft = false;
                    break;
                case VirtualKey.D:
                    MoveRight = false;
                    break;
                case VirtualKey.Space:
                    Jump = false;
                    break;
            }

            if (!(MoveLeft || MoveRight))
                playPage.TimerHandler.ToucanTimer.Stop();
        }
    }
}