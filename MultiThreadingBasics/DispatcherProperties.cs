using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MultiThreadingBasics
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// A public class to hold the propertied of the execution results of this program.
        /// </summary>
        public class StringProperties : INotifyPropertyChanged
        {
            /// <summary>
            /// The implementation of INotifyPropertyChanged.
            /// </summary>
            public event PropertyChangedEventHandler? PropertyChanged;

            private string _str1 = "";
            private string _str2 = "";
            private int _loop1 = 0;
            private int _loop2 = 0;
            private double _memUsed1 = 0d;
            private double _memUsed2 = 0d;
            private TimeSpan _timeUsed1 = new();
            private TimeSpan _timeUsed2 = new();

            /// <summary>
            /// The property to hold the result of the string concatenation.
            /// </summary>
            public string String1
            {
                get { return _str1; }
                set
                {
                    _str1 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(String1)));
                }
            }
            /// <summary>
            /// The loop count value related to the string concatenation.
            /// </summary>
            public int Count1
            {
                get { return _loop1; }
                set
                {
                    _loop1 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count1)));
                }
            }
            /// <summary>
            /// The memory consumption value of the string concatenation.
            /// </summary>
            public double MemoryUsed1
            {
                get { return _memUsed1; }
                set
                {
                    _memUsed1 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MemoryUsed1)));
                }
            }
            /// <summary>
            /// The time used by the string concatenation.
            /// </summary>
            public TimeSpan TimeUsed1
            {
                get { return _timeUsed1; }
                set
                {
                    _timeUsed1 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimeUsed1)));
                }
            }

            /// <summary>
            /// The property to hold the result of the StringBuilder concatenation.
            /// </summary>
            public string String2
            {
                get { return _str2; }
                set
                {
                    _str2 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(String2)));
                }
            }
            /// <summary>
            /// The loop count value related to the StringBuilder concatenation.
            /// </summary>
            public int Count2
            {
                get { return _loop2; }
                set
                {
                    _loop2 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count2)));
                }
            }
            /// <summary>
            /// The memory consumption value of the StringBuilder concatenation.
            /// </summary>
            public double MemoryUsed2
            {
                get { return _memUsed2; }
                set
                {
                    _memUsed2 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MemoryUsed2)));
                }
            }
            /// <summary>
            /// The time used by the StringBuilder concatenation.
            /// </summary>
            public TimeSpan TimeUsed2
            {
                get { return _timeUsed2; }
                set
                {
                    _timeUsed2 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimeUsed2)));
                }
            }

        }
    }
}
