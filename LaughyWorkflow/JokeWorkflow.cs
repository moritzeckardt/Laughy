using Laughy.Adapter.ApiService.Contracts;
using Laughy.Data.Repository.Sqlite.SqliteNetPCL.Contracts;
using Laughy.Logic.Integration.LaughyWorkflow.Contracts;
using Laughy.Logic.Integration.LaughyWorkflow.Mapper.Interfaces;
using Laughy.Models.UiModels;
using System;
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
        public async Task CreateOwnJoke(JokeUiModel jokeUiModel)
        {
            var jokeDomainModel = _jokeLogicMapper.MapToDomainModel(jokeUiModel);

            await _jokeRepository.CreateOwnJoke(jokeDomainModel);
        }

        public async Task<JokeUiModel> GetRandomJoke()
        {
            var jokeDomainModel = await _jokeProcessor.GetRandomJoke();

            var jokeUiModel = _jokeLogicMapper.MapToUiModel(jokeDomainModel);

            return jokeUiModel;
        }

        public async Task<List<JokeUiModel>> GetAllOwnJokes()
        {
            var jokesDomainModels = await _jokeRepository.GetAllOwnJokes();

            var jokeUiModels = jokesDomainModels.ConvertAll(jk => _jokeLogicMapper.MapToUiModel(jk));

            return jokeUiModels;
        }

        public async Task UpdateOwnJoke(JokeUiModel jokeUiModel)
        {
            var jokeDomainModel = _jokeLogicMapper.MapToDomainModel(jokeUiModel);

            await _jokeRepository.UpdateOwnJoke(jokeDomainModel);
        }

        public async Task DeleteOwnJoke(Guid jokeId)
        {
            await _jokeRepository.DeleteOwnJoke(jokeId);
        }      
    }
}
