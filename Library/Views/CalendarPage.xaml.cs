using System;
using System.Collections.Generic;
using XamForms.Controls;
using Xamarin.Forms;
using Library.Views.CollapseListView;
using System.Threading.Tasks;
using static System.DateTime;
using MvvmHelpers;


namespace Library
{
    public partial class CalendarPage : ContentPage
	{

        public IEnumerable<CalendarTable> CalenderEvents = new List<CalendarTable>();
        public List<EntityClass> Enity2 { get; set; }
        List<SpecialDate> listday;
        public bool ForceSync { get; set; }
        readonly IDataStore dataStore;

        Calendar calendar;
        public CalendarPage()
        {
            InitializeComponent();
            dataStore = DependencyService.Get<IDataStore>();
            displayAsync();
        }
        public async void displayAsync()
        {
            var nativeListView2 = new ExtendedListView()
            {
                BackgroundColor = Color.White
            };
            var MainView = new StackLayout()
            {
                BackgroundColor = LibInfo.Backgroundcolor

            };

            CalenderEvents = await dataStore.GetCalendarAsync();
            Enity2 = new List<EntityClass>();

            DateTime before = DateTime.MinValue;
            listday = new List<SpecialDate>();
            foreach (var Event in CalenderEvents)
            {

                DateTime result;

                if (DateTime.TryParse(Event.start, out result))
                {
                    if (!before.Date.Equals(result.Date))
                    {
                        before = result.Date;
                        listday.Add(new SpecialDate(result.Date) { FontSize = 30, TextColor = Color.Blue, Selectable = true });
                    }
                }

                var Children = new List<EntityClass>();
                Children.Add(new EntityClass { Title = Event.description });
                Enity2.Add(new EntityClass { Title = String.Format("{0}:  {1}", result.ToString("t"), Event.summary), Description = result.Date.ToString(), ChildItems = Children });

            }
            calendar = new Calendar
            {
                MinDate = DateTime.Now,
                DisableAllDates = false,
                MultiSelectDates = false,
                SelectedTextColor = Color.Fuchsia,
                StartDate = DateTime.Today,
                SpecialDates = listday,
                BackgroundColor = Color.White

            };

            MainView.Padding = new Thickness(5, Device.OS == TargetPlatform.iOS ? 25 : 5, 5, 5);

            MainView.Children.Add(calendar);

            calendar.DateClicked += (sender, e) =>
            {

                System.Diagnostics.Debug.WriteLine(calendar.SelectedDates);
                //REQUIRED: To share a scrollable view with other views in a StackLayout, it should have a VerticalOptions of FillAndExpand.


                if (MainView.Children.Contains(nativeListView2))
                {
                    MainView.Children.Remove(nativeListView2);
                    nativeListView2 = new ExtendedListView() { BackgroundColor = Color.White };
                }

                nativeListView2.VerticalOptions = LayoutOptions.FillAndExpand;
                var select = new List<EntityClass>();
                select = Enity2.FindAll(r => r.Description.Contains(e.DateTime.Date.ToString()));
                nativeListView2.Items = select;

                MainView.Children.Add(nativeListView2);

            };
            if (Device.OS == TargetPlatform.iOS)
            {
                MainView.BackgroundColor = Color.White;
                ScrollView scrollView = new ScrollView()
                {
                    Content = MainView,
                    Padding = new Thickness(5,0,5, 0)
                };
                Content = scrollView;
            }
            else
                Content = MainView;
            
        }



           

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //calendar.SelectedDate = DateTime.Today;
            displayAsync();
        }





	}
}

