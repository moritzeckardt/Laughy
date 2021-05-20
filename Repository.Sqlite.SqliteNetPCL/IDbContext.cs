using SQLite;
using System.Threading.Tasks;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL
{
    public interface IDbContext
    {
        //Properties
        SQLiteConnection Database { get; set; }


        //Methods
        Task Init();
    }
}
