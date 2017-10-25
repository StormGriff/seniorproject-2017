using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using MahApps.Metro.Controls;
using MahApps.Metro;
using WpfAnimatedGif;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

//TODO: load gifs
//TODO: alter behavior due to file type
//TODO: next and previous buttons
//TODO: image transforms

namespace MediaViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            Accent accent = ThemeManager.GetAccent("Blue");
            AppTheme theme = ThemeManager.GetAppTheme("BaseLight");

            ThemeManager.ChangeAppStyle(Application.Current, accent, theme);
        }

        private void LoadConfig()
        {
            //get directory for the executing directory
            //the config file is located in the same directory as the executable
            DirectoryInfo configDir = Directory.GetParent(System.Reflection.Assembly.GetEntryAssembly().Location);

            FileInfo configFile = new FileInfo(configDir + "\\config.cfg");

            if (configFile.Exists)
            {
                FileStream fs = configFile.OpenRead();
                StreamReader sr = new StreamReader(fs);

                Accent accent = ThemeManager.GetAccent("Blue");
                AppTheme theme = ThemeManager.GetAppTheme("BaseLight");

                //string text = sr.ReadToEnd();
                //string[] lines = text.Split(new char[] { '\n', '\r' });

                //foreach (string l in lines)
                //{
                //    if (l.StartsWith("accent:"))
                //    {
                //        string[] temp = l.Split(':');

                //        accent = ThemeManager.GetAccent(temp[1]);
                //    }
                //    if (l.StartsWith("theme:"))
                //    {
                //        string[] temp = l.Split(':');

                //        theme = ThemeManager.GetAppTheme(temp[1]);
                //    }
                //}

                ThemeManager.ChangeAppStyle(Application.Current, accent, theme);
            }
        }

        private void btnTheme_Click(object sender, RoutedEventArgs e)
        {
            ThemeWindow win = new ThemeWindow();
            win.ShowDialog();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadConfig();

            imgCenter.Source = new BitmapImage(new Uri("Z:\\IMAGES\\PONY\\BY ARTIST\\Ambris\\1370296 - Friendship_is_Magic Lightning_Dust My_Little_Pony Spitfire ambris.jpg"));
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.png; *.bmp; *.jpg; *.gif)|*.png; *.bmp; *.jpg; *.gif)|All Files|*.*";

            if(ofd.ShowDialog() == true)
            {
                imgCenter.Source = new BitmapImage(new Uri(ofd.FileName));
            }
        }
    }
}
