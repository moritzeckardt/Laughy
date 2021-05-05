using SQLite;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL
{
    public interface IDbService
    {
        //Properties
        SQLiteAsyncConnection Database { get; set; }


        //Methods
        void Init();
    }
}
