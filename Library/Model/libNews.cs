using System;
using System.Collections.Generic;

namespace Library
{
	public class libNews
	{
		public libNews()
		{
		}
		public class Author
		{
			public int id { get; set; }
			public string slug { get; set; }
			public string name { get; set; }
			public string first_name { get; set; }
			public string last_name { get; set; }
			public string nickname { get; set; }
			public string url { get; set; }
			public string description { get; set; }
		}
		public class CustomFields
		{
			public List<string> publicize_twitter_user { get; set; }
		}

		public class Full
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class Thumbnail
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class Medium
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class MediumLarge
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class Large
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class ThumbnailImages
		{
			public Full full { get; set; }
			public Thumbnail thumbnail { get; set; }
			public Medium medium { get; set; }
			public MediumLarge medium_large { get; set; }
			public Large large { get; set; }
		}

		public class Post
		{
			public int id { get; set; }
			public string type { get; set; }
			public string slug { get; set; }
			public string url { get; set; }
			public string status { get; set; }
			public string title { get; set; }
			public string title_plain { get; set; }
			public string content { get; set; }
			public string excerpt { get; set; }
			public string date { get; set; }
			public string modified { get; set; }
			public List<object> categories { get; set; }
			public List<object> tags { get; set; }
			public Author author { get; set; }
			public List<object> comments { get; set; }
			public List<object> attachments { get; set; }
			public int comment_count { get; set; }
			public string comment_status { get; set; }
			public string thumbnail { get; set; }
			public CustomFields custom_fields { get; set; }
			public string thumbnail_size { get; set; }
			public ThumbnailImages thumbnail_images { get; set; }
		}

		public class Query
		{
			public bool ignore_sticky_posts { get; set; }
		}

		public class RootObject
		{
			public string status { get; set; }
			public int count { get; set; }
			public int count_total { get; set; }
			public int pages { get; set; }
			public List<Post> posts { get; set; }
			public Query query { get; set; }
		}
	}
}
