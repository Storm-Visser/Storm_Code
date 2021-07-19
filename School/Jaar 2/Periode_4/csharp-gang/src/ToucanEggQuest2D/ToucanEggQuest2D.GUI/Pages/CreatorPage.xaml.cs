using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;
using ToucanEggQuest2D.Core;
using ToucanEggQuest2D.GUI.Config.Factories;
using ToucanEggQuest2D.Core.Factories;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using ToucanEggQuest2D.Core.MoveableObjects;
using ToucanEggQuest2D.Core.Obstacles;
using ToucanEggQuest2D.Core.SemiObstacles;
using ToucanEggQuest2D.Core.Enemies;
using ToucanEggQuest2D.Core.Abilities;
using ToucanEggQuest2D.Core.Modes;
using ToucanEggQuest2D.Core.Objectives;
using ToucanEggQuest2D.Core.Collisions.Models;
using Windows.UI.Core;
using Windows.System;

namespace ToucanEggQuest2D.GUI.Pages
{
    public sealed partial class CreatorPage : Page
    {
        private readonly DispatcherTimer sliderTimer;
        private readonly Rectangle menu;
        private TranslateTransform objectToBeDraged;
        private readonly int PW;
        private bool hide;
        private readonly Level level = new Level
        {
            MovableObjects = new List<MovableObject>(),
            Abilities = new List<Ability>(),
            Enemies = new List<Enemy>(),
            SemiObstacles = new List<SemiObstacle>(),
            Obstacles = new List<Obstacle>(),
            Lives = 3,
            Mode = new Time(new List<TreeCavity>(), null),
            ToucanStartCoordinates = new Coordinates { X = 0, Y = 0 },
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

        public CreatorPage()
        {
            InitializeComponent();
            Window.Current.CoreWindow.KeyDown += Exit;
            PW = (int)SliderCanvas.Width;
            hide = false;
            menu = new Rectangle
            {
                Height = 380,
                Width = Window.Current.Bounds.Width / 2,
                Fill = new SolidColorBrush(Windows.UI.Colors.White),
                Opacity = 0.5
            };
            SliderCanvas.Children.Add(menu);
            sliderTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(10)
            };
            sliderTimer.Tick += SliderOnTick;

            var roundtile = new Rectangle
            {
                Height = 50,
                Width = 50,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/RoundTile.png"))
                },
                ManipulationMode = ManipulationModes.All
            };
            roundtile.ManipulationDelta += MinapulationDelta;
            TranslateTransform roundtileTransform = new TranslateTransform();
            roundtile.RenderTransform = roundtileTransform;
            PointerEventHandler roundtilePointerReleasedEvent = null;
            roundtilePointerReleasedEvent = (sender, args) =>
            {
                AddObjectToCanvas(new BitmapImage(new Uri(@"ms-appx:///Assets/RoundTile.png")), 25, 10, 50, 50, roundtile, roundtilePointerReleasedEvent, "TinyPlatform");
            };
            roundtile.PointerReleased += roundtilePointerReleasedEvent;
            roundtile.PointerPressed += (sender, args) =>
            {
                objectToBeDraged = roundtileTransform;
            };
            SliderCanvas.Children.Add(roundtile);
            Canvas.SetLeft(roundtile, 25);
            Canvas.SetTop(roundtile, 10);

            var bigplatformtile1 = new Rectangle
            {
                Height = 50,
                Width = 200,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/BigRoundPlatform.png"))
                },
                ManipulationMode = ManipulationModes.All
            };
            bigplatformtile1.ManipulationDelta += MinapulationDelta;
            TranslateTransform bigplatformtile1Transform = new TranslateTransform();
            bigplatformtile1.RenderTransform = bigplatformtile1Transform;
            PointerEventHandler bigplatformtile1PointerReleasedEvent = null;
            bigplatformtile1PointerReleasedEvent = (sender, args) =>
            {
                AddObjectToCanvas(new BitmapImage(new Uri(@"ms-appx:///Assets/BigRoundPlatform.png")), 120, 10, 50, 200, bigplatformtile1, bigplatformtile1PointerReleasedEvent, "FloatingPlatform");
            };
            bigplatformtile1.PointerReleased += bigplatformtile1PointerReleasedEvent;
            bigplatformtile1.PointerPressed += (sender, args) =>
            {
                objectToBeDraged = bigplatformtile1Transform;
            };
            SliderCanvas.Children.Add(bigplatformtile1);
            Canvas.SetLeft(bigplatformtile1, 120);
            Canvas.SetTop(bigplatformtile1, 10);

