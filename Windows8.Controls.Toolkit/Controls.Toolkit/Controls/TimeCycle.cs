using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Controls.Toolkit.Controls
{
    public sealed class TimeCycle : Control
    {
        TextBlock HourText1;
        TextBlock HourText2;
        TextBlock MinuteText1;
        TextBlock MinuteText2;
      
        private DispatcherTimer timer;
        public TimeCycle()
        {
            this.DefaultStyleKey = typeof(TimeCycle);
            Loaded += TimeCycle_Loaded;
            Unloaded += TimeCycle_Unloaded;
        }

        void TimeCycle_Unloaded(object sender, RoutedEventArgs e)
        {
            timer.Tick -= timer_Tick;
            timer.Stop();
        }

        void TimeCycle_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(5) };
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, object e)
        {
            setTime();
        }
        void setTime()
        {
            var hour = DateTime.Now.Hour;
            var minute = DateTime.Now.Minute;
            var minuteStr = string.Format("{0:00}", minute);
            if (HourText1 != null)
                HourText1.Text = hour.ToString().Substring(0, 1);
            if (HourText2 != null)
                HourText2.Text = hour.ToString().Substring(1, 1);
            if (MinuteText1 != null)
                MinuteText1.Text = minuteStr.Substring(0, 1);
            if (MinuteText2 != null)
                MinuteText2.Text = minuteStr.Substring(1, 1);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            HourText1 = GetTemplateChild("HourText1") as TextBlock;
            HourText2 = GetTemplateChild("HourText2") as TextBlock;
            MinuteText1 = GetTemplateChild("MinuteText1") as TextBlock;
            MinuteText2 = GetTemplateChild("MinuteText2") as TextBlock;
            setTime();
        }
    }
}
