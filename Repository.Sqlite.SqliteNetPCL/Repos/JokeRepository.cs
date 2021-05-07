using Laughy.Data.Repository.Sqlite.SqliteNetPCL.Contracts;
using Laughy.Data.Repository.Sqlite.SqliteNetPCL.DbModels;
using Laughy.Data.Repository.Sqlite.SqliteNetPCL.Mapper.Interfaces;
using Laughy.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task CreateOwnJoke(JokeDomainModel jokeDomainModel)
        {
            await _dbContext.Init();

            var jokeDbModel = _jokeDataMapper.MapToDbModel(jokeDomainModel);

            await _dbContext.Database.InsertAsync(jokeDbModel);
        }

        public async Task<List<JokeDomainModel>> GetAllOwnJokes()
        {
            await _dbContext.Init();

            var jokeDbModels = await _dbContext.Database.Table<JokeDbModel>().ToListAsync();

            var jokeDomainModels = jokeDbModels.ConvertAll(jk => _jokeDataMapper.MapToDomainModel(jk));

            return jokeDomainModels;
        }

        public async Task UpdateOwnJoke(JokeDomainModel jokeDomainModel)
        {
            await _dbContext.Init();

            var jokeDbModel = _jokeDataMapper.MapToDbModel(jokeDomainModel);

            await _dbContext.Database.UpdateAsync(jokeDbModel);
        }

        public async Task DeleteOwnJoke(Guid jokeId)
        {
            await _dbContext.Init();

            await _dbContext.Database.DeleteAsync<JokeDbModel>(jokeId);
        }
    }
}
