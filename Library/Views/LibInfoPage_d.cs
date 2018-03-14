using System;

using Xamarin.Forms;

using System.Collections.Generic;
using Plugin.ExternalMaps;
using Plugin.Messaging;
using Library.Helpers;
using Xamarin.Forms.Maps;

namespace Library
{
    public class LibInfoPage_d : ContentPage
    {
        LibInfo.RootObject libInfo { get; set; }

        private LibInfoViewModel viewModel;
        private List<Grid> gridlist = new List<Grid>();
        private List<Map> Maplist = new List<Map>();
        public LibInfoPage_d(LibInfo.RootObject lib)
        {
            
            libInfo = lib;

#region Grid Interface
            for (int i = 0; i < libInfo.Items.Count; i++)
            {
                var controlgrid = new Grid
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    RowSpacing = 10,
                    ColumnSpacing = 5,
                    Padding = new Thickness(5, 0, 5, 0),
                    BackgroundColor = Color.White,
                    RowDefinitions =
                    {
                    new RowDefinition{Height= GridLength.Auto},
                    new RowDefinition{Height= GridLength.Auto},
                    new RowDefinition{Height= GridLength.Auto},
                    new RowDefinition{Height= GridLength.Auto},
                    new RowDefinition{Height= GridLength.Auto},
                    new RowDefinition{Height= GridLength.Auto},
                    new RowDefinition{Height= GridLength.Auto},
                    new RowDefinition{Height= GridLength.Auto},
                    new RowDefinition{Height= GridLength.Auto},
                    new RowDefinition{Height= GridLength.Auto},
                    new RowDefinition{Height= GridLength.Auto},
                    new RowDefinition{Height= GridLength.Auto},
                    new RowDefinition{Height= GridLength.Auto},
                    new RowDefinition{Height= GridLength.Auto},
                   
                    new RowDefinition{Height= new GridLength(300,GridUnitType.Absolute)}
                    },
                    ColumnDefinitions =
                    {
                    new ColumnDefinition{Width = new GridLength(.475,GridUnitType.Star)},
                    new ColumnDefinition{Width = new GridLength(.05,GridUnitType.Star)},
                    new ColumnDefinition{Width = new GridLength(.475,GridUnitType.Star)}
                    }

                };
                controlgrid.Children.Add(new Image
                {
                    
                    VerticalOptions = LayoutOptions.CenterAndExpand,HorizontalOptions = LayoutOptions.CenterAndExpand,
                    WidthRequest = libInfo.Items[i].image != string.Empty ? 320 : 0,
                    HeightRequest = libInfo.Items[i].image != string.Empty ? 130 : 0,
                    Source =  ImageSource.FromResource(LibInfo.Imagefolderclinetlogos + lib.Items[i].image, typeof(LibInfoPage_d)),

                }, 0, 3, 0, 1);
                controlgrid.Children.Add(new Label
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Text = libInfo.Items[i].branchName,
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),

                }, 0, 3, 1, 2);

            


                controlgrid.Children.Add(new Button
                {
                    CommandParameter = i,
                    Command = new Command(o =>
                    {
                        
                        var phoneCallTask = CrossMessaging.Current.PhoneDialer;
                        if (phoneCallTask.CanMakePhoneCall)
                            phoneCallTask.MakePhoneCall(libInfo.Items[int.Parse(o.ToString())].phoneNumber.CleanPhone());
                    }),
                    Text = string.Format("Call:{0}",
                                         libInfo.Items[i].phoneNumber),
                    Image = "phone.png",
                    TextColor = Color.FromHex(libInfo.TextColor),
                    CornerRadius = 1,
                    BackgroundColor = Color.FromHex(libInfo.backGroundColor),
                    BorderColor = Color.FromHex(libInfo.borderColor),

                },0,1,2,3);
                controlgrid.Children.Add(new Label
                {
                   
                    Text = string.Format("Fax:{0}",libInfo.Items[i].Fax),

                    TextColor = Color.FromHex(libInfo.TextColor),
                   
                    BackgroundColor = Color.FromHex(libInfo.backGroundColor),
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.End

                }, 2, 3, 2, 3);
                controlgrid.Children.Add(new Button
                {
                    CommandParameter = i,

                    Command = new Command(o =>
                    {
                        Device.OpenUri(new Uri("mailto:" + libInfo.Items[int.Parse(o.ToString())].email ));
                    }),
                    Text = libInfo.Items[i].email,

                    TextColor = Color.FromHex(libInfo.TextColor),
                    CornerRadius = 1,
                    BackgroundColor = Color.FromHex(libInfo.backGroundColor),
                    BorderColor = Color.FromHex(libInfo.borderColor),
                },0,3,3,4);

