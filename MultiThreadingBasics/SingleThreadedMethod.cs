using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MultiThreadingBasics
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Concatenate a string type variable 50,000 times.
        /// </summary>
        private void ConcatString()
        {
            string _s = "";
            int _count_S = 0;
            Stopwatch _sw_S = new();
            _sw_S.Start();  // Start the stopwatch to time the process execution.

            for (int i = 0; i < 50000; i++)
            {
                // Convert integer i to string and concatenate to _s. 
                _s += i.ToString();
                // Record the loop count numbers.
                _count_S++;
            }
            txb_String_Count.Text = _count_S.ToString(); // Display loop count.
            // Display the memory consumption value.
            txb_String_RAM.Text = (GC.GetAllocatedBytesForCurrentThread() / 1024 / 1024).ToString();
            txb_String_Time.Text = _sw_S.Elapsed.ToString(); // Display the time elasped.
            _sw_S.Stop(); // Stop the stopwatch.
            txb_String_Result.Text = _s;    // Display the final string 
            lbl_String_Length.Content = _s.Length;  // Display the total length of the final string.
        }

        /// <summary>
        /// Concatenate a StringBuilder object 50,000 times.
        /// </summary>
        private void ConcatStringBuilder()
        {
            StringBuilder _sb = new();
            int _count_SB = 0;
            Stopwatch _sw_SB = new();
            _sw_SB.Start();  // Start the stopwatch to time the process execution.

            for (int i = 0; i < 50000; i++)
            {
                // Append integer i to the StringBuilder object _sb. 
                _sb.Append(i);
                // Record the loop count numbers.
                _count_SB++;
            }
            txb_StringBuilder_Count.Text = _count_SB.ToString(); // Display loop count.
            // Display the memory consumption value.
            txb_StringBuilder_RAM.Text = (GC.GetAllocatedBytesForCurrentThread() / 1024 / 1024).ToString();
            txb_StringBuilder_Time.Text = _sw_SB.Elapsed.ToString(); // Display the time elasped.
            _sw_SB.Stop(); // Stop the stopwatch.
            // Display the final result of the StringBuilder object.
            txb_StringBuilder_Result.Text = _sb.ToString();
            // Display the total length of the StringBuilder object.
            lbl_StringBuilder_Length.Content = _sb.Length;
        }
    }
}
