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
                Id = jokeUiModel.Id,
                Joke = jokeUiModel.Joke,
                Setup = jokeUiModel.Setup,
                Delivery = jokeUiModel.Delivery,
                Category = jokeUiModel.Category
            };

            return domainModel;
        }

        public JokeUiModel MapToUiModel(JokeDomainModel jokeDomainModel)
        {
            var uiModel = new JokeUiModel
            {
                Id = jokeDomainModel.Id,
                Joke = jokeDomainModel.Joke,
                Setup = jokeDomainModel.Setup,
                Delivery = jokeDomainModel.Delivery,
                Category = jokeDomainModel.Category
            };

            return uiModel;
        }
    }
}
