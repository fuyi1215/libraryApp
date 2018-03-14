using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Library.Model;

namespace Library.API
{
	/*public class EntryRepository : IEntryRepository
	{
		public async Task<IEnumerable<NewListItem>> TopEntriesAsync()
		{
			var client = new HttpClient();

			var result = await client.GetStringAsync(NewsApiUrls.Base);

			//var sdfa  = result;
			//return JsonConvert.DeserializeObject<Page>(sdfa).Items;

			var dfsfaf = JsonConvert.DeserializeObject<NewListItem>(result);

			return sfds;
		}


		
	}
	public interface IEntryRepository
	{
		Task<IEnumerable<NewListItem>> TopEntriesAsync();
	}*/
	public class EntryRepository : IEntryRepository
	{
		public async Task<IEnumerable<NewsListItem>> TopEntriesAsync()
		{
			var client = new HttpClient();

				var result = await client.GetStringAsync(NewsApiUrls.Base);

			result = result.Substring(result.IndexOf("[", System.StringComparison.CurrentCulture));
			result = result.Substring(0,result.LastIndexOf("]", System.StringComparison.CurrentCulture)+1);
			var sfds = JsonConvert.DeserializeObject<List<NewsListItem>>(result);
			 //var sfssfd= JsonConvert.DeserializeObject<List<NewsListItem>>(result);
			return sfds;
		}
	}

	public interface IEntryRepository
	{
		Task<IEnumerable<NewsListItem>> TopEntriesAsync();
	}
}

