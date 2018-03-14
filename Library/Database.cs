using System;
using SQLite;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using Library.Model;
using System.Threading.Tasks;

namespace Library
{
	public class Database
	{
		private SQLiteConnection _connection;

		public Database()
		{
			_connection = DependencyService.Get<ISQLite>().GetConnection();
			_connection.CreateTable<NewsListItem>();
			_connection.CreateTable<CalendarTable>();
			_connection.CreateTable<libcard>();
            _connection.CreateTable<libname>();

		}
		public Task AddlibCard(string libcardvalue)
		{
			libcard libc = new libcard();
			_connection.DeleteAll<libcard>();

				libc.LibrarycardValue = libcardvalue;
            return Task.Run(()=>(_connection.Insert(libc)));

		}
        public Task<string> GetlibraryCardItem()
        {

            return Task.Run(() => (from t in _connection.Table<libcard>()
                                   select t).First().LibrarycardValue);

        }

        public void DeleteAlltable()
        {
            _connection.DeleteAll<libcard>();
            _connection.DeleteAll<NewsListItem>();
            _connection.DeleteAll<CalendarTable>();
            _connection.DeleteAll<libname>();

        }
        public Task Addlibrary(LibInfo.RootObject lib)
        {
            libname libn = new libname();
            _connection.DeleteAll<libname>();
            libn.LibraryName = lib.LibName;
            return Task.Run(() => (_connection.Insert(libn)));
        }
		
        public libname GetlibraryName()
        {
            return  (from t in _connection.Table<libname>()
                                   select t).First();
        }
		public Task AddCalendarItems(CalendarInfo.RootObject rootObject)
		{
			if (rootObject.items.Count > 100)
			{
				_connection.DeleteAll<CalendarTable>();
			}
			foreach (var items in rootObject.items)
			{
				
				if (items != null)
				{

					var Citem = new CalendarTable(items);
					{
						if (!_connection.Table<CalendarTable>().Any(x => x.id == Citem.id))
						{
							_connection.Insert(Citem);
						}
						else
						{
							_connection.Update(Citem);
						}
					}
				
				}
			}
			return Task.Run(() => rootObject);

		}
		public NewsListItem GetNewsListItem()
		{
			if (_connection.Table<NewsListItem>().Count() > 0)
			{
				return (from t in _connection.Table<NewsListItem>()
						orderby t.id descending
						select t).FirstOrDefault();
			}
			else
			{
				return new NewsListItem();
			}
		}
		public IEnumerable<CalendarTable> GetCalendarItems()
		{
			return (from t in _connection.Table<CalendarTable>()
					select t).ToList();
		}

		public  IEnumerable<NewsListItem> GetNewListItems() 
		{
			return (from t in _connection.Table<NewsListItem>()
			                       select t).ToList();
		}
		public void AddNewListItem(NewsListItem item)
		{
			 _connection.Insert(item);
		}

		public Task AddNewListItems(libNewsBlog.RootObject rootObject)
		{
			//_connection.Dispose();
			//var a = rootObject.items.Count;
			_connection.DeleteAll<NewsListItem>();
			foreach (var i in rootObject.items)
			{
				
					var Newitem = new NewsListItem(i);
					{
						if (!_connection.Table<NewsListItem>().Any(x => x.id == Newitem.id))
 							 _connection.Insert(Newitem);
					   else
							 _connection.Update(Newitem);
					}

			}
			return Task.Run(() => rootObject);
		 }

		public  Task updateListItems(IEnumerable<NewsListItem> items)
		{
			return Task.Run(()=>_connection.UpdateAll(items));
		}



	}
}

