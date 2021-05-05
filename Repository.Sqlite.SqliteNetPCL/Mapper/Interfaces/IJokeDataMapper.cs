using Laughy.Data.Repository.Sqlite.SqliteNetPCL.DbModels;
using Laughy.Models.DomainModels;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL.Mapper.Interfaces
{
    public interface IJokeDataMapper
    {
        JokeDbModel MapToDbModel(JokeDomainModel jokeDomainModel);

        JokeDomainModel MapToDomainModel(JokeDbModel jokeDbModel);
    }
}
