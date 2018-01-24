using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace VideoPlayer
{
    /// <summary>
    /// Interaction logic for PlaylistWindow.xaml
    /// </summary>
    public partial class PlaylistWindow : MetroWindow
    {
        public ObservableCollection<string> playlist;
        private int index = 0;

        public PlaylistWindow()
        {
            InitializeComponent();

            playlist = new ObservableCollection<string>();

            listPlaylist.ItemsSource = playlist;
        }

        public string Next()
        {
            if(playlist.Count != 0)
            {
                index++;
                if(index >= playlist.Count)
                {
                    index -= playlist.Count;
                }
                else if(index < 0)
                {
                    index += playlist.Count;
                }

                return playlist[index];
            }
            else
            {
                return null;
            }
        }

        public string Previous()
        {
            if (playlist.Count != 0)
            {
                index--;
                if (index > playlist.Count)
                {
                    index -= playlist.Count;
                }
                else if (index < 0)
                {
                    index += playlist.Count;
                }

                return playlist[index];
            }
            else
            {
                return null;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Video Files|*.mp4;*.webm|Audio Files|*.mp3;*.wav|All Files|*.*";
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == true)
            {
                if (ofd.FileNames != null)
                {
                    foreach(string s in ofd.FileNames)
                    {
                        playlist.Add(s);
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            string select = listPlaylist.SelectedItem.ToString();

            playlist.Remove(select);
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
