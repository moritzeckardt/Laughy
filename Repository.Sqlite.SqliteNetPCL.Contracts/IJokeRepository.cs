using Laughy.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL.Contracts
{
    public interface IJokeRepository
    {
        //Methods
        Task CreateOwnJoke(JokeDomainModel jokeDomainModel);

        Task<List<JokeDomainModel>> GetAllOwnJokes();

        Task UpdateOwnJoke(JokeDomainModel jokeDomainModel);

        Task DeleteOwnJoke(Guid jokeId);
    }
}
