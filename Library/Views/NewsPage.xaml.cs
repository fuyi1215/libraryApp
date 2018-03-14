using System;
using System.Collections.Generic;
using System.Linq;

using Library.API;

using Xamarin.Forms;

namespace Library
{
	public partial class NewsPage : ContentPage
	{
		public NewsPage()
		{
			

			InitializeComponent();
			CheckDatabasePopulated();

			listView.ItemsSource = GetNewList();

			//
		}
		public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
				return;
			((ListView)sender).SelectedItem = null;

			String  contents = (e.SelectedItem as NewsListItem).content;

			String title = (e.SelectedItem as NewsListItem).title;
			var page = new WebViewPage(contents,false) { Title = title};
			await Navigation.PushAsync(page);
			
		}
		async void CheckDatabasePopulated() 
		{
			if (new Database().GetNewListItems().Count < 1) 
			{
				//fill up the database with default value
				//var items = new List<NewListItem>();



					var source = new EntryRepository();
		    var test = await source.TopEntriesAsync();
			var items = new List<NewsListItem>(test);



				

				new Database().AddNewListItems(items);
			}
		}

		public List<NewsListItem> GetNewList()
		{
			var items = new Database().GetNewListItems();
			return items;
		}

	}
}

