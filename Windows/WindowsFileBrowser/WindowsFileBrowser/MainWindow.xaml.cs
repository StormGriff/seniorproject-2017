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

                        //for lazy loading
                        subitem.Items.Add(dummy);
                        subitem.Expanded += new RoutedEventHandler(folder_Expanded);

                        item.Items.Add(subitem);
                    }
                }
                catch (Exception) { }
            }
        }

        private void tvFileTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            lvFileView.Items.Clear();

            TreeViewItem item = (TreeViewItem)tvFileTree.SelectedItem;
            ListViewItem newItem;

            string[] files = Directory.GetFiles(Convert.ToString(item.Tag));

            foreach(string s in files)
            {
                newItem = new ListViewItem();
                lvFileView.Items.Add(newItem);
            }
        }
    }
}
