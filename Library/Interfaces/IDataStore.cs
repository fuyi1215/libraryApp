using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Model;

namespace Library
{
	public interface IDataStore
	{
		void Init();
		Task<IEnumerable<NewsListItem>> GetNewsAsync();
		Task<IEnumerable<CalendarTable>> GetCalendarAsync();
        Task SyncNewsAsync();
        Task SyncCalendarAsync(string Url);

	}
}
