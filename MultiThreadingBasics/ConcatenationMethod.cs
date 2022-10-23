using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MultiThreadingBasics
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The method is used to concatenate a string type variable 50,000 times.
        /// This method is extract from the DoWork1 event of BackgroundWorker.
        /// </summary>
        private void ConcatString1()
        {
            _stopWatch1.Restart();  // Start the stopwatch to time the process execution.

            for (int i = 0; i < 50000; i++)
            {
                _string1 += i.ToString();
                _count1++;
                _mem1 = ((double)GC.GetAllocatedBytesForCurrentThread() / 1024d / 1024d);
                _time1 = _stopWatch1.Elapsed;
            }
            _stopWatch1.Stop(); // Stop the stopwatch.
        }

        /// <summary>
        /// The method is used to concatenate a StringBuilder type variable 50,000 times.
        /// This method is extract from the DoWork2 event of BackgroundWorker.
        /// </summary>
        private void ConcatString2()
        {
            _stopWatch2.Restart();  // Start the stopwatch to time the process execution.

            for (int i = 0; i < 50000; i++)
            {
                _string2.Append(i);
                _count2++;
                _mem2 = ((double)GC.GetAllocatedBytesForCurrentThread() / 1024d / 1024d);
                _time2 = _stopWatch2.Elapsed;
            }
            _stopWatch2.Stop(); // Stop the stopwatch.
        }
        /// <summary>
        /// This method is a Task<string> type method which concatenates a string 50,000 times.
        /// </summary>
        /// <returns>Returns a Task.FromResult(_string1)</returns>
        private Task<string> ConcatString1Task()
        {
            _stopWatch1.Restart();  // Start the stopwatch to time the process execution.

            for (int i = 0; i < 50000; i++)
            {
                _string1 += i.ToString();
                _count1++;
                _mem1 = ((double)GC.GetAllocatedBytesForCurrentThread() / 1024d / 1024d);
                _time1 = _stopWatch1.Elapsed;
            }
            _stopWatch1.Stop(); // Stop the stopwatch.
            return Task.FromResult(_string1);
        }
        /// <summary>
        /// This method is a Task<string> type method which concatenates a StringBuilder 
        /// 50,000 times.
        /// </summary>
        /// <returns>Return a Task.FromResult(_string2.ToString())</returns>
        private Task<string> ConcatString2Task()
        {
            _stopWatch2.Restart();  // Start the stopwatch to time the process execution.

            for (int i = 0; i < 50000; i++)
            {
                _string2.Append(i);
                _count2++;
                _mem2 = ((double)GC.GetAllocatedBytesForCurrentThread() / 1024d / 1024d);
                _time2 = _stopWatch2.Elapsed;
            }
            _stopWatch2.Stop(); // Stop the stopwatch.
            return Task.FromResult(_string2.ToString());
        }
    }
}
