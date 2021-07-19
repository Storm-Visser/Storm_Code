namespace ToucanEggQuest2D.Core.Interactions
{
    public class HurtToucan : IHurtToucan
    {
        private readonly IMakeToucanImmune makeToucanImmune;

        public HurtToucan(IMakeToucanImmune makeToucanImmune)
        {
            this.makeToucanImmune = makeToucanImmune;
        }

        public void Hurt(Level level)
        {
            level.Toucan.Lives--;
            makeToucanImmune.Execute(level, 3);
        }
    }
}