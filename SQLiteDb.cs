using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using ProiectMobile.Droid;

[assembly: Dependency(typeof(SQLiteDb))]

namespace ProiectMobile.Droid
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteConnection DbConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "UserDb.db3");

            return new SQLiteConnection(path);
        }
    }
}