using System.Windows;
using System.IO;
using MahApps.Metro.Controls;
using MahApps.Metro;
using Microsoft.Win32;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        FileInfo file = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTheme_Click(object sender, RoutedEventArgs e)
        {
            ThemeWindow win = new ThemeWindow();
            win.ShowDialog();
        }

        private void NewCommand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            file = null;

            //rtbTextBox.Document.Blocks.Clear();
        }

        private void OpenCommand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (*.txt)|*.txt|Rich Text Files (*.rtf)|*.rtf|All Files (*.*)|*.*";

            ofd.ShowDialog();

            FileInfo temp = file;
            file = new FileInfo(ofd.FileName);
            
            if(!file.Exists)
            {
                file = temp;
            }

            FileStream fs = new FileStream(file.FullName, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            rtbTextBox.Text = sr.ReadToEnd();

            sr.Close();
            fs.Close();
        }

        private void SaveCommand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if (file == null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.AddExtension = true;
                sfd.ValidateNames = true;
                sfd.Filter = "Text Files (*.txt)|*.txt|Rich Text Files (*.rtf)|*.rtf|All Files (*.*)|*.*";

                if (sfd.ShowDialog() == true)
                {
                    file = new FileInfo(sfd.FileName);
                }
            }

            FileStream fs = new FileStream(file.FullName, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            
            foreach(char c in rtbTextBox.Text)
            {
                sw.Write(c);
            }

            sw.Flush();

            sw.Close();
            fs.Close();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //get directory for the executing directory
            //the config file is located in the same directory as the executable
            DirectoryInfo configDir = Directory.GetParent(System.Reflection.Assembly.GetEntryAssembly().Location);

            FileInfo configFile = new FileInfo(configDir + "\\config.cfg");

            if (configFile.Exists)
            {
                FileStream fs = configFile.OpenRead();
                StreamReader sr = new StreamReader(fs);

                Accent accent = ThemeManager.GetAccent("Blue");
                AppTheme theme = ThemeManager.GetAppTheme("BaseLight");

                string text = sr.ReadToEnd();
                string[] lines = text.Split(new char[] { '\n', '\r' });

                foreach (string l in lines)
                {
                    if (l.StartsWith("accent:"))
                    {
                        string[] temp = l.Split(':');

                        accent = ThemeManager.GetAccent(temp[1]);
                    }
                    if(l.StartsWith("theme:"))
                    {
                        string[] temp = l.Split(':');

                        theme = ThemeManager.GetAppTheme(temp[1]);
                    }
                }

                ThemeManager.ChangeAppStyle(Application.Current, accent, theme);
            }
        }
    }
}
