using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToucanEggQuest2D.Core;
using ToucanEggQuest2D.GUI.Elements;
using ToucanEggQuest2D.GUI.Models;
using ToucanEggQuest2D.GUI.Pages;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

/*
 * Objecten worden geplaatst van de startpositie van de toekan.
 * Dus als de toekan op x:1500 begint en een object op x:1000
 * dan wordt het object op -500 geplaatst relatief aan de positie van de toekan.
 */
namespace ToucanEggQuest2D.GUI.Handlers
{
    public class RenderHandler
    {
        private readonly PlayPage playPage;
        private readonly ElementFactory elementFactory;

        public ToucanUI ToucanUI;
        public List<EnemyUI> EnemyUIs = new List<EnemyUI>();
        public List<ObjectiveUI> ObjectiveUIs = new List<ObjectiveUI>();
        public List<AbilityUI> AbilityUIs = new List<AbilityUI>();
        public List<MovableObjectUI> MovableObjectUIs = new List<MovableObjectUI>();
        public List<SemiObstacleUI> SemiObstacleUIs = new List<SemiObstacleUI>();
        public List<ObstacleUI> ObstacleUIs = new List<ObstacleUI>();

        public RenderHandler(PlayPage playPage)
        {
            this.playPage = playPage;

            elementFactory = new ElementFactory();

            playPage.Canvas.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(playPage.Level.Background.ImageKey)),
                Stretch = Stretch.Fill
            };

