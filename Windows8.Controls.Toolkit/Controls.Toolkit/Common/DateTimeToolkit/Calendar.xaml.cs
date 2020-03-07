using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Controls.Toolkit.Common.DateTimeToolkit
{
    public sealed partial class Calendar : UserControl, INotifyPropertyChanged
    {
        #region today
        public DateTime TodayOfDate
        {
            get { return (DateTime)GetValue(TodayOfDateProperty); }
            set { SetValue(TodayOfDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TodayOfDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TodayOfDateProperty =
            DependencyProperty.Register("TodayOfDate", typeof(DateTime), typeof(Calendar), new PropertyMetadata(DateTime.Now));
        #endregion

        #region the area that has been selected
        public DateTime StartDate
        {
            get { return (DateTime)GetValue(StartDateProperty); }
            set { SetValue(StartDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartDateProperty =
            DependencyProperty.Register("StartDate", typeof(DateTime), typeof(Calendar), new PropertyMetadata(DateTime.MaxValue));

        public DateTime EndDate
        {
            get { return (DateTime)GetValue(EndDateProperty); }
            set { SetValue(EndDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EndDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EndDateProperty =
            DependencyProperty.Register("EndDate", typeof(DateTime), typeof(Calendar), new PropertyMetadata(DateTime.MinValue, (sender, args) =>
            {
                Calendar calendar = sender as Calendar;
                if (calendar != null)
                {
                    DateTime datetime = DateTime.Now;
                    try
                    {
                        datetime = Convert.ToDateTime(args.NewValue);
                        if (datetime == DateTime.MinValue)
                            datetime = DateTime.Now;
                    }
                    catch (Exception)
                    {
                        datetime = DateTime.Now;
                    }
                    finally
                    {
                        calendar.UpdateSelectedDays(datetime);
                    }
                }
            }));

        public bool ShowOtherMonth
        {
            get { return (bool)GetValue(ShowOtherMonthProperty); }
            set { SetValue(ShowOtherMonthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowOtherMonth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowOtherMonthProperty =
            DependencyProperty.Register("ShowOtherMonth", typeof(bool), typeof(Calendar), new PropertyMetadata(true));

        #endregion

        #region calendar style

        #region Title brush
        public Brush YearOnDaysTitleBrush
        {
            get { return (Brush)GetValue(YearOnDaysTitleBrushProperty); }
            set { SetValue(YearOnDaysTitleBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for YearTitleBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YearOnDaysTitleBrushProperty =
            DependencyProperty.Register("YearOnDaysTitleBrush", typeof(Brush), typeof(Calendar), new PropertyMetadata(new SolidColorBrush(Colors.Black)));


        public Brush MonthOnDaysTitleBrush
        {
            get { return (Brush)GetValue(MonthOnDaysTitleBrushProperty); }
            set { SetValue(MonthOnDaysTitleBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonthTitleBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonthOnDaysTitleBrushProperty =
            DependencyProperty.Register("MonthOnDaysTitleBrush", typeof(Brush), typeof(Calendar), new PropertyMetadata(new SolidColorBrush(Colors.Gray)));


        public Brush YearOnMonthsTitlBrush
        {
            get { return (Brush)GetValue(YearOnMonthsTitlBrushProperty); }
            set { SetValue(YearOnMonthsTitlBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for YearOnMonthsTitlBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YearOnMonthsTitlBrushProperty =
            DependencyProperty.Register("YearOnMonthsTitlBrush", typeof(Brush), typeof(Calendar), new PropertyMetadata(new SolidColorBrush(Colors.Gray)));


        public Brush MonthOnMonthsTitleBrush
        {
            get { return (Brush)GetValue(MonthOnMonthsTitleBrushProperty); }
            set { SetValue(MonthOnMonthsTitleBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonthOnMonthsTitleBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonthOnMonthsTitleBrushProperty =
            DependencyProperty.Register("MonthOnMonthsTitleBrush", typeof(Brush), typeof(Calendar), new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        #endregion

        #region previous and next button style
        public Style PreviousButtonStyle
        {
            get { return (Style)GetValue(PreviousButtonStyleProperty); }
            set { SetValue(PreviousButtonStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PreviousButtonStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PreviousButtonStyleProperty =
            DependencyProperty.Register("PreviousButtonStyle", typeof(Style), typeof(Calendar), new PropertyMetadata(null));

        public Style NextButtonStyle
        {
            get { return (Style)GetValue(NextButtonStyleProperty); }
            set { SetValue(NextButtonStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NextButtonStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NextButtonStyleProperty =
            DependencyProperty.Register("NextButtonStyle", typeof(Style), typeof(Calendar), new PropertyMetadata(null));
        #endregion


        #region week brush
        public Brush WeekTitleBrush
        {
            get { return (Brush)GetValue(WeekTitleBrushProperty); }
            set { SetValue(WeekTitleBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WeekTitleBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WeekTitleBrushProperty =
            DependencyProperty.Register("WeekTitleBrush", typeof(Brush), typeof(Calendar), new PropertyMetadata(new SolidColorBrush(Colors.Black)));


        public Brush FistAndLastWeekBrush
        {
            get { return (Brush)GetValue(FistAndLastWeekBrushProperty); }
            set { SetValue(FistAndLastWeekBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FistAndLastWeekBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FistAndLastWeekBrushProperty =
            DependencyProperty.Register("FistAndLastWeekBrush", typeof(Brush), typeof(Calendar), new PropertyMetadata(new SolidColorBrush(Colors.Red)));
        #endregion

        #region day forground
        public Brush DayForground
        {
            get { return (Brush)GetValue(DayForgroundProperty); }
            set { SetValue(DayForgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DayForground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DayForgroundProperty =
            DependencyProperty.Register("DayForground", typeof(Brush), typeof(Calendar), new PropertyMetadata(new SolidColorBrush(Colors.Black)));


        public Brush FirstAndLastDayColumnForground
        {
            get { return (Brush)GetValue(FirstAndLastDayColumnForgroundProperty); }
            set { SetValue(FirstAndLastDayColumnForgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FirstAndLastDayColumnForground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FirstAndLastDayColumnForgroundProperty =
            DependencyProperty.Register("FirstAndLastDayColumnForground", typeof(Brush), typeof(Calendar), new PropertyMetadata(new SolidColorBrush(Colors.Red)));
        #endregion

        #region month style
        public Style MonthStyle
        {
            get { return (Style)GetValue(MonthStyleProperty); }
            set { SetValue(MonthStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Month.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonthStyleProperty =
            DependencyProperty.Register("MonthStyle", typeof(Style), typeof(Calendar), new PropertyMetadata(null));


        public Style SelectedMonthStyle
        {
            get { return (Style)GetValue(SelectedMonthStyleProperty); }
            set { SetValue(SelectedMonthStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedMonthStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedMonthStyleProperty =
            DependencyProperty.Register("SelectedMonthStyle", typeof(Style), typeof(Calendar), new PropertyMetadata(null));
        #endregion


        public Style DaySelectedStyle
        {
            get { return (Style)GetValue(DaySelectedStyleProperty); }
            set { SetValue(DaySelectedStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DaySelectedStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DaySelectedStyleProperty =
            DependencyProperty.Register("DaySelectedStyle", typeof(Style), typeof(Calendar), new PropertyMetadata(null));

        public Style MonthSelectedStyle
        {
            get { return (Style)GetValue(MonthSelectedStyleProperty); }
            set { SetValue(MonthSelectedStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonthSelectedStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonthSelectedStyleProperty =
            DependencyProperty.Register("MonthSelectedStyle", typeof(Style), typeof(Calendar), new PropertyMetadata(null));

        public Brush OtherMonthDayBrush
        {
            get { return (Brush)GetValue(OtherMonthDayBrushProperty); }
            set { SetValue(OtherMonthDayBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OtherMonthDayBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OtherMonthDayBrushProperty =
            DependencyProperty.Register("OtherMonthDayBrush", typeof(Brush), typeof(Calendar), new PropertyMetadata(new SolidColorBrush(Colors.Gray)));

        public Style DayStyle
        {
            get { return (Style)GetValue(DayStyleProperty); }
            set { SetValue(DayStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DayStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DayStyleProperty =
            DependencyProperty.Register("DayStyle", typeof(Style), typeof(Calendar), new PropertyMetadata(null));

        public Style SelectedAeroStyle
        {
            get { return (Style)GetValue(SelectedAeroStyleProperty); }
            set { SetValue(SelectedAeroStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedAeroStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedAeroStyleProperty =
            DependencyProperty.Register("SelectedAeroStyle", typeof(Style), typeof(Calendar), new PropertyMetadata(null));

        public Style SelectedDayStyle
        {
            get { return (Style)GetValue(SelectedDayStyleProperty); }
            set { SetValue(SelectedDayStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedDayStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedDayStyleProperty =
            DependencyProperty.Register("SelectedDayStyle", typeof(Style), typeof(Calendar), new PropertyMetadata(null));
        #endregion

        public double CalendarWidth
        {
            get { return (double)GetValue(CalendarWidthProperty); }
            set { SetValue(CalendarWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CalendarWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CalendarWidthProperty =
            DependencyProperty.Register("CalendarWidth", typeof(double), typeof(Calendar), new PropertyMetadata(0));


        public double CalendarHeight
        {
            get { return (double)GetValue(CalendarHeightProperty); }
            set { SetValue(CalendarHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CalendarHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CalendarHeightProperty =
            DependencyProperty.Register("CalendarHeight", typeof(double), typeof(Calendar), new PropertyMetadata(0));

        #region data source
        private ObservableCollection<Day> days;
        public ObservableCollection<Day> Days
        {
            get { return days; }
            set { days = value; }
        }

        private ObservableCollection<Month> months;
        public ObservableCollection<Month> Months
        {
            get { return months; }
            set { months = value; }
        }

        private ObservableCollection<Year> years;
        public ObservableCollection<Year> Years
        {
            get { return years; }
            set { years = value; }
        }
        #endregion

        private DateTime _currentDateTime;
        public DateTime CurrentDateTime
        {
            get { return _currentDateTime; }
            set
            {
                _currentDateTime = value;
                if (_currentDateTime != null)
                    CreateDay(_currentDateTime);
                else
                    CreateDay(DateTime.Now);
            }
        }

        private DateTime _selectedDateTime;
        public DateTime SelectedDateTime
        {
            get { return _selectedDateTime; }
            set { _selectedDateTime = value; }
        }

        private int _monthTitle = 1;
        public int MonthTitle
        {
            get { return _monthTitle; }
            set
            {
                _monthTitle = value;
                this.OnPropertyChanged();
            }
        }

        private int _yearTitle = 2013;
        public int YearTitle
        {
            get { return _yearTitle; }
            set
            {
                _yearTitle = value;
                this.OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event DateTimeSelectedEventhandler DateTimeSelected;
        private void OnDateTimeSelected(DateTime datetime)
        {
            DateTimeSelectedEventhandler handler = DateTimeSelected;
            if (handler != null)
                handler(datetime);
        }

        public double HeaderWidth
        {
            get { return (double)GetValue(HeaderWidthProperty); }
            set { SetValue(HeaderWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderWidthProperty =
            DependencyProperty.Register("HeaderWidth", typeof(double), typeof(Calendar), new PropertyMetadata(400));


        public Calendar()
        {
            this.InitializeComponent();

            Days = new ObservableCollection<Day>();
            Months = new ObservableCollection<Month>();
            Years = new ObservableCollection<Year>();

            this.Loaded += Calendar_Loaded;
        }

        void Calendar_Loaded(object sender, RoutedEventArgs e)
        {
            TodayOfDate = DateTime.Now;

            CreateDay(DateTime.Now);
            CreateMonth(DateTime.Now);

            SelectedDateTime = DateTime.Now;

            gridviewDays.ItemsSource = days;
            gridviewMonths.ItemsSource = Months;
        }

        public void UpdateSelectedDays(DateTime datetime)
        {
            CreateDay(datetime);
        }

        private ObservableCollection<Day> CreateDay(DateTime date)
        {
            days.Clear();

            //MonthTitle = date.Month;
            //YearTitle = date.Year;

            DayOfWeek week = date.DayOfWeek;
            DateTime tempDateTime = new DateTime(date.Year, date.Month, 1);

            bool isinselected = false;
            if (ShowOtherMonth)
            {
                while (tempDateTime.DayOfWeek != DayOfWeek.Sunday)
                {
                    tempDateTime = tempDateTime.AddDays(-1);
                    GeneralSelectedAero(out isinselected, tempDateTime);
                    Days.Insert(0, new Day() { SelectedDate = tempDateTime, CurrentDate = date, DefaultDate = date, DayForeground = GetDayForeBrush(tempDateTime, isOtherMonth: true), IsOtherMonth = true, DayStyle = DayStyle, IsInSelectedAero = isinselected });
                }
            }

            tempDateTime = new DateTime(date.Year, date.Month, 1);
            DateTime tempNextDateTime = DateTime.Now;
            if (date.Month != 12)
                tempNextDateTime = new DateTime(date.Year, date.Month + 1, 1);
            else
                tempNextDateTime = new DateTime(date.Year + 1, 1, 1);


            GeneralSelectedAero(out isinselected, tempDateTime);
            if (tempDateTime.Year == DateTime.Now.Year && tempDateTime.Month == DateTime.Now.Month)
                Days.Add(new Day() { CurrentDate = date, DefaultDate = date, SelectedDate = tempDateTime, DayForeground = GetDayForeBrush(tempDateTime), IsOtherMonth = false, DayStyle = DayStyle, IsInSelectedAero = isinselected });
            else
                Days.Add(new Day() { CurrentDate = date, DefaultDate = date, SelectedDate = tempDateTime, DayForeground = GetDayForeBrush(tempDateTime), IsOtherMonth = false, DayStyle = GetDayForeBrush(), IsInSelectedAero = isinselected });
            tempDateTime = tempDateTime.AddDays(1);

            while (tempDateTime < tempNextDateTime)
            {
                GeneralSelectedAero(out isinselected, tempDateTime);
                Days.Add(new Day() { CurrentDate = date, DefaultDate = date, SelectedDate = tempDateTime, DayForeground = GetDayForeBrush(tempDateTime), IsOtherMonth = false, DayStyle = DayStyle, IsInSelectedAero = isinselected });
                tempDateTime = tempDateTime.AddDays(1);
            }

            if (ShowOtherMonth)
            {
                if (date.Month != 12)
                    tempNextDateTime = new DateTime(date.Year, date.Month + 1, 1);
                else
                    tempNextDateTime = new DateTime(date.Year + 1, 1, 1);

                while (tempNextDateTime.DayOfWeek != DayOfWeek.Saturday)
                {
                    GeneralSelectedAero(out isinselected, tempNextDateTime);
                    Days.Add(new Day() { SelectedDate = tempNextDateTime, CurrentDate = date, DefaultDate = date, DayForeground = GetDayForeBrush(tempNextDateTime, isOtherMonth: true), IsInSelectedAero = isinselected, IsOtherMonth = true, DayStyle = DayStyle });
                    tempNextDateTime = tempNextDateTime.AddDays(1);
                }

                GeneralSelectedAero(out isinselected, tempNextDateTime);
                Days.Add(new Day() { SelectedDate = tempNextDateTime, CurrentDate = date, DefaultDate = date, DayForeground = GetDayForeBrush(tempNextDateTime, true), IsOtherMonth = true, DayStyle = DayStyle, IsInSelectedAero = isinselected });
            }
            SelectedFirstDayOfCurrentMonth();
            LayoutRoot.DataContext = this;

            return days;
        }

        private ObservableCollection<Month> CreateMonth(DateTime date)
        {
            months.Clear();

            int monthIndex = 1;
            while (monthIndex < 13)
            {
                Months.Add(new Month() { SelectedDate = new DateTime(date.Year, monthIndex, date.AddMonths(monthIndex - 1).Day), DefaultDate = date, CurrentDate = date, Days = days == null ? CreateDay(date) : days });

                monthIndex++;
            }
            return months;
        }

        private ObservableCollection<Day> GoToNextMonth(DateTime date)
        {
            return CreateDay(date.AddMonths(1));
        }

        private ObservableCollection<Day> GotoPreviousMonth(DateTime date)
        {
            return CreateDay(date.AddMonths(-1));
        }

        private void OnMonthChanged_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null && btn.Tag != null)
            {
                DateTime dateTime = DateTime.Now;
                try
                {
                    dateTime = Convert.ToDateTime(btn.Tag);
                    SelectedDateTime = new DateTime(YearTitle, dateTime.Month, dateTime.Day);
                }
                catch (Exception)
                {
                    SelectedDateTime = DateTime.Now;
                }
                finally
                {
                    UpdateDays(SelectedDateTime);
                    semanticzoomDate.ToggleActiveView();
                }
            }

            if (SelectedMonthStyle != null)
                btn.Style = SelectedMonthStyle;
        }

        private void UpdateDays(DateTime date)
        {
            CreateDay(date);
        }

        private void UpdateMonths(DateTime date)
        {
            CreateMonth(date);
        }

        private Brush GetDayForeBrush(DateTime date, bool isOtherMonth = false)
        {
            if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                return FirstAndLastDayColumnForground;
            else
                if (isOtherMonth)
                    return OtherMonthDayBrush;
                else
                    return DayForground;
        }
        private Style GetDayForeBrush()
        {
            if (DaySelectedStyle != null)
                return DaySelectedStyle;
            else
                return Application.Current.Resources["SelectedButtonStyle"] as Style;
        }

        Button lastTempButton = null;
        private void OnDataSelected_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Update(btn);
            if (btn != null && btn.Tag != null)
            {
                DateTime datetime = DateTime.Now;
                try
                {
                    datetime = Convert.ToDateTime(btn.Tag);

                    Day day = btn.DataContext as Day;
                    if (day.IsOtherMonth)
                    {
                        SelectedDateTime = datetime;
                        UpdateDays(datetime);
                    }
                }
                catch (Exception)
                {
                    datetime = DateTime.Now;
                }
                finally
                {
                    OnDateTimeSelected(datetime);
                    SelectedDateTime = datetime;
                }
            }
            if (DaySelectedStyle != null)
                btn.Style = DaySelectedStyle;
            else
                btn.Style = Application.Current.Resources["SelectedButtonStyle"] as Style;
        }

        private void Update(Button btn)
        {
            if (lastTempButton != null)
            {
                Day day = lastTempButton.DataContext as Day;
                if (day != null)
                {
                    if (lastTempButton != null && !day.IsInSelectedAero)
                        lastTempButton.Style = Resources["BtnNormalStyle"] as Style;//Application.Current.Resources["BtnNormalStyle"] as Style;
                    else if (lastTempButton != null && day.IsInSelectedAero)
                        lastTempButton.Style = Application.Current.Resources["SelectedAeroStyle"] as Style;
                }
            }
            lastTempButton = btn;
        }

        private void OnMonthTitle_Click(object sender, RoutedEventArgs e)
        {
            semanticzoomDate.ToggleActiveView();
        }

        private void GoToPreviousDateTime_Click(object sender, RoutedEventArgs e)
        {
            if (semanticzoomDate.IsZoomedInViewActive)
            {
                if (MonthTitle == 1)
                    MonthTitle = 13;
                MonthTitle--;

                DateTime datetime = DateTime.Now;
                if (MonthTitle == 12)
                {
                    datetime = new DateTime(SelectedDateTime.Year - 1, 12, datetime.Day);
                    YearTitle--;
                }
                else
                {
                    if (SelectedDateTime.Month == 1)
                        SelectedDateTime = new DateTime(SelectedDateTime.Year, 12, SelectedDateTime.Day, SelectedDateTime.Hour, SelectedDateTime.Minute, SelectedDateTime.Second);
                    //datetime = new DateTime(SelectedDateTime.Year, MonthTitle, SelectedDateTime.AddMonths(MonthTitle).Day);
                    int count = SelectedDateTime.Month - MonthTitle;
                    datetime = new DateTime(SelectedDateTime.Year, MonthTitle, SelectedDateTime.AddMonths(-count).Day);
                }
                UpdateDays(datetime);
            }
            else
            {
                YearTitle--;

                CurrentDateTime = new DateTime(SelectedDateTime.Year - 1, MonthTitle, SelectedDateTime.AddMonths(MonthTitle).Day);
            }

            //SelectedFirstDayOfCurrentMonth();
        }

        private void GoToNextDateTime_Click(object sender, RoutedEventArgs e)
        {
            if (semanticzoomDate.IsZoomedInViewActive)
            {
                if (MonthTitle == 12)
                    MonthTitle = 0;
                MonthTitle++;

                DateTime datetime = DateTime.Now;
                if (MonthTitle == 1)
                {
                    datetime = new DateTime(SelectedDateTime.Year + 1, 1, datetime.Day);
                    YearTitle++;
                }
                else
                {
                    if (SelectedDateTime.Month == 12)
                        SelectedDateTime = new DateTime(SelectedDateTime.Year, 1, SelectedDateTime.Day, SelectedDateTime.Hour, SelectedDateTime.Minute, SelectedDateTime.Second);
                    int count = SelectedDateTime.Month - MonthTitle;
                    //datetime = new DateTime(SelectedDateTime.Year, MonthTitle, SelectedDateTime.AddMonths(MonthTitle - 1).Day);
                    datetime = new DateTime(SelectedDateTime.Year, MonthTitle, SelectedDateTime.AddMonths(-count).Day);
                }


                UpdateDays(datetime);
            }
            else
            {
                YearTitle++;

                CurrentDateTime = new DateTime(SelectedDateTime.Year + 1, MonthTitle, SelectedDateTime.AddMonths(MonthTitle).Day);
            }
            //SelectedFirstDayOfCurrentMonth();
        }

        bool isDefaultStyle = true;
        private void GeneralSelectedAero(out bool isinselectedaero, DateTime datetime = default(DateTime))
        {
            if (DayStyle != null && !isDefaultStyle)
            {
                isDefaultStyle = false;
                isinselectedaero = false;
            }
            else
            {
                if (datetime.Year == DateTime.Now.Year && datetime.Month == DateTime.Now.Month && datetime.Day == DateTime.Now.Day)
                {
                    if (SelectedDayStyle == null)
                        DayStyle = Resources["SelectedButtonStyle"] as Style;//Application.Current.Resources["SelectedButtonStyle"] as Style;
                    else
                        DayStyle = SelectedDayStyle;
                    isinselectedaero = true;
                }
                else if (SelectedDateTime == datetime)
                {
                    if (SelectedDayStyle == null)
                        DayStyle = Resources["SelectedButtonStyle"] as Style;//Application.Current.Resources["SelectedButtonStyle"] as Style;
                    else
                        DayStyle = SelectedDayStyle;
                    isinselectedaero = false;
                }
                else
                {
                    DayStyle = Resources["BtnNormalStyle"] as Style;//Application.Current.Resources["BtnNormalStyle"] as Style;
                    isinselectedaero = false;
                }

                if (StartDate != DateTime.MaxValue && EndDate != DateTime.MinValue && datetime >= StartDate && datetime <= EndDate)
                {
                    if (SelectedAeroStyle == null)
                        DayStyle = Application.Current.Resources["SelectedAeroStyle"] as Style;
                    else
                        DayStyle = SelectedAeroStyle;
                    isinselectedaero = true;
                }
            }
        }

        private void SelectedFirstDayOfCurrentMonth()
        {
            //for (int i = 0; i < Days.Count; i++)
            //{
            //    if (!Days[i].IsOtherMonth)
            //    {
            //        if (DaySelectedStyle != null)
            //            Days[i].DayStyle = DaySelectedStyle;
            //        else
            //        {
            //            Days[i].DayStyle = null;
            //            Days[i].DayStyle = Application.Current.Resources["SelectedButtonStyle"] as Style;
            //        }
            //        return;
            //    }
            //}
        }

        private void MonthHeader_Taped(object sender, TappedRoutedEventArgs e)
        {
            semanticzoomDate.ToggleActiveView();
        }
    }
}
