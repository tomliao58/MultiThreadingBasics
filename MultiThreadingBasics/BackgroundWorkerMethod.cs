using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MultiThreadingBasics
{
    public partial class MainWindow : Window
    {
        #region The BackgroundWorker Method
        /// <summary>
        /// The method to activate 2 BackgroundWorkers.
        /// </summary>
        private void ActivateBGWorker()
        {
            // BGWorker1 concatenates a string type variable 50,000 times.
            BackgroundWorker BGWorker1 = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };
            BGWorker1.DoWork += DoWork1; // Concatenate a string 50,000 times.
            BGWorker1.ProgressChanged += ProgChanged1; // Update data to UI during process. (But not working)
            BGWorker1.RunWorkerCompleted += WorkComplete1; // Update the result when DoWork is done.
            BGWorker1.RunWorkerAsync(); // The method really activates the BackgroundWorker.

            // BGWorker2 concatenates a StringBuilder type variable 50,000 times.
            BackgroundWorker BGWorker2 = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };
            BGWorker2.DoWork += DoWork2;    // Concatenate a StringBuilder 50,000 times.
            BGWorker2.ProgressChanged += ProgChanged2;  // Update data to UI during process. (But not working)
            BGWorker2.RunWorkerCompleted += WorkCompleted2; // Update the result when DoWork is done.
            BGWorker2.RunWorkerAsync(); // The method really activates the BackgroundWorker.
        }

        /// <summary>
        /// Concatenate a string 50,000 times.
        /// </summary>
        /// <param name="sender">The caller object.</param>
        /// <param name="e">The arguments.</param>
        private void DoWork1(object sender, DoWorkEventArgs e)
        {
            _stopWatch1.Restart();  // Start the stopwatch to time the process execution.

            for (int i = 0; i < 50000; i++)
            {
                _string1 += i.ToString();
                _count1++;
                _mem1 = ((double)GC.GetAllocatedBytesForCurrentThread() / 1024d / 1024d);
                _time1 = _stopWatch1.Elapsed;
                //(sender as BackgroundWorker).ReportProgress((i / 50000 * 100));
                //Thread.Sleep(1);
            }
            _stopWatch1.Stop(); // Stop the stopwatch.
            e.Result = _string1;
        }

        /// <summary>
        /// Update data to UI during process. (But not working)
        /// Will use a Dispatcher to perform the same task.
        /// </summary>
        /// <param name="sender">The caller object.</param>
        /// <param name="e">The arguments.</param>
        private void ProgChanged1(object sender, ProgressChangedEventArgs e)
        {
            txb_String_Count.Text = _count1.ToString();
            txb_String_RAM.Text = _mem1.ToString();
            txb_String_Time.Text = _time1.ToString();
        }

        /// <summary>
        /// Update the result when DoWork is done.
        /// </summary>
        /// <param name="sender">The caller object.</param>
        /// <param name="e">The arguments.</param>
        private void WorkComplete1(object sender, RunWorkerCompletedEventArgs e)
        {
            txb_String_Result.Text = _string1;
            lbl_String_Length.Content = _string1.Length;
        }

        /// <summary>
        /// Concatenate a StringBuilder 50,000 times.
        /// </summary>
        /// <param name="sender">The caller object.</param>
        /// <param name="e">The arguments.</param>
        private void DoWork2(object sender, DoWorkEventArgs e)
        {
            _stopWatch2.Restart();  // Start the stopwatch to time the process execution.

            for (int i = 0; i < 50000; i++)
            {
                _string2.Append(i);
                _count2++;
                _mem2 = ((double)GC.GetAllocatedBytesForCurrentThread() / 1024d / 1024d);
                _time2 = _stopWatch2.Elapsed;
                //(sender as BackgroundWorker).ReportProgress((i / 50000 * 100));
                //Thread.Sleep(1);
            }
            _stopWatch2.Stop(); // Stop the stopwatch.
            e.Result = _string2;
        }

        /// <summary>
        /// Update data to UI during process. (But not working)
        /// Will use a Dispatcher to perform the same task.
        /// </summary>
        /// <param name="sender">The caller object.</param>
        /// <param name="e">The arguments.</param>
        private void ProgChanged2(object sender, ProgressChangedEventArgs e)
        {
            txb_StringBuilder_Count.Text = _count2.ToString();
            txb_StringBuilder_RAM.Text = _mem2.ToString();
            txb_StringBuilder_Time.Text = _time2.ToString();
        }

        /// <summary>
        /// Update the result when DoWork is done.
        /// </summary>
        /// <param name="sender">The caller object.</param>
        /// <param name="e">The arguments.</param>
        private void WorkCompleted2(object sender, RunWorkerCompletedEventArgs e)
        {
            txb_StringBuilder_Result.Text = _string2.ToString();
            lbl_StringBuilder_Length.Content = _string2.Length;
        }
        #endregion
    }
}
