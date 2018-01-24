using MahApps.Metro;
using MahApps.Metro.Controls;
using System;
using System.IO;

namespace MusicPlayer
{
    /// <summary>
    /// Interaction logic for PreferencesWindow.xaml
    /// </summary>
    public partial class PreferencesWindow : MetroWindow
    {
        public PreferencesWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveConfig();
        }

        private void SaveConfig()
        {
            //get directory for the executing directory
            //the config file is located in the same directory as the executable
            DirectoryInfo configDir = Directory.GetParent(System.Reflection.Assembly.GetEntryAssembly().Location);

            FileInfo configFile = new FileInfo(configDir + "\\config.cfg");

            configFile.Delete();

            FileStream fs = configFile.OpenWrite();
            StreamWriter writer = new StreamWriter(fs);

            writer.Write(SaveStyleToConfig());
            writer.Flush();

            fs.Close();
        }

        private string SaveStyleToConfig()
        {
            StringWriter str = new StringWriter();
            Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle();

            str.WriteLine("[STYLE]");
            str.WriteLine("theme:" + appStyle.Item1.Name);
            str.WriteLine("accent:" + appStyle.Item2.Name);

            return str.ToString();
        }
    }
}
