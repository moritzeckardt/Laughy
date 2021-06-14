using Laughy.Models.DomainModels;
using Laughy.Models.UiModels;

namespace Laughy.Logic.Integration.LaughyWorkflow.Mapper.Interfaces
{
    public interface IYodaTranslationLogicMapper
    {
        //Methods
        YodaTranslationDomainModel MapToDomainModel(YodaTranslationUiModel transUiModel);

        YodaTranslationUiModel MapToUiModel(YodaTranslationDomainModel transDomainModel);
    }
}
