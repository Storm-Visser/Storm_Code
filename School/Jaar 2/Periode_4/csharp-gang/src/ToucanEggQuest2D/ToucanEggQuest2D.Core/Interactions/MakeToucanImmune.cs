namespace ToucanEggQuest2D.Core.Interactions
{
    public class MakeToucanImmune : IMakeToucanImmune
    {
        public void Execute(Level level, int durationInSeconds)
        {
            level.Toucan.Immune.Active = true;
            level.Toucan.Immune.DurationInSeconds = durationInSeconds;
        }
    }
}