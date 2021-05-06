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
        private readonly IDbContext _dbContext;
        private readonly IJokeDataMapper _jokeDataMapper;


        //Constructor
        public JokeRepository(IDbContext dbContext, IJokeDataMapper jokeDataMapper)
        {
            _dbContext = dbContext;
            _jokeDataMapper = jokeDataMapper;
        }


        //Methods
        public void CreateOwnJoke(JokeDomainModel jokeDomainModel)
        {
            _dbContext.Init();

            var jokeDbModel = _jokeDataMapper.MapToDbModel(jokeDomainModel);

            _dbContext.Database.InsertAsync(jokeDbModel);
        }

        public List<JokeDomainModel> GetAllOwnJokes()
        {
            _dbContext.Init();

            var jokeDbModels = _dbContext.Database.Table<JokeDbModel>().ToListAsync().Result;

            var jokeDomainModels = jokeDbModels.ConvertAll(jk => _jokeDataMapper.MapToDomainModel(jk));

            return jokeDomainModels;
        }

        public void UpdateOwnJoke(JokeDomainModel jokeDomainModel)
        {
            _dbContext.Init();

            var jokeDbModel = _jokeDataMapper.MapToDbModel(jokeDomainModel);

            _dbContext.Database.UpdateAsync(jokeDbModel);
        }

        public void DeleteOwnJoke(Guid jokeId)
        {
            _dbContext.Init();

            _dbContext.Database.DeleteAsync<JokeDbModel>(jokeId);
        }
    }
}
