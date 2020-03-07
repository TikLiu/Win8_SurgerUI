using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Controls.Layout.Toolkit.Masonry
{
    public class HorizontalMasonryPanel : Panel
    {

        IList<Image> ItemsSource;

        public double MaxnumHeight { get; set; }

        public int LargeImageColumns
        {
            get { return (int)GetValue(LargeImageColumnsProperty); }
            set { SetValue(LargeImageColumnsProperty, value); }
        }

        public static readonly DependencyProperty LargeImageColumnsProperty =
            DependencyProperty.Register("LargeImageColumns", typeof(int), typeof(HorizontalMasonryPanel), new PropertyMetadata(1));

        public double ImageSpare
        {
            get { return (double)GetValue(ImageSpareProperty); }
            set { SetValue(ImageSpareProperty, value); }
        }

        public static readonly DependencyProperty ImageSpareProperty =
            DependencyProperty.Register("ImageSpare", typeof(double), typeof(HorizontalMasonryPanel), new PropertyMetadata(0));

        private int largeCount = 0;

        public HorizontalMasonryPanel()
        {
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            List<UIElement> ungroupList = new List<UIElement>();

            foreach (UIElement item in base.Children)
            {
                if (item is StackPanel && (item as StackPanel).Tag.ToString().Contains("masonry"))
                {
                    continue;
                }
                ungroupList.Add(item);
            }

            if (ungroupList.Count == 0)
                return base.ArrangeOverride(finalSize);

            foreach(UIElement item in ungroupList)
            {
                base.Children.Remove(item);
            }
            StackPanel MainSp;
            if (base.Children.Count > 0)
            {
                MainSp = base.Children[0] as StackPanel;
            }
            else
            {
                MainSp = new StackPanel() { Orientation = Orientation.Horizontal, Tag = "masonry" };
                if ( !double.IsNaN(this.MaxnumHeight) && this.MaxnumHeight > 0)
                {
                    MainSp.Height = this.MaxnumHeight;
                }
                MainSp.Width = 10000;
                this.Children.Add(MainSp);
                this.largeCount = 0;

            }
            int index = largeCount;
            for (; index < LargeImageColumns; index++)
            {
                if (ungroupList.Count > 0)
                {
                    
                    var uielement = ungroupList[0];
                    MainSp.Children.Add(uielement);
                    uielement.UpdateLayout();
                    uielement.InvalidateMeasure();
                    uielement.InvalidateArrange();
                    ungroupList.RemoveRange(0,1);
                    largeCount++;
                }
            }
            MainSp.Arrange(new Rect(0, 0, 10000, this.MaxnumHeight));
            MainSp.UpdateLayout();
            MainSp.InvalidateMeasure();
            MainSp.InvalidateArrange();      
            return base.ArrangeOverride(finalSize);
        }

    }
}
