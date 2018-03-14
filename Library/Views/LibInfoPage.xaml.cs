using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Library
{
	public partial class LibInfoPage : ContentPage
	{
		private LibInfoViewModel viewModel;
		public LibInfoPage()
		{
			InitializeComponent();
			BindingContext = viewModel = new LibInfoViewModel(this);

		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			//var position = new Position(Replace.libraryInfo.Latitude, Replace.libraryInfo.Longitude); // Latitude, Longitude
			
			var pin = new Pin
			{
				Type = PinType.Place,
				//Position = position,
				//Label = Replace.libraryInfo.Name,
				//Address = Replace.libraryInfo.StreetAddress
			};

			
			MyMap.Pins.Add(pin);


			//MyMap.MoveToRegion(
				//MapSpan.FromCenterAndRadius(
					//position, Distance.FromMiles(.2)));
			
			
		}
	}
}
