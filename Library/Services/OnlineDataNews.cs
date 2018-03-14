using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Threading.Tasks;
using Library;
using Library.Helpers;
using Library.Model;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Xamarin.Forms;
using System.Linq;
using PCLStorage;

[assembly: Dependency(typeof(OnlineDataNews))]
namespace Library
{
	public class OnlineDataNews : IDataStore
	{
		//bool initialized = false;

		bool initialized = false;
		Database sqlite = new Database();

        libNewsBlog.RootObject googleNews = new libNewsBlog.RootObject();
        CalendarInfo.RootObject CalendarTable = new CalendarInfo.RootObject();
		IFolder rootFolder = FileSystem.Current.LocalStorage;


		//HttpClient client;
		//public OnlineDataNews()
		//{

		//}
		public async Task<IEnumerable<NewsListItem>> GetNewsAsync()
		{
			//var client = new HttpClient();
			//var NewsString = await client.GetStringAsync(NewsApiUrls.Base);
			//NewsString = NewsString.Substring(NewsString.IndexOf("[", System.StringComparison.CurrentCulture));
			//NewsString = NewsString.Substring(0, NewsString.LastIndexOf("]", System.StringComparison.CurrentCulture) + 1);
			//NewsTable = JsonConvert.DeserializeObject<List<NewsListItem>>(NewsString);
			if (!initialized)
				 Init();
            
            // create a file, overwriting any existing fileMySubFolder
            IFolder folder = await rootFolder.CreateFolderAsync("Jsonfile", CreationCollisionOption.OpenIfExists);
            IFile Newsfile = await folder.CreateFileAsync("News.json", CreationCollisionOption.OpenIfExists);
            var json = await Newsfile.ReadAllTextAsync();
            //populate the file with some text
            googleNews = JsonConvert.DeserializeObject<libNewsBlog.RootObject>(json);

            List<NewsListItem> newlists = new List<NewsListItem>();
            foreach (var item in googleNews.items)
            {
                NewsListItem newslist = new NewsListItem(item);
                newlists.Add(newslist);
            }
            //await SyncNewsAsync();
            return await Task.Run(() => newlists);
                             //sqlite.GetNewListItems());
		}

		public async Task<IEnumerable<CalendarTable>> GetCalendarAsync()
		{
			
			if (!initialized)
				 Init();
            IFolder folder = await rootFolder.CreateFolderAsync("Jsonfile", CreationCollisionOption.OpenIfExists);
            // create a file, overwriting any existing fileMySubFolder
            IFile Calendarfile = await folder.CreateFileAsync("Calendar.json", CreationCollisionOption.OpenIfExists);
            var json = await Calendarfile.ReadAllTextAsync();
            // populate the file with some text
            CalendarTable = JsonConvert.DeserializeObject<CalendarInfo.RootObject>(json);
            List<CalendarTable> calendarTables = new List<CalendarTable>();
            foreach(var item in CalendarTable.items)
            {
                CalendarTable calendar = new CalendarTable(item);
                calendarTables.Add(calendar);
            }
            return await Task.Run(() => calendarTables);

                                  //sqlite.GetCalendarItems());
		}
		public void Init()
		{
			initialized = true;
            //await SyncNewsAsync();
           
		}


