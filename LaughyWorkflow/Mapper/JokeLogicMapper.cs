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
                FirstPart = jokeUiModel.FirstPart,
                SecondPart = jokeUiModel.SecondPart,
                Category = jokeUiModel.Category,
                Favourite = jokeUiModel.Favourite,
                Selfcreated = jokeUiModel.Selfcreated

            };

            return domainModel;
        }

        public JokeUiModel MapToUiModel(JokeDomainModel jokeDomainModel)
        {
            var uiModel = new JokeUiModel
            {
                DbId = jokeDomainModel.DbId,
                FirstPart = jokeDomainModel.FirstPart,
                SecondPart = jokeDomainModel.SecondPart,
                Category = jokeDomainModel.Category,
                Favourite = jokeDomainModel.Favourite,
                Selfcreated = jokeDomainModel.Selfcreated
            };

            return uiModel;
        }
    }
}
