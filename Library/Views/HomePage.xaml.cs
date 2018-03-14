using System;
using System.Collections.Generic;
using Library.Model;
using Xamarin.Forms;
using Library.Helpers;

namespace Library
{
	public partial class HomePage : ContentPage
	{
		//public IEnumerable<CalendarTable> CalenderEvents { get; set; }
		//public IEnumerable<NewsListItem> NewsModel { get; set; }
		readonly IDataStore dataStore;

        LibInfo.RootObject Lib = new LibInfo.RootObject();
        public HomePage(LibInfo.RootObject lib)
		{
			InitializeComponent();
            dataStore = DependencyService.Get<IDataStore>();
            Lib = lib;
		}
		protected override async void OnAppearing()
		{
			base.OnAppearing();
			var showAlert = false;



			mainLabel1.Text ="";
			MainLabel.Text = "Connecting";
			await MainProgressBar.ProgressTo(0.5, 500, Easing.Linear);
			await MainProgressBar.ProgressTo(0.9, 900, Easing.Linear);
			await MainProgressBar.ProgressTo(1, 1000, Easing.Linear);


			Application.Current.MainPage = new Library.MainTabPage(Lib);
			




			//MainPage.Appearing();

		}
	}
}
