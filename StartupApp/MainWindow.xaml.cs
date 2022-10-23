using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace StartupApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Go_Click(object sender, RoutedEventArgs e)
        {
            // Start 4 tasks parallelly.
            Parallel.For(1, 5, doAct =>
            {
                Process p = new Process();
                p.StartInfo.FileName = "MultiThreadingBasics.exe"; // This file should be in the same folder.
                p.StartInfo.Arguments = doAct.ToString(); // Pass in the current loop count.
                p.Start();
            });

            Thread.Sleep(1800); // Sleep 1.8 seconds before it closes itself.
            this.Close();   // Close this application.
        }
    }
}
