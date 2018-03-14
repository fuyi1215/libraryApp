using System;
using System.Collections.Generic;

namespace Library
{
	public class libNewsJsonAPI
	{
		public libNewsJsonAPI()
		{
		}
		public class Category
		{
			public int id { get; set; }
			public string slug { get; set; }
			public string title { get; set; }
			public string description { get; set; }
			public int parent { get; set; }
			public int post_count { get; set; }
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
			public List<string> slide_template { get; set; }
			public List<string> wpex_overlay_header_style { get; set; }
			public List<string> wpex_overlay_header_dropdown_style { get; set; }
			public List<string> all_day_event { get; set; }
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

		public class ShopThumbnail
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class ShopCatalog
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class ShopSingle
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class Lightbox
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class BlogEntry
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class BlogPost
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class BlogPostFull
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class BlogRelated
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class PortfolioEntry
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class PortfolioPost
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class PortfolioRelated
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class StaffEntry
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class StaffPost
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class StaffRelated
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class TestimonialsEntry
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class ShopSingleThumbnail
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class ShopCategory
		{
			public string url { get; set; }
			public int width { get; set; }
			public int height { get; set; }
		}

		public class Gallery
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
			public ShopThumbnail shop_thumbnail { get; set; }
			public ShopCatalog shop_catalog { get; set; }
			public ShopSingle shop_single { get; set; }
			public Lightbox lightbox { get; set; }
			public BlogEntry blog_entry { get; set; }
			public BlogPost blog_post { get; set; }
			public BlogPostFull blog_post_full { get; set; }
			public BlogRelated blog_related { get; set; }
			public PortfolioEntry portfolio_entry { get; set; }
			public PortfolioPost portfolio_post { get; set; }
			public PortfolioRelated portfolio_related { get; set; }
			public StaffEntry staff_entry { get; set; }
			public StaffPost staff_post { get; set; }
			public StaffRelated staff_related { get; set; }
			public TestimonialsEntry testimonials_entry { get; set; }
			public ShopSingleThumbnail shop_single_thumbnail { get; set; }
			public ShopCategory shop_category { get; set; }
			public Gallery gallery { get; set; }
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
			public List<Category> categories { get; set; }
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
			public List<object> taxonomy_post_series { get; set; }
		}

		public class RootObject
		{
			public string status { get; set; }
			public int count { get; set; }
			public int count_total { get; set; }
			public int pages { get; set; }
			public List<Post> posts { get; set; }
		}
	}
}
