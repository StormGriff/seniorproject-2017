using System;
using MahApps.Metro.Controls;
using System.IO;
using MahApps.Metro;

namespace WindowsFileBrowser
{
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : MetroWindow
    {
        public OptionsWindow()
        {
            InitializeComponent();
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

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveConfig();
        }
    }
}
