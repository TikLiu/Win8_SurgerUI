using Controls.Toolkit.Controls;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;



namespace Controls.Toolkit
{

    public sealed class timecontrol : Control
    {
        Button yearButton;
        Button monthButton;
        Button dayButton;
        TimeSlider yearSlider;
        TimeSlider monthSlider;
        TimeSlider daySlider;
        TextBlock yearMinusText;
        TextBlock yearPlusText;
        TextBlock monthMinusText;
        TextBlock monthPlusText;
        TextBlock dayMinusText;
        TextBlock dayPlusText;
        private int increase = 1;

        public DateTime DateTime
        {
            get { return (DateTime)GetValue(DateTimeProperty); }
            set { SetValue(DateTimeProperty, value); }
        }

        public static readonly DependencyProperty DateTimeProperty =
            DependencyProperty.Register("DateTime", typeof(DateTime), typeof(timecontrol),
                                        new PropertyMetadata(DateTime.Now, (s, e) =>
                    {
                        var control = s as timecontrol;
                        control.RefreshDate(e.NewValue is DateTime ? (DateTime)e.NewValue : System.DateTime.Now);
                    }));

        void Getchild()
        {
            yearButton = this.GetTemplateChild("YearButton") as Button;
            monthButton = this.GetTemplateChild("MonthButton") as Button;
            dayButton = this.GetTemplateChild("DayButton") as Button;
            yearSlider = GetTemplateChild("sliderYear") as TimeSlider;
            monthSlider = GetTemplateChild("sliderMonth") as TimeSlider;
            daySlider = GetTemplateChild("sliderDay") as TimeSlider;
            yearMinusText = GetTemplateChild("minusYear") as TextBlock;
            yearPlusText = GetTemplateChild("plusYear") as TextBlock;
            monthPlusText = GetTemplateChild("plusMonth") as TextBlock;
            monthMinusText = GetTemplateChild("minusMonth") as TextBlock;
            dayMinusText = GetTemplateChild("minusDay") as TextBlock;
            dayPlusText = GetTemplateChild("plusDay") as TextBlock;
        }

        #region add event
        void RegisterEvent()
        {
            if (yearButton != null)
            {
                yearButton.Click += yearButton_Click;
                yearButton.Content = DateTime.Now.Year;
            }

            if (dayButton != null)
            {
                dayButton.Click += dayButton_Click;
                dayButton.Content = DateTime.Now.Day;
            }

            if (monthButton != null)
            {
                monthButton.Click += monthButton_Click;
                monthButton.Content = DateTime.Now.Month;
            }
            if (yearSlider != null)
            {
                yearSlider.ValueChanged += yearSlider_ValueChanged;
                yearSlider.Value = DateTime.Now.Year;

            }
            if (yearMinusText != null)
            {
                yearMinusText.Tapped += yearMinusText_Tapped;
            }
            if (yearPlusText != null)
            {
                yearPlusText.Tapped += yearPlusText_Tapped;
            }
            if (monthSlider != null)
            {
                monthSlider.ValueChanged += monthSlider_ValueChanged;
                monthSlider.Value = DateTime.Now.Month;
            }
            if (monthMinusText != null)
            {
                monthMinusText.Tapped += monthMinusText_Tapped;
            }
            if (monthPlusText != null)
            {
                monthPlusText.Tapped += monthPlusText_Tapped;
            }
            if (daySlider != null)
            {
                daySlider.ValueChanged += daySlider_ValueChanged;
                daySlider.Value = DateTime.Now.Day;
            }
            if (dayMinusText != null)
            {
                dayMinusText.Tapped += dayMinusText_Tapped;
            }
            if (dayPlusText != null)
            {
                dayPlusText.Tapped += dayPlusText_Tapped;
            }
        }
        # endregion

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Getchild();
            RegisterEvent();
        }

        void yearPlusText_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            yearSlider.Value += increase;
        }
        void monthPlusText_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            monthSlider.Value += increase;
        }
        void dayPlusText_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            daySlider.Value += increase;
        }


        void monthMinusText_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            monthSlider.Value -= increase;
        }
        void yearMinusText_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            yearSlider.Value -= increase;
        }
        void dayMinusText_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            daySlider.Value -= increase;
        }


        void daySlider_ValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            dayButton.Content = e.NewValue;
        }

        void monthSlider_ValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            monthButton.Content = e.NewValue;
            daySlider.Maximum = DateTime.DaysInMonth(int.Parse(yearButton.Content.ToString()), int.Parse(monthButton.Content.ToString()));
        }

        void yearSlider_ValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            yearButton.Content = e.NewValue;
            daySlider.Maximum = DateTime.DaysInMonth(int.Parse(yearButton.Content.ToString()), int.Parse(monthButton.Content.ToString()));
        }

        void monthButton_Click(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "SelectMonth", true);
        }

        void dayButton_Click(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "SelectDay", true);
            daySlider.Maximum = DateTime.DaysInMonth(int.Parse(yearButton.Content.ToString()), int.Parse(monthButton.Content.ToString()));
        }

        void yearButton_Click(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "SelectYear", true);
        }


        public timecontrol()
        {
            this.DefaultStyleKey = typeof(timecontrol);

        }
        public void ThisLostFocus()
        {
            VisualStateManager.GoToState(this, "Default", true);
        }

        void RefreshDate(DateTime dateTime)
        {
            yearButton.Content = dateTime.Year;
            monthButton.Content = dateTime.Month;
            dayButton.Content = dateTime.Day;
        }
    }
}
