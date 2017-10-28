using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MediaViewer
{
    class ImageTransform
    {
        private UIElement subject;
        private Point origin;
        private Point start;

        private TranslateTransform GetTranslateTransform(UIElement element)
        {
            return (TranslateTransform)((TransformGroup)element.RenderTransform)
              .Children.First(tr => tr is TranslateTransform);
        }

        private ScaleTransform GetScaleTransform(UIElement element)
        {
            return (ScaleTransform)((TransformGroup)element.RenderTransform)
              .Children.First(tr => tr is ScaleTransform);
        }

        private void Reset()
        {
            if (subject != null)
            {
                // reset zoom
                var st = GetScaleTransform(subject);
                st.ScaleX = 1.0;
                st.ScaleY = 1.0;

                // reset pan
                var tt = GetTranslateTransform(subject);
                tt.X = 0.0;
                tt.Y = 0.0;
            }
        }

        public void Initialize(UIElement element)
        {
            this.subject = element;
            if(subject != null)
            {
                TransformGroup group = new TransformGroup();
                ScaleTransform st = new ScaleTransform();
                group.Children.Add(st);
                TranslateTransform tt = new TranslateTransform();
                group.Children.Add(tt);
                subject.RenderTransform = group;
                subject.RenderTransformOrigin = new Point(0.0, 0.0);
            }
        }

        public void MouseWheel(MouseWheelEventArgs e)
        {
            if (subject != null)
            {
                var st = GetScaleTransform(subject);
                var tt = GetTranslateTransform(subject);

                double zoom = e.Delta > 0 ? .2 : -.2;
                if (!(e.Delta > 0) && (st.ScaleX < .4 || st.ScaleY < .4))
                    return;

                Point relative = e.GetPosition(subject);
                double abosuluteX;
                double abosuluteY;

                abosuluteX = relative.X * st.ScaleX + tt.X;
                abosuluteY = relative.Y * st.ScaleY + tt.Y;

                st.ScaleX += zoom;
                st.ScaleY += zoom;

                tt.X = abosuluteX - relative.X * st.ScaleX;
                tt.Y = abosuluteY - relative.Y * st.ScaleY;
            }
        }

        public void ZoomButton(int delta)
        {
            if (subject != null)
            {
                var st = GetScaleTransform(subject);
                var tt = GetTranslateTransform(subject);

                double zoom = delta > 0 ? .2 : -.2;
                if (!(delta > 0) && (st.ScaleX < .4 || st.ScaleY < .4))
                    return;

                //Point relative = e.GetPosition(subject);
                double abosuluteX;
                double abosuluteY;

                abosuluteX = st.ScaleX + tt.X;
                abosuluteY = st.ScaleY + tt.Y;

                st.ScaleX += zoom;
                st.ScaleY += zoom;

                tt.X = abosuluteX - st.ScaleX;
                tt.Y = abosuluteY - st.ScaleY;
            }
        }

        public void MouseLeftDown(MouseButtonEventArgs e, Window item)
        {
            if (subject != null)
            {
                var tt = GetTranslateTransform(subject);
                start = e.GetPosition(item);
                origin = new Point(tt.X, tt.Y);
                item.Cursor = Cursors.Hand;
                subject.CaptureMouse();
            }
        }

        public void MouseLeftUp(MouseButtonEventArgs e, Window item)
        {
            if (subject != null)
            {
                subject.ReleaseMouseCapture();
                item.Cursor = Cursors.Arrow;
            }
        }

        public void PreviewMouseRightDown()
        {
            this.Reset();
        }

        public void MouseMove(MouseEventArgs e, Window item)
        {
            if (subject != null)
            {
                if (subject.IsMouseCaptured)
                {
                    var tt = GetTranslateTransform(subject);
                    Vector v = start - e.GetPosition(item);
                    tt.X = origin.X - v.X;
                    tt.Y = origin.Y - v.Y;
                }
            }
        }
    }
}
