using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace WindowsFileBrowser
{
    public class FileSystemListView: ListView
    {
        public FileSystemListView()
        {
            GridView gridView = new GridView();
            gridView.AllowsColumnReorder = true;
            gridView.ColumnHeaderToolTip = "Item Information";

            GridViewColumn gvc1 = new GridViewColumn();
            gvc1.DisplayMemberBinding = new Binding("Name");
            gvc1.Header = "Name";
            gvc1.Width = 300;
            gridView.Columns.Add(gvc1);

            GridViewColumn gvc2 = new GridViewColumn();
            gvc2.DisplayMemberBinding = new Binding("Size");
            gvc2.Header = "Size";
            gvc2.Width = 100;
            gridView.Columns.Add(gvc2);

            GridViewColumn gvc3 = new GridViewColumn();
            gvc3.DisplayMemberBinding = new Binding("FileType");
            gvc3.Header = "Type";
            gvc3.Width = 150;
            gridView.Columns.Add(gvc3);

            GridViewColumn gvc4 = new GridViewColumn();
            gvc4.DisplayMemberBinding = new Binding("LastModified");
            gvc4.Header = "Last Modified";
            gvc4.Width = 150;
            gridView.Columns.Add(gvc4);

            this.View = gridView;

        }
    }
}
