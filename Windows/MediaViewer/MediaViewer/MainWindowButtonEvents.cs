using Microsoft.Win32;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MediaViewer
{
    public partial class MainWindow
    {
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.png;*.bmp;*.jpg;*.gif|All Files|*.*";

            if (ofd.ShowDialog() == true)
            {
                Cursor tempCursor = this.Cursor;
                this.Cursor = Cursors.Wait;


                currentDirectory = new DirectoryInfo(Path.GetDirectoryName(ofd.FileName));
                currentFileList = currentDirectory.GetFiles().ToList();

                for (int i = 0; i < currentFileList.Count; i++)
                {
                    if (currentFileList.ElementAt(i).FullName == ofd.FileName)
                    {
                        fileIndex = i;
                        break;
                    }
                }

                SetMedia(ofd.FileName);
                this.Title = Path.GetFileName(ofd.FileName);

                this.Cursor = tempCursor;
            }
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            FileInfo file = null;

            //prevent use before file loaded
            if ( (!IsImageLoaded) && (!IsVideoLoaded) )
            {
                return;
            }

            //keeps edge cases from skipping the for loop
            if (fileIndex - 1 < 0)
            {
                fileIndex += currentFileList.Count;
            }

            for (int i = fileIndex - 1; i < currentFileList.Count && i >= 0; i--)
            {
                file = currentFileList.ElementAt(i);

                if (i < 0)
                {
                    i += currentFileList.Count;
                }

                //full loop through every file with no valid files
                if (i == fileIndex)
                {
                    return;
                }

                if (IsValid(file.Extension))
                {
                    fileIndex = i;

                    SetMedia(ref file);
                    this.Title = file.Name;

                    return;
                }
            }
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            FileInfo file = null;

            //prevent use before file loaded
            if ( (!IsImageLoaded) && (!IsVideoLoaded) )
            {
                return;
            }

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

                    SetMedia(ref file);
                    this.Title = file.Name;

                    return;
                }
            }

        }

        private void btnZoomIn_Click(object sender, RoutedEventArgs e)
        {
            if (IsImageLoaded)
            {
                transform.ZoomButton(1);
            }
            else if(IsVideoLoaded)
            {
                if(IsVideoPlaying)
                {
                    vidCenter.Pause();
                    icoZoomIn.Fill = new VisualBrush() { Visual = (Visual)Resources["appbar_control_play"] };
                    IsVideoPlaying = false;
                }
                else
                {
                    vidCenter.Play();
                    icoZoomIn.Fill = new VisualBrush() { Visual = (Visual)Resources["appbar_control_pause"] };
                    IsVideoPlaying = true;
                }
            }
        }

        private void btnZoomOut_Click(object sender, RoutedEventArgs e)
        {
            if (IsImageLoaded)
            {
                transform.ZoomButton(-1);
            }
            else if (IsVideoLoaded)
            {
                vidCenter.Stop();
            }
        }

        private void btnOptions_Click(object sender, RoutedEventArgs e)
        {
            OptionsWindow win = new OptionsWindow();
            win.Show();
        }

        private void btnFullscreen_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFullscreen)
            {
                this.ShowTitleBar = false;
                this.WindowState = WindowState.Maximized;
                this.WindowStyle = WindowStyle.None;

                IsFullscreen = true;
            }
            else
            {
                this.ShowTitleBar = true;
                this.WindowState = WindowState.Normal;
                this.WindowStyle = WindowStyle.SingleBorderWindow;

                IsFullscreen = false;
            }
        }

    }
}
