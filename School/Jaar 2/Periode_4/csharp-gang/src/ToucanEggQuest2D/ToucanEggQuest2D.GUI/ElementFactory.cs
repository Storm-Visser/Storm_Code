using System;
using ToucanEggQuest2D.Core;
using ToucanEggQuest2D.Core.Abilities;
using ToucanEggQuest2D.Core.Enemies;
using ToucanEggQuest2D.Core.MoveableObjects;
using ToucanEggQuest2D.Core.Objectives;
using ToucanEggQuest2D.Core.Obstacles;
using ToucanEggQuest2D.Core.SemiObstacles;
using ToucanEggQuest2D.GUI.Elements;
using ToucanEggQuest2D.GUI.Models;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace ToucanEggQuest2D.GUI
{
    public class ElementFactory
    {
        public ElementFactory()
        {
        }

        public ToucanUI CreateToucanElement(Toucan t)
        {
            return new ToucanUI
            {
                Source = t,
                Rectangle = Collider(t.Dimensions.Height, t.Dimensions.Width, Colors.Transparent),
                Image = Texture(t.Texture.Dimensions.Height, t.Texture.Dimensions.Width, t.Texture.ImageKey)
            };
        }

        public EnemyUI CreateEnemyElement(Enemy e)
        {
            return new EnemyUI
            {
                Source = e,
                Rectangle = Collider(e.Dimensions.Height, e.Dimensions.Width, Colors.Transparent),
                Image = Texture(e.Texture.Dimensions.Height, e.Texture.Dimensions.Width, e.Texture.ImageKey)
            };
        }

        public ObjectiveUI CreateObjectiveElement(Objective o)
        {
            return new ObjectiveUI
            {
                Source = o,
                Rectangle = Collider(o.Dimensions.Height, o.Dimensions.Width, Colors.Transparent),
                Image = Texture(o.Texture.Dimensions.Height, o.Texture.Dimensions.Width, o.Texture.ImageKey)
            };
        }

        public ObjectiveUI CreateGoalElement(Objective o)
        {
            return new ObjectiveUI
            {
                Source = o,
                Rectangle = Collider(o.Dimensions.Height, o.Dimensions.Width, Colors.Transparent),
                Image = Texture(o.Texture.Dimensions.Height, o.Texture.Dimensions.Width, o.Texture.ImageKey)
            };
        }

        public AbilityUI CreateAbilityElement(Ability a)
        {
            return new AbilityUI
            {
                Source = a,
                Rectangle = Collider(a.Dimensions.Height, a.Dimensions.Width, Colors.Transparent),
                Image = Texture(a.Texture.Dimensions.Height, a.Texture.Dimensions.Width, a.Texture.ImageKey)
            };
        }

        public MovableObjectUI CreateMovableObjectElement(MovableObject m)
        {
            return new MovableObjectUI
            {
                Source = m,
                Rectangle = Collider(m.Dimensions.Height, m.Dimensions.Width, Colors.Transparent),
                Image = Texture(m.Texture.Dimensions.Height, m.Texture.Dimensions.Width, m.Texture.ImageKey)
            };
        }

        public SemiObstacleUI CreateSemiObstacleElement(SemiObstacle s)
        {
            return new SemiObstacleUI
            {
                Source = s,
                Rectangle = Collider(s.Dimensions.Height, s.Dimensions.Width, Colors.Transparent),
                Image = Texture(s.Texture.Dimensions.Height, s.Texture.Dimensions.Width, s.Texture.ImageKey)
            };
        }

        public ObstacleUI CreateObstacleElement(Obstacle o)
        {
            return new ObstacleUI
            {
                Source = o,
                Rectangle = Collider(o.Dimensions.Height, o.Dimensions.Width, Colors.Transparent),
                Image = Texture(o.Texture.Dimensions.Height, o.Texture.Dimensions.Width, o.Texture.ImageKey)
            };
        }

        private Rectangle Collider(int height, int width, /* TEMP */ Color c)
        {
            return new Rectangle
            {
                Height = height,
                Width = width,
                Fill = new SolidColorBrush(c)
            };
        }

        private Image Texture(int height, int width, string key)
        {
            if (key.Contains(".svg"))
            {
                return new Image
                {
                    Source = new SvgImageSource(new Uri(key)),
                    Height = height,
                    Width = width
                };
            }
            else
            {
                return new Image
                {
                    Source = new BitmapImage(new Uri(key)),
                    Height = height,
                    Width = width,
                    Stretch = Stretch.Fill
                };
            }
        }
    }
}