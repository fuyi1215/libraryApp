using System;
using System.ComponentModel;
using Library;
using Xamarin.Forms;

namespace Library
{
	public class NewsTabletPage : MasterDetailPage
	{
		Database db = new Database();
		public NewsTabletPage()
		{
			Title = "News";
			Master = new NewsPhonePage();
			IsPresented = true;
			try
			{
				Detail = new WebViewPage(db.GetNewsListItem().content, false);
			}
			catch (Exception ex)
			{
				
			}

			MasterBehavior = MasterBehavior.Popover;


		
			((NewsPhonePage)Master).ItemSelected = (news) =>
			{
				Detail = new WebViewPage(news.content,false);
				//if (Device.OS != TargetPlatform.Windows)
					//IsPresented = false;
			};


		  	//TappedEventArgs

		}

		protected override void OnParentSet()
		{
			base.OnParentSet();

		}
		protected override bool OnBackButtonPressed()
		{
			if (IsPresented)
			{
				return base.OnBackButtonPressed();
			}
			else
			{
				IsPresented = true;
				return true;
			}
		}
		protected override void OnAppearing()
		{
			
			base.OnAppearing();
			IsPresented = true;
		}


	}
}

