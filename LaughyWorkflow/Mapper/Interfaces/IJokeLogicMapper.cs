using Laughy.Models.DomainModels;
using Laughy.Models.UiModels;

namespace Laughy.Logic.Integration.LaughyWorkflow.Mapper.Interfaces
{
    public interface IJokeLogicMapper
    {
        JokeDomainModel MapToDomainModel(JokeUiModel jokeUiModel);

        JokeUiModel MapToUiModel(JokeDomainModel jokeDomainModel);
    }
}
