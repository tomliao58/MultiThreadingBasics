using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MultiThreadingBasics
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private string appArg = "0";
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length == 1)
                appArg = e.Args[0];
            MainWindow mainWin = new(appArg);
            mainWin.Show();
        }
    }
}
