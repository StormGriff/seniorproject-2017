using System.Windows;

namespace MusicPlayer
{
    public partial class MainWindow
    {
        private void mnuVolumeUp_Click(object sender, RoutedEventArgs e)
        {
            ChangeMediaVolume(5);
        }

        private void mnuVolumeDown_Click(object sender, RoutedEventArgs e)
        {
            ChangeMediaVolume(-5);
        }

        private void mnuMute_Click(object sender, RoutedEventArgs e)
        {
            vlcPlayer.ToggleMute();
        }
    }
}