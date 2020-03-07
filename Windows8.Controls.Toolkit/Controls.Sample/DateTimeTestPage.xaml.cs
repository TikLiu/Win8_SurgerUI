﻿using System;
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

// The Group Detail Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234229

namespace Controls.Sample
{
    /// <summary>
    /// A page that displays an overview of a single group, including a preview of the items
    /// within the group.
    /// </summary>
    public sealed partial class DateTimeTestPage : Controls.Sample.Common.LayoutAwarePage
    {
        public DateTimeTestPage()
        {
            this.InitializeComponent();

            this.Loaded += DateTimeTestPage_Loaded;
        }

        void DateTimeTestPage_Loaded(object sender, RoutedEventArgs e)
        {
            //this.calendar.StartDate = new DateTime(2013, 1, 15);
            //this.calendar.EndDate = new DateTime(2013, 1, 22);
            this.calendarpicker.StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 10);
            this.calendarpicker.EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 20);
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            
        }        
    }
}