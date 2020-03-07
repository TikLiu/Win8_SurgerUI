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
    public sealed partial class AmOrPm : UserControl
    {
        private List<string> lstSource;

        public AmOrPm()
        {
            this.InitializeComponent();

            lstSource = new List<string>() { "PM", "AM", "PM" };
            InitializeSource();

            this.scrollviewer.ViewChanged += scrollviewer_ViewChanged;
        }

        private double lastScrollValue = 0;
        void scrollviewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            ScrollViewer sv = sender as ScrollViewer;
            if (sv != null)
            {
                double templValue = sv.VerticalOffset - lastScrollValue;
                if (templValue >6||templValue<-6)
                    ScrollContent(templValue);
                lastScrollValue = sv.VerticalOffset;
            }
        }

        private void InitializeSource()
        {
            for (int i = 0; i < lstSource.Count; i++)
            {
                AddObj(lstSource[i]);
            }
        }

        public Style ContentStyle
        {
            get { return (Style)GetValue(ContentStyleProperty); }
            set { SetValue(ContentStyleProperty, value); }
        }

        
        public static readonly DependencyProperty ContentStyleProperty =
            DependencyProperty.Register("ContentStyle", typeof(Style), typeof(AmOrPm), new PropertyMetadata(null));

        private void ScrollContent(double offset)
        {
            if (offset != 0)
            {
                string strValue = string.Empty;
                Button btn = (stackpanelContainer.Children[1] as Button);
                if (btn != null)
                    strValue = btn.Content.ToString();
                switch (strValue)
                {
                    case "PM":
                        ChooseNextOrPrevious(offset, CurrentTimeType.AM);
                        break;
                    case "AM":
                        ChooseNextOrPrevious(offset, CurrentTimeType.PM);
                        break;
                    default:
                        break;
                }
            }
        }

        private void ChooseNextOrPrevious(double offset,CurrentTimeType timetype)
        {
            if (offset > 0)
                MoveItem(0, timetype);
            else
                MoveItem(stackpanelContainer.Children.Count - 1, timetype);
        }

        private void MoveItem(int removeIndex,CurrentTimeType timetype)
        {
            RemoveObj(removeIndex);
            AddObj(timetype.ToString());
            Scroll();
        }

        private void AddObj(string content)
        {
            stackpanelContainer.Children.Add(DateTimeHelper.GetButton(content, ContentStyle, null));
        }

        private void InsertObj(string content)
        {
            stackpanelContainer.Children.Insert(0, DateTimeHelper.GetButton(content, ContentStyle, null));
        }

        private void RemoveObj(int index)
        {
            if (index < stackpanelContainer.Children.Count && index >= 0)
                stackpanelContainer.Children.RemoveAt(index);
        }

        private void Scroll()
        {
            this.scrollviewer.ScrollToVerticalOffset(this.scrollviewer.ScrollableHeight / 3 + 10);
        }
    }

    enum CurrentTimeType
    {
        AM, PM
    }
}