            var middleplatformtile = new Rectangle
            {
                Height = 50,
                Width = 200,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/MiddlePlatform.png"))
                },
                ManipulationMode = ManipulationModes.All
            };
            middleplatformtile.ManipulationDelta += MinapulationDelta;
            TranslateTransform middleplatformtileTransform = new TranslateTransform();
            middleplatformtile.RenderTransform = middleplatformtileTransform;
            PointerEventHandler middleplatformPointerReleasedEvent = null;
            middleplatformPointerReleasedEvent = (sender, args) =>
            {
                AddObjectToCanvas(new BitmapImage(new Uri(@"ms-appx:///Assets/MiddlePlatform.png")), 360, 10, 50, 200, middleplatformtile, middleplatformPointerReleasedEvent, "Platform");
            };
            middleplatformtile.PointerReleased += middleplatformPointerReleasedEvent;
            middleplatformtile.PointerPressed += (sender, args) =>
            {
                objectToBeDraged = middleplatformtileTransform;
            };
            SliderCanvas.Children.Add(middleplatformtile);
            Canvas.SetLeft(middleplatformtile, 360);
            Canvas.SetTop(middleplatformtile, 10);

            var riggedplatformtile = new Rectangle
            {
                Height = 50,
                Width = 100,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/RiggedPlatform.png"))
                },
                ManipulationMode = ManipulationModes.All
            };
            riggedplatformtile.ManipulationDelta += MinapulationDelta;
            var riggedplatformtileTransform = new TranslateTransform();
            riggedplatformtile.RenderTransform = riggedplatformtileTransform;
            PointerEventHandler riggedplatformPointerReleasedEvent = null;
            riggedplatformPointerReleasedEvent = (sender, args) => { AddObjectToCanvas(new BitmapImage(new Uri(@"ms-appx:///Assets/RiggedPlatform.png")), 10, 95, 50, 100, riggedplatformtile, riggedplatformPointerReleasedEvent, "SmallPlatform"); };
            riggedplatformtile.PointerReleased += riggedplatformPointerReleasedEvent;
            riggedplatformtile.PointerPressed += (sender, args) =>
            {
                objectToBeDraged = riggedplatformtileTransform;
            };
            SliderCanvas.Children.Add(riggedplatformtile);
            Canvas.SetLeft(riggedplatformtile, 10);
            Canvas.SetTop(riggedplatformtile, 95);


            var water = new Rectangle
            {
                Height = 10,
                Width = 100,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/Water.png"))
                },
                ManipulationMode = ManipulationModes.All
            };
            water.ManipulationDelta += MinapulationDelta;
            TranslateTransform waterTransform = new TranslateTransform();
            water.RenderTransform = waterTransform;
            PointerEventHandler waterplatformPointerReleasedEvent = null;
            waterplatformPointerReleasedEvent = (sender, args) => { AddObjectToCanvas(new BitmapImage(new Uri(@"ms-appx:///Assets/Water.png")), 350, 105, 10, 100, water, waterplatformPointerReleasedEvent, "Waterpool"); };
            water.PointerReleased += waterplatformPointerReleasedEvent;
            water.PointerPressed += (sender, args) =>
            {
                objectToBeDraged = waterTransform;
            };
            SliderCanvas.Children.Add(water);
            Canvas.SetLeft(water, 350);
            Canvas.SetTop(water, 105);

            var bigcloudplatform = new Rectangle
            {
                Height = 80,
                Width = 200,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/BigCloudPlatform.png"))
                },
                ManipulationMode = ManipulationModes.All
            };
            bigcloudplatform.ManipulationDelta += MinapulationDelta;
            TranslateTransform bigcloudplatformTransform = new TranslateTransform();
            bigcloudplatform.RenderTransform = bigcloudplatformTransform;
            PointerEventHandler bigcloudplatformPointerReleasedEvent = null;
            bigcloudplatformPointerReleasedEvent = (sender, args) => { AddObjectToCanvas(new BitmapImage(new Uri(@"ms-appx:///Assets/BigCloudPlatform.png")), 130, 85, 80, 200, bigcloudplatform, bigcloudplatformPointerReleasedEvent, "Cloud"); };
            bigcloudplatform.PointerReleased += bigcloudplatformPointerReleasedEvent;
            bigcloudplatform.PointerPressed += (sender, args) =>
            {
                objectToBeDraged = bigcloudplatformTransform;
            };
            SliderCanvas.Children.Add(bigcloudplatform);
            Canvas.SetLeft(bigcloudplatform, 130);
            Canvas.SetTop(bigcloudplatform, 85);

            var nestgoal = new Rectangle
            {
                Height = 50,
                Width = 65,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/NestGoal.png"))
                },
                ManipulationMode = ManipulationModes.All
            };
            nestgoal.ManipulationDelta += MinapulationDelta;
            TranslateTransform nestgoalTransform = new TranslateTransform();
            nestgoal.RenderTransform = nestgoalTransform;
            PointerEventHandler nestgoalPointerReleasedEvent = null;
            nestgoalPointerReleasedEvent = (sender, args) => { AddObjectToCanvas(new BitmapImage(new Uri(@"ms-appx:///Assets/NestGoal.png")), 20, 200, 50, 65, nestgoal, nestgoalPointerReleasedEvent, "EggsNest"); };
            nestgoal.PointerReleased += nestgoalPointerReleasedEvent;
            nestgoal.PointerPressed += (sender, args) =>
            {
                objectToBeDraged = nestgoalTransform;
            };
            SliderCanvas.Children.Add(nestgoal);
            Canvas.SetLeft(nestgoal, 20);
            Canvas.SetTop(nestgoal, 200);


            var tree = new Rectangle
            {
                Height = 450,
                Width = 450,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/Tree.png"))
                },
                ManipulationMode = ManipulationModes.All
            };
            tree.ManipulationDelta += MinapulationDelta;
            TranslateTransform treeTransform = new TranslateTransform();
            tree.RenderTransform = treeTransform;
            PointerEventHandler treePointerReleasedEvent = null;
            treePointerReleasedEvent = (sender, args) => { AddObjectToCanvas(new BitmapImage(new Uri(@"ms-appx:///Assets/Tree.png")), 550, -35, 450, 450, tree, treePointerReleasedEvent, "Tree"); };
            tree.PointerReleased += treePointerReleasedEvent;
            tree.PointerPressed += (sender, args) =>
            {
                objectToBeDraged = treeTransform;
            };
            SliderCanvas.Children.Add(tree);
            Canvas.SetLeft(tree, 550);
            Canvas.SetTop(tree, -35);

            var branch = new Rectangle
            {
                Height = 20,
                Width = 100,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/Branch.png"))
                },
                ManipulationMode = ManipulationModes.All
            };
            branch.ManipulationDelta += MinapulationDelta;
            TranslateTransform branchTransform = new TranslateTransform();
            branch.RenderTransform = branchTransform;
            PointerEventHandler branchPointerReleasedEvent = null;
            branchPointerReleasedEvent = (sender, args) => { AddObjectToCanvas(new BitmapImage(new Uri(@"ms-appx:///Assets/Branch.png")), 470, 105, 20, 100, branch, branchPointerReleasedEvent, "Branch"); };
            branch.PointerReleased += branchPointerReleasedEvent;
            branch.PointerPressed += (sender, args) =>
            {
                objectToBeDraged = branchTransform;
            };
            SliderCanvas.Children.Add(branch);
            Canvas.SetLeft(branch, 470);
            Canvas.SetTop(branch, 105);

            var snake = new Rectangle
            {
                Height = 50,
                Width = 80,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/Snake.png"))
                },
                ManipulationMode = ManipulationModes.All
            };
            snake.ManipulationDelta += MinapulationDelta;
            TranslateTransform snakeTransform = new TranslateTransform();
            snake.RenderTransform = snakeTransform;
            PointerEventHandler snakePointerReleasedEvent = null;
            snakePointerReleasedEvent = (sender, args) => { AddObjectToCanvas(new BitmapImage(new Uri(@"ms-appx:///Assets/Snake.png")), 180, 200, 50, 80, snake, snakePointerReleasedEvent, "Snake"); };
            snake.PointerReleased += snakePointerReleasedEvent;
            snake.PointerPressed += (sender, args) =>
            {
                objectToBeDraged = snakeTransform;
            };
            SliderCanvas.Children.Add(snake);
            Canvas.SetLeft(snake, 180);
            Canvas.SetTop(snake, 200);

            var raptor = new Rectangle
            {
                Height = 80,
                Width = 100,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/Raptor.png"))
                },
                ManipulationMode = ManipulationModes.All
            };
            raptor.ManipulationDelta += MinapulationDelta;
            TranslateTransform raptorTransform = new TranslateTransform();
            raptor.RenderTransform = raptorTransform;
            PointerEventHandler raptorPointerReleasedEvent = null;
            raptorPointerReleasedEvent = (sender, args) => { AddObjectToCanvas(new BitmapImage(new Uri(@"ms-appx:///Assets/Raptor.png")), 330, 195, 80, 100, raptor, raptorPointerReleasedEvent, "Raptor"); };
            raptor.PointerReleased += raptorPointerReleasedEvent;
            raptor.PointerPressed += (sender, args) =>
            {
                objectToBeDraged = raptorTransform;
            };
            SliderCanvas.Children.Add(raptor);
            Canvas.SetLeft(raptor, 330);
            Canvas.SetTop(raptor, 195);

            var jaguar = new Rectangle
            {
                Height = 80,
                Width = 150,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/Jaguar.png"))
                },
                ManipulationMode = ManipulationModes.All
            };
            jaguar.ManipulationDelta += MinapulationDelta;
            TranslateTransform jaguarTransform = new TranslateTransform();
            jaguar.RenderTransform = jaguarTransform;
            PointerEventHandler jaguarPointerReleasedEvent = null;
            jaguarPointerReleasedEvent = (sender, args) => { AddObjectToCanvas(new BitmapImage(new Uri(@"ms-appx:///Assets/Jaguar.png")), 460, 195, 80, 150, jaguar, jaguarPointerReleasedEvent, "Jaguar"); };
            jaguar.PointerReleased += jaguarPointerReleasedEvent;
            jaguar.PointerPressed += (sender, args) =>
            {
                objectToBeDraged = jaguarTransform;
            };
            SliderCanvas.Children.Add(jaguar);
            Canvas.SetLeft(jaguar, 460);
            Canvas.SetTop(jaguar, 195);

            var peckpowerup = new Rectangle
            {
                Height = 40,
                Width = 40,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/RedPowerUp.png"))
                },
                ManipulationMode = ManipulationModes.All
            };
            peckpowerup.ManipulationDelta += MinapulationDelta;
            TranslateTransform peckpowerupTransform = new TranslateTransform();
            peckpowerup.RenderTransform = peckpowerupTransform;
            PointerEventHandler peckpowerupPointerReleasedEvent = null;
            peckpowerupPointerReleasedEvent = (sender, args) => { AddObjectToCanvas(new BitmapImage(new Uri(@"ms-appx:///Assets/RedPowerUp.png")), 20, 320, 40, 40, peckpowerup, peckpowerupPointerReleasedEvent, "Peck"); };
            peckpowerup.PointerReleased += peckpowerupPointerReleasedEvent;
            peckpowerup.PointerPressed += (sender, args) =>
            {
                objectToBeDraged = peckpowerupTransform;
            };
            SliderCanvas.Children.Add(peckpowerup);
            Canvas.SetLeft(peckpowerup, 20);
            Canvas.SetTop(peckpowerup, 320);
            var doublejumppowerup = new Rectangle
            {
                Height = 40,
                Width = 40,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/PurplePowerUp.png"))
                },
                ManipulationMode = ManipulationModes.All
            };
            doublejumppowerup.ManipulationDelta += MinapulationDelta;
            TranslateTransform doublejumppowerupTransform = new TranslateTransform();
            doublejumppowerup.RenderTransform = doublejumppowerupTransform;
            PointerEventHandler doublejumpPointerReleasedEvent = null;
            doublejumpPointerReleasedEvent = (sender, args) => { AddObjectToCanvas(new BitmapImage(new Uri(@"ms-appx:///Assets/PurplePowerUp.png")), 140, 320, 40, 40, doublejumppowerup, doublejumpPointerReleasedEvent, "DoubleJump"); };
            doublejumppowerup.PointerReleased += doublejumpPointerReleasedEvent;
            doublejumppowerup.PointerPressed += (sender, args) =>
            {
                objectToBeDraged = doublejumppowerupTransform;
            };
            SliderCanvas.Children.Add(doublejumppowerup);
            Canvas.SetLeft(doublejumppowerup, 140);
            Canvas.SetTop(doublejumppowerup, 320);

            var floatpowerup = new Rectangle
            {
                Height = 40,
                Width = 40,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/GreyPowerUp.png"))
                },
                ManipulationMode = ManipulationModes.All
            };
            floatpowerup.ManipulationDelta += MinapulationDelta;
            TranslateTransform floatpowerupTransform = new TranslateTransform();
            floatpowerup.RenderTransform = floatpowerupTransform;
            PointerEventHandler floatpowerupPointerReleasedEvent = null;
            floatpowerupPointerReleasedEvent = (sender, args) => { AddObjectToCanvas(new BitmapImage(new Uri(@"ms-appx:///Assets/GreyPowerUp.png")), 250, 320, 40, 40, floatpowerup, floatpowerupPointerReleasedEvent, "Float"); };
            floatpowerup.PointerReleased += floatpowerupPointerReleasedEvent;
            floatpowerup.PointerPressed += (sender, args) =>
            {
                objectToBeDraged = floatpowerupTransform;
            };
            SliderCanvas.Children.Add(floatpowerup);
            Canvas.SetLeft(floatpowerup, 250);
            Canvas.SetTop(floatpowerup, 320);

            var waterpowerup = new Rectangle
            {
                Height = 40,
                Width = 40,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/BluePowerUp.png"))
                },
                ManipulationMode = ManipulationModes.All
            };
            waterpowerup.ManipulationDelta += MinapulationDelta;
            TranslateTransform waterpowerupTransform = new TranslateTransform();
            waterpowerup.RenderTransform = waterpowerupTransform;
            PointerEventHandler waterpowerupPointerReleasedEvent = null;
            waterpowerupPointerReleasedEvent = (sender, args) =>
            {
                AddObjectToCanvas(new BitmapImage(new Uri(@"ms-appx:///Assets/BluePowerUp.png")), 360, 320, 40, 40, waterpowerup, waterpowerupPointerReleasedEvent, "Float");
            };
            waterpowerup.PointerReleased += waterpowerupPointerReleasedEvent;
            waterpowerup.PointerPressed += (sender, args) =>
            {
                objectToBeDraged = waterpowerupTransform;
            };
            SliderCanvas.Children.Add(waterpowerup);
            Canvas.SetLeft(waterpowerup, 360);
            Canvas.SetTop(waterpowerup, 320);

            var bigrock = new Rectangle
            {
                Height = 100,
                Width = 100,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/BigRock.png"))
                },
                ManipulationMode = ManipulationModes.All
            };
            bigrock.ManipulationDelta += MinapulationDelta;
            TranslateTransform bigrockTransform = new TranslateTransform();
            bigrock.RenderTransform = bigrockTransform;
            PointerEventHandler bigrockPointerReleasedEvent = null;
            bigrockPointerReleasedEvent = (sender, args) =>
            {
                AddObjectToCanvas(new BitmapImage(new Uri(@"ms-appx:///Assets/BigRock.png")), 480, 280, 100, 100, bigrock, bigrockPointerReleasedEvent, "Rock");
            };
            bigrock.PointerReleased += bigrockPointerReleasedEvent;
            bigrock.PointerPressed += (sender, args) =>
            {
                objectToBeDraged = bigrockTransform;
            };
            SliderCanvas.Children.Add(bigrock);
            Canvas.SetLeft(bigrock, 480);
            Canvas.SetTop(bigrock, 280);
        }

        public void PageLoaded(object sender, RoutedEventArgs e)
        {
            var startingBlock = new Rectangle
            {
                Height = 50,
                Width = 50,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/RoundTile.png"))
                }
            };

            var toucan = new Rectangle
            {
                Height = 80,
                Width = 80,
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/Toucan.png"))
                }
            };

            SliderCanvas.Children.Add(startingBlock);
            SliderCanvas.Children.Add(toucan);

            Canvas.SetLeft(startingBlock, ((Frame)Window.Current.Content).ActualWidth / 2);
            Canvas.SetTop(startingBlock, ((Frame)Window.Current.Content).ActualHeight / 1.2 + 80);
            Canvas.SetLeft(toucan, ((Frame)Window.Current.Content).ActualWidth / 2);
            Canvas.SetTop(toucan, ((Frame)Window.Current.Content).ActualHeight / 1.2);

            level.Toucan = new ToucanFactoryImp().Create(new ToucanFactoryModel
            {
                Name = "Toucan",
                Lives = 3,
                Coordinates = new Coordinates
                {
                    X = 0,
                    Y = 0
                }
            });

            CreateNewGameObject("TinyPlatform", 0, 100);
        }

        private void SliderOnTick(object sender, object e)
        {
            if (hide)
            {
                SliderCanvas.Width += 1;
                if (SliderCanvas.Width >= PW)
                {
                    sliderTimer.Stop();
                    hide = false;
                    this.UpdateLayout();
                }
            }
            else
            {
                SliderCanvas.Width -= 1;
                if (SliderCanvas.Width <= 0)
                {
                    sliderTimer.Stop();
                    hide = true;
                    UpdateLayout();
                }
            }
        }

        private void AddObjectToCanvas(BitmapImage image, int XOffset, int YOffset, int height, int width, Rectangle standardObject, PointerEventHandler pointerClickedEventHandler, string name)
        {
            Rectangle dummyRectangle = new Rectangle
            {
                Height = height,
                Width = width,
                Fill = new ImageBrush
                {
                    ImageSource = image
                },
                ManipulationMode = ManipulationModes.All
            };

            dummyRectangle.ManipulationDelta += MinapulationDelta;
            var dummyTransform = new TranslateTransform();
            dummyRectangle.RenderTransform = dummyTransform;
            PointerEventHandler dummyPointerReleasedEvent = null;
            dummyPointerReleasedEvent = (sender, e) =>
            {
                AddObjectToCanvas(image, XOffset, YOffset, height, width, dummyRectangle, dummyPointerReleasedEvent, name);
            };
            dummyRectangle.PointerReleased += dummyPointerReleasedEvent;

            dummyRectangle.PointerPressed += (sender, e) =>
            {
                objectToBeDraged = dummyTransform;
            };

            var x = (int)(objectToBeDraged.X + XOffset - ((Frame)Window.Current.Content).ActualWidth / 2);
            var y = (int)(objectToBeDraged.Y + YOffset - ((Frame)Window.Current.Content).ActualHeight / 1.2);

            var gameObject = CreateNewGameObject(name, x, y);

            standardObject.PointerPressed += (sender, e) =>
            {
                var ptr = e.Pointer;
                if (ptr.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse)
                {
                    Windows.UI.Input.PointerPoint ptrPt = e.GetCurrentPoint(this);
                    if (ptrPt.Properties.IsRightButtonPressed)
                    {
                        SliderCanvas.Children.Remove(standardObject);
                        RemoveGameObject(gameObject);
                    }
                }
            };

            standardObject.PointerReleased -= pointerClickedEventHandler;

            SliderCanvas.Children.Add(dummyRectangle);
            standardObject.ManipulationDelta -= MinapulationDelta;
            Canvas.SetLeft(dummyRectangle, XOffset);
            Canvas.SetTop(dummyRectangle, YOffset);
        }

        private void MinapulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            //Moves the TextBox.
            objectToBeDraged.X += e.Delta.Translation.X;
            objectToBeDraged.Y += e.Delta.Translation.Y;
        }

        private Collider CreateNewGameObject(string name, int X, int Y)
        {
            var abilityFactory = new AbilityFactoryImp();
            var enemyFactory = new EnemyFactoryImp();
            var movableObjectFactory = new MovableObjectFactoryImp();
            var objectiveFactory = new ObjectiveFactoryImp();
            var obstacleFactory = new ObstacleFactoryImp();
            var semiObstacleFactory = new SemiObstacleFactoryImp();

            try
            {
                var ability = abilityFactory.Create(new AbilityFactoryModel
                {
                    Name = name,
                    Coordinates = new Coordinates { X = X, Y = Y }
                });
                level.AddAbility(ability);
                return ability;
            }
            catch
            {
                // ignored
            }

            try
            {
                var enemy = enemyFactory.Create(new EnemyFactoryModel
                {
                    Name = name,
                    StartCoordinates = new Coordinates { X = X, Y = Y },
                    EndCoordinates = new Coordinates { X = X, Y = Y }
                });
                level.AddEnemy(enemy);
                return enemy;
            }
            catch
            {
                // ignored
            }

            try
            {
                var movableObject = movableObjectFactory.Create(new MovableObjectFactoryModel
                {
                    Name = name,
                    StartCoordinates = new Coordinates { X = X, Y = Y },
                    EndCoordinates = new Coordinates { X = X, Y = Y }
                });
                level.AddMovableObject(movableObject);
                return movableObject;
            }
            catch
            {
                // ignored
            }

            try
            {
                if (name != "EggsNest")
                {
                    var objective = objectiveFactory.Create(new ObjectiveFactoryModel
                    {
                        Name = name,
                        Coordinates = new Coordinates { X = X, Y = Y }
                    });
                    level.Mode.AddObjective(objective);
                    return objective;
                }
                else
                {
                    level.Mode.Goal = objectiveFactory.Create(new ObjectiveFactoryModel
                    {
                        Name = name,
                        Coordinates = new Coordinates { X = X, Y = Y }
                    });
                }
                return null;
            }
            catch
            {
                // ignored
            }

            try
            {
                var obstacle = obstacleFactory.Create(new ObstacleFactoryModel
                {
                    Name = name,
                    Coordinates = new Coordinates { X = X, Y = Y }
                });
                if (name == nameof(Tree))
                {
                    var objective = objectiveFactory.Create(new ObjectiveFactoryModel
                    {
                        Name = nameof(TreeCavity),
                        Coordinates = new Coordinates
                        {
                            X = X + 178,
                            Y = Y + 270
                        }
                    });
                    level.Mode.AddObjective(objective);
                }
                level.AddObstacle(obstacle);
                return obstacle;
            }
            catch
            {
                // ignored
            }

            try
            {
                var semiObstacle = semiObstacleFactory.Create(new SemiObstacleFactoryModel
                {
                    Name = name,
                    Coordinates = new Coordinates { X = X, Y = Y }
                });
                level.AddSemiObstacle(semiObstacle);
                return semiObstacle;
            }
            catch
            {
                // ignored
            }
            throw new Exception("Name is not found");
        }


        private void RemoveGameObject(Collider @object)
        {

            try
            {
                level.RemoveAbility((Ability)@object);
                return;
            }
            catch
            {
                // ignored
            }

            try
            {
                level.RemoveEnemy((Enemy)@object);
                return;
            }
            catch
            {
                // ignored
            }

            try
            {
                level.RemoveMoveAbleObject(@object);
                return;
            }
            catch
            {
                // ignored
            }

            try
            {
                if (@object.GetType() != typeof(EggsNest))
                {
                    level.Mode.removeObjective(@object);
                }
                else
                {
                    level.Mode.Goal = null;
                }
                return;
            }
            catch
            {
                // ignored
            }

            try
            {
                level.RemoveObstacle((Obstacle)@object);
                return;
            }
            catch
            {
                // ignored
            }

            try
            {
                level.RemoveSemiObstacle((SemiObstacle)@object);
                return;
            }
            catch
            {
                // ignored
            }
            throw new Exception("Name is not found");
        }

        public void Save(object sender, RoutedEventArgs e)
        {
            timePopup.IsOpen = true;
        }

        public void ClosePopup(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(time.Text, @"^[a-zA-Z]+$") || string.IsNullOrEmpty(time.Text))
            {
                errorText.Text = "Please insert a number";
            }
            else
            {
                level.Mode.TimeToCompleteInSeconds = int.Parse(time.Text);
                timePopup.IsOpen = false;
            }
            Window.Current.CoreWindow.KeyDown -= Exit;
            Frame.Navigate(typeof(PlayPage), level);
        }
        public void Exit(object sender, KeyEventArgs e)
        {
            switch (e.VirtualKey)
            {
                case VirtualKey.Escape:
                    Frame.Navigate(typeof(MainPage));
                    Window.Current.CoreWindow.KeyDown -= Exit;
                    break;
            }
        }
    }
}