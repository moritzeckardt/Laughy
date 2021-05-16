using SQLite;
using System;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL.DbModels
{
    public class JokeDbModel
    {
        //Properties
        [PrimaryKey, AutoIncrement]
        public Guid DbId { get; set; }
        public string Joke { get; set; } // joke type: single
        public string Setup { get; set; } // joke type: two part
        public string Delivery { get; set; } // joke type: two part
        public string Category { get; set; }
    }
}
