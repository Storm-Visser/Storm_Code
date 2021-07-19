using System.Linq;

namespace ToucanEggQuest2D.Core.Enemies.Interactions
{
    public class EnemyIsBeaten : IEnemyIsBeaten
    {
        public void Execute(Level level, Enemy e)
        {
            var enem = level.Enemies.ToList();
            enem.Remove(e);
            level.Enemies = enem;
        }
    }
}