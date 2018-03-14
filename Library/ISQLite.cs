using System;
using SQLite;
namespace Library
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

