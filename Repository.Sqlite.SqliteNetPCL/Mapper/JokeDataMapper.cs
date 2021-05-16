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
                Joke = jokeDomainModel.Joke,
                Setup = jokeDomainModel.Setup,
                Delivery = jokeDomainModel.Delivery,
                Category = jokeDomainModel.Category
            };

            return dbModel;
        }

        public JokeDomainModel MapToDomainModel(JokeDbModel jokeDbModel)
        {
            var domainModel = new JokeDomainModel()
            {
                DbId = jokeDbModel.DbId,
                Joke = jokeDbModel.Joke,
                Setup = jokeDbModel.Setup,
                Delivery = jokeDbModel.Delivery,
                Category = jokeDbModel.Category
            };

            return domainModel;
        }
    }
}
