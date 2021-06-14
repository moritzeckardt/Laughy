using Laughy.Logic.Integration.LaughyWorkflow.Mapper.Interfaces;
using Laughy.Models.DomainModels;
using Laughy.Models.UiModels;

namespace Laughy.Logic.Integration.LaughyWorkflow.Mapper
{
    public class YodaTranslationLogicMapper : IYodaTranslationLogicMapper
    {
        public YodaTranslationDomainModel MapToDomainModel(YodaTranslationUiModel transUiModel)
        {
            var domainModel = new YodaTranslationDomainModel
            {
                DbId = transUiModel.DbId,
                Yoda = transUiModel.Yoda,
                Translated = transUiModel.Translated,
                ImageSource = transUiModel.ImageSource,
                Time = transUiModel.Time,
            };

            return domainModel;
        }

        public YodaTranslationUiModel MapToUiModel(YodaTranslationDomainModel transDomainModel)
        {
            var uiModel = new YodaTranslationUiModel
            {
                DbId = transDomainModel.DbId,
                Yoda = transDomainModel.Yoda,
                Translated = transDomainModel.Translated,
                ImageSource = transDomainModel.ImageSource,
                Time = transDomainModel.Time,
            };

            return uiModel;
        }
    }
}
