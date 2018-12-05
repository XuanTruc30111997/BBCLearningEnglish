using System;
using System.Collections.Generic;
using System.Text;

using bbc.Views;
using bbc.ViewModels;
using bbc.Data.Models;

using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace bbc.Functions
{
    public class NavigationService : BaseViewModel
    {
        public void MyNavigatorOnMaster(string idTopic, string title)
        {
            // var _currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
            var _currentPage = GetCurrentPage();
            MasterDetailPage myPage = (MasterDetailPage)_currentPage;
            if (idTopic != null && idTopic.Equals("MyDataOffline")) // Dữ liệu Offline
            {
                myPage.Master = new MasterPage();
                myPage.Detail = new NavigationPage(new BBCMainPage());
            }
            else
            {
                if (idTopic != null) // Lesson theo năm
                {
                    myPage.Detail = new NavigationPage(new BBCMainPage(idTopic, title));
                }
                else // Tất cả Lesson
                {
                    myPage.Master = new MasterPage();
                    myPage.Detail = new NavigationPage(new BBCMainPage(null, null));
                }
            }
            myPage.IsPresented = false;
        }

        public async void NavigateOnDetail(Lesson lesson)
        {
            var _currentPage = GetCurrentPage();
            await _currentPage.Navigation.PushAsync(new TestVideoPage(lesson));
        }
    }
}
