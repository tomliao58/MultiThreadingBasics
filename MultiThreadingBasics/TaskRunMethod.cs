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
        /// Running two tasks by using Task.Run in one method.
        /// </summary>
       private void UseTaskRun()
        {
            // Concatenate a string 50,000 times.
            Task.Run(() => ConcatString1())
                .ContinueWith(result =>
                {
                    // Update result string back to UI.
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        GetProperties.String1 = _string1;
                    }));
                });

            // Concatenate a StringBuilder 50,000 times.
            Task.Run(() => ConcatString2())
                .ContinueWith(result =>
                {
                    // Update result string back to UI.
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        GetProperties.String2 = _string2.ToString();
                    }));
                });

            // The following running a task within another task by using Task.Run.
            //Task? childTask = null;

            //var fatherTask = Task.Run(() =>
            //{
            //    ConcatString2();
            //    childTask = new Task(() => ConcatString1(), TaskCreationOptions.AttachedToParent);
            //    childTask.Start();
            //    childTask.ContinueWith(result =>
            //    {
            //        this.Dispatcher.BeginInvoke(new Action(() =>
            //        {
            //            GetProperties.String1 = _string1;
            //        }));
            //    });
            //}).ContinueWith(result =>
            //{
            //    this.Dispatcher.BeginInvoke(new Action(() =>
            //    {
            //        GetProperties.String2 = _string2.ToString();
            //    }));
            //});

            //fatherTask.Wait();
        }
    }
}
