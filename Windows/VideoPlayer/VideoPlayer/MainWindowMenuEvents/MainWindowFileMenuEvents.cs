﻿using System.Windows;

namespace VideoPlayer
{
    public partial class MainWindow
    {
        private void mnuOpenFile_Click(object sender, RoutedEventArgs e)
        {
            SelectNewSingleFile();
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
