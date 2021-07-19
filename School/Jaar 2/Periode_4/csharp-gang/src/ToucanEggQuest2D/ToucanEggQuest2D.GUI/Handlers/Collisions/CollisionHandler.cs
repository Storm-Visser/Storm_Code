using ToucanEggQuest2D.Core.Collisions;
using ToucanEggQuest2D.GUI.Handlers.Collisions;
using ToucanEggQuest2D.GUI.Pages;

namespace ToucanEggQuest2D.GUI.Handlers
{
    public class CollisionHandler
    {
        public LeftCollisionHandler LeftCollisionHandler;
        public RightCollisionHandler RightCollisionHandler;
        public AboveCollisionHandler AboveCollisionHandler;

        public ICollision Collision;

        public CollisionHandler(PlayPage playPage)
        {
            Collision = new Collision();
            LeftCollisionHandler = new LeftCollisionHandler(playPage, this);
            RightCollisionHandler = new RightCollisionHandler(playPage, this);
            AboveCollisionHandler = new AboveCollisionHandler(playPage, this);
        }
    }
}