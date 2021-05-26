using Laughy.Adapter.ApiService.Contracts;
using Laughy.Data.Repository.Sqlite.SqliteNetPCL.Contracts;
using Laughy.Logic.Integration.LaughyWorkflow.Contracts;
using Laughy.Logic.Integration.LaughyWorkflow.Mapper.Interfaces;
using Laughy.Models.UiModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Laughy.Logic.Integration.LaughyWorkflow
{
    public class JokeWorkflow : IJokeWorkflow
    {
        //Fields
        private readonly IJokeLogicMapper _jokeLogicMapper;
        private readonly IJokeProcessor _jokeProcessor;
        private readonly IJokeRepository _jokeRepository;


        //Contructor
        public JokeWorkflow(IJokeRepository jokeRepository, IJokeLogicMapper jokeLogicMapper, IJokeProcessor jokeProcessor)
        {
            _jokeRepository = jokeRepository;
            _jokeLogicMapper = jokeLogicMapper;
            _jokeProcessor = jokeProcessor;
        }


        //Methods
        public void CreateOrLikeJoke(JokeUiModel jokeUiModel)
        {
            var jokeDomainModel = _jokeLogicMapper.MapToDomainModel(jokeUiModel);

            _jokeRepository.CreateOrLikeJoke(jokeDomainModel);
        }

        public async Task<JokeUiModel> GetJokeByCategory(string category)
        {
            var jokeDomainModel = await _jokeProcessor.GetJokeByCategory(category);

            var jokeUiModel = _jokeLogicMapper.MapToUiModel(jokeDomainModel);

            return jokeUiModel;
        }

        public List<JokeUiModel> GetAllOwnJokes()
        {
            var jokeDomainModels = _jokeRepository.GetAllOwnJokes();

            var jokeUiModels = jokeDomainModels.ConvertAll(jk => _jokeLogicMapper.MapToUiModel(jk));

            return jokeUiModels;
        }

        public List<JokeUiModel> GetAllFavouriteJokes()
        {
            var jokeDomainModels = _jokeRepository.GetAllFavouriteJokes();

            var jokeUiModels = jokeDomainModels.ConvertAll(jk => _jokeLogicMapper.MapToUiModel(jk));

            return jokeUiModels;
        }

        public void UpdateOwnJoke(JokeUiModel jokeUiModel)
        {
            var jokeDomainModel = _jokeLogicMapper.MapToDomainModel(jokeUiModel);

            _jokeRepository.UpdateOwnJoke(jokeDomainModel);
        }

        public void DeleteOwnOrFavJoke(JokeUiModel jokeUiModel)
        {
            var jokeDomainModel = _jokeLogicMapper.MapToDomainModel(jokeUiModel);

            _jokeRepository.DeleteOwnOrFavJoke(jokeDomainModel);
        }
    }
}
