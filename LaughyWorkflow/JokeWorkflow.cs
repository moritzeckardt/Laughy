using Laughy.Adapter.ApiService.Contracts;
using Laughy.Data.Repository.Sqlite.SqliteNetPCL.Contracts;
using Laughy.Logic.Integration.LaughyWorkflow.Contracts;
using Laughy.Logic.Integration.LaughyWorkflow.Mapper.Interfaces;
using Laughy.Models.UiModels;
using System;
using System.Collections.Generic;

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
        public void CreateOwnJoke(JokeUiModel jokeUiModel)
        {
            var jokeDomainModel = _jokeLogicMapper.MapToDomainModel(jokeUiModel);

            _jokeRepository.CreateOwnJoke(jokeDomainModel);
        }

        public List<JokeUiModel> GetAllOwnJokes()
        {
            var jokesDomainModels = _jokeRepository.GetAllOwnJokes();

            var jokeUiModels = jokesDomainModels.ConvertAll(jk => _jokeLogicMapper.MapToUiModel(jk));

            return jokeUiModels;
        }

        public void UpdateOwnJoke(JokeUiModel jokeUiModel)
        {
            var jokeDomainModel = _jokeLogicMapper.MapToDomainModel(jokeUiModel);

            _jokeRepository.UpdateOwnJoke(jokeDomainModel);
        }

        public void DeleteOwnJoke(Guid jokeId)
        {
            _jokeRepository.DeleteOwnJoke(jokeId);
        }

        public void GetRandomJoke()
        {

        }
    }
}
