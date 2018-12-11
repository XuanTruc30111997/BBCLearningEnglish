using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using bbc.ViewModels;

namespace bbc.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class YearPage : ContentPage
	{
		public YearPage (string pageTitle,string idTopic)
		{
			InitializeComponent ();
            // BindingContext = new YearViewModel();
            viewModel = new YearViewModel(pageTitle,idTopic);
		}

        public YearPage()
        {
            InitializeComponent();
            // BindingContext = new YearViewModel();
            viewModel = new YearViewModel();
        }

        public YearViewModel viewModel
        {
            get { return BindingContext as YearViewModel; }
            set { BindingContext = value; }
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var _yearPageVM = BindingContext as YearViewModel;
            _yearPageVM.ItemListViewClick.Execute(null);
        }

        private void Handler_DownloadDeleteLesson(object sender, EventArgs e)
        {
            var vmYear = BindingContext as YearViewModel;
            var myLesson = (MenuItem)sender;
            vmYear.DownloadDeleteCommand.Execute(myLesson.CommandParameter);
        }
    }
}