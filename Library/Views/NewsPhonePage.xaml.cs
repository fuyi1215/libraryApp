using System;
using System.Collections.Generic;
using Library.Model;
using Xamarin.Forms;

namespace Library
{
	public partial class NewsPhonePage : ContentPage
	{
		NewsViewModel viewModel;
		public Action<NewsListItem> ItemSelected
		{
			get { return viewModel.ItemSelected; }
            set { viewModel.ItemSelected = value; }
		}
		public NewsPhonePage()
		{
			InitializeComponent();
			
			BindingContext = viewModel = new NewsViewModel(this);
			//if (Device.OS == TargetPlatform.WinPhone || (Device.OS == TargetPlatform.Windows && Device.Idiom == TargetIdiom.Phone))
			//{
			//	//StoreList.IsGroupingEnabled = false;
			//	//StoreList.ItemsSource = viewModel.Stores;
			//}

		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (viewModel.NewsList.Count > 0 || viewModel.IsBusy)
				return;

			viewModel.GetNewsCommand.Execute(null);
		}
	}
}
