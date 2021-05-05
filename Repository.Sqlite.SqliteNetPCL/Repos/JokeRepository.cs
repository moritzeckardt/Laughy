using Laughy.Data.Repository.Sqlite.SqliteNetPCL.Contracts;
using Laughy.Data.Repository.Sqlite.SqliteNetPCL.DbModels;
using Laughy.Data.Repository.Sqlite.SqliteNetPCL.Mapper.Interfaces;
using Laughy.Models.DomainModels;
using System;
using System.Collections.Generic;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL.Repos
{
    public class JokeRepository : IJokeRepository
    {
        //Fields
        private readonly IDbService _dbService;
        private readonly IJokeDataMapper _jokeDataMapper;

        //Constructor
        public JokeRepository(IDbService dbService, IJokeDataMapper jokeDataMapper)
        {
            _dbService = dbService;
            _jokeDataMapper = jokeDataMapper;
        }


        //Methods
        public void CreateOwnJoke(JokeDomainModel jokeDomainModel)
        {
            _dbService.Init();

            var jokeDbModel = _jokeDataMapper.MapToDbModel(jokeDomainModel);

            _dbService.Database.InsertAsync(jokeDbModel);
        }

        public List<JokeDomainModel> GetAllOwnJokes()
        {
            _dbService.Init();

            var jokeDbModels = _dbService.Database.Table<JokeDbModel>().ToListAsync().Result;

            var jokeDomainModels = jokeDbModels.ConvertAll(jk => _jokeDataMapper.MapToDomainModel(jk));

            return jokeDomainModels;
        }

        public void UpdateOwnJoke(JokeDomainModel jokeDomainModel)
        {
            _dbService.Init();

            var jokeDbModel = _jokeDataMapper.MapToDbModel(jokeDomainModel);

            _dbService.Database.UpdateAsync(jokeDbModel);
        }

        public void DeleteOwnJoke(Guid jokeId)
        {
            _dbService.Init();

            _dbService.Database.DeleteAsync<JokeDbModel>(jokeId);
        }
    }
}
