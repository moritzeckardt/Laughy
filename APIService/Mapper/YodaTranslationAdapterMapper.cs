using Laughy.Adapter.ApiService.ApiModels;
using Laughy.Adapter.ApiService.Mapper.Interfaces;
using Laughy.Models.DomainModels;

namespace Laughy.Adapter.ApiService.Mapper
{
    public class YodaTranslationAdapterMapper : IYodaTranslationAdapterMapper
    {
        public YodaTranslationApiModel MapToApiModel(YodaTranslationDomainModel transDomainModel)
        {
            var apiModel = new YodaTranslationApiModel
            {
                DbId = transDomainModel.DbId,
                Yoda = transDomainModel.Yoda,
                Translated = transDomainModel.Translated,
                ImageSource = transDomainModel.ImageSource,
                Time = transDomainModel.Time,
            };

            return apiModel;
        }

        public YodaTranslationDomainModel MapToDomainModel(YodaTranslationApiModel transApiModel)
        {
            var domainModel = new YodaTranslationDomainModel
            {
                DbId = transApiModel.DbId,
                Yoda = transApiModel.Yoda,
                Translated = transApiModel.Translated,
                ImageSource = transApiModel.ImageSource,
                Time = transApiModel.Time,
            };

            return domainModel;
        }
    }
}
