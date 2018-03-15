using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Plugin.EmbeddedResource;
using Xamarin.Forms;
using PCLStorage;
namespace Library
{
    public class PickerPage : ContentPage
    {
        
        Database database = new Database();
        IFolder rootFolder = FileSystem.Current.LocalStorage;
        LibInfo.RootObject lib = new LibInfo.RootObject();
        Picker picker = new Picker()
        {
            Title = "Select your Library",
            VerticalOptions = LayoutOptions.CenterAndExpand

        };
        StackLayout stackLayout = new StackLayout();
        Label header = new Label
        {
            Text = "Welcome",
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            HorizontalOptions = LayoutOptions.Center
        };

        Label title = new Label
        {
            Text = "It looks like this is the first time you’ve opened the Library App.  We need to know which library you would like to access.  Please choose your home library from the list below.  We will remember your selection each time you open the Library App.  If you select the wrong library by accident, or move and need to set your home library to a different library, this can be don at any time inside of the Settings page.",
            FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),

            HorizontalOptions = LayoutOptions.Center
        };

        Image image = new Image
        {

            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Start
        };

        Button launch = new Button
        {
            Text = "Enter",
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.StartAndExpand
        };
        public PickerPage()
        {
            
           
            stackLayout.Children.Add(header);

            stackLayout.Children.Add(title);

            stackLayout.Children.Add(picker);
            foreach (string libName in LibInfo.LibraryList.Keys)
            {
                picker.Items.Add(libName);
            }
           
           
            stackLayout.Children.Add(launch);
            picker.SelectedIndexChanged += (sender, args) =>
            {
                if (picker.SelectedIndex == -1)
                {
                    DisplayAlert("Warning", "Please select one Library", "Ok");
                }
                else
                {
                    string libname = picker.Items[picker.SelectedIndex];
                    if(stackLayout.Children.Contains(title))
                    {
                        stackLayout.Children.Remove(title);
                        stackLayout.Children.Insert(1, image);
                    }
                    var json = ResourceLoader.GetEmbeddedResourceString(Assembly.Load(new AssemblyName("Library")), LibInfo.LibraryList[libname]);
                    lib = JsonConvert.DeserializeObject<LibInfo.RootObject>(json);
                    image.Source = ImageSource.FromResource(LibInfo.Imagefolderclinetlogos + lib.Items[0].image, typeof(PickerPage));
                    image.WidthRequest = 320;
                    image.HeightRequest = 135;
                }
            };
            launch.Clicked += OnbuttonClicked;
            Title = "Librarys";
            BackgroundColor = Color.White;
            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
            Content = stackLayout;
        }
        async void deletefile()
        {
            IFolder folder = await rootFolder.CreateFolderAsync("Library", CreationCollisionOption.OpenIfExists);
            // create a file, overwriting any existing fileMySubFolder
            IFile Calendarfile = await folder.CreateFileAsync("Calendar.json", CreationCollisionOption.OpenIfExists);
            await folder.DeleteAsync();
           
        }
        void OnbuttonClicked(object sender, EventArgs e)
        {
            if (picker.SelectedItem != null)
            {
                database.DeleteAlltable();
                deletefile();
                Application.Current.MainPage = new LoadPage(lib);
                database.Addlibrary(lib);
            }
            else
            {
                DisplayAlert("Warning", "Please select one Library", "Ok");
            }

        }
    }
}

//ToolbarItems.Add(new ToolbarItem
//{
//    Text = "back",
//    Command = new Command(async (obj) =>
//    {
//        await Navigation.PopAsync();
//    })


//});