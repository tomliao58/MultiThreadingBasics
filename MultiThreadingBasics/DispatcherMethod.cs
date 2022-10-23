using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MultiThreadingBasics
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The method to activate the DispatcherTimer.
        /// </summary>
        private void UIDataDispatcher()
        {
            dispatchTimer.Tick += new EventHandler(dispatchTimer_Tick);
            dispatchTimer.Interval = new TimeSpan();
            dispatchTimer.Start();
        }

        /// <summary>
        /// The method to run the DispatcherTimer at the given interval.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dispatchTimer_Tick(object sender, EventArgs e)
        {
            DoUIUpdate();
        }

        /// <summary>
        /// The method that actually update data to a public property class 
        /// using Lambda expression.
        /// </summary>
        private void DoUIUpdate()
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                GetProperties.Count1 = _count1;
                GetProperties.MemoryUsed1 = _mem1;
                GetProperties.TimeUsed1 = _time1;
                // Change the background color of txb_String_RAM.Background.
                if (_count1 != 50000)
                {
                    LinearGradientBrush tb1 = new();
                    tb1.StartPoint = new Point(0, 0.5);
                    tb1.EndPoint = new Point(1, 0.5);
                    tb1.GradientStops.Add(new(Colors.Red, _mem1 / 12000));
                    tb1.GradientStops.Add(new(Colors.White, _mem1 / 12000));
                    txb_String_RAM.Background = tb1;
                }
                else if (param == 1 || param == 2 || param == 5)
                {
                    GetProperties.String1 = _string1;
                }
                GetProperties.Count2 = _count2;
                GetProperties.MemoryUsed2 = _mem2;
                GetProperties.TimeUsed2 = _time2;
                // Change the background color of txb_StringBuilder_RAM.Background.
                if (_count2 != 50000)
                {
                    LinearGradientBrush tb2 = new();
                    tb2.StartPoint = new Point(0, 0.5);
                    tb2.EndPoint = new Point(1, 0.5);
                    tb2.GradientStops.Add(new(Colors.Red, _mem1 / 12000));
                    tb2.GradientStops.Add(new(Colors.White, _mem1 / 12000));
                    txb_StringBuilder_RAM.Background = tb2;
                }
                else if (param == 1 || param == 2 || param == 5)
                {
                    GetProperties.String2 = _string2.ToString();
                }
            }));
        }
    }
}
