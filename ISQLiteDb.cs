using System;
using System.Collections.Generic;
using System.Text;


namespace ProiectMobile
{
    public interface ISQLiteDb
    {
        SQLite.SQLiteConnection DbConnection();
    }
}
