using SQLite;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL
{
    public interface IDbContext
    {
        //Properties
        SQLiteAsyncConnection Database { get; set; }


        //Methods
        void Init();
    }
}
