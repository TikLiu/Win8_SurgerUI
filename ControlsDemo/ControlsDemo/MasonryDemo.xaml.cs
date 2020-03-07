using Controls.Toolkit;
using ControlsDemo;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Windows8_Controls_Showcase.ControlsSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MasonryDemo : Page
    {
        public MasonryDemo()
        {
            this.InitializeComponent();
            this.Loaded += MasonryDemo_Loaded;
        }

        void MasonryDemo_Loaded(object sender, RoutedEventArgs e)
        {
            mp.Items = GetTestSample();

            //gridView.ItemsSource = GetTestSample();
        }

        private List<MasonryItem> GetTestSample()
        {
            List<MasonryItem> list = new List<MasonryItem>();
            //for (int i = 0; i < 10; i++)
            //{

                list.Add(new MasonryItem() { ItemWidth = 436, ItemHeight = 544, ImageSource = "ms-appx:///Images/001.jpg" });
                list.Add(new MasonryItem() { ItemWidth = 400, ItemHeight = 600, ImageSource = "ms-appx:///Images/002.jpg" });

                list.Add(new MasonryItem() { ItemWidth = 300, ItemHeight = 450, ImageSource = "ms-appx:///Images/003.jpg" });
                list.Add(new MasonryItem() { ItemWidth = 604, ItemHeight = 402, ImageSource = "ms-appx:///Images/004.jpg" });

                list.Add(new MasonryItem(487, 720, "ms-appx:///Images/007.jpg"));
                list.Add(new MasonryItem(1024, 768, "ms-appx:///Images/008.jpg"));

                list.Add(new MasonryItem(600, 853, "ms-appx:///Images/009.jpg"));
                list.Add(new MasonryItem(900, 547, "ms-appx:///Images/010.jpg"));
                list.Add(new MasonryItem(1024, 640, "ms-appx:///Images/011.jpg"));
                list.Add(new MasonryItem(1024, 801, "ms-appx:///Images/012.jpg"));
                list.Add(new MasonryItem(1024, 768, "ms-appx:///Images/013.jpg"));
                list.Add(new MasonryItem(1024, 768, "ms-appx:///Images/014.jpg"));
                list.Add(new MasonryItem(1280, 1024, "ms-appx:///Images/015.jpg"));
            //}
            return list;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            App.NavigateToPage(typeof(SemanticZoomOutDemo));
        }
    }
}
