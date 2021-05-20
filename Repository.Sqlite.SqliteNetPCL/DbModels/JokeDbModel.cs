using SQLite;
using System;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL.DbModels
{
    [Table("Jokes")]
    public class JokeDbModel
    {
        //Properties
        [PrimaryKey, AutoIncrement]
        public Guid DbId { get; set; }
        public string FirstPart { get; set; } // joke type: single
        public string SecondPart { get; set; } // joke type: two part
        public string Category { get; set; }
        public bool Favourite { get; set; }
        public bool Selfcreated { get; set; }
    }
}
