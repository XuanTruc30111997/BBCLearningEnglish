using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using bbc.ViewModels;
using bbc.Functions;
using bbc.ViewModels;

namespace bbc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationDrawerPage : MasterDetailPage
    {

        public NavigationDrawerPage()
        {
            InitializeComponent();
            this.Master = new MasterPage();
            if (CheckInternetStatus.CheckInternet()) // Kiểm tra kết nối Internet
            {
                // Có kết nối
                // Hiển thị Online
                BaseViewModel.myOffline = false;
                this.Detail = new NavigationPage(new BBCMainPage(null, null));
            }
            else // Không kết nối
            {
                BaseViewModel.myOffline = true;
                this.Detail = new NavigationPage(new BBCMainPage()); // Hiển thị Offline
                NavigationPage.SetHasNavigationBar(this, false); //turn off toolbar default
            }
        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    if (!CrossConnectivity.Current.IsConnected)
        //    {
        //        isConnect = false;
        //    }

        //    if (CrossConnectivity.Current.IsConnected)
        //    {
        //        isConnect = true;
        //    }
        //}

    }
}