                controlgrid.Children.Add(new Label
                {

                    Text = "Library Hours",

                    TextColor = Color.FromHex(libInfo.backGroundColor),
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    FontAttributes = FontAttributes.Bold,


                }, 0, 3, 4, 5);

                controlgrid.Children.Add(new Label
                {

                    Text = "Monday",

                    VerticalOptions = LayoutOptions.Center,
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    FontAttributes = FontAttributes.Bold,


                }, 0, 2, 5, 6);
                controlgrid.Children.Add(new Label
                {

                    Text =string.Format("{0} - {1}", 
                                        libInfo.Items[i].Time.MondayOpen,
                                        libInfo.Items[i].Time.MondayClose),

                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),

                    HorizontalOptions = LayoutOptions.End,

                }, 2, 3, 5, 6);
                controlgrid.Children.Add(new Label
                {

                    Text = "Tuesday",

                    VerticalOptions = LayoutOptions.Center,
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    FontAttributes = FontAttributes.Bold,


                }, 0, 2, 6, 7);
                controlgrid.Children.Add(new Label
                {

                    Text = string.Format("{0} - {1}", 
                                         libInfo.Items[i].Time.TuesdayOpen, 
                                         libInfo.Items[i].Time.TuesdayClose),

                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),

                    HorizontalOptions = LayoutOptions.End,

                }, 2, 3, 6, 7);
                controlgrid.Children.Add(new Label
                {

                    Text = "Wednesday",

                    VerticalOptions = LayoutOptions.Center,
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    FontAttributes = FontAttributes.Bold,


                }, 0, 2, 7, 8);
                controlgrid.Children.Add(new Label
                {

                    Text = string.Format("{0} - {1}", 
                                         libInfo.Items[i].Time.WednesdayOpen, 
                                         libInfo.Items[i].Time.WednesdayClose),
                    
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                  
                    HorizontalOptions = LayoutOptions.End,

                }, 2, 3, 7, 8);

                controlgrid.Children.Add(new Label
                {

                    Text = "Thursday",

                    VerticalOptions = LayoutOptions.Center,
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    FontAttributes = FontAttributes.Bold,


                }, 0, 2, 8, 9);
                controlgrid.Children.Add(new Label
                {

                    Text = string.Format("{0} - {1}", 
                                         libInfo.Items[i].Time.ThursdayOpen, 
                                         libInfo.Items[i].Time.ThursdayClose),
                  
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),

                    HorizontalOptions = LayoutOptions.End,

                }, 2, 3, 8, 9);
                controlgrid.Children.Add(new Label
                {

                    Text = "Friday",
                    VerticalOptions = LayoutOptions.Center,
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    FontAttributes = FontAttributes.Bold,


                }, 0, 2, 9, 10);
                controlgrid.Children.Add(new Label
                {

                    Text = string.Format("{0} - {1}", 
                                         libInfo.Items[i].Time.FridayOpen, 
                                         libInfo.Items[i].Time.FridayClose),
                
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),

                    HorizontalOptions = LayoutOptions.End,

                }, 2, 3, 9, 10);

                controlgrid.Children.Add(new Label
                {

                    Text = "Saturday",
                    VerticalOptions = LayoutOptions.Center,
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    FontAttributes = FontAttributes.Bold,


                }, 0, 2, 10, 11);
                controlgrid.Children.Add(new Label
                {

                    Text = string.Format("{0} - {1}", 
                                         libInfo.Items[i].Time.SaturdayOpen, 
                                         libInfo.Items[i].Time.SaturdayClose),

                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),

                    HorizontalOptions = LayoutOptions.End,

                }, 2, 3, 10, 11);

                controlgrid.Children.Add(new Label
                {

                    Text = "Sunday",
                    VerticalOptions = LayoutOptions.Center,
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    FontAttributes = FontAttributes.Bold,


                }, 0, 2, 11, 12);
                controlgrid.Children.Add(new Label
                {

                    Text = string.Format("{0} - {1}", 
                                         libInfo.Items[i].Time.SundayOpen, 
                                         libInfo.Items[i].Time.SundayClose),

                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                   
                    HorizontalOptions = LayoutOptions.End,

                }, 2, 3, 11, 12);

                controlgrid.Children.Add(new Label
                {

                    Text = "Location",
                    VerticalOptions = LayoutOptions.Center,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    FontAttributes = FontAttributes.Bold,
                    TextColor = Color.FromHex(libInfo.backGroundColor)


                }, 0, 3, 12, 13);

                controlgrid.Children.Add(new Button
                {
                    CommandParameter = libInfo.Items[i],
                    Command = new Command<LibInfo.Item>(obj => 
                                                        CrossExternalMaps.Current.NavigateTo(
                                                            obj.branchName, 
                                                            obj.Latitude,
                                                            obj.Longitude)),
                    Text = "Navigate",
                    Image ="navigation.png",
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    TextColor = Color.FromHex(libInfo.TextColor),
                    CornerRadius = 1,
                    BackgroundColor = Color.FromHex(libInfo.backGroundColor),
                    BorderColor = Color.FromHex(libInfo.borderColor)
                }, 0, 1, 13, 14);


                controlgrid.Children.Add(new Label
                {

                    Text = string.Format(" {0} {4} {1}, {2} {3}", 
                                         libInfo.Items[i].Address.Street,
                                         libInfo.Items[i].Address.City, 
                                         libInfo.Items[i].Address.State, 
                                         libInfo.Items[i].Address.zipCode, 
                                         Environment.NewLine),
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),


                }, 1, 3, 13, 14);
                var map = new Map()
                {
                    IsShowingUser = true,
                    MapType = MapType.Hybrid,
                };
                controlgrid.Children.Add(map, 0, 3, 14, 15);
                gridlist.Add(controlgrid);
                Maplist.Add(map);
            }
#endregion


            ToolbarItems.Add(new ToolbarItem
            {
                Text = "Setting",
                Command = new Command(async (obj) =>
                {
                    await Navigation.PushAsync(new PickerPage());
                })
                                      
                    
            });
            var stack = new StackLayout();
            for (int i = 0; i < libInfo.Items.Count; i++)
            {
                stack.Children.Add(gridlist[i]);
            }
            Content = new ScrollView
            {
                Padding = new Thickness(5, 10, 5, 5),
                BackgroundColor = Color.FromHex(libInfo.backGroundColor),
                Content = stack
            };
           
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            for (int i = 0; i < libInfo.Items.Count; i++)
            {
                var position = new Position(libInfo.Items[i].Latitude, libInfo.Items[i].Longitude); // Latitude, Longitude
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = position,
                    Label = libInfo.Items[i].branchName,
                    Address = libInfo.Items[i].Address.Street,
                };


                Maplist[i].Pins.Add(pin);
                Maplist[i].MoveToRegion(
                    MapSpan.FromCenterAndRadius(
                        position, Distance.FromMiles(.2)));
            }
        }
    }
}

