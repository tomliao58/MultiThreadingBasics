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
using System.Windows.Threading;

namespace MultiThreadingBasics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Shared Varibles
        string _string1 = "";
        StringBuilder _string2 = new();
        int _count1 = 0;
        int _count2 = 0;
        double _mem1 = 0d;
        double _mem2 = 0d;
        TimeSpan _time1 = new();
        TimeSpan _time2 = new();
        Stopwatch _stopWatch1 = new();
        Stopwatch _stopWatch2 = new();
        public StringProperties GetProperties = new();
        DispatcherTimer dispatchTimer = new();
        int param = 0;  // added in the last video.
        #endregion

        /// <summary>
        /// The default constructor of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = GetProperties;
        }
        /// <summary>
        /// The second constructor of the MainWindow class. 
        /// It has one optional argument.
        /// </summary>
        /// <param name="appArg">The option numer of the task to run.</param>
        public MainWindow(string appArg = "0")
        {
            InitializeComponent();
            this.DataContext = GetProperties;

            #region Initialize Windows Position and Startup function
            // Start the Window position setup procedure.
            AppStartOption(appArg);
            #endregion
        }
        /// <summary>
        /// The procedure to setup the window position.
        /// And hide the button. 
        /// </summary>
        /// <param name="argString"></param>
        private void AppStartOption(string argString)
        {
            param = Convert.ToInt32(argString);
            switch (argString)
            {
                case "1":
                case "2":
                    this.Top = 20;
                    this.Left = 100 + (SystemParameters.PrimaryScreenWidth / 2) * (param - 1);
                    btn_Go.Visibility = Visibility.Hidden;
                    DoConcatenation(param);
                    break;
                case "3":
                case "4":
                    this.Top = 20 + (SystemParameters.PrimaryScreenHeight / 2);
                    this.Left = 100 + (SystemParameters.PrimaryScreenWidth / 2) * (param - 3);
                    btn_Go.Visibility = Visibility.Hidden;
                    DoConcatenation(param);
                    break;
                default:
                    break;
            }
        }

        private void btn_Go_Click(object sender, RoutedEventArgs e)
        {
            //ConcatString(); // Concatenate a String type variable 50,000 times.
            //ConcatStringBuilder(); // Concatenate a StringBuilder object 50,000 times.
            DoConcatenation(1);  // Select a thread technique to perform string concatenation.
        }

        /// <summary>
        /// The caller method of running string concatenation by using the 
        /// selected threading approach. 
        /// <para> threadOption: 1 = BackgroundWorker.</para>
        /// </summary>
        /// <param name="threadOption">The option of the threading approach.</param>
        private async void DoConcatenation(int threadOption = 1)
        {
            UIDataDispatcher();
            switch (threadOption)
            {
                case 1:
                    lbl_TaskName.Content = "(1) BackgroundWorker";
                    //UIDataDispatcher(); // Call the Dispatcher method to update data to UI.
                    ActivateBGWorker(); // Defined in the BackgroundWorkerMethod.cs file.
                    break;
                case 2:
                    lbl_TaskName.Content = "(2) Thread Class";
                    Thread1();
                    Thread2();
                    break;
                case 3: // Move up from 4 to 3 in the last video.
                    lbl_TaskName.Content = "(3) TPL - Task.Run";
                    UseTaskRun();
                    break;
                case 4: // Move up from 6 to 4 in the last video.
                    lbl_TaskName.Content = "(4) TPL - async / await";
                    GetProperties.String2 = await Task.Run(() => ConcatString2Task());
                    GetProperties.String1 = await Task.Run(() => ConcatString1Task());
                    break;
                case 5: // Move down from 3 to 5 in the last video.
                    lbl_TaskName.Content = "(5) ThreadPool";
                    UseThreadPool();
                    break;
                case 6: // Move down from 5 to 6 in the last video.
                    lbl_TaskName.Content = "(6) TPL - Task.Factory.StartNew";
                    UseTaskFactoryStartNew();
                    break;
                case 7:
                    lbl_TaskName.Content = "(7) TPL - Parallel Programming";
                    UseParallel();
                    break;
            }
        }
    }
}
