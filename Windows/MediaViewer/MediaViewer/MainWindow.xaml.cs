using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using MahApps.Metro.Controls;
using MahApps.Metro;
using WpfAnimatedGif;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;
using Meta.Vlc.Wpf;

//TODO: memory leaks

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
        bool IsVideoPlaying;

        //filetype accept bools
        bool AcceptPNG;
        bool AcceptJPG;
        bool AcceptBMP;
        bool AcceptGIF;
        bool AcceptTIF;
        bool AcceptMP4;
        bool AcceptAAC;
        bool AcceptWMV;
        bool AcceptFFV1;
        bool AcceptH264;
        bool AcceptWEBM;

        public MainWindow()
        {
            InitializeComponent();

            Accent accent = ThemeManager.GetAccent("Blue");
            AppTheme theme = ThemeManager.GetAppTheme("BaseLight");

            ThemeManager.ChangeAppStyle(Application.Current, accent, theme);

            IsImageLoaded = false;
            IsVideoLoaded = false;
            IsVideoPlaying = false;

            //insurance in case the config file has no bool info saved
            AcceptPNG = true;
            AcceptJPG = true;
            AcceptBMP = true;
            AcceptGIF = true;
            AcceptTIF = false;
            AcceptMP4 = false;
            AcceptAAC = false;
            AcceptWMV = false;
            AcceptFFV1 = false;
            AcceptH264 = false;
            AcceptWEBM = false;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadConfig();

            //ImageBehavior.SetRepeatBehavior(imgGifCenter, System.Windows.Media.Animation.RepeatBehavior.Forever);

            transform = new ImageTransform();

            //vidCenter.EndBehavior = Meta.Vlc.Wpf.EndBehavior.Repeat;
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
                LoadTheme(configFile);
                LoadBools(configFile);
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

        private void LoadBools(FileInfo configFile)
        {
            FileStream fs = configFile.OpenRead();
            StreamReader sr = new StreamReader(fs);

            string text = sr.ReadToEnd();
            string[] lines = text.Split(new char[] { '\n', '\r' });

            foreach (string l in lines)
            {
                if(l.StartsWith("PNG:"))
                {
                    string[] temp = l.Split(':');

                    AcceptPNG = Convert.ToBoolean(temp[1]);
                }
                else if(l.StartsWith("JPG:"))
                {
                    string[] temp = l.Split(':');

                    AcceptJPG = Convert.ToBoolean(temp[1]);
                }
                else if (l.StartsWith("BMP:"))
                {
                    string[] temp = l.Split(':');

                    AcceptBMP = Convert.ToBoolean(temp[1]);
                }
                else if (l.StartsWith("GIF:"))
                {
                    string[] temp = l.Split(':');

                    AcceptGIF = Convert.ToBoolean(temp[1]);
                }
                else if (l.StartsWith("TIF:"))
                {
                    string[] temp = l.Split(':');

                    AcceptTIF = Convert.ToBoolean(temp[1]);
                }
                else if (l.StartsWith("MP4:"))
                {
                    string[] temp = l.Split(':');

                    AcceptMP4 = Convert.ToBoolean(temp[1]);
                }
                else if (l.StartsWith("AAC:"))
                {
                    string[] temp = l.Split(':');

                    AcceptAAC = Convert.ToBoolean(temp[1]);
                }
                else if (l.StartsWith("WMV:"))
                {
                    string[] temp = l.Split(':');

                    AcceptWMV = Convert.ToBoolean(temp[1]);
                }
                else if (l.StartsWith("FFV1:"))
                {
                    string[] temp = l.Split(':');

                    AcceptFFV1 = Convert.ToBoolean(temp[1]);
                }
                else if (l.StartsWith("H264:"))
                {
                    string[] temp = l.Split(':');

                    AcceptH264 = Convert.ToBoolean(temp[1]);
                }
                else if (l.StartsWith("WEBM:"))
                {
                    string[] temp = l.Split(':');

                    AcceptWEBM = Convert.ToBoolean(temp[1]);
                }
            }

            fs.Close();
            sr.Close();
        }

        private bool IsValid(string extension)
        {
            if( (extension == ".png" && AcceptPNG) || 
                (extension == ".jpg" || extension == ".jpeg" && AcceptJPG) || 
                (extension == ".bmp" && AcceptBMP) ||
                (extension == ".gif" && AcceptGIF) ||
                (extension == ".tif" || extension == ".tiff" && AcceptTIF) ||
                (extension == ".mp4" && AcceptMP4) ||
                (extension == ".aac" && AcceptAAC) ||
                (extension == ".wmv" && AcceptWMV) ||
                (extension == ".ffv1" && AcceptFFV1) ||
                (extension == ".h264" && AcceptH264) ||
                (extension == ".webm" && AcceptWEBM))
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
            if(extension == ".png" || extension == ".jpg"　|| extension == ".jpeg" || extension == ".tif" || extension == ".bmp")
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
            if(extension == ".webm" || extension == ".mp4" || extension == ".aac" || extension == ".ffv1" || extension == ".wmv" || extension == ".h264")
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

            IsVideoPlaying = false;

            if (IsImage(file.Extension))
            {
                BitmapImage bitmap = new BitmapImage(new Uri(file.FullName));
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.Freeze();
                imgStaticCenter.Source = bitmap;

                transform.Initialize(imgStaticCenter);

                SwitchToImage();
                ChangeButtonsForImages();

                IsImageLoaded = true;
                IsVideoLoaded = false;
            }
            else if (IsGif(file.Extension))
            {
                ImageBehavior.SetAnimatedSource(imgGifCenter, new BitmapImage(new Uri(file.FullName)));

                //transform.Initialize(imgGifCenter);

                SwitchToGif();
                ChangeButtonsForImages();

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
                IsVideoPlaying = true;
                icoZoomIn.Fill = new VisualBrush() { Visual = (Visual)Resources["appbar_control_pause"] };
                icoZoomOut.Fill = new VisualBrush() { Visual = (Visual)Resources["appbar_control_stop"] };
            }

            //explicit collection
            //gifs accumulate memory quickly and it doesn't seem to dispose correctly without an explicit call
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void SetMedia(ref FileInfo file)
        {
            IsVideoPlaying = false;

            if (IsImage(file.Extension))
            {
                BitmapImage bitmap = new BitmapImage(new Uri(file.FullName));
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.Freeze();
                imgStaticCenter.Source = bitmap;

                transform.Initialize(imgStaticCenter);

                SwitchToImage();
                ChangeButtonsForImages();

                IsImageLoaded = true;
                IsVideoLoaded = false;
            }
            else if (IsGif(file.Extension))
            {
                ImageBehavior.SetAnimatedSource(imgGifCenter, new BitmapImage(new Uri(file.FullName)));

                transform.Initialize(imgGifCenter);

                SwitchToGif();
                ChangeButtonsForImages();

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
                IsVideoPlaying = true;
                icoZoomIn.Fill = new VisualBrush() { Visual = (Visual)Resources["appbar_control_pause"] };
                icoZoomOut.Fill = new VisualBrush() { Visual = (Visual)Resources["appbar_control_stop"] };
            }

            //explicit collection
            //gifs accumulate memory quickly and it doesn't seem to dispose correctly without an explicit call
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void ChangeButtonsForImages()
        {
            icoZoomIn.Fill = new VisualBrush() { Visual = (Visual)Resources["appbar_magnify_add"] };
            icoZoomOut.Fill = new VisualBrush() { Visual = (Visual)Resources["appbar_magnify_minus"] };
        }

        private List<bool> CreateFiletypeBoolList()
        {
            List<bool> ret = new List<bool>();

            ret.Add(AcceptPNG);
            ret.Add(AcceptJPG);
            ret.Add(AcceptBMP);
            ret.Add(AcceptGIF);
            ret.Add(AcceptTIF);
            ret.Add(AcceptMP4);
            ret.Add(AcceptAAC);
            ret.Add(AcceptWMV);
            ret.Add(AcceptFFV1);
            ret.Add(AcceptH264);
            ret.Add(AcceptWEBM);

            return ret;
        }

        private void ProcessFiletypeBoolList(List<bool> list)
        {
            if(list.Count != 11)
            {
                return;
            }

            AcceptPNG = list[0];
            AcceptJPG = list[1];
            AcceptBMP = list[2];
            AcceptGIF = list[3];
            AcceptTIF = list[4];
            AcceptMP4 = list[5];
            AcceptAAC = list[6];
            AcceptWMV = list[7];
            AcceptFFV1 = list[8];
            AcceptH264 = list[9];
            AcceptWEBM = list[10];
        }
        
    }
}
