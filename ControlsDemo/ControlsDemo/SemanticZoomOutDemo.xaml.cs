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

namespace Windows8_Controls_Showcase.ControlsSample
{
    public class SecondaryType
    {
        public int TypeID { set; get; }

        public int ProID { set; get; }

        public string TypeName { set; get; }

        public Uri ImageUrl { set; get; }
    }

    public class MainType
    {
        public int ProID { set; get; }

        public string Name { set; get; }
    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SemanticZoomOutDemo : Page
    {
        public SemanticZoomOutDemo()
        {
            this.InitializeComponent();

            lvlist.IsItemClickEnabled = true;
            lvlist.ItemClick += lvlist_ItemClick;
           
        }
       
        void lvlist_ItemClick(object sender, ItemClickEventArgs e)
        {
            App.NavigateToPage(typeof(MasonryDemo));
        }
      
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MainType[] MainTypes = { 
                                    new MainType{ProID=1,Name="News"},
                                    new MainType{ProID=2,Name="Movie"},
                                    new MainType{ProID=3,Name="Sports"},
                                    new MainType{ProID=4,Name="Games"}
                              };

            SecondaryType[] SecondaryTypes = { 
                                new SecondaryType{TypeID=11,ProID=1,TypeName="News 1",ImageUrl=new Uri("ms-appx:///Images/001.jpg")},
                                new SecondaryType{TypeID=12,ProID=1,TypeName="News 2",ImageUrl=new Uri("ms-appx:///Images/002.jpg")},
                                new SecondaryType{TypeID=13,ProID=1,TypeName="News 3",ImageUrl=new Uri("ms-appx:///Images/003.jpg")},
                                new SecondaryType{TypeID=14,ProID=1,TypeName="News 4",ImageUrl=new Uri("ms-appx:///Images/004.jpg")},
                                new SecondaryType{TypeID=21,ProID=2,TypeName="Batman",ImageUrl=new Uri("ms-appx:///Images/007.jpg")},
                                new SecondaryType{TypeID=22,ProID=2,TypeName="SpiderMan",ImageUrl=new Uri("ms-appx:///Images/008.jpg")},
                                new SecondaryType{TypeID=31,ProID=3,TypeName="Basketball",ImageUrl=new Uri("ms-appx:///Images/009.jpg")},
                                new SecondaryType{TypeID=32,ProID=3,TypeName="Swimming",ImageUrl=new Uri("ms-appx:///Images/010.jpg")},
                                new SecondaryType{TypeID=33,ProID=3,TypeName="Football",ImageUrl=new Uri("ms-appx:///Images/011.jpg")},
                                new SecondaryType{TypeID=34,ProID=3,TypeName="Fencing",ImageUrl=new Uri("ms-appx:///Images/012.jpg")},
                                new SecondaryType{TypeID=35,ProID=3,TypeName="Weightlifting",ImageUrl=new Uri("ms-appx:///Images/013.jpg")},
                                new SecondaryType{TypeID=41,ProID=4,TypeName="WOW",ImageUrl=new Uri("ms-appx:///Images/014.jpg")},
                                new SecondaryType{TypeID=42,ProID=4,TypeName="StarCraft",ImageUrl=new Uri("ms-appx:///Images/015.jpg")}
                           };
           
            var res = (from p in MainTypes
                       join c in SecondaryTypes on p.ProID equals c.ProID
                       into g
                       select new
                       {
                           p.Name,
                           TypeList = g.ToList()
                       }).ToList<dynamic>();
           
            CollectionViewSource cvs = new CollectionViewSource();
            cvs.IsSourceGrouped = true;

            cvs.ItemsPath = new PropertyPath("TypeList");
             
            cvs.Source = res;
            
            gvList.ItemsSource = cvs.View.CollectionGroups;
            lvlist.ItemsSource = cvs.View;
        } 
    }
}
