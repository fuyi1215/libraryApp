using System;
using Xamarin.Forms;
using Library.Model;
using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using Library.Helpers;

namespace Library
{
	public class NewsViewModel : ViewModelBase
	{

		public ObservableRangeCollection<NewsListItem> NewsList { get; set; }
        //public ObservableRangeCollection<Grouping<string, NewsListItem>> NewsGrouped { get; set; }
       
        public Color backgroundcolor { get; set; }
		public bool ForceSync { get; set; }
		readonly IDataStore dataStore;

        private bool _isRefreshing = false;
        public bool IsRefreshing{
            get { return _isRefreshing; }
            set{
                _isRefreshing = value;
                OnPropertyChanged((nameof(IsRefreshing)));
            }
        }

		public NewsViewModel() :base()
		{
			Title = "News";
			dataStore = DependencyService.Get<IDataStore>();
			NewsList = new ObservableRangeCollection<NewsListItem>();
            backgroundcolor = LibInfo.Backgroundcolor;
			//NewsGrouped = new ObservableRangeCollection<Grouping<string, NewsListItem>>();
		}
		public NewsViewModel(Page page) : base(page)
		{
			Title = "News";
			dataStore = DependencyService.Get<IDataStore>();
			NewsList = new ObservableRangeCollection<NewsListItem>();
            backgroundcolor = LibInfo.Backgroundcolor;
			//NewsGrouped = new ObservableRangeCollection<Grouping<string, NewsListItem>>();
		}


        public Command RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;
                    await dataStore.SyncNewsAsync();
                    var News = await dataStore.GetNewsAsync();
                    //var News = await dataStore.GetNewsAsync();
                    NewsList.ReplaceRange(News.OrderByDescending(x => x.Published)); ;

                    IsRefreshing = false;
                });
            }
        }
		public Action<NewsListItem> ItemSelected { get; set; }
		NewsListItem selectedNews;

		public NewsListItem SelectedNews
		{
			get { return selectedNews; }
			set
			{
				selectedNews = value;
				OnPropertyChanged("SelectedNews");
				if (SelectedNews == null)
					return;

				if (ItemSelected == null)
				{
					page.Navigation.PushAsync(new WebViewPage(selectedNews.content, false) { Title = selectedNews.title });
					SelectedNews = null;
				}
				else
				{
					ItemSelected.Invoke(selectedNews);
				}

			}
		}


		private Command getNewsCommand;
		public Command GetNewsCommand
		{
			get
			{
				return getNewsCommand ??
					(getNewsCommand = new Command(async () => await ExecuteGetNewsCommand(), () => { return !IsBusy; }));
			}
		}

		private async Task ExecuteGetNewsCommand()
		{
			if (IsBusy)
				return;

			// (ForceSync)
			//	Settings.LastSync = DateTime.Now.AddDays(-2);

			IsBusy = true;
			GetNewsCommand.ChangeCanExecute();

			var showAlert = false;
			try
			{
				NewsList.Clear();

                var News = await dataStore.GetNewsAsync();
                //var News = await dataStore.GetNewsAsync();
                NewsList.ReplaceRange(News.OrderByDescending(x => x.Published));

				//Sort();
			}
			catch (Exception ex)
			{
				showAlert = true;
				//await page.DisplayAlert("Uh Oh :(", ex.Message, "OK");
			}
			finally
			{
				IsBusy = false;
				GetNewsCommand.ChangeCanExecute();
			}

			if (showAlert && page != null)
				await page.DisplayAlert("Uh Oh :(", "Unable to gather News.", "OK");


		}
		//private void Sort()
		//{

		//	//NewsGrouped.Clear();

		//	var sorted = NewsList.OrderByDescending(x => x.id);
		//	//var sorted = from News in NewsList
		//	//	orderby News.title,News.id
		//	//  group News by News.title into storeGroup
		//	//  select new Grouping<string, NewsListItem>(storeGroup.Key, storeGroup);
		//	NewsList.ReplaceRange(sorted);
		//	//NewsGrouped.ReplaceRange(sorted);
		//}



	}
}
