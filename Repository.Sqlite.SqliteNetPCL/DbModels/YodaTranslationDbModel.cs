using SQLite;
using System;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL.DbModels
{
    [Table("Yoda Translations")]
    public class YodaTranslationDbModel
    {
        //Properties
        [PrimaryKey, AutoIncrement]
        public Guid DbId { get; set; }
        public string Yoda { get; set; }
        public string Translated { get; set; }
        public string ImageSource { get; set; }
        public DateTime Time { get; set; }
    }
}
