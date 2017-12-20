using Microsoft.Win32;
using System.Windows.Media;

namespace VideoPlayer
{
    public partial class MainWindow
    {
        public void PlayOrPauseMedia()
        {
            vidPlayer.PauseOrResume();

            if(IsPlaying)
            {
                icoPlayPause.Fill = new VisualBrush() { Visual = (Visual)Resources["appbar_control_play"] };
                IsPlaying = false;
            }
            else
            {
                icoPlayPause.Fill = new VisualBrush() { Visual = (Visual)Resources["appbar_control_pause"] };
                IsPlaying = true;
            }
        }

        public void StopMedia()
        {
            vidPlayer.Stop();
        }

        public void ChangeMediaVolume(int value)
        {
            if(vidPlayer.Volume + value > 200)
            {
                vidPlayer.Volume = 200;
            }
            else if(vidPlayer.Volume + value < 0)
            {
                vidPlayer.Volume = 0;
            }
            else
            {
                vidPlayer.Volume += value;
            }
        }

        public void SkipNext()
        {
            string file = playlistWindow.Next();

            if(file != null)
            {
                LoadVideo(file);
            }
            else
            {
                return;
            }
        }

        public void SkipPrevious()
        {
            string file = playlistWindow.Previous();

            if (file != null)
            {
                LoadVideo(file);
            }
            else
            {
                return;
            }
        }

        public void SelectNewSingleFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Video Files|*.mp4;*.webm|Audio Files|*.mp3;*.wav|All Files|*.*";

            if (ofd.ShowDialog() == true)
            {
                if (ofd.FileName != null)
                {
                    LoadVideo(ofd.FileName);
                }
            }
        }

        private void LoadVideo(string file)
        {
            vidPlayer.LoadMedia(file);
            vidPlayer.Volume = (int)sldVolume.Value;
            vidPlayer.Play();
            IsPlaying = true;
            icoPlayPause.Fill = new VisualBrush() { Visual = (Visual)Resources["appbar_control_pause"] };
        }
    }
}
