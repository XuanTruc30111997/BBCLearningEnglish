using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using bbc.Functions;
using bbc.Interfaces;

namespace bbc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BBCMainPage : TabbedPage
    {
        public BBCMainPage(string idTopic, string title)
        {
            InitializeComponent();
            if (title == null)
                Title = "BBC Learing English";
            else
                Title = title;

            if (CheckInternetStatus.CheckInternet()) // Kiểm tra kết nối Internet
            {
                // Có kết nối
                
                var pageAll = new YearPage("All", idTopic);
                pageAll.Title = "All";

                var page2016 = new YearPage("2016", idTopic);
                page2016.Title = "2016";

                var page2017 = new YearPage("2017", idTopic);
                page2017.Title = "2017";

                var page2018 = new YearPage("2018", idTopic);
                page2018.Title = "2018";

                Children.Add(pageAll);
                Children.Add(page2016);
                Children.Add(page2017);
                Children.Add(page2018);
            }
            else // Không kết nối
                DependencyService.Get<IMessage>().ShortToast("Connect Fail! Please make sure your device is connected internet");
        }

        // Page Offline
        public BBCMainPage()
        {
            Title = "My Data Offline";
            var myPageOffline = new YearPage();
            myPageOffline.Title = "My Lesson";
            Children.Add(myPageOffline);
        }
    }
}