using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;



namespace Controls.Toolkit.Common.DateTimeToolkit
{
    public sealed partial class TimerToolkit : UserControl
    {
        public TimerToolkit()
        {
            this.InitializeComponent();

            this.timeTimeHour.TimeChanged += timeTime_TimeChanged;
            this.timeItemMinute.TimeChanged += timeTime_TimeChanged;
        }

        void timeTime_TimeChanged()
        {
            DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(timeTimeHour.TimeContent), Convert.ToInt32(timeItemMinute.TimeContent), DateTime.Now.Second);
            OnTimeChanged(time);
        }

        public event Action<DateTime> TimeChanged;
        private void OnTimeChanged(DateTime datetime)
        {
            Action<DateTime> handler = TimeChanged;
            if (handler != null)
                handler(datetime);
        }     
    }
}
