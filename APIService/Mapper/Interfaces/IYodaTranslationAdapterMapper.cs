using Laughy.Adapter.ApiService.ApiModels;
using Laughy.Models.DomainModels;

namespace Laughy.Adapter.ApiService.Mapper.Interfaces
{
    public interface IYodaTranslationAdapterMapper
    {
        YodaTranslationApiModel MapToApiModel(YodaTranslationDomainModel transDomainModel);

        YodaTranslationDomainModel MapToDomainModel(YodaTranslationApiModel transApiModel);
    }
}