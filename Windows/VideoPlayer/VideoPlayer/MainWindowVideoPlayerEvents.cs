using System;
using System.Windows.Input;

namespace VideoPlayer
{
    public partial class MainWindow
    {
        private void vidPlayer_TimeChanged(object sender, EventArgs e)
        {
            prgProgress.Value = (vidPlayer.Time.TotalSeconds / vidPlayer.Length.TotalSeconds) * 100;
        }

        private void vidPlayer_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if(e.Delta > 0)
            {
                ChangeMediaVolume(1);
            }
            else if(e.Delta < 0)
            {
                ChangeMediaVolume(-1);
            }
        }

        private void vidPlayer_VolumeChanged(object sender, EventArgs e)
        {
            txtVolume.Text = "Volume: " + vidPlayer.Volume.ToString();
        }
    }
}
