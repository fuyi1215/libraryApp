using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(Library.Droid.SQLite_Android))]
namespace Library.Droid
{
	public class SQLite_Android : ISQLite
	{
		public SQLite_Android()
		{
		}
		#region ISOLite implementation
		public SQLite.SQLiteConnection GetConnection()
		{
			var filename = "database.db3";
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var path = Path.Combine(documentsPath, filename);

			var connection = new SQLite.SQLiteConnection(path, true);

			return connection;
		}

		#endregion
	}
}

