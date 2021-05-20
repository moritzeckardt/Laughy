using Laughy.Data.Repository.Sqlite.SqliteNetPCL.Contracts;
using Laughy.Data.Repository.Sqlite.SqliteNetPCL.DbModels;
using Laughy.Data.Repository.Sqlite.SqliteNetPCL.Mapper.Interfaces;
using Laughy.Models.DomainModels;
using System.Collections.Generic;
using System.Linq;
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
        public void CreateOrLikeJoke(JokeDomainModel jokeDomainModel)
        {
            _dbContext.Init();

            var jokeDbModel = _jokeDataMapper.MapToDbModel(jokeDomainModel);

            _dbContext.Database.Insert(jokeDbModel);
        }

        public List<JokeDomainModel> GetAllOwnJokes()
        {
            _dbContext.Init();

            var jokeDbModels = _dbContext.Database.Table<JokeDbModel>().ToList();

            jokeDbModels = jokeDbModels.Where(jk => jk.Selfcreated).ToList();

            var jokeDomainModels = jokeDbModels.ConvertAll(jk => _jokeDataMapper.MapToDomainModel(jk));

            return jokeDomainModels;
        }

        public List<JokeDomainModel> GetAllFavouriteJokes()
        {
            _dbContext.Init().ConfigureAwait(false);

            var jokeDbModels = _dbContext.Database.Table<JokeDbModel>().ToList();

            jokeDbModels = jokeDbModels.Where(jk => jk.Favourite).ToList();

            var jokeDomainModels = jokeDbModels.ConvertAll(jk => _jokeDataMapper.MapToDomainModel(jk));

            return jokeDomainModels;
        }

        public void UpdateOwnJoke(JokeDomainModel jokeDomainModel)
        {
            _dbContext.Init();

            var jokeDbModel = _jokeDataMapper.MapToDbModel(jokeDomainModel);

            _dbContext.Database.Update(jokeDbModel);
        }

        public void DeleteOwnJoke(JokeDomainModel jokeDomainModel)
        {
            _dbContext.Init();

            if (jokeDomainModel.Favourite == false)
            {
                _dbContext.Database.Delete<JokeDbModel>(jokeDomainModel.DbId);
            }
        }

        public void DeleteFavouriteJoke(JokeDomainModel jokeDomainModel)
        {
            _dbContext.Init();

            if(jokeDomainModel.Selfcreated == false)
            {
                _dbContext.Database.Delete<JokeDbModel>(jokeDomainModel.DbId);
            }
        }
                
    }
}
