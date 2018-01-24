using MahApps.Metro;
using System;
using System.Windows;

namespace MediaViewer
{
    public partial class OptionsWindow
    {
        private void ChangeAppStyle(string theme = null, string accent = null)
        {
            Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);

            if (theme != null)
            {
                if (accent != null)
                {
                    ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(accent), ThemeManager.GetAppTheme(theme));
                }
                else
                {
                    ThemeManager.ChangeAppStyle(Application.Current, appStyle.Item2, ThemeManager.GetAppTheme(theme));
                }
            }
            else
            {
                if (accent != null)
                {
                    ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(accent), appStyle.Item1);
                }
            }
        }

        private void btnLight_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle("BaseLight");
        }

        private void btnDark_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle("BaseDark");
        }

        private void btnRed_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Red");
        }

        private void btnGreen_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Green");
        }

        private void btnBlue_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Blue");
        }

        private void btnPurple_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Purple");
        }

        private void btnOrange_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Orange");
        }

        private void btnLime_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Lime");
        }

        private void btnEmerald_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Emerald");
        }

        private void btnTeal_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Teal");
        }

        private void btnCyan_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Cyan");
        }

        private void btnCobalt_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Cobalt");
        }

        private void btnIndigo_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Indigo");
        }

        private void btnViolet_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Violet");
        }

        private void btnPink_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Pink");
        }

        private void btnMagenta_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Magenta");
        }

        private void btnCrimson_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Crimson");
        }

        private void btnAmber_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Amber");
        }

        private void btnYellow_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Yellow");
        }

        private void btnBrown_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Brown");
        }

        private void btnOlive_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Olive");
        }

        private void btnSteel_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Steel");
        }

        private void btnMauve_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Mauve");
        }

        private void btnTaupe_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Taupe");
        }

        private void btnSienna_Click(object sender, RoutedEventArgs e)
        {
            ChangeAppStyle(null, "Sienna");
        }
    }
}
