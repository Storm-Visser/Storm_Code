using System;
using System.Collections.Generic;
using System.Linq;
using ToucanEggQuest2D.Core.Abilities;
using ToucanEggQuest2D.Core.Collisions.Models;
using ToucanEggQuest2D.Core.Enemies;
using ToucanEggQuest2D.Core.Modes;
using ToucanEggQuest2D.Core.MoveableObjects;
using ToucanEggQuest2D.Core.Obstacles;
using ToucanEggQuest2D.Core.SemiObstacles;

namespace ToucanEggQuest2D.Core
{
    public class Level
    {
        public string Name { get; set; }
        //Aangezien time de enige is die wordt geimplementeerd gebruikt de level dat object direct
        public Time Mode { get; set; }
        public Dimensions Dimensions { get; set; }
        public int TimeInMilliSeconds { get; set; }
        public Texture Background { get; set; }
        public IEnumerable<Ability> Abilities { get; set; }
        public IEnumerable<Enemy> Enemies { get; set; }
        public IEnumerable<SemiObstacle> SemiObstacles { get; set; }
        public IEnumerable<Obstacle> Obstacles { get; set; }
        public IEnumerable<MovableObject> MovableObjects { get; set; }
        public int Lives { get; set; }
        public Toucan Toucan { get; set; }
        public Coordinates ToucanStartCoordinates { get; set; }

        public void AddAbility(Ability ability)
        {
            List<Ability> list = Abilities.ToList();
            list.Add(ability);
            Abilities = list;
        }

        public void RemoveAbility(Ability ability)
        {
            var list = Abilities.ToList();
            list.Remove(ability);
            Abilities = list;
        }

        public void AddEnemy(Enemy enemy)
        {
            var list = Enemies.ToList();
            list.Add(enemy);
            Enemies = list;
        }

        public void RemoveEnemy(Enemy enemy)
        {
            var list = Enemies.ToList();
            list.Remove(enemy);
            Enemies = list;
        }

        public void AddObstacle(Obstacle obstacle)
        {
            var list = Obstacles.ToList();
            list.Add(obstacle);
            Obstacles = list;
        }

        public void RemoveObstacle(Obstacle obstacle)
        {
            var list = Obstacles.ToList();
            list.Remove(obstacle);
            Obstacles = list;
        }
        public void AddSemiObstacle(SemiObstacle semiObstacle)
        {
            var list = SemiObstacles.ToList();
            list.Add(semiObstacle);
            SemiObstacles = list;
        }

        public void RemoveSemiObstacle(SemiObstacle semiObstacle)
        {
            var list = SemiObstacles.ToList();
            list.Remove(semiObstacle);
            SemiObstacles = list;
        }

        public void AddMovableObject(MovableObject moveAbleObject)
        {
            var list = MovableObjects.ToList();
            list.Add(moveAbleObject);
            MovableObjects = list;
        }

        public void RemoveMoveAbleObject(MovableObject movAbleObject)
        {
            var list = MovableObjects.ToList();
            list.Remove(movAbleObject);
            MovableObjects = list;
        }

        public void RemoveMoveAbleObject(Collider @object)
        {
            throw new NotImplementedException();
        }
    }
}