            InitialiseGame();
        }

        private void InitialiseGame()
        {
            AddToucanElementToCanvas();
            CreateObstacleElements();
            CreateSemiObstacleElements();
            CreateMovableObjectElements();
            CreateAbilityElements();
            CreateObjectiveElements();
            CreateEnemyElements();
        }

        public void ResetCanvas()
        {
            playPage.Canvas.Children.Clear();
            ToucanUI = null;
            EnemyUIs.Clear();
            ObjectiveUIs.Clear();
            AbilityUIs.Clear();
            MovableObjectUIs.Clear();
            SemiObstacleUIs.Clear();
            ObstacleUIs.Clear();
            InitialiseGame();
        }

        public async Task RedrawHorizontal()
        {
            await Task.WhenAll(EnemyUIs.Select(x =>
            {
                SetElementCoordinates(x.Rectangle, x.Image, x.Source.Coordinates);
                return Task.CompletedTask;
            }));

            await Task.WhenAll(ObjectiveUIs.Select(x =>
            {
                SetElementCoordinates(x.Rectangle, x.Image, x.Source.Coordinates);
                return Task.CompletedTask;
            }));

            await Task.WhenAll(AbilityUIs.Select(x =>
            {
                SetElementCoordinates(x.Rectangle, x.Image, x.Source.Coordinates);
                return Task.CompletedTask;
            }));

            await Task.WhenAll(MovableObjectUIs.Select(x =>
            {
                SetElementCoordinates(x.Rectangle, x.Image, x.Source.Coordinates);
                return Task.CompletedTask;
            }));

            await Task.WhenAll(SemiObstacleUIs.Select(x =>
            {
                SetElementCoordinates(x.Rectangle, x.Image, x.Source.Coordinates);
                return Task.CompletedTask;
            }));

            await Task.WhenAll(ObstacleUIs.Select(x =>
            {
                SetElementCoordinates(x.Rectangle, x.Image, x.Source.Coordinates);
                return Task.CompletedTask;
            }));
        }

        /// <summary>
        /// Updates the environments vertical position
        /// </summary>
        /// <param name="units">Units to update (can be negative)</param>
        /// <returns>Whether the toucan is colliding from above</returns>
        public async Task RedrawVertical()
        {
            await Task.WhenAll(EnemyUIs.Select(x =>
            {
                SetElementCoordinates(x.Rectangle, x.Image, x.Source.Coordinates);
                return Task.CompletedTask;
            }));

            await Task.WhenAll(ObjectiveUIs.Select(x =>
            {
                SetElementCoordinates(x.Rectangle, x.Image, x.Source.Coordinates);
                return Task.CompletedTask;
            }));

            await Task.WhenAll(AbilityUIs.Select(x =>
            {
                SetElementCoordinates(x.Rectangle, x.Image, x.Source.Coordinates);
                return Task.CompletedTask;
            }));

            await Task.WhenAll(MovableObjectUIs.Select(x =>
            {
                SetElementCoordinates(x.Rectangle, x.Image, x.Source.Coordinates);
                return Task.CompletedTask;
            }));

            await Task.WhenAll(SemiObstacleUIs.Select(x =>
            {
                SetElementCoordinates(x.Rectangle, x.Image, x.Source.Coordinates);
                return Task.CompletedTask;
            }));

            await Task.WhenAll(ObstacleUIs.Select(x =>
            {
                SetElementCoordinates(x.Rectangle, x.Image, x.Source.Coordinates);
                return Task.CompletedTask;
            }));

            await Task.CompletedTask;
        }

        public async Task RedrawEnemies()
        {
            await Task.WhenAll(EnemyUIs.Select(x =>
            {
                x.Source.Update(); //Needs to be replaced
                SetElementCoordinates(x.Rectangle, x.Image, x.Source.Coordinates);
                return Task.CompletedTask;
            }));
        }

        public async Task RedrawMovableObjects()
        {
            await Task.WhenAll(MovableObjectUIs.Select(x =>
            {
                if (x.Source.Update()) //Needs to be replaced
                    SetElementCoordinates(x.Rectangle, x.Image, x.Source.Coordinates);
                return Task.CompletedTask;
            }));
        }

        private void AddToucanElementToCanvas()
        {
            //Create toucan element
            ToucanUI = elementFactory.CreateToucanElement(playPage.Level.Toucan);

            //Add toucan collider and texture
            playPage.Canvas.Children.Add(ToucanUI.Rectangle);
            playPage.Canvas.Children.Add(ToucanUI.Image);

            //Position toucan collider and texture
            Canvas.SetLeft(ToucanUI.Rectangle, (int)playPage.Canvas.Width / 2);
            Canvas.SetTop(ToucanUI.Rectangle, (int)(playPage.Canvas.Height / 1.2));
            Canvas.SetZIndex(ToucanUI.Rectangle, 1);
            Canvas.SetLeft(ToucanUI.Image, (int)playPage.Canvas.Width / 2);
            Canvas.SetTop(ToucanUI.Image, (int)(playPage.Canvas.Height / 1.2));
            Canvas.SetZIndex(ToucanUI.Image, 7);
        }

        private void CreateObstacleElements()
        {
            foreach (var o in playPage.Level.Obstacles)
            {
                var element = elementFactory.CreateObstacleElement(o);
                ObstacleUIs.Add(element);
                AddElementToCanvas(element.Rectangle, element.Image, element.Source.Coordinates, 1);
            }
        }

        private void CreateMovableObjectElements()
        {
            foreach (var o in playPage.Level.MovableObjects)
            {
                var element = elementFactory.CreateMovableObjectElement(o);
                MovableObjectUIs.Add(element);
                AddElementToCanvas(element.Rectangle, element.Image, element.Source.Coordinates, 2);
            }
        }

        private void CreateSemiObstacleElements()
        {
            foreach (var o in playPage.Level.SemiObstacles)
            {
                var element = elementFactory.CreateSemiObstacleElement(o);
                SemiObstacleUIs.Add(element);
                AddElementToCanvas(element.Rectangle, element.Image, element.Source.Coordinates, 3);
            }
        }

        private void CreateAbilityElements()
        {
            foreach (var o in playPage.Level.Abilities)
            {
                var element = elementFactory.CreateAbilityElement(o);
                AbilityUIs.Add(element);
                AddElementToCanvas(element.Rectangle, element.Image, element.Source.Coordinates, 4);
            }
        }

        private void CreateObjectiveElements()
        {
            foreach (var o in playPage.Level.Mode.Objectives)
            {
                var element = elementFactory.CreateObjectiveElement(o);
                ObjectiveUIs.Add(element);
                AddElementToCanvas(element.Rectangle, element.Image, element.Source.Coordinates, 5);
            }

            if (playPage.Level.Mode.Goal != null)
            {
                var element = elementFactory.CreateObjectiveElement(playPage.Level.Mode.Goal);
                ObjectiveUIs.Add(element);
                AddElementToCanvas(element.Rectangle, element.Image, element.Source.Coordinates, 5);
            }
        }

        private void CreateEnemyElements()
        {
            foreach (var e in playPage.Level.Enemies)
            {
                var element = elementFactory.CreateEnemyElement(e);
                EnemyUIs.Add(element);
                AddElementToCanvas(element.Rectangle, element.Image, element.Source.Coordinates, 6);
            }
        }

        private void AddElementToCanvas(Rectangle collider, Image texture, Coordinates coordinates, int zIndex)
        {
            playPage.Canvas.Children.Add(collider);
            playPage.Canvas.Children.Add(texture);
            Canvas.SetZIndex(texture, zIndex);
            Canvas.SetZIndex(collider, zIndex);
            //Allign texture exactly around the collider
            SetElementCoordinates(collider, texture, coordinates);
        }

        private void SetElementCoordinates(Rectangle collider, Image texture, Coordinates coordinates)
        {
            //Calculate coordinates
            var x = coordinates.X - ToucanUI.Source.Coordinates.X;
            var y = coordinates.Y - ToucanUI.Source.Coordinates.Y;
            //Get current UI coordinates
            var toucanLeft = Canvas.GetLeft(ToucanUI.Rectangle);
            var toucanTop = Canvas.GetTop(ToucanUI.Rectangle);
            //Set collider
            Canvas.SetLeft(collider, toucanLeft + x);
            Canvas.SetTop(collider, toucanTop + y);
            //Set texture
            Canvas.SetLeft(texture, toucanLeft + x);
            Canvas.SetTop(texture, toucanTop + y);
        }
    }
}