using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(Library.iOS.SQLite_iOS))]

namespace Library.iOS
{
	public class SQLite_iOS : ISQLite
	{
		public SQLite_iOS()
		{
			
		}
		#region ISOLite implementation
		public SQLite.SQLiteConnection GetConnection()
		{	
			var filename = "database.db3";
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var LibraryPath = Path.Combine(documentsPath, "..", "Library");

			var path = Path.Combine(LibraryPath, filename);

			var connection = new SQLite.SQLiteConnection(path, true);

			return connection;
		}

		#endregion
	}

}

