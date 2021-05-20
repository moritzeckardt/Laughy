using Laughy.Models.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL.Contracts
{
    public interface IJokeRepository
    {
        //Methods
        void CreateOrLikeJoke(JokeDomainModel jokeDomainModel);

        List<JokeDomainModel> GetAllOwnJokes();

        List<JokeDomainModel> GetAllFavouriteJokes();

        void UpdateOwnJoke(JokeDomainModel jokeDomainModel);

        void DeleteOwnJoke(JokeDomainModel jokeDomainModel);

        void DeleteFavouriteJoke(JokeDomainModel jokeDomainModel);
    }
}
