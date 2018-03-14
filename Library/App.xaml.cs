using System;
using Xamarin.Forms;
using System.Collections.Generic;
using ZXing.Net.Mobile.Forms;
using Library.Views;
using Plugin.EmbeddedResource;
using Newtonsoft.Json;
using System.Reflection;

namespace Library
{
	public partial class App : Application
	{
        Database database = new Database();
		public App()
		{
			InitializeComponent();
            try
            {
                
                var libname = database.GetlibraryName();

                var json = ResourceLoader.GetEmbeddedResourceString(Assembly.Load(new AssemblyName("Library")),LibInfo.LibraryList[libname.LibraryName]);
                var lib = JsonConvert.DeserializeObject<LibInfo.RootObject>(json);
                MainPage = new LoadPage(lib);
            }
            catch (Exception)
            {
               MainPage = new LoadPage();
            }
		}

		protected  override  void  OnStart()
		{
			//NewsViewModel viewModel = new NewsViewModel();
			//viewModel.GetNewsCommand.Execute(null);
			//GetCalendersCommand
			// Handle when your app starts

		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
		public void UITestBackdoorScan(string param)
		{
			var expectedFormat = ZXing.BarcodeFormat.CODE_128;
			Enum.TryParse(param, out expectedFormat);
			var opts = new ZXing.Mobile.MobileBarcodeScanningOptions
			{
				PossibleFormats = new List<ZXing.BarcodeFormat> { expectedFormat }
			};

			System.Diagnostics.Debug.WriteLine("Scanning " + expectedFormat);

			var scanPage = new ZXingScannerPage(opts);
			scanPage.OnScanResult += (result) =>
			{
				scanPage.IsScanning = false;

				Device.BeginInvokeOnMainThread(() =>
				{
					var format = result?.BarcodeFormat.ToString() ?? string.Empty;
					var value = result?.Text ?? string.Empty;

					MainPage.Navigation.PopAsync();
					MainPage.DisplayAlert("Barcode Result", format + "|" + value, "OK");
				});
			};

			MainPage.Navigation.PushAsync(scanPage);
		}
	}
}

