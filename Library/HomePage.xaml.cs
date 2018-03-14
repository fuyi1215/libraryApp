using System;
using System.Collections.Generic;
using Library.Model;
using Xamarin.Forms;

namespace Library
{
	public partial class HomePage : ContentPage
	{
		public IEnumerable<CalendarTable> CalenderEvents { get; set; }
		public IEnumerable<NewsListItem> NewsModel { get; set; }
		readonly IDataStore dataStore;
		public HomePage()
		{
			InitializeComponent();
			dataStore = DependencyService.Get<IDataStore>();
		}
		protected override async void OnAppearing()
		{
			base.OnAppearing();
			var showAlert = false;



			mainLabel1.Text ="Eckhart Public Library";
			MainLabel.Text = "Updating content, please be patient...";
			try
			{
				await dataStore.SyncNewsAsync();
				await MainProgressBar.ProgressTo(0.5, 500, Easing.Linear);
				await dataStore.SyncCalendarAsync();
				await MainProgressBar.ProgressTo(0.9, 900, Easing.Linear);

				//var CalenderEvents = await dataStore.GetCalendarAsync();
				//var NewsModel = await dataStore.GetNewsAsync();
			}
			catch (Exception ex)
			{

				showAlert = true;

			}
			if (showAlert)
				await DisplayAlert("Uh oh :(", "Unable to get locations", "OK");

			await MainProgressBar.ProgressTo(1, 1000, Easing.Linear);


			Application.Current.MainPage = new Library.MainTabPage();
			//MainPage.Appearing();

		}
	}
}
