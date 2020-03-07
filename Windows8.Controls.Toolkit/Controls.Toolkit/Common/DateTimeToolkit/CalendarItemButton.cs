using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;


namespace Controls.Toolkit.Common.DateTimeToolkit
{
    [TemplatePart(Name = "BorderBase", Type = typeof(Border))]
    public sealed class CalendarItemButton : ToggleButton
    {
        public Style SelectedAeroStyle
        {
            get { return (Style)GetValue(SelectedAeroStyleProperty); }
            set { SetValue(SelectedAeroStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedAeroStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedAeroStyleProperty =
            DependencyProperty.Register("SelectedAeroStyle", typeof(Style), typeof(CalendarItemButton), new PropertyMetadata(null));


        public Style SelectedDayStyle
        {
            get { return (Style)GetValue(SelectedDayStyleProperty); }
            set { SetValue(SelectedDayStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedDayStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedDayStyleProperty =
            DependencyProperty.Register("SelectedDayStyle", typeof(Style), typeof(CalendarItemButton), new PropertyMetadata(null));


        public Style FirstAndLastWeekStyle
        {
            get { return (Style)GetValue(FirstAndLastWeekStyleProperty); }
            set { SetValue(FirstAndLastWeekStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FirstAndLastWeekStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FirstAndLastWeekStyleProperty =
            DependencyProperty.Register("FirstAndLastWeekStyle", typeof(Style), typeof(CalendarItemButton), new PropertyMetadata(null));


        public Border BorderBase { get; set; }
        const string DateChecked = "DateChecked";
        const string PointerOver = "PointerOver";
        const string WeekendState = "Weekend";
        const string WorkTimeState = "Worktime";

        public CalendarItemButton()
        {
            this.DefaultStyleKey = typeof(CalendarItemButton);
            this.Loaded += CalendarItemButton_Loaded;
            this.Click += CalendarItemButton_Click;
        }

        void CalendarItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedDayStyle != null)
                this.Style = SelectedDayStyle;
            else
                VisualStateManager.GoToState(this, DateChecked, false);

            var data = this.DataContext as Day;
            data.Call();
        }

        bool LoadedOK = false;
        bool Templated = false;

        private void SetState()
        {
            if (LoadedOK && Templated)
            {
                Day day = this.DataContext as Day;
                DateTime datetime = day.SelectedDate;
                if (datetime.Year == DateTime.Now.Year && datetime.Month == DateTime.Now.Month && datetime.Day == DateTime.Now.Day)
                {
                    VisualStateManager.GoToState(this, DateChecked, false); //this.Background = new SolidColorBrush(Colors.Red);
                }

                if (datetime.DayOfWeek == DayOfWeek.Sunday || datetime.DayOfWeek == DayOfWeek.Saturday)
                {
                    if (FirstAndLastWeekStyle != null)
                        this.Style = FirstAndLastWeekStyle;
                    else
                        VisualStateManager.GoToState(this, WeekendState, false);
                }
                else
                {
                    VisualStateManager.GoToState(this, WorkTimeState, false);
                }

                if (day.IsOtherMonth)
                    this.Opacity = 0.5;

                if (day.IsInSelectedAero)
                {
                    if (SelectedAeroStyle != null)
                        this.Style = SelectedAeroStyle;
                    else
                        this.BorderBase.Background = new SolidColorBrush(Colors.Gray);
                }
                else
                {
                    this.BorderBase.Background = new SolidColorBrush(Colors.White);
                }

                this.Content = datetime.Day.ToString().PadLeft(2, '0');
            }
        }

        void CalendarItemButton_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            LoadedOK = true;
            SetState();
        }
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Templated = true;
            BorderBase = this.GetTemplateChild("BorderBase") as Border;
            SetState();
        }

    }
}
