using ToucanEggQuest2D.GUI.Config;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml.Controls;

namespace ToucanEggQuest2D.GUI.Pages
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonPlay_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PlayPage), new TestLevelFactory().CreateTestLevel());
        }

        private void ButtonCreate_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreatorPage));
        }

        private void ButtonSettings_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SettingsPage));
        }

        private void ButtonQuit_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }
    }
}