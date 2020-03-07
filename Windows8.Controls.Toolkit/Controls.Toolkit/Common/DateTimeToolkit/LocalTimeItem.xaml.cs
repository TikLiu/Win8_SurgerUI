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
    public sealed partial class LocalTimeItem : UserControl
    {
        private int firstValue=7;
        private int lastValue = 9;
        private List<string> lstSource;

        public LocalTimeItem()
        {
            this.InitializeComponent();

            lstSource = new List<string>() { "7", "8", "9" };
            this.scrollviewer.ViewChanged += scrollviewer_ViewChanged;

            InitializeTempData();
        }

        private void InitializeTempData()
        {
            for (int i = 0; i < lstSource.Count; i++)
            {
                AddObj(lstSource[i]);
            }
        }

        double lastVari;
        void scrollviewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            ScrollViewer sv = sender as ScrollViewer;
            if (sv != null)
            {
                double temp = sv.VerticalOffset - lastVari;
                if (temp > 3 || temp < -3)
                {
                    ScrollContent(temp);
                    lastVari = sv.VerticalOffset;
                }
            }

            Scroll();
        }

        public int MaxValue
        {
            get { return (int)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(int), typeof(LocalTimeItem), new PropertyMetadata(23));

        public Style ContentStyle
        {
            get { return (Style)GetValue(ContentStyleProperty); }
            set { SetValue(ContentStyleProperty, value); }
        }

        
        public static readonly DependencyProperty ContentStyleProperty =
            DependencyProperty.Register("ContentStyle", typeof(Style), typeof(LocalTimeItem), new PropertyMetadata(null));


        private void ScrollContent(double offset)
        {
            if (offset > 0)
            {
                int temp = ++lastValue;
                if (temp > MaxValue)
                {
                    temp = 1;
                    lastValue = 1;
                }
                stackpanels.Children.RemoveAt(0);
                AddObj(temp.ToString());
            }
            else if (offset < 0)
            {
                int temp = --firstValue;
                if (temp < 1)
                {
                    temp = MaxValue;
                    firstValue = MaxValue;
                }
                InsertObj(temp.ToString());
                stackpanels.Children.RemoveAt(stackpanels.Children.Count - 1);
            }
            else
                return;

            firstValue = Convert.ToInt32((stackpanels.Children[1] as Button).Content);
        }

        private void AddObj(string content)
        {
            stackpanels.Children.Add(DateTimeHelper.GetButton(content, ContentStyle, null));
        }

        private void InsertObj(string content)
        {
            stackpanels.Children.Add(DateTimeHelper.GetButton(content, ContentStyle, null));
        }

        private void Scroll()
        {
            scrollviewer.ScrollToVerticalOffset(scrollviewer.ScrollableHeight / 3+10);
        }
    }
}
