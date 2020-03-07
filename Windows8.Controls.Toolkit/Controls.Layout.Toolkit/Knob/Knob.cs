using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace Controls.Layout.Toolkit
{
    [TemplatePart(Name = grid, Type = typeof(Grid))]
    [TemplatePart(Name = composite, Type = typeof(CompositeTransform))]
    [TemplatePart(Name = textComposite, Type = typeof(CompositeTransform))]
    [TemplatePart(Name = gridComposite, Type = typeof(CompositeTransform))]
    [TemplatePart(Name = rotateGrid, Type = typeof(Grid))]
    [TemplatePart(Name = gridText, Type = typeof(Grid))]
    [TemplatePart(Name = offsetFirst1, Type = typeof(GradientStop))]
    [TemplatePart(Name = offsetFirst2, Type = typeof(GradientStop))]
    [TemplatePart(Name = offsetSecond1, Type = typeof(GradientStop))]
    [TemplatePart(Name = offsetSecond2, Type = typeof(GradientStop))]
    [TemplatePart(Name = offsetThird1, Type = typeof(GradientStop))]
    [TemplatePart(Name = offsetThird2, Type = typeof(GradientStop))]

    public sealed class Knob : RangeBase
    {
        #region
        private const string grid = "grid";
        private const string composite = "composite";
        private const string textComposite = "textComposite";
        private const string gridComposite = "gridComposite";
        private const string rotateGrid = "rotateGrid";
        private const string gridText = "gridText";
        private const string offsetFirst1 = "offsetFirst1";
        private const string offsetFirst2 = "offsetFirst2";
        private const string offsetSecond1 = "offsetSecond1";
        private const string offsetSecond2 = "offsetSecond2";
        private const string offsetThird1 = "offsetThird1";
        private const string offsetThird2 = "offsetThird2";
        Point oldPoint, centerPoint;
        double rotate, controlWidth, marginLeft, rotateHeight, perValue;
        CompositeTransform compositTransform, textCompositTransform, gridCompositeTransform;
        #endregion

        #region Angle
        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Angle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(Knob), new PropertyMetadata(0.0));

        #endregion

        #region TextValue
        public string TextVlaue
        {
            get { return (string)GetValue(TextVlaueProperty); }
            set { SetValue(TextVlaueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextVlaue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextVlaueProperty =
            DependencyProperty.Register("TextVlaue", typeof(string), typeof(Knob), new PropertyMetadata(""));

        #endregion

        #region MaxValue
        public string MaxValue
        {
            get { return (string)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(string), typeof(Knob), new PropertyMetadata(""));
        #endregion


        public Knob()
        {
            this.DefaultStyleKey = typeof(Knob);
        }

        protected override void OnApplyTemplate()
        {

            base.OnApplyTemplate();
            controlWidth = (this.GetTemplateChild(grid) as Grid).Width;
            compositTransform = this.GetTemplateChild(composite) as CompositeTransform;
            textCompositTransform = this.GetTemplateChild(textComposite) as CompositeTransform;
            gridCompositeTransform = this.GetTemplateChild(gridComposite) as CompositeTransform;
            Angle = Angle == 0 ? 270 : Angle;
            if (Maximum - Minimum > 0)
            {
                perValue = Angle / (Maximum - Minimum);
            }
            compositTransform.Rotation = -Value * perValue;
            textCompositTransform.Rotation = -compositTransform.Rotation;
            gridCompositeTransform.Rotation = -compositTransform.Rotation;
            TextVlaue = Value.ToString();
            MaxValue = this.Maximum.ToString();
            SetGradientStopOffset();

            Grid rotate = this.GetTemplateChild(rotateGrid) as Grid;
            marginLeft = rotate.Margin.Left;
            rotateHeight = rotate.Height;
            centerPoint = new Point(-(marginLeft - controlWidth / 2), rotateHeight / 2);
            rotate.ManipulationStarted += rotateGrid_ManipulationStarted;
            rotate.ManipulationDelta += rotateGrid_ManipulationDelta;
            rotate.PointerCaptureLost += rotateGrid_PointerCaptureLost;

        }

        void rotateGrid_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
        {
            Completed = false;
            (this.GetTemplateChild(gridText) as Grid).Visibility = Visibility.Collapsed;
        }

        bool Completed = false;

        void rotateGrid_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (Completed)
            {
                (this.GetTemplateChild(gridText) as Grid).Visibility = Visibility.Visible;
                double a, b, c;
                a = Math.Sqrt((centerPoint.X - oldPoint.X) * (centerPoint.X - oldPoint.X) + (centerPoint.Y - oldPoint.Y) * (centerPoint.Y - oldPoint.Y));
                b = Math.Sqrt((centerPoint.X - e.Position.X) * (centerPoint.X - e.Position.X) + (centerPoint.Y - e.Position.Y) * (centerPoint.Y - e.Position.Y));
                c = Math.Sqrt((oldPoint.X - e.Position.X) * (oldPoint.X - e.Position.X) + (oldPoint.Y - e.Position.Y) * (oldPoint.Y - e.Position.Y));
                rotate = (Math.Acos((a * a + b * b - c * c) / (2 * a * b))) / Math.PI * 180;

                if (oldPoint.X > centerPoint.X)
                {
                    if (oldPoint.Y < e.Position.Y)
                    {
                        compositTransform.Rotation = compositTransform.Rotation - rotate;
                    }
                    else
                    {
                        compositTransform.Rotation = compositTransform.Rotation + rotate;
                    }
                }
                else
                {
                    if (oldPoint.Y > e.Position.Y)
                        compositTransform.Rotation = compositTransform.Rotation + rotate;
                    else
                        compositTransform.Rotation = compositTransform.Rotation - rotate;
                }
                if (compositTransform.Rotation < -Angle)
                    compositTransform.Rotation = -Angle;
                else if (compositTransform.Rotation > 0)
                    compositTransform.Rotation = 0;
                textCompositTransform.Rotation = -compositTransform.Rotation;
                gridCompositeTransform.Rotation = -compositTransform.Rotation;
                TextVlaue = (Convert.ToInt32(-compositTransform.Rotation / perValue)).ToString();
                SetGradientStopOffset();
            }
            else
                e.Complete();

        }

        void rotateGrid_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            oldPoint = e.Position;
            Completed = true;
        }

        private void SetGradientStopOffset()
        {
            try
            {
                if (Convert.ToInt32(TextVlaue) < Maximum / 3)
                {
                    (this.GetTemplateChild(offsetFirst1) as GradientStop).Offset = (this.GetTemplateChild(offsetFirst2) as GradientStop).Offset = Convert.ToInt32(TextVlaue) / (Maximum / 3);
                    (this.GetTemplateChild(offsetSecond1) as GradientStop).Offset = (this.GetTemplateChild(offsetSecond2) as GradientStop).Offset = 0;
                    (this.GetTemplateChild(offsetThird1) as GradientStop).Offset = (this.GetTemplateChild(offsetThird2) as GradientStop).Offset = 0;
                }
                else if (Convert.ToInt32(TextVlaue) > (Maximum / 3 * 2))
                {
                    (this.GetTemplateChild(offsetFirst1) as GradientStop).Offset = (this.GetTemplateChild(offsetFirst2) as GradientStop).Offset = 1;
                    (this.GetTemplateChild(offsetSecond1) as GradientStop).Offset = (this.GetTemplateChild(offsetSecond2) as GradientStop).Offset = 1;
                    (this.GetTemplateChild(offsetThird1) as GradientStop).Offset = (this.GetTemplateChild(offsetThird2) as GradientStop).Offset = (Convert.ToInt32(TextVlaue) - (Maximum / 3 * 2)) / (Maximum / 3);
                }
                else
                {
                    (this.GetTemplateChild(offsetFirst1) as GradientStop).Offset = (this.GetTemplateChild(offsetFirst2) as GradientStop).Offset = 1;
                    (this.GetTemplateChild(offsetSecond1) as GradientStop).Offset = (this.GetTemplateChild(offsetSecond2) as GradientStop).Offset = (Convert.ToInt32(TextVlaue) - (Maximum / 3)) / (Maximum / 3);
                    (this.GetTemplateChild(offsetThird1) as GradientStop).Offset = (this.GetTemplateChild(offsetThird2) as GradientStop).Offset = 0;

                }
            }
            catch { }
        }
    }
}
