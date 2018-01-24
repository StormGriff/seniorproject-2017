using System;
using System.Windows;
using System.Collections.Generic;
using MahApps.Metro.Controls;
using MahApps.Metro;
using System.IO;

namespace MediaViewer
{
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : MetroWindow
    {
        bool PNG;
        bool JPG;
        bool BMP;
        bool GIF;
        bool TIF;
        bool MP4;
        bool AAC;
        bool WMV;
        bool FFV1;
        bool H264;
        bool WEBM;

        public OptionsWindow(List<bool> list)
        {
            InitializeComponent();

            ProcessInputList(list);
            UpdateCheckboxes();
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveConfig();
            UpdateBools();
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
            writer.Write(SaveBoolsToConfig());
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

        private string SaveBoolsToConfig()
        {
            UpdateBools();

            StringWriter str = new StringWriter();

            str.WriteLine();
            str.WriteLine();
            str.WriteLine("[BOOLS]");
            str.WriteLine("PNG:" + (PNG ? bool.TrueString : bool.FalseString));
            str.WriteLine("JPG:" + (JPG ? bool.TrueString : bool.FalseString));
            str.WriteLine("BMP:" + (BMP ? bool.TrueString : bool.FalseString));
            str.WriteLine("GIF:" + (GIF ? bool.TrueString : bool.FalseString));
            str.WriteLine("TIF:" + (TIF ? bool.TrueString : bool.FalseString));
            str.WriteLine("MP4:" + (MP4 ? bool.TrueString : bool.FalseString));
            str.WriteLine("AAC:" + (AAC ? bool.TrueString : bool.FalseString));
            str.WriteLine("WMV:" + (WMV ? bool.TrueString : bool.FalseString));
            str.WriteLine("FFV1:" + (FFV1 ? bool.TrueString : bool.FalseString));
            str.WriteLine("H264:" + (H264 ? bool.TrueString : bool.FalseString));
            str.WriteLine("WEBM:" + (WEBM ? bool.TrueString : bool.FalseString));

            return str.ToString();
        }

        private void UpdateBools()
        {
            PNG = (bool)chkPNG.IsChecked;
            JPG = (bool)chkJPG.IsChecked;
            BMP = (bool)chkBMP.IsChecked;
            GIF = (bool)chkGIF.IsChecked;
            TIF = (bool)chkTIF.IsChecked;
            MP4 = (bool)chkMP4.IsChecked;
            AAC = (bool)chkAAC.IsChecked;
            WMV = (bool)chkWMV.IsChecked;
            FFV1 = (bool)chkFFV1.IsChecked;
            H264 = (bool)chkH264.IsChecked;
            WEBM = (bool)chkWEBM.IsChecked;
        }

        private void UpdateCheckboxes()
        {
            chkPNG.IsChecked = PNG;
            chkJPG.IsChecked = JPG;
            chkBMP.IsChecked = BMP;
            chkGIF.IsChecked = GIF;
            chkTIF.IsChecked = TIF;
            chkMP4.IsChecked = MP4;
            chkAAC.IsChecked = AAC;
            chkWMV.IsChecked = WMV;
            chkFFV1.IsChecked = FFV1;
            chkH264.IsChecked = H264;
            chkWEBM.IsChecked = WEBM;
        }

        /// <summary>
        /// processed in order of declaration for the class
        /// </summary>
        /// <param name="list"></param>
        private void ProcessInputList(List<bool> list)
        {
            if(list.Count != 11)
            {
                return;
            }

            PNG = list[0];
            JPG = list[1];
            BMP = list[2];
            GIF = list[3];
            TIF = list[4];
            MP4 = list[5];
            AAC = list[6];
            WMV = list[7];
            FFV1 = list[8];
            H264 = list[9];
            WEBM = list[10];
        }

        public List<bool> GetOutputList()
        {
            List<bool> ret = new List<bool>();

            ret.Add(PNG);
            ret.Add(JPG);
            ret.Add(BMP);
            ret.Add(GIF);
            ret.Add(TIF);
            ret.Add(MP4);
            ret.Add(AAC);
            ret.Add(WMV);
            ret.Add(FFV1);
            ret.Add(H264);
            ret.Add(WEBM);

            return ret;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        //TODO file type options
    }
}
