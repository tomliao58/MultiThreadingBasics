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
        /// Method of using the Thread class to execute a thread of work.
        /// This one is used to run ConcatString1 method.
        /// </summary>
        private void Thread1()
        {
            Thread thread1 = new(() => ConcatString1());
            thread1.Start();
            //thread1.Join(0);
            //txb_String_Result.Text = _string1;
            //lbl_String_Length.Content = _string1.Length;
        }

        /// <summary>
        /// Method of using the Thread class to execute a thread of work.
        /// This one is used to run ConcatString2 method.
        /// </summary>
        private void Thread2()
        {
            Thread thread2 = new(() => ConcatString2());
            thread2.Start();
            //thread2.Join(0);
            //txb_StringBuilder_Result.Text = _string2.ToString();
            //lbl_StringBuilder_Length.Content = _string2.Length;
        }
    }
}
