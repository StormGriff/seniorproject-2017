using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.IO;
using MahApps.Metro;

namespace MusicPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        bool IsPlaying = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            //get directory for the executing directory
            //the config file is located in the same directory as the executable
            DirectoryInfo configDir = Directory.GetParent(System.Reflection.Assembly.GetEntryAssembly().Location);

            FileInfo configFile = new FileInfo(configDir + "\\config.cfg");

            if (configFile.Exists)
            {
                LoadTheme(configFile);
            }
        }

        private void LoadTheme(FileInfo configFile)
        {
            FileStream fs = configFile.OpenRead();
            StreamReader sr = new StreamReader(fs);

            Accent accent = ThemeManager.GetAccent("Blue");
            AppTheme theme = ThemeManager.GetAppTheme("BaseLight");

            string text = sr.ReadToEnd();
            string[] lines = text.Split(new char[] { '\n', '\r' });

            foreach (string l in lines)
            {
                if (l.StartsWith("accent:"))
                {
                    string[] temp = l.Split(':');

                    accent = ThemeManager.GetAccent(temp[1]);
                }
                if (l.StartsWith("theme:"))
                {
                    string[] temp = l.Split(':');

                    theme = ThemeManager.GetAppTheme(temp[1]);
                }
            }

            fs.Close();
            sr.Close();

            ThemeManager.ChangeAppStyle(Application.Current, accent, theme);
        }
    }
}
