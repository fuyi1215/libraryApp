using System;
using Xamarin.Forms;
using Library.Model;
using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using XamForms.Controls;
using System.Collections.Generic;
using Library.Views.CollapseListView;
using System.ComponentModel;

namespace Library
{
   
    public class CalendarViewModel :ViewModelBase
	{

        private ObservableRangeCollection<SpecialDate> calendarList;
       
        public ObservableRangeCollection<SpecialDate> CalendarList
        {
            get 
            { 
                return calendarList; 
            }
            set 
            { 
                calendarList = value;
                OnPropertyChanged(nameof(CalendarList));
            }
        }
  
		public List<EntityClass> Entity { get; set;}
        public DateTime Todaydate { get; set; } = DateTime.Today;  
		//public bool ForceSync { get; set; }
		readonly IDataStore dataStore;
        public CalendarViewModel(Page page):base(page)
		{
			dataStore = DependencyService.Get<IDataStore>();
			CalendarList = new ObservableRangeCollection<SpecialDate>();
            //CalendarListGrouped = new ObservableRangeCollection<Grouping<string, CalendarTable>>();
           
		}
        //public event PropertyChangedEventHandler PropertyChanged;
        //public void NotifyPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
       

		public Action<SpecialDate> ItemSelected { get; set; }
		SpecialDate selectedCalendar;

		public SpecialDate SelectedCalendar
		{
			get { return selectedCalendar; }
			set
			{
				selectedCalendar = value;
				
				if (SelectedCalendar == null)
					return;
				if (ItemSelected == null)
				{
					var nativeListView2 = new ExtendedListView();
					var select = new List<EntityClass>();
					select = Entity.FindAll(r => r.Description.Contains(selectedCalendar.Date.ToString()));

                     
					//view.Navigation.PushAsync(new WebViewPage(SelectedCalendar.htmlLink, false) { Title = selectedCalendar.start });
					
				}
				else
				{
					ItemSelected.Invoke(selectedCalendar);
				}
			}
		}


		Command getDateCommand;
		public Command GetDateCommand
		{
			get
			{
				return getDateCommand ??
					(getDateCommand = 
                     new Command(async () => 
                                 await ExecuteCalendersCommand())
                    );
			}
		}



        public async Task ExecuteCalendersCommand()
		{
			if (IsBusy)
				return;
			IsBusy = true;
            GetDateCommand?.ChangeCanExecute();

			try
			{
				CalendarList.Clear();
				var Event = await dataStore.GetCalendarAsync();

				CalendarList.ReplaceRange(Event.Select(s => { 
					DateTime result = DateTime.MinValue;
					if (DateTime.TryParse(s.start, out result))
					{
						return new SpecialDate(result.Date) 
						{ FontSize = 30, TextColor = Color.Blue, Selectable = true };

					}
					return new SpecialDate(DateTime.MinValue);
				}).ToList());


                //foreach (var e in Event.ToList())
                //{
                //    DateTime result = DateTime.MinValue;
                //    if (DateTime.TryParse(e.start, out result))
                //    {
                //        var Children = new List<EntityClass>();
                //        Children.Add(new EntityClass { Title = string.IsNullOrEmpty(e.description)? string.Empty: e.description});
                //        Entity.Add(new EntityClass
                //        {
                //            Title = String.Format("{0}:  {1}", result.ToString("t"), e.summary),
                //            Description = result.Date.ToString(),
                //            ChildItems = Children
                //        });
                //    }
                //}

			}
			catch (Exception ex)
			{
				//await page.DisplayAlert("Uh Oh :(", "Unable to gather Event.", "OK");
			}
			finally
			{
				IsBusy = false;
                GetDateCommand?.ChangeCanExecute();
               
			}

			//await page.Navigation.PopAsync();

		}

	}
}
