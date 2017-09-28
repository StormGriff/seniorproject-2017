using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;

namespace WindowsFileBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        object dummy; //dummy object for tree view lazy load

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string s in Directory.GetLogicalDrives())
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = s;
                item.Tag = s;
                
                //for lazy loading of tree view nodes
                item.Items.Add(dummy); 
                item.Expanded += new RoutedEventHandler(folder_Expanded);

                tvFileTree.Items.Add(item);
            }
        }

        private void folder_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;
            if (item.Items.Count == 1 && item.Items[0] == dummy)
            {
                item.Items.Clear();
                try
                {
                    foreach (string s in Directory.GetDirectories(item.Tag.ToString()))
                    {
                        TreeViewItem subitem = new TreeViewItem();
                        subitem.Header = s.Substring(s.LastIndexOf("\\") + 1);
                        subitem.Tag = s;
                        subitem.FontWeight = FontWeights.Normal;

                        DirectoryInfo di = new DirectoryInfo(s);

                        if (di.GetDirectories().Length != 0)
                        {
                            //for lazy loading
                            subitem.Items.Add(dummy);
                            subitem.Expanded += new RoutedEventHandler(folder_Expanded);
                        }

                        item.Items.Add(subitem);
                    }
                }
                catch (Exception) { }
            }
        }

        private void tvFileTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            lvFileView.ItemsSource = null;

            this.Cursor = Cursors.Wait;

            List<DirectoryFileInfo> items = new List<DirectoryFileInfo>();

            TreeViewItem item = (TreeViewItem)tvFileTree.SelectedItem;

            string[] files = Directory.GetFiles(Convert.ToString(item.Tag));
            FileInfo file;
            foreach(string s in files)
            {
                file = new FileInfo(s);
                items.Add(new DirectoryFileInfo(file));
            }

            string[] directories = Directory.GetDirectories(Convert.ToString(item.Tag));
            DirectoryInfo directory;
            foreach(string s in directories)
            {
                directory = new DirectoryInfo(s);
                items.Add(new DirectoryFileInfo(directory));
            }

            lvFileView.ItemsSource = items;
            this.Cursor = Cursors.Arrow;

            /*
            string[] files = Directory.GetFiles(Convert.ToString(item.Tag));
            

            foreach(string s in files)
            {
                
            }
            */
        }

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
