using Laughy.Logic.Integration.LaughyWorkflow.Mapper.Interfaces;
using Laughy.Models.DomainModels;
using Laughy.Models.UiModels;

namespace Laughy.Logic.Integration.LaughyWorkflow.Mapper
{
    public class JokeLogicMapper : IJokeLogicMapper
    {
        public JokeDomainModel MapToDomainModel(JokeUiModel jokeUiModel)
        {
            var domainModel = new JokeDomainModel
            {
                DbId = jokeUiModel.DbId,
                JokeId = jokeUiModel.JokeId,
                Joke = jokeUiModel.Joke,
                Setup = jokeUiModel.Setup,
                Delivery = jokeUiModel.Delivery,
                Category = jokeUiModel.Category,
                Type = jokeUiModel.Type,
            };

            return domainModel;
        }

        public JokeUiModel MapToUiModel(JokeDomainModel jokeDomainModel)
        {
            var uiModel = new JokeUiModel
            {
                DbId = jokeDomainModel.DbId,
                JokeId = jokeDomainModel.JokeId,
                Joke = jokeDomainModel.Joke,
                Setup = jokeDomainModel.Setup,
                Delivery = jokeDomainModel.Delivery,
                Category = jokeDomainModel.Category,
                Type = jokeDomainModel.Type,
            };

            return uiModel;
        }
    }
}
