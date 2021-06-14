using Laughy.Data.Repository.Sqlite.SqliteNetPCL.DbModels;
using Laughy.Models.DomainModels;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL.Mapper.Interfaces
{
    public interface IYodaTranslationDataMapper
    {
        //Methods
        YodaTranslationDbModel MapToDbModel(YodaTranslationDomainModel transDomainModel);

        YodaTranslationDomainModel MapToDomainModel(YodaTranslationDbModel transDbModel);
    }
}
