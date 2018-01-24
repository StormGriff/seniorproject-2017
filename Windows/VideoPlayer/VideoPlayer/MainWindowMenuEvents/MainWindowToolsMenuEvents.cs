using System.Windows;

namespace VideoPlayer
{
    public partial class MainWindow
    {
        private void mnuPreferences_Click(object sender, RoutedEventArgs e)
        {
            PreferencesWindow win = new PreferencesWindow();

            win.ShowDialog();
        }

        private void mnuPlaylists_Click(object sender, RoutedEventArgs e)
        {
            playlistWindow.Show();
        }
    }
}
