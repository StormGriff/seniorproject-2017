using System.Windows;

namespace VideoPlayer
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

        private void btnFullscreen_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFullscreen)
            {
                this.ShowTitleBar = false;
                this.WindowState = WindowState.Maximized;
                mnuMain.Visibility = Visibility.Collapsed;

                IsFullscreen = true;
            }
            else
            {
                this.ShowTitleBar = true;
                this.WindowState = WindowState.Normal;
                mnuMain.Visibility = Visibility.Visible;

                IsFullscreen = false;
            }
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
            vidPlayer.Volume = (int)sldVolume.Value;
        }
    }
}
