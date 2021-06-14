using Laughy.Data.Repository.Sqlite.SqliteNetPCL.DbModels;
using Laughy.Data.Repository.Sqlite.SqliteNetPCL.Mapper.Interfaces;
using Laughy.Models.DomainModels;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL.Mapper
{
    public class YodaTranslationDataMapper : IYodaTranslationDataMapper
    {
        public YodaTranslationDbModel MapToDbModel(YodaTranslationDomainModel transDomainModel)
        {
            var dbModel = new YodaTranslationDbModel
            {
                DbId = transDomainModel.DbId,
                Yoda = transDomainModel.Yoda,
                Translated = transDomainModel.Translated,
                ImageSource = transDomainModel.ImageSource,
                Time = transDomainModel.Time,
            };

            return dbModel;
        }

        public YodaTranslationDomainModel MapToDomainModel(YodaTranslationDbModel transDbModel)
        {
            var domainModel = new YodaTranslationDomainModel
            {
                DbId = transDbModel.DbId,
                Yoda = transDbModel.Yoda,
                Translated = transDbModel.Translated,
                ImageSource = transDbModel.ImageSource,
                Time = transDbModel.Time,
            };

            return domainModel;
        }
    }
}
