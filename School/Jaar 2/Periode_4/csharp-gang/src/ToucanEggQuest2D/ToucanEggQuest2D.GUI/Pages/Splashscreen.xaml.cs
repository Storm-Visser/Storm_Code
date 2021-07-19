using System;
using System.Timers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ToucanEggQuest2D.GUI.Pages
{
    public sealed partial class Splashscreen : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Start();
            timer.Interval = TimeSpan.FromMilliseconds(25);
            timer.Tick += (object source, object s) => {
                if (progressbarToucan.Value < 100)
                {
                    progressbarToucan.Value += 1;
                }
                else
                {
                    timer.Stop();
                    Frame.Navigate(typeof(MainPage));
                }
            };
        }
    }
}