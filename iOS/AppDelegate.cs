using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Library.Views.CollapseListView;
using UIKit;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(XamForms.Controls.CalendarButton), typeof(XamForms.Controls.iOS.CalendarButtonRenderer))]
namespace Library.iOS
{
	
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		App formsApp;
		public static Enums.DeviceType DeviceType = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone ? Enums.DeviceType.IPHONE : Enums.DeviceType.IPAD;
		public static double DeviceWidth = UIScreen.MainScreen.Bounds.Width * 2;
		public static double DeviceHeight = UIScreen.MainScreen.Bounds.Height * 2;


		public override UIWindow Window
		{
			get;
			set;
		}
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			


			UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(43, 132, 211); //bar background
			//UINavigationBar.Appearance.TintColor = UIColor.White; //Tint color of button items
			UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
			{
				Font = UIFont.FromName("HelveticaNeue", (nfloat)30f),
				TextColor = UIColor.White
			});

			//TabBar.TintColor = UIColor.White;

			//normalTextAttributes.Font = UIFont.FromName("AmericanTypewriter", 8.0F); // unselected
			//normalTextAttributes.TextColor = UIColor.Green;
			//base.TabBarItem.SetTitleTextAttributes(normalTextAttributes, UIControlState.Selected);


			global::Xamarin.Forms.Forms.Init();
			global::ZXing.Net.Mobile.Forms.iOS.Platform.Init();
			Xamarin.FormsMaps.Init();

			XamForms.Controls.iOS.Calendar.Init();


			//Xamarin.Calabash.Start();
			//formsApp = new App();

			//LoadApplication(formsApp);

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
		//[Export("UITestBackdoorScan:")] // notice the colon at the end of the method name
		//public NSString UITestBackdoorScan(NSString value)
		//{
		//	//formsApp.UITestBackdoorScan(value.ToString());
		//	return new NSString();
		//}
	}
}

