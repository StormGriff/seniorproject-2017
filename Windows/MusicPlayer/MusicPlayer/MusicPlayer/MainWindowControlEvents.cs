using System.Windows;

namespace MusicPlayer
{
    public partial class MainWindow
    {
        private void btnPlayPause_Click(object sender, RoutedEventArgs e)
        {
            PlayOrPauseMedia();
        }

        private void btnSkipLeft_Click(object sender, RoutedEventArgs e)
        {
            SkipPrevious();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            StopMedia();
        }

        private void btnSkipRight_Click(object sender, RoutedEventArgs e)
        {
            SkipNext();
        }

        private void btnOptions_Click(object sender, RoutedEventArgs e)
        {
            PreferencesWindow win = new PreferencesWindow();

            win.ShowDialog();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            SelectNewSingleFile();
        }

        private void sldVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            vlcPlayer.Volume = (int)sldVolume.Value;
            txtVolume.Text = "Volume: " + vlcPlayer.Volume;
        }
    }
}
