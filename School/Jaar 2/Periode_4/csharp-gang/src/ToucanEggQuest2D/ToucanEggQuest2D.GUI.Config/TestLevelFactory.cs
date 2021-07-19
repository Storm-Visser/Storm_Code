using System.Collections.Generic;
using ToucanEggQuest2D.Core;
using ToucanEggQuest2D.Core.Abilities;
using ToucanEggQuest2D.Core.Enemies;
using ToucanEggQuest2D.Core.Factories;
using ToucanEggQuest2D.Core.Modes;
using ToucanEggQuest2D.Core.Objectives;
using ToucanEggQuest2D.Core.MoveableObjects;
using ToucanEggQuest2D.Core.Obstacles;
using ToucanEggQuest2D.Core.SemiObstacles;
using ToucanEggQuest2D.GUI.Config.Factories;

namespace ToucanEggQuest2D.GUI.Config
{
    public class TestLevelFactory
    {
        public Level CreateTestLevel()
        {
            var startCoordinates = new Coordinates { X = 0, Y = 0 };

            return new Level
            {
                Toucan = new ToucanFactoryImp().Create(new ToucanFactoryModel
                {
                    Name = nameof(Toucan),
                    Lives = 3,
                    Coordinates = startCoordinates
                }),
                Enemies = CreateEnemies(),
                Mode = CreateMode(),
                Abilities = CreateAbilities(),
                MovableObjects = CreateMovableObjects(),
                SemiObstacles = CreateSemiObstacles(),
                Obstacles = CreateObstacles(),
                Lives = 3,
                Name = "Test Level",
                ToucanStartCoordinates = startCoordinates,
                Background = new Texture
                {
                    Dimensions = new Dimensions
                    {
                        Height = 1920,
                        Width = 1080
                    },
                    ImageKey = "ms-appx:///Assets/BackgroundGame.png"
                }
            };
        }

        private List<Obstacle> CreateObstacles()
        {
            var factory = new ObstacleFactoryImp();
            var obstacles = new List<Obstacle>
            {
                factory.Create(new ObstacleFactoryModel
                {
                    Name = nameof(Rock),
                    Coordinates = new Coordinates
                    {
                        X = 420,
                        Y = -25
                    }
                }),

                factory.Create(new ObstacleFactoryModel
                {
                    Name = nameof(Rock),
                    Coordinates = new Coordinates
                    {
                        X = 200,
                        Y = -198
                    }
                }),

                factory.Create(new ObstacleFactoryModel
                {
                    Name = nameof(Tree),
                    Coordinates = new Coordinates
                    {
                        X = -700,
                        Y = -555
                    }
                })
            };

            return obstacles;
        }

        private List<SemiObstacle> CreateSemiObstacles()
        {
            var semiObstacleFactory = new SemiObstacleFactoryImp();
            var semiObstacles = new List<SemiObstacle>();

            semiObstacles.Add(semiObstacleFactory.Create(new SemiObstacleFactoryModel
            {
                Name = nameof(Waterpool),
                Coordinates = new Coordinates
                {
                    X = 240,
                    Y = 60
                }
            }));

            semiObstacles.Add(semiObstacleFactory.Create(new SemiObstacleFactoryModel
            {
                Name = nameof(Waterpool),
                Coordinates = new Coordinates
                {
                    X = -50,
                    Y = -150
                }
            }));

            return semiObstacles;
        }

        private List<MovableObject> CreateMovableObjects()
        {
            var movableObjectFactory = new MovableObjectFactoryImp();
            var movableObjects = new List<MovableObject>();

            //Ground
            for (var x = -900; x <= 1100; x += 200)
            {
                movableObjects.Add(movableObjectFactory.Create(new MovableObjectFactoryModel
                {
                    Name = nameof(Platform),
                    StartCoordinates = new Coordinates
                    {
                        X = x,
                        Y = 60
                    },
                    EndCoordinates = new Coordinates
                    {
                        X = x,
                        Y = 60
                    }
                }));
            }

            //Platform left above 
            for (var x = -900; x <= 100; x += 200)
            {
                movableObjects.Add(movableObjectFactory.Create(new MovableObjectFactoryModel
                {
                    Name = nameof(Platform),
                    StartCoordinates = new Coordinates
                    {
                        X = x,
                        Y = -150
                    },
                    EndCoordinates = new Coordinates
                    {
                        X = x,
                        Y = -150
                    }
                }));
            }

            //Platform upper right
            for (var x = 900; x <= 1100; x += 200)
            {
                movableObjects.Add(movableObjectFactory.Create(new MovableObjectFactoryModel
                {
                    Name = nameof(Platform),
                    StartCoordinates = new Coordinates
                    {
                        X = x,
                        Y = -150
                    },
                    EndCoordinates = new Coordinates
                    {
                        X = x,
                        Y = -150
                    }
                }));
            }

            //platform upper middle
            for (var x = -100; x <= 800; x += 200)
            {
                movableObjects.Add(movableObjectFactory.Create(new MovableObjectFactoryModel
                {
                    Name = nameof(Platform),
                    StartCoordinates = new Coordinates
                    {
                        X = x,
                        Y = -360
                    },
                    EndCoordinates = new Coordinates
                    {
                        X = x,
                        Y = -360
                    }
                }));
            }

            movableObjects.Add(movableObjectFactory.Create(new MovableObjectFactoryModel
            {
                Name = nameof(TinyPlatform),
                StartCoordinates = new Coordinates
                {
                    X = 800,
                    Y = -800
                },
                EndCoordinates = new Coordinates
                {
                    X = 600,
                    Y = -800
                }
            }));

            return movableObjects;
        }

