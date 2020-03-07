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
    //[TemplatePart(Name = childStep, Type = typeof(List<Step>))]
    public sealed class StepIndicator : Control
    {

        private List<Step> childStep;
        public StepIndicator()
        {
            this.DefaultStyleKey = typeof(StepIndicator);         
        }   

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            childStep = new List<Step>();
            List<Step> stepChildren = GetChildern(this);
            for (int i = 0; i < stepChildren.Count; i++)
            {
                Step stepChild = childStep[i];
                if (stepChild.IsSelected == true)
                {
                    break;
                }
                stepChild.IsSelected = false;
                stepChild.IsFinished = true;
            }
           
            foreach (Step step in stepChildren)
            {
                step.Tapped += step_Tapped;
            }
        }

        void step_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Step step = sender as Step;
            int currentStep = 0;
            for (int i = 0; i < childStep.Count; i++)
            {
                Step stepChild = childStep[i];
                if (stepChild == step)
                {
                    currentStep = i; break;
                }
            }
            for (int i = 0; i < childStep.Count; i++)
            {
                Step stepChild = childStep[i];
                if (i < currentStep)
                {
                    stepChild.IsFinished = true;
                    stepChild.IsSelected = false;
                }
                else if (i > currentStep)
                {
                    stepChild.IsSelected = false;
                    stepChild.IsFinished = false;
                }
                else
                {
                    stepChild.IsSelected = true;
                    stepChild.IsFinished = false;
                }
            }

        }

        private List<Step> GetChildern(DependencyObject root)
        {
            if (root == null)
                return null;
            int count = VisualTreeHelper.GetChildrenCount(root);
            if (count <= 0)
                return null;

            for (int i = 0; i < count; i++)
            {
                DependencyObject dependencyObject = VisualTreeHelper.GetChild(root, i);
                if (dependencyObject != null)
                {
                    if (VisualTreeHelper.GetChildrenCount(root) > 0)
                    {
                        GetChildern(dependencyObject);
                    }
                    if (dependencyObject.GetType() == typeof(Step))
                        childStep.Add(dependencyObject as Step);
                }
            }
            return childStep;
        }

        public void GotoNext()
        {
            int currentSelected = 0;
            for (int i = 0; i < childStep.Count; i++)
            {
                Step stepChild = childStep[i];
                if (stepChild.IsSelected == true)
                {
                    currentSelected = i; break;
                }
            }
            if (currentSelected == childStep.Count - 1) return;
            for (int i = 0; i < childStep.Count; i++)
            {
                if (i <= currentSelected)
                {
                    childStep[i].IsSelected = false;
                    childStep[i].IsFinished = true;
                }
                else if (i == currentSelected + 1)
                {
                    childStep[i].IsSelected = true;
                    childStep[i].IsFinished = false;
                }
                else
                {
                    childStep[i].IsSelected = false;
                    childStep[i].IsFinished = false;
                }
            }
           

        }

        public void GotoBack()
        {
            int currentSelected = 0;
            for (int i = 0; i < childStep.Count; i++)
            {
                Step stepChild = childStep[i];
                if (stepChild.IsSelected == true)
                {
                    currentSelected = i; break;
                }
            }
            if (currentSelected ==0) return;
            for (int i = 0; i < childStep.Count; i++)
            {
                if (i <= currentSelected-2)
                {
                    childStep[i].IsSelected = false;
                    childStep[i].IsFinished = true;
                }
                else if (i == currentSelected - 1)
                {
                    childStep[i].IsSelected = true;
                    childStep[i].IsFinished = false;
                }
                else
                {
                    childStep[i].IsSelected = false;
                    childStep[i].IsFinished = false;
                }
            }
        }
    }
}
