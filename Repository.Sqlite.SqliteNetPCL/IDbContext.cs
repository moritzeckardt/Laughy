using SQLite;
using System.Threading.Tasks;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL
{
    public interface IDbContext
    {
        //Properties
        SQLiteAsyncConnection Database { get; set; }


        //Methods
        Task Init();
    }
}
