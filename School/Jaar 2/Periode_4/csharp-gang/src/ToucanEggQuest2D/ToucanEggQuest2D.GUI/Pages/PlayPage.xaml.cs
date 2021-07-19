using ToucanEggQuest2D.Core;
using ToucanEggQuest2D.GUI.Handlers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Windows.UI;
using Windows.UI.Xaml.Media.Imaging;
using System;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Input;

namespace ToucanEggQuest2D.GUI.Pages
{
    public sealed partial class PlayPage : Page
    {
        public Level Level;

        public TextBlock TimeTextBlock;
        public TextBlock LivesTextBlock;

        public RenderHandler RenderHandler;
        public KeyHandler KeyHandler;
        public TimerHandler TimerHandler;
        public InteractionHandler InteractionHandler;
        public ProgressionHandler ProgressionHandler;
        public CollisionHandler CollisionHandler;

        public PlayPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs x)
        {
            Level = x.Parameter as Level;

            Loaded += (object sender, RoutedEventArgs y) =>
            {
                Canvas.Height = Window.Current.Bounds.Height;
                Canvas.Width = Window.Current.Bounds.Width;

                RenderHandler = new RenderHandler(this);
                KeyHandler = new KeyHandler(this);
                TimerHandler = new TimerHandler(this);
                InteractionHandler = new InteractionHandler(this);
                ProgressionHandler = new ProgressionHandler(this);
                CollisionHandler = new CollisionHandler(this);

                InitialiseMenu();

                Window.Current.CoreWindow.KeyDown += KeyHandler.MenuOnKeyDown;

                Play();
            };
        }

        public void InitialiseMenu()
        {
            TimeTextBlock = new TextBlock
            {
                FontFamily = new FontFamily("Ravie"),
                Foreground = new SolidColorBrush(Colors.Black)
            };
            MenuGrid.Children.Add(TimeTextBlock);
            Grid.SetColumn(TimeTextBlock, 1);
            Grid.SetRow(TimeTextBlock, 0);
            Grid.SetColumnSpan(TimeTextBlock, 6);
            Grid.SetRowSpan(TimeTextBlock, 6);

            LivesTextBlock = new TextBlock
            {
                FontFamily = new FontFamily("Ravie"),
                Foreground = new SolidColorBrush(Colors.Black)
            };
            MenuGrid.Children.Add(LivesTextBlock);
            Grid.SetColumn(LivesTextBlock, 6);
            Grid.SetRow(LivesTextBlock, 0);
            Grid.SetColumnSpan(LivesTextBlock, 6);
            Grid.SetRowSpan(LivesTextBlock, 6);

            var fader = new Rectangle
            {
                Fill = new SolidColorBrush(Colors.Black),
                Opacity = 0.8
            };
            MenuGrid.Children.Add(fader);
            Grid.SetColumn(fader, 0);
            Grid.SetRow(fader, 0);
            Grid.SetColumnSpan(fader, 6);
            Grid.SetRowSpan(fader, 6);

            var ResumeButton = new Rectangle
            {
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/ResumeMenuButton.png"))
                }
            };
            ResumeButton.PointerPressed += (object sender, PointerRoutedEventArgs e) =>
            {
                Play();
                HideMenu();
            };
            MenuGrid.Children.Add(ResumeButton);
            Grid.SetColumn(ResumeButton, 2);
            Grid.SetRow(ResumeButton, 1);
            Grid.SetColumnSpan(ResumeButton, 2);
            Grid.SetRowSpan(ResumeButton, 2);

            var QuitButton = new Rectangle
            {
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/QuitMenuButton.png"))
                }
            };
            QuitButton.PointerPressed += (object sender, PointerRoutedEventArgs e) =>
            {
                Pause();
                Frame.Navigate(typeof(MainPage));
            };
            MenuGrid.Children.Add(QuitButton);
            Grid.SetColumn(QuitButton, 2);
            Grid.SetRow(QuitButton, 3);
            Grid.SetColumnSpan(QuitButton, 2);
            Grid.SetRowSpan(QuitButton, 2);
        }

        public void HideMenu()
        {
            foreach (var child in MenuGrid.Children)
                if (!child.Equals(Canvas) && !child.Equals(TimeTextBlock) && !child.Equals(LivesTextBlock))
                    child.Visibility = Visibility.Collapsed;
        }

        public void ShowMenu()
        {
            foreach (var child in MenuGrid.Children)
                if (!child.Equals(Canvas) && !child.Equals(TimeTextBlock) && !child.Equals(LivesTextBlock))
                    child.Visibility = Visibility.Visible;
        }

        public void InitialiseGameOver()
        {
            var fader = new Rectangle
            {
                Fill = new SolidColorBrush(Colors.Black),
                Opacity = 0.8
            };

            MenuGrid.Children.Add(fader);
            Grid.SetColumn(fader, 0);
            Grid.SetRow(fader, 0);
            Grid.SetColumnSpan(fader, 6);
            Grid.SetRowSpan(fader, 6);

            var losingText = new Rectangle
            {
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/LosingText.png"))
                }
            };

            MenuGrid.Children.Add(losingText);
            Grid.SetColumn(losingText, 1);
            Grid.SetRow(losingText, 1);
            Grid.SetColumnSpan(losingText, 4);
            Grid.SetRowSpan(losingText, 4);
        }

        public void InitialiseGameWon()
        {
            var fader = new Rectangle
            {
                Fill = new SolidColorBrush(Colors.Black),
                Opacity = 0.8
            };

            MenuGrid.Children.Add(fader);
            Grid.SetColumn(fader, 0);
            Grid.SetRow(fader, 0);
            Grid.SetColumnSpan(fader, 6);
            Grid.SetRowSpan(fader, 6);

            var winningText = new Rectangle
            {
                Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"ms-appx:///Assets/WinningText.png"))
                }
            };

            MenuGrid.Children.Add(winningText);
            Grid.SetColumn(winningText, 1);
            Grid.SetRow(winningText, 1);
            Grid.SetColumnSpan(winningText, 4);
            Grid.SetRowSpan(winningText, 4);
        }

        public void Play()
        {
            KeyHandler.Running = true;

            Window.Current.CoreWindow.KeyDown += KeyHandler.GameOnKeyDown;
            Window.Current.CoreWindow.KeyUp += KeyHandler.GameOnKeyUp;

            TimerHandler.InteractionTimer.Start();
            TimerHandler.ProgressionTimer.Stop();
            TimerHandler.ToucanJumpAndFallTimer.Start();
            TimerHandler.DynamicObjectsTimer.Start();
        }

        public void Pause()
        {
            KeyHandler.Running = false;

            Window.Current.CoreWindow.KeyDown -= KeyHandler.GameOnKeyDown;
            Window.Current.CoreWindow.KeyUp -= KeyHandler.GameOnKeyUp;

            TimerHandler.InteractionTimer.Stop();
            TimerHandler.ProgressionTimer.Stop();
            TimerHandler.ToucanJumpAndFallTimer.Stop();
            TimerHandler.DynamicObjectsTimer.Stop();

            //This one will start when a move button is pressed
            TimerHandler.ToucanTimer.Stop();
        }

        public void GoToMainMenu()
        {
            Pause();
            Frame.Navigate(typeof(MainPage));
            Window.Current.CoreWindow.KeyDown -= KeyHandler.GameOnKeyDown;
        }
    }
}