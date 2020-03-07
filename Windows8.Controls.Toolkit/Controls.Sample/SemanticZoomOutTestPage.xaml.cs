using Controls.Sample.Common;
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

namespace Controls.Sample
{
    /// <summary>
    /// 城市
    /// </summary>
    public class City
    {
        public int CityID { set; get; }

        public int ProID { set; get; }

        public string CityName { set; get; }
    }

    /// <summary>
    /// 省
    /// </summary>
    public class Province
    {
        public int ProID { set; get; }

        public string Name { set; get; }
    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SemanticZoomOutTestPage : Page
    {
        public SemanticZoomOutTestPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ///准备数据
            ///添加几个省份
            Province[] Pros = { 
                                    new Province{ProID=1,Name="News"},
                                    new Province{ProID=2,Name="Sports"},
                                    new Province{ProID=3,Name="Movie"},
                                    new Province{ProID=4,Name="Travel"}
                              };

            ////然后再添加几个省下面对应的城市的，随便来几个
            City[] Citys = { 
                                new City{CityID=11,ProID=1,CityName="威海市"},
                                new City{CityID=12,ProID=1,CityName="烟台市"},
                                new City{CityID=13,ProID=1,CityName="济南市"},
                                new City{CityID=21,ProID=2,CityName="广州市"},
                                new City{CityID=22,ProID=2,CityName="深圳市"},
                                new City{CityID=31,ProID=3,CityName="武汉市"},
                                new City{CityID=32,ProID=3,CityName="武昌市"},
                                new City{CityID=33,ProID=3,CityName="汉口市"},
                                new City{CityID=34,ProID=3,CityName="汉阳市"},
                                new City{CityID=35,ProID=3,CityName="宜昌市"},
                                new City{CityID=41,ProID=4,CityName="西宁市"},
                                new City{CityID=42,ProID=4,CityName="桂林市"}
                           };

            // 将省份和城市进行关联，对数据源进行分组，此处用到linq   
            var res = (from p in Pros
                       join c in Citys on p.ProID equals c.ProID
                       into g
                       select new
                       {
                           p.Name,
                           CityList = g.ToList()
                       }).ToList<dynamic>();
            // 实例化CollectionViewSource对象   
            CollectionViewSource cvs = new CollectionViewSource();
            cvs.IsSourceGrouped = true; //支持分组   
            // 分组后集合项的路径，本例中为CityList   
            cvs.ItemsPath = new PropertyPath("CityList");
            // 设置数据来源，就是我们刚才分好组的动态列表   
            cvs.Source = res;
            // 分别对两个视图进行绑定 
            gvList.ItemsSource = cvs.View.CollectionGroups;
            lvlist.ItemsSource = cvs.View;
                        
        }
       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            contentTextBox.IsOpen = true;
        }
    }
}
