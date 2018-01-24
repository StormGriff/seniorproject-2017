using System.Windows;

namespace MusicPlayer
{
    public partial class MainWindow
    {
        private void mnuPreferences_Click(object sender, RoutedEventArgs e)
        {
            PreferencesWindow win = new PreferencesWindow();

            win.ShowDialog();
        }
    }
}
