using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;



namespace Controls.Toolkit.Common.DateTimeToolkit
{
    public sealed partial class TimeItem : UserControl
    {
        private double FirstValue = 0;
        private double LastValue = 0;

        public TimeItem()
        {
            this.InitializeComponent();

            this.ItemsSource = new List<string>() { "01", "02", "03", "04", "05", "06", "07", "08", "09" };

            this.LayoutRoot.DataContext = this;

            this.scrollviewer.ViewChanged += scrollviewer_ViewChanged;
        }
    

        double tempLastValue;
        void scrollviewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            ScrollViewer sv = sender as ScrollViewer;
            if (sv != null)
            {
                double temp = sv.VerticalOffset - tempLastValue;
                if (temp > 19 || temp < -19)
                {
                    Button firstButton = stackpanelTicks.Children[0] as Button;
                    if (firstButton != null)
                        FirstValue = Convert.ToDouble(firstButton.Content.ToString());
                    Button lastButton = stackpanelTicks.Children[stackpanelTicks.Children.Count - 1] as Button;
                    if (lastButton != null)
                        LastValue = Convert.ToDouble(lastButton.Content.ToString());

                    int removeCount = (int)temp % 38 > 19 ? (int)temp / 38 + 1 : (int)temp / 38;
                    ScrollContent(temp, removeCount);
                }
                tempLastValue = sv.VerticalOffset;

                if (sv.VerticalOffset == 0)
                    ScrollToMiddlePlace();
            }

        }

        #region dependency properties
        public object TimeContent
        {
            get { return (object)GetValue(TimeContentProperty); }
            set { SetValue(TimeContentProperty, value); }
        }

        public static readonly DependencyProperty TimeContentProperty =
            DependencyProperty.Register("TimeContent", typeof(object), typeof(TimeItem), new PropertyMetadata("10"));

        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(double), typeof(TimeItem), new PropertyMetadata(23.0));


        public double TimeItemVerticalOffset
        {
            get { return (double)GetValue(TimeItemVerticalOffsetProperty); }
            set { SetValue(TimeItemVerticalOffsetProperty, value); }
        }

        public static readonly DependencyProperty TimeItemVerticalOffsetProperty =
            DependencyProperty.Register("TimeItemVerticalOffset", typeof(double), typeof(TimeItem), new PropertyMetadata(0, (sender, args) =>
            {
                TimeItem item = sender as TimeItem;
                if (item != null)
                    item.scrollviewer.ScrollToVerticalOffset((double)args.NewValue);
            }));


        public Visibility ShowBaseButton
        {
            get { return (Visibility)GetValue(ShowBaseButtonProperty); }
            set { SetValue(ShowBaseButtonProperty, value); }
        }

        public static readonly DependencyProperty ShowBaseButtonProperty =
            DependencyProperty.Register("ShowBaseButton", typeof(Visibility), typeof(TimeItem), new PropertyMetadata(Visibility.Visible, (sender, args) =>
            {
                TimeItem item = sender as TimeItem;
                if (item != null)
                    item.ShowButton((Visibility)args.NewValue);
            }));

        public List<string> ItemsSource
        {
            get
            {
                return (List<string>)GetValue(ItemsSourceProperty);
            }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(List<string>), typeof(TimeItem), new PropertyMetadata(null, (sender, args) =>
            {
                TimeItem timeItem = sender as TimeItem;

                List<string> lst = (List<string>)args.NewValue;
                if (timeItem != null && lst != null)
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        timeItem.stackpanelTicks.Children.Add(timeItem.GeneralButton(lst[i]));
                    }
                }
            }));


        public TimeType TimeType
        {
            get { return (TimeType)GetValue(TimeTypeProperty); }
            set { SetValue(TimeTypeProperty, value); }
        }

        public static readonly DependencyProperty TimeTypeProperty =
            DependencyProperty.Register("TimeType", typeof(TimeType), typeof(TimeItem), new PropertyMetadata(TimeType.HOUR));


        public Style TimeStyle
        {
            get { return (Style)GetValue(TimeStyleProperty); }
            set { SetValue(TimeStyleProperty, value); }
        }

        public static readonly DependencyProperty TimeStyleProperty =
            DependencyProperty.Register("TimeStyle", typeof(Style), typeof(TimeItem), new PropertyMetadata(null));


        public int CurrentTime
        {
            get { return (int)GetValue(CurrentTimeProperty); }
            set { SetValue(CurrentTimeProperty, value); }
        }

        public static readonly DependencyProperty CurrentTimeProperty =
            DependencyProperty.Register("CurrentTime", typeof(int), typeof(TimeItem), new PropertyMetadata(int.MinValue));

        #endregion

        public event Action TimeChanged;

        private void OnTimeChanged()
        {
            Action handler = TimeChanged;
            if (handler != null)
                handler();
        }

        private void ScrollContent(double offset, int removeCount)
        {
            if (offset < 0)
                for (int i = 1; i <= removeCount; i++)
                {
                    double temp = --FirstValue;
                    if (temp < 1)
                    {
                        FirstValue = MaxValue;
                        temp = MaxValue;
                    }
                    InsertContent(temp.ToString(), null);
                    this.stackpanelTicks.Children.RemoveAt(this.stackpanelTicks.Children.Count - 1);
                }
            else if (offset > 0)
            {
                for (int i = 1; i <= removeCount; i++)
                {
                    this.stackpanelTicks.Children.RemoveAt(0);

                    double temp = ++LastValue;
                    if (temp > MaxValue)
                    {
                        LastValue = 1;
                        temp = 1;
                    }
                    
                    AddContent(temp.ToString(), null);
                }
            }

            ScrollToMiddlePlace();
        }

        private void AddContent(string content, Style style)
        {
            if (!string.IsNullOrEmpty(content))
                stackpanelTicks.Children.Add(GeneralButton(content));
        }

        private void InsertContent(string content, Style style)
        {
            if (!string.IsNullOrEmpty(content))
                stackpanelTicks.Children.Insert(0, GeneralButton(content));
        }

        private void ShowTimeTicks_Click(object sender, RoutedEventArgs e)
        {
            btnShowTimeTicks.Visibility = Visibility.Collapsed;
            this.scrollviewer.Visibility = Visibility.Visible;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, object e)
        {
            DispatcherTimer timer = sender as DispatcherTimer;
            timer.Tick -= timer_Tick;
            ScrollToMiddlePlace();
        }

        private void ScrollToMiddlePlace()
        {
            this.scrollviewer.ScrollToVerticalOffset(this.scrollviewer.ScrollableHeight / 3);
        }

        public Button GeneralButton(string content)
        {
            Button btn = DateTimeHelper.GetButton(content.PadLeft(2, '0'), TimeStyle, btn_Click, TimeType);
            return btn;
        }

        void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Click -= btn_Click;
                btnShowTimeTicks.Visibility = Visibility.Visible;
                UpdateDateTime(btn.Content);
                this.scrollviewer.Visibility = Visibility.Collapsed;

                OnTimeChanged();
            }

            ScrollToMiddlePlace();
        }

        private void UpdateDateTime(object content)
        {
            btnShowTimeTicks.Content = content;
            TimeContent = btnShowTimeTicks.Content;
        }

        public void ShowButton(Visibility show)
        {
            btnShowTimeTicks.Visibility = show;
            scrollviewer.Visibility = show != Visibility.Visible ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
