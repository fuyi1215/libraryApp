using System;
using System.Collections.Generic;

namespace Library
{
	public class libNewsBlog
	{
		public libNewsBlog()
		{
		}


		public class Blog
		{
			public string id { get; set; }
		}

		public class Image
		{
			public string url { get; set; }
		}

		public class Author
		{
			public string id { get; set; }
			public string displayName { get; set; }
			public string url { get; set; }
			public Image image { get; set; }
		}

		public class Item
		{
			public string kind { get; set; }
			public string id { get; set; }
			public Blog blog { get; set; }
			public string published { get; set; }
			public string updated { get; set; }
			public string etag { get; set; }
			public string url { get; set; }
			public string selfLink { get; set; }
			public string title { get; set; }
			public string content { get; set; }
			public Author author { get; set; }
		}

		public class RootObject
		{
			public string kind { get; set; }
			public List<Item> items { get; set; }
			public string etag { get; set; }
		}
	
	
	
	
	}



}
