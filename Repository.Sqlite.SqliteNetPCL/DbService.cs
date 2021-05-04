using Laughy.Data.Repository.Sqlite.SqliteNetPCL.DbModels;
using SQLite;
using System.Collections.Generic;
using System.IO;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL
{
    public class DbService : IDbService
    {
        //Fields
        private readonly string _dbPath;


        //Properties
        public SQLiteAsyncConnection Database { get; set; }


        //Constructor
        public DbService(string dbPath)
        {
            _dbPath = dbPath;
        }


        //Methods
        public void Init()
        {
            if (Database != null)
                return;

            bool checkFile = File.Exists(_dbPath);  //Checking

            //Dropping tables
            List<string> tables = new List<string> {"JokeDbModel"};

            foreach (string table in tables)
            {
                using (var dbConnection = new SQLiteConnection(_dbPath))
                {
                    SQLiteCommand command = new SQLiteCommand(dbConnection);
                    command.CommandText = string.Format("DROP TABLE {0};", table);
                    command.ExecuteNonQuery();
                }
            }

            Database.CreateTableAsync<JokeDbModel>();
        }
    }
}
