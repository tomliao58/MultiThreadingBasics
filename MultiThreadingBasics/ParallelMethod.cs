using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MultiThreadingBasics
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// This object is used for the lock statement.
        /// </summary>
        private readonly object lockObj = new object();

        /// <summary>
        /// This method uses Parallel.For to concatenate a string 50,000 times.
        /// </summary>
        private void ConcatString1Parallel()
        {
            _stopWatch1.Restart();  // Start the stopwatch to time the process execution.

            Parallel.For(0, 50000, index =>
            {
                lock (lockObj)
                {
                    _string1 += index.ToString();
                    _count1++;
                    _mem1 = ((double)GC.GetAllocatedBytesForCurrentThread() / 1024d / 1024d);
                    _time1 = _stopWatch1.Elapsed;
                }

            });
            _stopWatch1.Stop(); // Stop the stopwatch.
        }

        /// <summary>
        /// This method uses Parallel.For to concatenate a StringBuilder 50,000 times.
        /// </summary>
        private void ConcatString2Parallel()
        {
            _stopWatch2.Restart();  // Start the stopwatch to time the process execution.

            Parallel.For(0, 50000, index =>
            {
                lock (lockObj)
                {
                    _string2.Append(index);
                    _count2++;
                    _mem2 = ((double)GC.GetAllocatedBytesForCurrentThread() / 1024d / 1024d);
                    _time2 = _stopWatch2.Elapsed;
                }

            });

            _stopWatch2.Stop(); // Stop the stopwatch.
        }

        /// <summary>
        /// Running two tasks by using Task.Run in one method.
        /// But calling the parallel version of ConcatString methods.
        /// </summary>
        private void UseParallel()
        {
            // Concatenate a string 50,000 times.
            Task.Run(() => ConcatString1Parallel())
                .ContinueWith(result =>
                {
                    // Update result string back to UI.
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        GetProperties.String1 = _string1;
                    }));
                });

            // Concatenate a StringBuilder 50,000 times.
            Task.Run(() => ConcatString2Parallel())
                .ContinueWith(result =>
                {
                    // Update result string back to UI.
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        GetProperties.String2 = _string2.ToString();
                    }));
                });
        }
    }
}
