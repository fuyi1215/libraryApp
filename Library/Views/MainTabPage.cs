

using Newtonsoft.Json;
using PCLStorage;
using Plugin.EmbeddedResource;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Library
{
    class MainTabPage : TabbedPage
	{
        public MainTabPage(LibInfo.RootObject lib)
		{
			


			this.Title = "TabbedPage";
            BarTextColor = lib.toTextColor();
            BarBackgroundColor = lib.tobackgroundColor();
            //this.Children.GetEnumerator.baStyle = Device.Styles.TitleStyle;
            //BindingContext


            var Newspad = new NewsTabletPage() { IsPresented = true, BackgroundColor = lib.tobackgroundColor() };
            if (Device.Idiom != TargetIdiom.Phone)
            {


                this.PropertyChanging += (sender, e) =>
                {

                    if (e.PropertyName == "CurrentPage")
                    {
                        Newspad.IsPresented = true;
                    }
                };


                this.Children.Add(new NavigationPage(Newspad)
                {
                    Title = "News",

                    BarTextColor = lib.toTextColor(),
                    BarBackgroundColor = lib.tobackgroundColor(),
                    BackgroundColor = lib.tobackgroundColor(),
                    Icon = "news_30x30.png"

                });
            }
            else
            {
                this.Children.Add(new NavigationPage(new NewsPhonePage())
                {
                    Title = "News",
                    //Style = Device.Styles.TitleStyle,
                    BarBackgroundColor = lib.tobackgroundColor(),
                    BarTextColor = lib.toTextColor(),
                    BackgroundColor = lib.tobackgroundColor(),
                    Icon = "news_30x30.png"
                });
            }


            this.Children.Add(new NavigationPage(new CalendarPage() { 
                Title = "Events",
                BackgroundColor = lib.tobackgroundColor() })
            {
                Title = "Events",
                BarBackgroundColor = lib.tobackgroundColor(),
                BarTextColor = lib.toTextColor(),
                BackgroundColor = lib.tobackgroundColor(),
                Icon = "calendar_30x30.png"


            });

			
           

            //string Url = "https://evergreen.lib.in.us/eg/opac/home";
            this.Children.Add(new WebViewPage(lib.Catalogs) { 
                Title = "Catalog", 
                BackgroundColor = lib.tobackgroundColor(), 
                Icon = "catalogue_30x30.png" });
            

           

            this.Children.Add(new NavigationPage(new LibInfoPage_d(lib) { 
                Title = "Contacts", 
                BackgroundColor =lib.tobackgroundColor() 
            })
            {
                Title = "Contacts",
                Icon = "contact_30x30.png",
                BarBackgroundColor = lib.tobackgroundColor(),
                BarTextColor = lib.toTextColor(),
                BackgroundColor = lib.tobackgroundColor(),


            });

            this.Children.Add(new NavigationPage(new BarCodePageX(lib) { 
                Title = "Card" })
            {
                Title = "Card",
                Icon = "card_30x30.png",
                BarBackgroundColor = lib.tobackgroundColor(),
                BarTextColor = lib.toTextColor(),
                BackgroundColor = lib.tobackgroundColor()


            });

			

			

			
			//{

			//	Title = "Catalog",

			//	BarBackgroundColor = Replace.backGroundcolor,
			//	BarTextColor = Replace.BarTextColor,
			//	//BackgroundColor = Replace.BarTextColor

			//});

			

			
				//this.Children.Add(new NavigationPage(new ScanListView { Title = "ScanView" })
				//{
				//	Title = "ScanView",
				//	BarBackgroundColor = Color.FromHex("#24678d"),
				//	BarTextColor = Color.White,
				//	BackgroundColor = Color.White
				//});

		}
	}
}




