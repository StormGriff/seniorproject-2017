using System.Windows.Input;

namespace MediaViewer
{
    public partial class MainWindow
    {
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
