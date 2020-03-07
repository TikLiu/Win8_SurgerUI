using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace Controls.Toolkit.Controls
{
    public sealed class CycleSection : Control
    {     
        public CycleSection()
        {
            this.DefaultStyleKey = typeof(CycleSection);
        }
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
          
        }
    }
}