        public async Task SyncNewsAsync()
		{
            
            string NewsString = ""; 
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                    return;
                    //return await Task.Run(() => sqlite.GetNewListItems());

                //var list = await GetNewsAsync();
                if (!string.IsNullOrEmpty(LibInfo.NewUrl))
                {
                    using (var client = new HttpClient())
                    {

                        NewsString = await client.GetStringAsync(LibInfo.NewUrl);
                        IFolder folder = await rootFolder.CreateFolderAsync("Jsonfile", CreationCollisionOption.OpenIfExists);
                        // create a file, overwriting any existing fileMySubFolder
                        IFile file = await folder.CreateFileAsync("News.json", CreationCollisionOption.OpenIfExists);
                        var json = await file.ReadAllTextAsync();
                        //populate the file with some text

                        if (json != NewsString && !string.IsNullOrEmpty(NewsString))
                        {
                            await file.WriteAllTextAsync(NewsString);
                        }
                      
                        //googleNews = JsonConvert.DeserializeObject<libNewsBlog.RootObject>(NewsString);

                        Settings.LastSync = DateTime.Now;

                        //return await Task.Run(() => newlists);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sync Failed:" + ex.Message);
            }
            //finally{
            //    //if (!string.IsNullOrEmpty(NewsString))
            //    //{
            //    //    await sqlite.AddNewListItems(JsonConvert.DeserializeObject<libNewsBlog.RootObject>(NewsString));
            //    //}
            //}

            //return await Task.Run(() => newlists);

		}
		public async Task SyncCalendarAsync(string Url)
		{

			try
			{
				if (!CrossConnectivity.Current.IsConnected)
					return;

                using (var clients = new HttpClient())
                {
                    var CalendarString = await clients.GetStringAsync(Url);

                    IFolder folder = await rootFolder.CreateFolderAsync("Jsonfile", CreationCollisionOption.OpenIfExists);
                    // create a file, overwriting any existing fileMySubFolder
                    IFile file = await folder.CreateFileAsync("Calendar.json", CreationCollisionOption.OpenIfExists);
                    var json = await file.ReadAllTextAsync();
                    // populate the file with some text

                    if (json != CalendarString)
                    {
                        await file.WriteAllTextAsync(CalendarString);
                        //await sqlite.AddCalendarItems(JsonConvert.DeserializeObject<CalendarInfo.RootObject>(CalendarString));
                    }

                }
                Settings.LastSync = DateTime.Now;

			}
			catch (Exception ex)
			{
				Debug.WriteLine("Sync Failed:" + ex.Message);
			}

		}




	}
}

//NewsString = NewsString.Substring(NewsString.IndexOf("[", System.StringComparison.CurrentCulture));
//NewsString = NewsString.Substring(0, NewsString.LastIndexOf("]", System.StringComparison.CurrentCulture) + 1);




//public async Task Init()
//{
//	try
//	{
//		if (!CrossConnectivity.Current.IsConnected)
//		{

//			//return await Task.Run(() => sqlite.GetNewListItems());
//		}
//		else
//		{
//			initialized = true;

//			var news = await GetNewsAsync();
//		   //sqlite.AddNewListItems(news.ToList());
//			//return await Task.Run(() =>GetNewsAsync());
//		}

//	}
//	catch (Exception ex)
//	{
//		Debug.WriteLine("Sync Failed:" + ex.Message);
//		//return await Task.Run(() => sqlite.GetNewListItems());
//	}


//}

//public async Task<IEnumerable<NewsListItem>> GetNewsAsync()
//{
//	 sqlite = new Database();
//	//IEnumerable<NewsListItem> list;
//	if (!CrossConnectivity.Current.IsConnected)
//	{

//		return await Task.Run(() => sqlite.GetNewListItems());
//	}
//	else 
//	{

//		var client = new HttpClient();

//		var result = await client.GetStringAsync(NewsApiUrls.Base);
//		var CalendarString = await client.GetStringAsync(NewsApiUrls.calendar);

//		result = result.Substring(result.IndexOf("[", System.StringComparison.CurrentCulture));
//		result = result.Substring(0, result.LastIndexOf("]", System.StringComparison.CurrentCulture) + 1);
//		if (!initialized)
//		{
//			//var news = JsonConvert.DeserializeObject<IEnumerable<NewsListItem>>(result);
//			//List<NewsListItem> List = new List<NewsListItem>();
//			var Calendar = JsonConvert.DeserializeObject<Calendar.RootObject>(CalendarString);
//			sqlite.AddCalendar(Calendar);
//			var list = JsonConvert.DeserializeObject<List<NewsListItem>>(result);
//			sqlite.AddNewListItems(list.ToList());
//			//sqlite.(list.ToList());
//		}

//		initialized = true;
//		return await Task.Run(() => sqlite.GetNewListItems());

//	}

//}