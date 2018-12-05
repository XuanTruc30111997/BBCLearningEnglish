
using Plugin.MediaManager;
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
	public partial class TestVideoPage : ContentPage
	{
		public TestVideoPage (Lesson lesson)
		{
			InitializeComponent ();
            BindingContext = new TestAudioViewModel(lesson);
		}
    }
}