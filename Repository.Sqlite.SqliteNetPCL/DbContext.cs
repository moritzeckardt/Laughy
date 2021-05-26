using Laughy.Data.Repository.Sqlite.SqliteNetPCL.DbModels;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL
{
    public class DbContext : IDbContext
    {
        //Fields
        private readonly string _dbPath;


        //Properties
        public SQLiteConnection Database { get; set; }


        //Constructor
        public DbContext(string dbPath)
        {
            _dbPath = dbPath;
        }


        //Methods
        public async Task Init()
        {
            if (Database != null)
                return;

            bool checkFile = File.Exists(_dbPath);  //Checking

            Database = new SQLiteConnection(_dbPath);

            bool checkFile2 = File.Exists(_dbPath);  //Checking

            //Dropping tables
            List<string> tables = new List<string> { "JokeDbModel" };

            foreach (string table in tables)
            {
                using (var dbConnection = new SQLiteConnection(_dbPath))
                {
                    SQLiteCommand command = new SQLiteCommand(dbConnection);
                    command.CommandText = string.Format("DROP TABLE {0};", table);
                    command.ExecuteNonQuery();
                }
            }

            //Creating tables
            Database.CreateTable<JokeDbModel>();
        }
    }
}
