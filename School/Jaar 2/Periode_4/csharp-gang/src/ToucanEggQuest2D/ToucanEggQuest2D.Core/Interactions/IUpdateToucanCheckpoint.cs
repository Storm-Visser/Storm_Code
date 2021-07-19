using ToucanEggQuest2D.Core.Objectives;

namespace ToucanEggQuest2D.Core.Interactions
{
    public interface IUpdateToucanCheckpoint
    {
        void Set(Level level, Objective objective);
    }
}