        private List<Ability> CreateAbilities()
        {
            var abilityFactory = new AbilityFactoryImp();
            var abilities = new List<Ability>();

            abilities.Add(abilityFactory.Create(new AbilityFactoryModel
            {
                Name = nameof(DoubleJump),
                Coordinates = new Coordinates
                {
                    X = -880,
                    Y = -200
                }
            }));


            abilities.Add(abilityFactory.Create(new AbilityFactoryModel
            {
                Name = nameof(Peck),
                Coordinates = new Coordinates
                {
                    X = 750,
                    Y = -400
                }
            }));

            abilities.Add(abilityFactory.Create(new AbilityFactoryModel
            {
                Name = nameof(DoubleJump),
                Coordinates = new Coordinates
                {
                    X = 1000,
                    Y = 5
                }
            }));


            abilities.Add(abilityFactory.Create(new AbilityFactoryModel
            {
                Name = nameof(WaterResistant),
                Coordinates = new Coordinates
                {
                    X = -880,
                    Y = 5
                }
            }));

            abilities.Add(abilityFactory.Create(new AbilityFactoryModel
            {
                Name = nameof(Float),
                Coordinates = new Coordinates
                {
                    X = 5,
                    Y = -410
                }
            }));

            return abilities;
        }

        private Time CreateMode()
        {
            var objectiveFactory = new ObjectiveFactoryImp();
            var modeFactory = new ModeFactoryImp();
            return (Time) modeFactory.Create(new TimeModeFactoryModel
            {
                Name = nameof(Time),
                Objectives = CreateObjectives(objectiveFactory),
                Goal = CreateGoal(objectiveFactory),
                CompletionTimeInSeconds = 60
            });
        }

        private List<Objective> CreateObjectives(ObjectiveFactoryImp objectiveFactory)
        {
            var objectives = new List<Objective>();

            objectives.Add(objectiveFactory.Create(new ObjectiveFactoryModel
            {
                Name = nameof(TreeCavity),
                Coordinates = new Coordinates
                {
                    X = -522,
                    Y = -285
                }
            }));

            return objectives;
        }

        private Objective CreateGoal(ObjectiveFactoryImp objectiveFactory)
        {
            return objectiveFactory.Create(new ObjectiveFactoryModel
            {
                Name = nameof(EggsNest),
                Coordinates = new Coordinates
                {
                    X = 800,
                    Y = -405
                }
            });
        }

        private static List<Enemy> CreateEnemies()
        {
            var enemyFactory = new EnemyFactoryImp();
            var enemies = new List<Enemy>();

            enemies.Add(enemyFactory.Create(new EnemyFactoryModel
            {
                Name = nameof(Raptor),
                StartCoordinates = new Coordinates
                {
                    X = -200,
                    Y = -220
                },
                EndCoordinates = new Coordinates
                {
                    X = -200,
                    Y = -500
                }
            }));

            enemies.Add(enemyFactory.Create(new EnemyFactoryModel
            {
                Name = nameof(Snake),
                StartCoordinates = new Coordinates
                {
                    X = 120,
                    Y = 15
                },
                EndCoordinates = new Coordinates
                {
                    X = 300,
                    Y = 15
                }
            }));

            enemies.Add(enemyFactory.Create(new EnemyFactoryModel
            {
                Name = nameof(Jaguar),
                StartCoordinates = new Coordinates
                {
                    X = 750,
                    Y = -430
                },
                EndCoordinates = new Coordinates
                {
                    X = 300,
                    Y = -430
                }
            }));

            return enemies;
        }
    }
}