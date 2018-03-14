using System;
using Xamarin.Forms;
using Library.Helpers;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Library
{
    public class LibCardViewModel:ViewModelBase,INotifyPropertyChanged 
	{
		Database db = new Database();



        public string LibrarycardValue { get; set; }
        private string CardValue;
        public ZXing.BarcodeFormat barcodeType { get; set; }
        public LibInfo.RootObject lib { get; set; } 
        public string cardValue
        {
            get
            {
                return  CardValue;
            }
            set
            {                
                CardValue = value;
                if (!string.IsNullOrEmpty(CardValue))
                {
                    try
                    {
                        if (!lib.CharAllowed)
                        {
                            if (!Regex.IsMatch(CardValue, "^[0-9]{0,14}$"))
                            {
                                throw new Exception("Please Entry 14 Digits");
                            }
                        }
                        LibrarycardValue =  lib.BarcodeStar+ CardValue + lib.BarcodeEnd;


                    }
                    catch (Exception ex)
                    {
                        page.DisplayAlert("Warning", ex.Message, "Ok");
                    }
                    finally
                    {
                        OnPropertyChanged("LibrarycardValue");
                    }
                }

            }
        }

        public LibCardViewModel(LibInfo.RootObject libinfo, Page page):base(page)
		{
           
            lib = libinfo;
            barcodeType = (ZXing.BarcodeFormat) Enum.Parse(typeof(ZXing.BarcodeFormat),libinfo.Barcodetype);

		}

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Command saveBarCodeCommand;

        public Command SaveBarCodeCommand{

            get
            {
                return saveBarCodeCommand ?? 
                    (saveBarCodeCommand = new Command(async () => await ExecuteSaveCardCommand()));
            }

        }


        private async Task ExecuteSaveCardCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            saveBarCodeCommand.ChangeCanExecute();
            try
            {
                if (!lib.CharAllowed)
                {
                    if (!Regex.IsMatch(CardValue, "^[0-9]{14}$"))
                    {
                        throw new Exception("Please Entry 14 Digits");
                    }
                }
                await db.AddlibCard(cardValue);
                await page.DisplayAlert("", "Card Number Saved", "Ok");
            }
            catch(Exception ex)
            {
                await page.DisplayAlert("Warning", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
                saveBarCodeCommand.ChangeCanExecute();

            }
                              
        }

		private Command getCardCommard;
		public Command GetCardCommand
		{
			get
			{
				return getCardCommard ??
                    (getCardCommard = new Command(async () => await ExecuteGetCardCommand()));
			}
		}

     

        private async Task ExecuteGetCardCommand()
		{
			if (IsBusy)
				return;
			IsBusy = true;
			GetCardCommand.ChangeCanExecute();
			try
			{
                CardValue = await db.GetlibraryCardItem();
                OnPropertyChanged("cardValue");
			}
			catch (Exception ex)
			{
                var message = ex.Message;
			}
            finally
            {
                IsBusy = false;
                getCardCommard.ChangeCanExecute();
            }
			
		}


    }
}
