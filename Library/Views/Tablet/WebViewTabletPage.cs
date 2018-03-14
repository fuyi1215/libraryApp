using System;

using Xamarin.Forms;

namespace Library
{
	public class WebViewTabletPage : ContentPage
	{
		public WebViewTabletPage(string URL)
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}

