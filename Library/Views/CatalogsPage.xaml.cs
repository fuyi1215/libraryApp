
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Library
{
	public partial class CatalogsPage : ContentPage
	{
		public CatalogsPage()
		{
			InitializeComponent();
			ButtonPrintCatalog.Clicked += async (sender, e) =>
			{
				string Url = "https://evergreen.lib.in.us/eg/opac/home?locg=316";
				if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
					await Navigation.PushAsync(new WebViewTabletPage(Url) { Title = ButtonPrintCatalog.Text });
				else
					await Navigation.PushAsync(new WebViewPage(Url) { Title = ButtonPrintCatalog.Text });
			};
					                           

			ButtonOnlineCatalog.Clicked += async (sender, e) =>
			{
				string Url = "http://nidl.libraryreserve.com/53EC660E-26FE-409C-8C4A-04D9E6ACFE1A/10/50/en/default.htm";
				await Navigation.PushAsync(new WebViewPage(Url) { Title = ButtonOnlineCatalog.Text });
			};
			           
		}
	}
}
