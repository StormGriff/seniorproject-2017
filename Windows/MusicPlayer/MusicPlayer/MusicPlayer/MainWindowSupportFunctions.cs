using Microsoft.Win32;
using System.Windows.Media;

namespace MusicPlayer
{
    public partial class MainWindow
    {
        public void PlayOrPauseMedia()
        {
            vlcPlayer.PauseOrResume();

            if (IsPlaying)
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
            vlcPlayer.Stop();
        }

        public void ChangeMediaVolume(int value)
        {
            if (vlcPlayer.Volume + value > 200)
            {
                vlcPlayer.Volume = 200;
            }
            else if (vlcPlayer.Volume + value < 0)
            {
                vlcPlayer.Volume = 0;
            }
            else
            {
                vlcPlayer.Volume += value;
            }
        }

        public void SkipNext()
        {
            //string file = playlistWindow.Next();

            //if (file != null)
            //{
            //    LoadVideo(file);
            //}
            //else
            //{
            //    return;
            //}
        }

        public void SkipPrevious()
        {
            //string file = playlistWindow.Previous();

            //if (file != null)
            //{
            //    LoadVideo(file);
            //}
            //else
            //{
            //    return;
            //}
        }

        public void SelectNewSingleFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Audio Files|*.mp3;*.wav|All Files|*.*";

            if (ofd.ShowDialog() == true)
            {
                if (ofd.FileName != null)
                {
                    LoadAudio(ofd.FileName);
                }
            }
        }

        private void LoadAudio(string file)
        {
            vlcPlayer.LoadMedia(file);
            vlcPlayer.Volume = (int)sldVolume.Value;
            vlcPlayer.Play();
            IsPlaying = true;
            icoPlayPause.Fill = new VisualBrush() { Visual = (Visual)Resources["appbar_control_pause"] };
        }
    }
}
