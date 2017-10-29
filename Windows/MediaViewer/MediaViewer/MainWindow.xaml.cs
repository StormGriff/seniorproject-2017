using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.IO;
using MahApps.Metro.Controls;
using MahApps.Metro;
using WpfAnimatedGif;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Windows.Input;

//TODO: options with valid file cycling option

namespace MediaViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        DirectoryInfo currentDirectory;
        List<FileInfo> currentFileList;
        ImageTransform transform;
        int fileIndex;
        bool IsFullscreen;
        bool IsImageLoaded;
        bool IsVideoLoaded;

        public MainWindow()
        {
            InitializeComponent();

            Accent accent = ThemeManager.GetAccent("Blue");
            AppTheme theme = ThemeManager.GetAppTheme("BaseLight");

            ThemeManager.ChangeAppStyle(Application.Current, accent, theme);

            IsImageLoaded = false;
            IsVideoLoaded = false;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadConfig();

            ImageBehavior.SetRepeatBehavior(imgGifCenter, System.Windows.Media.Animation.RepeatBehavior.Forever);

            transform = new ImageTransform();

            vidCenter.EndBehavior = Meta.Vlc.Wpf.EndBehavior.Repeat;
        }

        private void SwitchToGif()
        {
            imgGifCenter.Visibility = Visibility.Visible;
            imgStaticCenter.Visibility = Visibility.Hidden;
            vidCenter.Visibility = Visibility.Hidden;
        }

        private void SwitchToImage()
        {
            imgGifCenter.Visibility = Visibility.Hidden;
            imgStaticCenter.Visibility = Visibility.Visible;
            vidCenter.Visibility = Visibility.Hidden;
        }

        private void SwitchToVideo()
        {
            imgGifCenter.Visibility = Visibility.Hidden;
            imgStaticCenter.Visibility = Visibility.Hidden;
            vidCenter.Visibility = Visibility.Visible;
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

                ThemeManager.ChangeAppStyle(Application.Current, accent, theme);
            }
        }

        private bool IsValid(string extension)
        {
            if(IsGif(extension) || IsImage(extension) || IsVideo(extension))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsImage(string extension)
        {
            if(extension == ".png" || extension == ".jpg" || extension == ".tif")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsGif(string extension)
        {
            if(extension == ".gif")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsVideo(string extension)
        {
            if(extension == ".webm" || extension == ".mp4")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SetMedia(string filepath)
        {
            FileInfo file = new FileInfo(filepath);

            if (IsImage(file.Extension))
            {
                imgStaticCenter.Source = new BitmapImage(new Uri(file.FullName));

                transform.Initialize(imgStaticCenter);

                SwitchToImage();

                IsImageLoaded = true;
                IsVideoLoaded = false;
            }
            else if (IsGif(file.Extension))
            {
                ImageBehavior.SetAnimatedSource(imgGifCenter, new BitmapImage(new Uri(file.FullName)));

                transform.Initialize(imgGifCenter);

                SwitchToGif();

                IsImageLoaded = true;
                IsVideoLoaded = false;
            }
            else if (IsVideo(file.Extension))
            {
                vidCenter.LoadMedia(file.FullName);

                SwitchToVideo();

                vidCenter.Play();

                IsImageLoaded = false;
                IsVideoLoaded = true;
            }
        }

        private void SetMedia(ref FileInfo file)
        {
            if (IsImage(file.Extension))
            {
                imgStaticCenter.Source = new BitmapImage(new Uri(file.FullName));

                transform.Initialize(imgStaticCenter);

                SwitchToImage();

                IsImageLoaded = true;
                IsVideoLoaded = false;
            }
            else if (IsGif(file.Extension))
            {
                ImageBehavior.SetAnimatedSource(imgGifCenter, new BitmapImage(new Uri(file.FullName)));

                transform.Initialize(imgGifCenter);

                SwitchToGif();

                IsImageLoaded = true;
                IsVideoLoaded = false;
            }
            else if (IsVideo(file.Extension))
            {
                vidCenter.LoadMedia(file.FullName);

                SwitchToVideo();

                vidCenter.Play();

                IsImageLoaded = false;
                IsVideoLoaded = true;
            }
        }
        
    }
}
