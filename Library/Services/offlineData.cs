//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Library;
//using Library.Model;
//using Xamarin.Forms;

//[assembly: Dependency(typeof(offlineData))]
//namespace Library
//{
//	class offlineData : IDataStore
//	{
//		public Task<IEnumerable<CalendarTable>> GetCalendarAsync()
//		{
//			throw new NotImplementedException();
//		}

//		public Task<IEnumerable<NewsListItem>> GetNewsAsync()
//		{
//			throw new NotImplementedException();
//		}

//		public void Init()
//		{
//			//throw new NotImplementedException();
//		}

//		public Task SyncCalendarAsync()
//		{
//			throw new NotImplementedException();
//		}

//		public Task SyncNewsAsync()
//		{
//			throw new NotImplementedException();
//		}

//	}
//}

	//	public class offlineData :IDataStore
	//	{


	//		public offlineData()
	//		{
	//		}

	//		public async Task<IEnumerable<NewsListItem>> GetNewsAsync()
	//		{
	//			Database sql = new Database();
	//			return await Task.Run(() => sql.GetNewListItems());
	//		}

	//		public void Init()
	//		{
	//			//return Task.Run(() => { });
	//		}

	//		public Task SyncNewsAsync()
	//		{
	//			return Task.Run(() => { });
	//		}
	//	}
	//}

