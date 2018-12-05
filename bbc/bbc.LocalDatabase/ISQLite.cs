using System;

namespace bbc.LocalDatabase
{
    public interface ISQLite
    {
        SQLite.SQLiteConnection GetConnection();
    }
}
