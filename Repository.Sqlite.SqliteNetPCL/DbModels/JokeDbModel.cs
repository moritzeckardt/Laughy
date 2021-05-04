using SQLite;
using System;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL.DbModels
{
    public class JokeDbModel
    {
        //Properties
        [PrimaryKey, AutoIncrement]
        public Guid DbId { get; set; }
        public int JokeId { get; set; }
        public string Joke { get; set; } // type: single
        public string Setup { get; set; } // type: two part
        public string Delivery { get; set; } // type: two part
        public string Category { get; set; }
        public string Type { get; set; }
    }
}
