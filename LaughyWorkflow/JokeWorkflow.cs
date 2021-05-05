using Laughy.Data.Repository.Sqlite.SqliteNetPCL.Contracts;
using Laughy.Logic.Integration.LaughyWorkflow.Contracts;
using Laughy.Logic.Integration.LaughyWorkflow.Mapper.Interfaces;
using Laughy.Models.UiModels;

namespace Laughy.Logic.Integration.LaughyWorkflow
{
    public class JokeWorkflow : IJokeWorkflow
    {
        //Fields
        private readonly IJokeLogicMapper _jokeLogicMapper;
        private readonly IJokeRepository _jokeRepository;

        //Contructor
        public JokeWorkflow(IJokeRepository jokeRepository, IJokeLogicMapper jokeLogicMapper)
        {
            _jokeRepository = jokeRepository;
            _jokeLogicMapper = jokeLogicMapper;
        }


        //Methods
        public JokeUiModel CreateJoke(JokeUiModel jokeUiModel)
        {
            var jokeDomainModel = _jokeLogicMapper.MapToDomainModel(jokeUiModel);

            _jokeRepository.CreateOwnJoke(jokeDomainModel);

            jokeUiModel = _jokeLogicMapper.MapToUiModel(jokeDomainModel);
            
            return jokeUiModel;
        }
    }
}
