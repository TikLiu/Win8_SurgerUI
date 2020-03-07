using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace Controls.Layout.Toolkit
{
    public sealed class Step : Control
    {
        #region IsSelected
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(Step), new PropertyMetadata(null, (s, e) =>
            {
                Step step = s as Step;
                if (e.NewValue.ToString().ToUpper() == "TRUE")
                {
                    VisualStateManager.GoToState(step, "Selected", true);
                }

                else if (step.IsFinished==true)
                {
                    VisualStateManager.GoToState(step, "Finished", true);
                }
                else
                {
                    VisualStateManager.GoToState(step, "Basic", true);
                }
            }));

        #endregion

        #region Text
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(Step), new PropertyMetadata(""));
        #endregion

        #region IsFinished
        public bool IsFinished
        {
            get { return (bool)GetValue(IsFinishedProperty); }
            set { SetValue(IsFinishedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsFinished.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsFinishedProperty =
            DependencyProperty.Register("IsFinished", typeof(bool), typeof(Step), new PropertyMetadata(null, (s, e) =>
            {
                Step step = s as Step;
                if (e.NewValue.ToString().ToUpper() == "TRUE")
                {
                    VisualStateManager.GoToState(step, "Finished", true);
                }
               else if (step.IsSelected == true)
                {
                    VisualStateManager.GoToState(step, "Selected", true);
                }
                else
                {
                    VisualStateManager.GoToState(step, "Basic", true);
                }
            }));
        #endregion     

        #region IsInconformity
        public bool IsInconformity
        {
            get { return (bool)GetValue(IsInconformityProperty); }
            set { SetValue(IsInconformityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsInconformity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsInconformityProperty =
            DependencyProperty.Register("IsInconformity", typeof(bool), typeof(Step), new PropertyMetadata(false));
        #endregion


        public Step()
        {
            this.DefaultStyleKey = typeof(Step);

        }
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (this.IsSelected)
                VisualStateManager.GoToState(this, "Selected", true);
            if(this.IsFinished)
                VisualStateManager.GoToState(this, "Finished", true);

            if (this.IsInconformity)
            {
                (GetTemplateChild("StepTemplateFront") as Grid).Visibility = Visibility.Visible;
                (GetTemplateChild("StepTemplateRegular") as Grid).Visibility = Visibility.Collapsed;
            }
            else
            {
                (GetTemplateChild("StepTemplateFront") as Grid).Visibility = Visibility.Collapsed;
                (GetTemplateChild("StepTemplateRegular") as Grid).Visibility = Visibility.Visible;
            }
        }



    }
}
