using SQLite;

namespace ContactBase
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

