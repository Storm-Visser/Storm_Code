using ToucanEggQuest2D.Core.Enemies.Interactions;
using ToucanEggQuest2D.Core.Interactions;
using ToucanEggQuest2D.GUI.Elements;
using ToucanEggQuest2D.GUI.Models;
using ToucanEggQuest2D.GUI.Pages;

namespace ToucanEggQuest2D.GUI.Handlers
{
    public class InteractionHandler
    {
        private readonly PlayPage playPage;

        private readonly IPickUpAbility pickUpAbility;
        private readonly IMakeToucanImmune makeToucanImmune;
        private readonly IEnemyIsBeaten enemyIsBeaten;
        private readonly IHurtToucan hurtToucan;

        public InteractionHandler(PlayPage playPage)
        {
            this.playPage = playPage;
            pickUpAbility = new PickUpAbility();
            makeToucanImmune = new MakeToucanImmune();
            enemyIsBeaten = new EnemyIsBeaten();
            hurtToucan = new HurtToucan(makeToucanImmune);
        }

        public void PickUpAbility(AbilityUI element)
        {
            pickUpAbility.PickUp(playPage.Level, element.Source);
            playPage.Canvas.Children.Remove(element.Rectangle);
            playPage.Canvas.Children.Remove(element.Image);
            playPage.RenderHandler.AbilityUIs.Remove(element);
        }

        public void RemoveEnemy(EnemyUI e)
        {
            enemyIsBeaten.Execute(playPage.Level, e.Source);
            playPage.Canvas.Children.Remove(e.Rectangle);
            playPage.Canvas.Children.Remove(e.Image);
            playPage.RenderHandler.EnemyUIs.Remove(e);
        }

        public void HurtToucan()
        {
            hurtToucan.Hurt(playPage.Level);
        }
    }
}