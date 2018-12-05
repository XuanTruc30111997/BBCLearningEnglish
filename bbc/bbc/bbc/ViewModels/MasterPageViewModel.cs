using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

using bbc.Data.Models;
using bbc.Data.Services;
using bbc.Interfaces;
using bbc.Functions;
using Plugin.Connectivity;

namespace bbc.ViewModels
{
    public class MasterPageViewModel : BaseViewModel
    {
        #region Attributes
        private RestTopicService topicService = null;
        private List<Topic> _listTopic { get; set; }
        private Topic _selectedItem { get; set; }
        #endregion

        #region properties
        public List<Topic> ListTopic
        {
            get { return _listTopic; }
            set
            {
                _listTopic = value;
                OnPropertyChanged();
            }
        }
        public Topic SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Command
        public ICommand ItemClick
        {
            get
            {
                return new Command(() =>
                {
                    DoWhenClickItem();
                });
            }
            set { }
        }

        public Command ImageTapCommand
        {
            get
            {
                return new Command(ImageTap);
            }
        }

        public Command DataOfflineCommand
        {
            get
            {
                return new Command(MyDataOffline);
            }
        }
        #endregion

        #region constructor
        public MasterPageViewModel()
        {
            //if (CrossConnectivity.Current.IsConnected)
            //{
            //    Offline = false;
            //    IsBusy = true;
            //    Title = "BBC Learing English";
            //    GetTopicAsync().GetAwaiter();
            //    IsBusy = false;
            //}
            //else
            //{
            //    Offline = true;
            //    DependencyService.Get<IMessage>().ShortToast("You are offline");
            //}

            //if(!Offline) // Online
            //{
            //    DependencyService.Get<IMessage>().ShortToast("You are online");
            //    IsBusy = true;
            //    Title = "BBC Learing English";
            //    GetTopicAsync().GetAwaiter();
            //    IsBusy = false;
            //}
            //else // Offline
            //{
            //    DependencyService.Get<IMessage>().ShortToast("You are offline");
            //}
            
            Title = "BBC Learing English";
            IsBusy = true;
            GetTopicAsync().GetAwaiter();
            IsBusy = false;

        }
        #endregion

        #region methods
        private async Task GetTopicAsync()
        {
            topicService = new RestTopicService();
            ListTopic = await topicService.GetDataAsync();
        }

        NavigationService navigationService;
        private void DoWhenClickItem()
        {

            int index = _listTopic.IndexOf(_selectedItem);
            DependencyService.Get<IMessage>().ShortToast(_listTopic[index].Name);

            navigationService = new NavigationService();
            // await navigationService.MyNavigatorOnMaster(_listTopic[index].Id, "BBCMainPage");
            navigationService.MyNavigatorOnMaster(_listTopic[index].Id, _listTopic[index].Name);
        }

        private void ImageTap()
        {
            navigationService = new NavigationService();
            // await navigationService.MyNavigatorOnMaster(_listTopic[index].Id, "BBCMainPage");
            navigationService.MyNavigatorOnMaster(null, null);
        }


        private void MyDataOffline()
        {
            Offline = true;
            myOffline = true;
            navigationService = new NavigationService();
            // await navigationService.MyNavigatorOnMaster(_listTopic[index].Id, "BBCMainPage");
            navigationService.MyNavigatorOnMaster("MyDataOffline", null);
        }
        #endregion
    }
}
