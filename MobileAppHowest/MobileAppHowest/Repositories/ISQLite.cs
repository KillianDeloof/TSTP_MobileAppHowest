using System;
using SQLite;

namespace MobileAppHowest.Repositories
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection(string databaseName);
        long GetSize(string databaseName);
    }
}