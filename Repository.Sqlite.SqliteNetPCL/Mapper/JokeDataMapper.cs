using Laughy.Data.Repository.Sqlite.SqliteNetPCL.DbModels;
using Laughy.Data.Repository.Sqlite.SqliteNetPCL.Mapper.Interfaces;
using Laughy.Models.DomainModels;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL.Mapper
{
    public class JokeDataMapper : IJokeDataMapper
    {
        public JokeDbModel MapToDbModel(JokeDomainModel jokeDomainModel)
        {
            var dbModel = new JokeDbModel()
            {
                DbId = jokeDomainModel.DbId,
                FirstPart = jokeDomainModel.FirstPart,
                SecondPart = jokeDomainModel.SecondPart,
                Category = jokeDomainModel.Category
            };

            return dbModel;
        }

        public JokeDomainModel MapToDomainModel(JokeDbModel jokeDbModel)
        {
            var domainModel = new JokeDomainModel()
            {
                DbId = jokeDbModel.DbId,
                FirstPart = jokeDbModel.FirstPart,
                SecondPart = jokeDbModel.SecondPart,
                Category = jokeDbModel.Category
            };

            return domainModel;
        }
    }
}
