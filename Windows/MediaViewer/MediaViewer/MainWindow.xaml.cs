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

//TODO: click through image transforms
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

        public MainWindow()
        {
            InitializeComponent();

            Accent accent = ThemeManager.GetAccent("Blue");
            AppTheme theme = ThemeManager.GetAppTheme("BaseLight");

            ThemeManager.ChangeAppStyle(Application.Current, accent, theme);
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadConfig();

            ImageBehavior.SetRepeatBehavior(imgGifCenter, System.Windows.Media.Animation.RepeatBehavior.Forever);

            transform = new ImageTransform();
        }

        private void SwitchToGif()
        {
            imgGifCenter.Visibility = Visibility.Visible;
            imgStaticCenter.Visibility = Visibility.Hidden;
        }

        private void SwitchToImage()
        {
            imgGifCenter.Visibility = Visibility.Hidden;
            imgStaticCenter.Visibility = Visibility.Visible;
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

        private bool IsValid(string extension)
        {
            if(IsGif(extension) || IsImage(extension))
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

        private void btnTheme_Click(object sender, RoutedEventArgs e)
        {
            ThemeWindow win = new ThemeWindow();
            win.ShowDialog();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.png;*.bmp;*.jpg;*.gif|All Files|*.*";

            if(ofd.ShowDialog() == true)
            {
                Cursor tempCursor = this.Cursor;
                this.Cursor = Cursors.Wait;
                

                currentDirectory = new DirectoryInfo(Path.GetDirectoryName(ofd.FileName));
                currentFileList = currentDirectory.GetFiles().ToList();

                for(int i = 0; i < currentFileList.Count; i++)
                {
                    if(currentFileList.ElementAt(i).FullName == ofd.FileName)
                    {
                        fileIndex = i;
                        break;
                    }
                }

                FileInfo file = new FileInfo(ofd.FileName);

                if (IsImage(file.Extension))
                {
                    imgStaticCenter.Source = new BitmapImage(new Uri(ofd.FileName));

                    transform.Initialize(imgStaticCenter);

                    SwitchToImage();
                }
                else if (IsGif(file.Extension))
                {
                    ImageBehavior.SetAnimatedSource(imgGifCenter, new BitmapImage(new Uri(file.FullName)));

                    transform.Initialize(imgGifCenter);

                    SwitchToGif();
                }

                this.Cursor = tempCursor;
            }
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            FileInfo file = null;

            //keeps edge cases from skipping the for loop
            if (fileIndex - 1 < 0)
            {
                fileIndex += currentFileList.Count;
            }
            
            for(int i = fileIndex - 1; i < currentFileList.Count && i >= 0; i--)
            {
                file = currentFileList.ElementAt(i);
                
                if(i < 0)
                {
                    i += currentFileList.Count;
                }

                //full loop through every file with no valid files
                if(i == fileIndex)
                {
                    return;
                }

                if (IsValid(file.Extension))
                {
                    fileIndex = i;

                    if (IsImage(file.Extension))
                    {
                        imgStaticCenter.Source = new BitmapImage(new Uri(file.FullName));

                        transform.Initialize(imgStaticCenter);

                        SwitchToImage();
                    }
                    else if (IsGif(file.Extension))
                    {
                        Cursor tempCursor = this.Cursor;
                        this.Cursor = Cursors.Wait;

                        ImageBehavior.SetAnimatedSource(imgGifCenter, null);
                        imgGifCenter.Source = null;

                        ImageBehavior.SetAnimatedSource(imgGifCenter, new BitmapImage(new Uri(file.FullName)));

                        transform.Initialize(imgGifCenter);

                        SwitchToGif();

                        this.Cursor = tempCursor;
                    }

                    return;
                }
            }
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            FileInfo file = null;

            //keeps edge cases from skipping the for loop
            if (fileIndex + 1 >= currentFileList.Count)
            {
                fileIndex -= currentFileList.Count;
            }

            for (int i = fileIndex + 1; i < currentFileList.Count && i >= 0; i++)
            {
                file = currentFileList.ElementAt(i);

                if (i >= currentFileList.Count)
                {
                    i -= currentFileList.Count;
                }

                //full loop through every file with no valid files
                if (i == fileIndex)
                {
                    return;
                }

                if (IsValid(file.Extension))
                {
                    fileIndex = i;

                    if (IsImage(file.Extension))
                    {
                        imgStaticCenter.Source = new BitmapImage(new Uri(file.FullName));

                        transform.Initialize(imgStaticCenter);

                        SwitchToImage();
                    }
                    else if (IsGif(file.Extension))
                    {
                        Cursor tempCursor = this.Cursor;
                        this.Cursor = Cursors.Wait;

                        ImageBehavior.SetAnimatedSource(imgGifCenter, null);
                        imgGifCenter.Source = null;

                        ImageBehavior.SetAnimatedSource(imgGifCenter, new BitmapImage(new Uri(file.FullName)));

                        transform.Initialize(imgGifCenter);

                        SwitchToGif();

                        this.Cursor = tempCursor;
                    }

                    return;
                }
            }

        }

        private void imgStaticCenter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            transform.MouseLeftDown(e, this);
        }

        private void imgStaticCenter_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            transform.MouseLeftUp(e, this);
        }

        private void imgStaticCenter_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            transform.MouseWheel(e);
        }

        private void imgStaticCenter_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            transform.PreviewMouseRightDown();
        }

        private void imgStaticCenter_MouseMove(object sender, MouseEventArgs e)
        {
            transform.MouseMove(e, this);
        }

        private void imgGifCenter_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            transform.MouseLeftDown(e, this);
        }

        private void imgGifCenter_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            transform.MouseLeftUp(e, this);
        }

        private void imgGifCenter_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            transform.MouseWheel(e);
        }

        private void imgGifCenter_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            transform.PreviewMouseRightDown();
        }

        private void imgGifCenter_MouseMove(object sender, MouseEventArgs e)
        {
            transform.MouseMove(e, this);
        }

        private void grdControlWrap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            transform.MouseLeftDown(e, this);
        }

        private void grdControlWrap_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            transform.MouseLeftUp(e, this);
        }

        private void grdControlWrap_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            transform.MouseWheel(e);
        }

        private void grdControlWrap_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            transform.PreviewMouseRightDown();
        }

        private void grdControlWrap_MouseMove(object sender, MouseEventArgs e)
        {
            transform.MouseMove(e, this);
        }
    }
}
