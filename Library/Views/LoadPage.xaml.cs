using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Library
{
    public partial class LoadPage : ContentPage
    {
        LibInfo.RootObject libary = new LibInfo.RootObject();
        readonly IDataStore dataStore;
        public LoadPage()
        {
            InitializeComponent();

            var assembly = typeof(LoadPage);

            logoEtangibles.Source = ImageSource.FromResource("Library.Assets.AppImages.logo_eTangibles_white_letters.png", assembly);
            logoTheLibraryApp.Source = ImageSource.FromResource("Library.Assets.AppImages.logo_the_library_app_full.png", assembly);

        }
        public LoadPage(LibInfo.RootObject lib)
        {
            InitializeComponent();
            dataStore = DependencyService.Get<IDataStore>();
            var assembly = typeof(LoadPage);
            libary = lib;
            logoEtangibles.Source = ImageSource.FromResource("Library.Assets.AppImages.logo_eTangibles_white_letters.png", assembly);
            logoTheLibraryApp.Source = ImageSource.FromResource(LibInfo.Imagefolderclinetlogos+lib.Items[0].image, assembly);
            loading();
        }
        protected async void loading()
        {
            try
            {
                LibInfo.NewUrl = libary.NewUrl;
                LibInfo.Backgroundcolor = libary.tobackgroundColor();
                var url = string.Format(libary.CalendarUrl, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                await dataStore.SyncNewsAsync();
                await dataStore.SyncCalendarAsync(url);
            }
            catch (Exception)
            {

                await DisplayAlert("Uh oh :(", "Unable to get locations", "OK");

            }
        }
        protected override async void OnAppearing()
        {
            //spacingLabel.Text = "";
            //statusLabel.Text = "Updating Content";
            await MainProgressBar.ProgressTo(0.5, 500, Easing.Linear);
            await MainProgressBar.ProgressTo(0.9, 900, Easing.Linear);
            await MainProgressBar.ProgressTo(1, 1000, Easing.Linear);
            if (!string.IsNullOrEmpty(libary.LibName))
            {
               
                Application.Current.MainPage = new MainTabPage(libary);
            }
            else
                Application.Current.MainPage = new NavigationPage(new PickerPage());
              
        }
    }
}