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
        /// The method to use ThreadPool to call those ConcatString methods.
        /// </summary>
        private void UseThreadPool()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ConcatPool1));
            ThreadPool.QueueUserWorkItem(new WaitCallback(ConcatPool2));
        }

        /// <summary>
        /// The delegate method for creating a ThreadPool queue item.
        /// This one is used to call ConcatString1 method.
        /// </summary>
        /// <param name="stateInfo"></param>
        private void ConcatPool1(object? stateInfo)
        {
            ConcatString1();
        }

        /// <summary>
        /// The delegate method for creating a ThreadPool queue item.
        /// This one is used to call ConcatString2 method.
        /// </summary>
        /// <param name="stateInfo"></param>
        private void ConcatPool2(object? stateInfo)
        {
            ConcatString2();
        }
    }
}
