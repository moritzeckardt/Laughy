using Laughy.Models.DomainModels;
using System;
using System.Collections.Generic;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL.Contracts
{
    public interface IJokeRepository
    {
        //Methods
        void CreateOwnJoke(JokeDomainModel jokeDomainModel);

        List<JokeDomainModel> GetAllOwnJokes();

        void UpdateOwnJoke(JokeDomainModel jokeDomainModel);

        void DeleteOwnJoke(Guid jokeId);
    }
}
