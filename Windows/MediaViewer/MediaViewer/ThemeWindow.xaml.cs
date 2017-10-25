using System;
using System.Windows;
using System.IO;
using MahApps.Metro.Controls;
using MahApps.Metro;

namespace MediaViewer
{
    /// <summary>
    /// Interaction logic for ThemeWindow.xaml
    /// </summary>
    public partial class ThemeWindow : MetroWindow
    {
        public ThemeWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveStyleToConfig();
        }

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

        private void SaveStyleToConfig()
        {
            Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle();

            //get directory for the executing directory
            //the config file is located in the same directory as the executable
            DirectoryInfo configDir = Directory.GetParent(System.Reflection.Assembly.GetEntryAssembly().Location);

            FileInfo configFile = new FileInfo(configDir + "\\config.cfg");

            configFile.Delete();

            FileStream fs = configFile.OpenWrite();
            StreamWriter writer = new StreamWriter(fs);
            StringWriter str = new StringWriter();

            str.WriteLine("[STYLE]");
            str.WriteLine("theme:" + appStyle.Item1.Name);
            str.WriteLine("accent:" + appStyle.Item2.Name);

            writer.Write(str.ToString());
            writer.Flush();

            str.Close();
            writer.Close();
            fs.Close();
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
