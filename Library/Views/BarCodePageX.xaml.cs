using System;
using System.Collections.Generic;
using ZXing.Net.Mobile.Forms;
using Xamarin.Forms;
using System.Text.RegularExpressions;
namespace Library
{
	public partial class BarCodePageX : ContentPage
	{
		//Database db = new Database();
		//ZXingScannerPage scanPage;
		private LibCardViewModel viewModel;
        //string cardValue="Tap '+' and scan your card.";
        //string cardValue = "";

        public BarCodePageX(LibInfo.RootObject lib)
		{
			
			InitializeComponent();
            BindingContext = viewModel = new LibCardViewModel(lib, this);
			
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
            viewModel.GetCardCommand.Execute(null);
           
		}
	}
}


//scrollview.BackgroundColor = Replace.backGroundcolor;
//ButtonAdd.Clicked += async delegate
//{
//  scanPage = new ZXingScannerPage();
//  scanPage.OnScanResult += (result) =>
//  {
//      scanPage.IsScanning = false;

//      Device.BeginInvokeOnMainThread(() =>
//      {
//          Navigation.PopAsync();

//          DisplayAlert("Scanned Barcode", result.Text, "OK");
//          cardValue = result.Text;
//          db.AddlibCard(result.Text);
//      });
//  };
//  try
//  {
//      BindingContext = viewModel = new LibCardViewModel(cardValue, this);
//  }
//  catch (Exception ex)
//  {

//  }
//  await Navigation.PushAsync(scanPage);
//};


//try
//{
//cardValue = db.GetlibraryCardItem();
//}
//catch (Exception ex)
//{

//}



//button.Clicked +=  delegate
//{
//if (Entry1.Text != "" && Regex.IsMatch(Entry1.Text, "^[0-9]{14}$"))
//{
//      try
//      {

//          BindingContext = viewModel = new LibCardViewModel(Entry1.Text, this);
//          db.AddlibCard(Entry1.Text);
//      }
//      catch (Exception ex)
//      {

//      }
//  }
//  else
//  {

//DisplayAlert("", "Please Entry 14 Digits", "OK");
//  }

//};
//try
//{

//  cardValue = db.GetlibraryCardItem();
//}
//catch (Exception ex)
//{

//}
//finally
//{
//  BindingContext = viewModel = new LibCardViewModel(cardValue, this);
//}
//