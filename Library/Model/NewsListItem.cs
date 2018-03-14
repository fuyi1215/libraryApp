using System;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using SQLite;

namespace Library.Model
{
	public class NewsListItem
	{
		
		private string _content = string.Empty;
		//private string mycontent;
		private string _title = string.Empty;
		//private string _contentP = string.Empty;
		//	private string _pictureURL = string.Empty;

		[JsonProperty(PropertyName = "id")]
		[PrimaryKey]
		public string id { get; set;}

		//[Microsoft.WindowsAzure.MobileServices.Version]
		public string title { get { return  WebUtility.HtmlDecode(_title); } set { _title = value; } }
		//public string slug { get; set; }
		public string content { get { return _content;} set {_content =value; } }
		//public string status { get; set; }
		public string url { get; set; } = string.Empty;
        public DateTime Update { get; set; }
        public DateTime Published { get; set; }

		[JsonIgnore]

		public string contentP { 
			get {
				//string sfdasf = mycontentP.Substring(0,80);
				return substring(_content);
				//return s); 
			} 

		}

		public string pictureURL { 
			get
			{
				string URL = matchImg(_content);
				if (URL.Contains("\""))
				   	return URL.Substring(0, matchImg(_content).IndexOf("\"", StringComparison.CurrentCulture));
				else
					return URL;
			}

		}

		private string substring(string value)
		{
			if(value.Contains("<"))
				value = StripTagsRegex(value);
			value = WebUtility.HtmlDecode(value);
				return  value.Length > 80 ? value.Substring(0, 80)+"...":value;
			
		}

		public static string matchImg(string source)
		{
			var regexurl = "https?:\\/\\/.*\\.(?:png|jpg)";
			return Regex.Match(WebUtility.HtmlDecode(source), regexurl).Value;
		}
		public static string StripTagsRegex(string source)
		{
			return Regex.Replace(source, "<.*?>", string.Empty);
		}



		public NewsListItem()
		{
		}

		public NewsListItem(libNewsBlog.Item item)
		{
			id = item.id.ToString();
			title = item.title;
			content = item.content;
			url = item.url;
            DateTime udate = DateTime.Today;
            DateTime pdate = DateTime.Today;
            Update = DateTime.TryParse(item.updated, out udate) ? udate : DateTime.Today;
            Published = DateTime.TryParse(item.published, out pdate) ? pdate : DateTime.Today;

		}
        public NewsListItem(libNewsJsonAPI.Post item)
        {
            id = item.id.ToString();
            title = item.title;
            content = item.content;
            url = item.url;
            DateTime udate = DateTime.Today;
            DateTime pdate = DateTime.Today;
            Update = DateTime.TryParse(item.date, out udate) ? udate : DateTime.Today;
            //Published = DateTime.TryParse(item.date, out pdate) ? pdate : DateTime.Today;

        }




		/*public static string StripTagsCharArray(string source)
		{
			char[] array = new char[source.Length];
			int arrayIndex = 0;
			bool inside = false;

			for (int i = 0; i < source.Length; i++)
			{
				char let = source[i];
				if (let == '<')
				{
					inside = true;
					continue;
				}
				if (let == '>')
				{
					inside = false;
					continue;
				}
				if (!inside)
				{
					array[arrayIndex] = let;
					arrayIndex++;
				}
			}
			return new string(array, 0, arrayIndex);
		}*/

		//public byte[]  pic { get; set;}
		//public string date { get; set; }
		//public string modified { get; set; }

		//public string alpha { get; set; }
	}
}

