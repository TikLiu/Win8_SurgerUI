using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace Controls.Layout.Toolkit
{
    [TemplatePart(Name = HoriontalTemplate, Type = typeof(Grid))]
    [TemplatePart(Name = VerticalTemplate, Type = typeof(Grid))]
    [TemplatePart(Name = thumbVerticalFrom, Type = typeof(Thumb))]
    [TemplatePart(Name = thumbVerticalTo, Type = typeof(Thumb))]
    [TemplatePart(Name = thumbHoriontalTo, Type = typeof(Thumb))]
    [TemplatePart(Name = thumbHoriontalFrom, Type = typeof(Thumb))]
    [TemplatePart(Name = popLeftHoriontal, Type = typeof(Grid))]
    [TemplatePart(Name = popRightHoriontal, Type = typeof(Grid))]
    [TemplatePart(Name = popRightVertical, Type = typeof(Grid))]
    [TemplatePart(Name = popLeftVertical, Type = typeof(Grid))]
    [TemplatePart(Name = gridRightHoriontal, Type = typeof(Grid))]
    [TemplatePart(Name = gridLeftVertical, Type = typeof(Grid))]
    [TemplatePart(Name = gridRightVertical, Type = typeof(Grid))]
    [TemplatePart(Name = gridLeftHoriontal, Type = typeof(Grid))]
    [TemplatePart(Name = rectMiddleHoriontal, Type = typeof(Rectangle))]
    [TemplatePart(Name = rectMiddleVertical, Type = typeof(Rectangle))]

    public sealed class RangeSlider : RangeBase
    {
        #region
        private const string HoriontalTemplate = "HoriontalTemplate";
        private const string VerticalTemplate = "VerticalTemplate";
        private const string thumbVerticalFrom = "thumbVerticalFrom";
        private const string thumbVerticalTo = "thumbVerticalTo";
        private const string thumbHoriontalFrom = "thumbHoriontalFrom";
        private const string thumbHoriontalTo = "thumbHoriontalTo";
        private const string popLeftHoriontal = "popLeftHoriontal";
        private const string rectMiddleHoriontal = "rectMiddleHoriontal";
        private const string popRightHoriontal = "popRightHoriontal";
        private const string popLeftVertical = "popLeftVertical";
        private const string rectMiddleVertical = "rectMiddleVertical";
        private const string popRightVertical = "popRightVertical";
        private const string gridRightHoriontal = "gridRightHoriontal";
        private const string gridLeftHoriontal = "gridLeftHoriontal";
        private const string gridLeftVertical = "gridLeftVertical";
        private const string gridRightVertical = "gridRightVertical";
        private Thumb thumbFrom;
        private Thumb thumbTo;
        private Point FoucsPoint;
        private double perValue;
        private double totalValue;
        private double fromLength, toLength, totalLength;
        #endregion

        #region FromThumbVisbilty
        public Visibility FromThumbVisbilty
        {
            get { return (Visibility)GetValue(FromThumbVisbiltyProperty); }
            set { SetValue(FromThumbVisbiltyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FromThumbVisbilty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FromThumbVisbiltyProperty =
            DependencyProperty.Register("FromThumbVisbilty", typeof(Visibility), typeof(RangeSlider), new PropertyMetadata(Visibility.Visible));
        #endregion

        #region FromValue
        public double FromValue
        {
            get { return (double)GetValue(FromValueProperty); }
            set { SetValue(FromValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FromValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FromValueProperty =
            DependencyProperty.Register("FromValue", typeof(double), typeof(RangeSlider), new PropertyMetadata(0.0));

        #endregion

        #region ToValue
        public double ToValue
        {
            get { return (double)GetValue(ToValueProperty); }
            set { SetValue(ToValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ToValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToValueProperty =
            DependencyProperty.Register("ToValue", typeof(double), typeof(RangeSlider), new PropertyMetadata(0.0));
        #endregion

        #region RangeFrom
        public double RangeFrom
        {
            get { return (double)GetValue(RangeFromProperty); }
            set { SetValue(RangeFromProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RangeFrom.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RangeFromProperty =
            DependencyProperty.Register("RangeFrom", typeof(double), typeof(RangeSlider), new PropertyMetadata(0.0));

        #endregion

        #region RangeTo
        public double RangeTo
        {
            get { return (double)GetValue(RangeToProperty); }
            set { SetValue(RangeToProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MiddleWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RangeToProperty =
            DependencyProperty.Register("RangeTo", typeof(double), typeof(RangeSlider), new PropertyMetadata(0.0));

        #endregion

        #region Orientation
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Orientation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation), typeof(RangeSlider), new PropertyMetadata(Orientation.Horizontal));

        #endregion

        #region Minmum
        public string Minmum
        {
            get { return (string)GetValue(MinmumProperty); }
            set { SetValue(MinmumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Maxmum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinmumProperty =
            DependencyProperty.Register("Minmum", typeof(string), typeof(RangeSlider), new PropertyMetadata(""));

        #endregion

        #region Maxmum
        public string Maxmum
        {
            get { return (string)GetValue(MaxmumProperty); }
            set { SetValue(MaxmumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Maxmum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxmumProperty =
            DependencyProperty.Register("Maxmum", typeof(string), typeof(RangeSlider), new PropertyMetadata(""));

        #endregion


        #region MinValue
        public string MinValue
        {
            get { return (string)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(string), typeof(RangeSlider), new PropertyMetadata(""));
        #endregion

        #region MaxValue
        public string MaxValue
        {
            get { return (string)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(string), typeof(RangeSlider), new PropertyMetadata(""));
        #endregion


        public RangeSlider()
        {
            this.DefaultStyleKey = typeof(RangeSlider);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Border border = this.GetTemplateChild("Background") as Border;
            (this.GetTemplateChild(HoriontalTemplate) as Grid).Visibility = this.Orientation == Orientation.Vertical ? Visibility.Collapsed : Visibility.Visible;
            (this.GetTemplateChild(VerticalTemplate) as Grid).Visibility = this.Orientation == Orientation.Vertical ? Visibility.Visible : Visibility.Collapsed;
            thumbFrom = this.Orientation == Orientation.Vertical ? this.GetTemplateChild(thumbVerticalFrom) as Thumb : this.GetTemplateChild(thumbHoriontalFrom) as Thumb;
            thumbTo = this.Orientation == Orientation.Vertical ? this.GetTemplateChild(thumbVerticalTo) as Thumb : this.GetTemplateChild(thumbHoriontalTo) as Thumb;
            fromLength = this.Orientation == Orientation.Vertical ? this.thumbFrom.Height : this.thumbFrom.Width;
            toLength = this.Orientation == Orientation.Vertical ? this.thumbTo.Height : this.thumbTo.Width;
            totalLength = this.Orientation == Orientation.Vertical ? this.Height : this.Width;
            totalValue = FromThumbVisbilty == Visibility.Visible ? totalLength - fromLength - toLength - toLength / 2 : totalLength  - toLength;
         
            if ((this.Maximum - this.Minimum) >= 0)
            {
                Minmum = this.Minimum.ToString();
                Maxmum = this.Maximum.ToString();
                perValue = totalValue / (this.Maximum - this.Minimum);
                if (FromThumbVisbilty == Visibility.Collapsed)
                {
                    RangeFrom = 0;
                    RangeTo = perValue * (this.Maximum - this.Value)+ toLength;
                    ToValue = this.Value;
                }
                else
                {
                    RangeFrom = perValue * (FromValue-this.Minimum) + fromLength;
                    RangeTo = perValue * (this.Maximum - ToValue) + toLength;
                }

            }

            MinValue = FromValue.ToString();
            MaxValue = ToValue.ToString();
            thumbFrom.ManipulationStarted += fromThumb_ManipulationStarted;
            thumbFrom.ManipulationDelta += fromThumb_ManipulationDelta;
            thumbTo.ManipulationStarted += thumbTo_ManipulationStarted;
            thumbTo.ManipulationDelta += thumbTo_ManipulationDelta;
            thumbTo.PointerCaptureLost += thumbTo_PointerCaptureLost;
            thumbFrom.PointerCaptureLost += thumbTo_PointerCaptureLost;

            Grid rectLeftHoriontal = this.GetTemplateChild(gridLeftHoriontal) as Grid;
            Rectangle MiddleHoriontal = this.GetTemplateChild(rectMiddleHoriontal) as Rectangle;
            Grid rectRightHoriontal = this.GetTemplateChild(gridRightHoriontal) as Grid;
            Grid rectLeftVertical = this.GetTemplateChild(gridLeftVertical) as Grid;
            Rectangle MiddleVertical = this.GetTemplateChild(rectMiddleVertical) as Rectangle;
            Grid rectRightVertical = this.GetTemplateChild(gridRightVertical) as Grid;

            rectLeftHoriontal.Tapped += rect_Tapped;
            MiddleHoriontal.Tapped += rect_Tapped;
            rectRightHoriontal.Tapped += rect_Tapped;
            rectLeftVertical.Tapped += rect_Tapped;
            MiddleVertical.Tapped += rect_Tapped;
            rectRightVertical.Tapped += rect_Tapped;

        }

        void thumbTo_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
        {
            (GetTemplateChild(popRightHoriontal) as Grid).Visibility = Visibility.Collapsed;
            (GetTemplateChild(popLeftHoriontal) as Grid).Visibility = Visibility.Collapsed;
            (GetTemplateChild(popRightVertical) as Grid).Visibility = Visibility.Collapsed;
            (GetTemplateChild(popLeftVertical) as Grid).Visibility = Visibility.Collapsed;
        }


        void rect_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Grid grid = this.Orientation == Orientation.Horizontal ? this.GetTemplateChild(HoriontalTemplate) as Grid : this.GetTemplateChild(VerticalTemplate) as Grid;
            Point currentPoint = e.GetPosition(grid);
            double currentLength = this.Orientation == Orientation.Horizontal ? currentPoint.X : currentPoint.Y;
            if (currentLength > (totalLength - RangeTo) || FromThumbVisbilty == Visibility.Collapsed)
            {
                RangeTo = totalLength - currentLength  <= toLength ? toLength : totalLength - currentLength ;
                this.Value = this.ToValue = this.Maximum - Convert.ToInt32((RangeTo - toLength) / perValue) == this.FromValue ? this.FromValue + 1 : this.Maximum - Convert.ToInt32((RangeTo - toLength) / perValue); 
                MaxValue = ToValue.ToString();
                ShowRightPop();
            }
            else
            {
                RangeFrom = currentLength <= fromLength ? fromLength : currentLength;
                this.Value = this.FromValue = Convert.ToInt32((RangeFrom - fromLength) / perValue) == this.ToValue ? this.ToValue - 1 : Convert.ToInt32((RangeFrom - fromLength) / perValue); 
                MinValue = FromValue.ToString();
                ShowLeftPop();
            }

        }


        void thumbTo_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            double limitLength = FromThumbVisbilty == Visibility.Visible ? toLength / 2 : 0;;
            if (this.Orientation == Orientation.Vertical)
            {              
                if ((RangeTo - (e.Position.Y - FoucsPoint.Y)) >= thumbTo.Height && (RangeTo - (e.Position.Y - FoucsPoint.Y)) <= this.Height - RangeFrom - limitLength)
                {
                    RangeTo = RangeTo - (e.Position.Y - FoucsPoint.Y);
                }           
              
            }
            else
            {
                if ((RangeTo - (e.Position.X - FoucsPoint.X)) >= thumbTo.Width && (RangeTo - (e.Position.X - FoucsPoint.X)) <= this.Width - RangeFrom - limitLength)
                {
                    RangeTo = RangeTo - (e.Position.X - FoucsPoint.X);
                }
            }
            this.Value = this.ToValue = this.Maximum - Convert.ToInt32((RangeTo - toLength) / perValue) == this.FromValue ? this.FromValue + 1 : this.Maximum - Convert.ToInt32((RangeTo - toLength) / perValue); 
            MaxValue = this.ToValue.ToString();

        }

        void thumbTo_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            FoucsPoint = e.Position;
            ShowRightPop();
        }

        void fromThumb_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (this.Orientation == Orientation.Horizontal)
            {
                if (RangeFrom + (e.Position.X - FoucsPoint.X) >= thumbFrom.Width && RangeFrom + (e.Position.X - FoucsPoint.X) <= this.Width - RangeTo - thumbFrom.Width / 2)
                {
                    RangeFrom = RangeFrom + (e.Position.X - FoucsPoint.X);
                }             
            }
            else
            {
                if (RangeFrom + (e.Position.Y - FoucsPoint.Y) >=thumbFrom.Height && RangeFrom + (e.Position.Y - FoucsPoint.Y) <= this.Height - RangeTo - thumbFrom.Height / 2)
                {
                    RangeFrom = RangeFrom + (e.Position.Y - FoucsPoint.Y);
                }
             
            }
            this.Value = this.FromValue = Convert.ToInt32((RangeFrom - fromLength) / perValue) + this.Minimum == this.ToValue ? this.ToValue - 1 : Convert.ToInt32((RangeFrom - fromLength) / perValue) + this.Minimum; 
            MinValue = FromValue.ToString();
        }

        void fromThumb_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            FoucsPoint = e.Position;
            ShowLeftPop();
        }

        private void ShowLeftPop()
        {
            (GetTemplateChild(popLeftHoriontal) as Grid).Visibility = Visibility.Visible;
            (GetTemplateChild(popRightHoriontal) as Grid).Visibility = Visibility.Collapsed;
            (GetTemplateChild(popLeftVertical) as Grid).Visibility = Visibility.Visible;
            (GetTemplateChild(popRightVertical) as Grid).Visibility = Visibility.Collapsed;
        }
        private void ShowRightPop()
        {
            (GetTemplateChild(popLeftHoriontal) as Grid).Visibility = Visibility.Collapsed;
            (GetTemplateChild(popRightHoriontal) as Grid).Visibility = Visibility.Visible;
            (GetTemplateChild(popLeftVertical) as Grid).Visibility = Visibility.Collapsed;
            (GetTemplateChild(popRightVertical) as Grid).Visibility = Visibility.Visible;
        }
    }
}
