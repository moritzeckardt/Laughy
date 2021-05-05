using SQLite;
using System;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL.DbModels
{
    public class JokeDbModel
    {
        //Properties
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }
        public string Joke { get; set; } // type: single
        public string Setup { get; set; } // type: two part
        public string Delivery { get; set; } // type: two part
        public string Category { get; set; }
    }
}
