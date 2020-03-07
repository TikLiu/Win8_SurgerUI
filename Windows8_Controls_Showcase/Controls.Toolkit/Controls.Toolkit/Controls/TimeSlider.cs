using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Controls.Toolkit.Controls
{
    public sealed class TimeSlider : Slider
    {           
        public TimeSlider()
        {
            this.DefaultStyleKey = typeof(TimeSlider);
        }
    }
}
