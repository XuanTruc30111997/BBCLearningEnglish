using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using bbc.ViewModels;
using bbc.Data.Models;

namespace bbc.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : ContentPage
	{
		public MasterPage ()
		{
			InitializeComponent ();
            myImage.GestureRecognizers.Add(new TapGestureRecognizer(imageTap));
            BindingContext = new MasterPageViewModel();
		}

        private void imageTap(View arg1, object arg2)
        {
            var _masterPageVM = BindingContext as MasterPageViewModel;
            _masterPageVM.ImageTapCommand.Execute(null);
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var _masterPageVM = BindingContext as MasterPageViewModel;
            _masterPageVM.ItemClick.Execute(null);
        }
    }
}