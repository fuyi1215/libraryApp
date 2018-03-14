using System;
using System.Collections.Generic;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace Library
{
	public partial class WebViewPage : ContentPage
	{
	    //string url;
		bool display  = true;
		public  WebViewPage(string URL)
		{
			
			InitializeComponent();

			//Browser.WidthRequest = 400;
			//Browser.HeightRequest = 1000;



			stackLayout.IsVisible = true;
			LabelC.IsVisible = true;
			//url = URL;
			Browser.Source = URL;
			

		}
		public WebViewPage(string HtmlContect, bool isVisiable)
		{
			InitializeComponent();
			//< link rel = "stylesheet" href = "http://www.epl.lib.in.us/wp-content/themes/hathor/style.css" type = "text/css" />
            //
			var htmlsource = new HtmlWebViewSource();

			htmlsource.Html = string.Format(@"<html lang=""en-US"">
			<head profile=""http://gmpg.org/xfn/11"">
 			<meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />
			<meta name=""viewport"" content=""width=device-width-, initial-scale=1.0"">
            <link rel='stylesheet' id='hathor_other-css'  href='http://www.businessn4matics.com/wp-content/themes/hathor/css/foundation.css?ver=4.6.1' type='text/css' media='all' />
			
			
			</head>
            <div pic_wrapper image_wrapper> {0} </div> </body></html>",HtmlContect);

			stackLayout.IsVisible = isVisiable;
			LabelC.IsVisible = isVisiable;
			display = isVisiable;

			//Browser.WidthRequest = 400;
			//Browser.HeightRequest = 2000;
			////Browser.MinimumWidthRequest = 320;
			////Browser.MinimumHeightRequest = 2000;
			Browser.Source = htmlsource;

			//Browser.Width = 100;
		}

		private void backClicked(object sender, EventArgs e)
		{
			// Check to see if there is anywhere to go back to
			if (Browser.CanGoBack)
			{
				Browser.GoBack();
			}
			else { // If not, leave the view
				//Navigation.PopAsync();
			}
		}

		private void forwardClicked(object sender, EventArgs e)
		{
			if (Browser.CanGoForward)
			{
				Browser.GoForward();
			}
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (display)
			{
				if (!CrossConnectivity.Current.IsConnected)
					//DisplayAlert("", "The Library's catalog is not available offline. Please connect to the Internet to browse the Library's Catalog.", "OK");
					DisplayAlert("", "Turn Off Airplane Mode or use Wi-Fi to Access Data", "OK");
				else
					if (Browser.Source != null)
					Browser.Source = (Browser.Source as UrlWebViewSource).Url;
			}
			
		}
	}
}

