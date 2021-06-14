using Laughy.Models.DomainModels;
using System.Threading.Tasks;

namespace Laughy.Adapter.ApiService.Contracts
{
    public interface IYodaTranslationProcessor
    {
        //Methods
        Task<YodaTranslationDomainModel> GetYodaTranslation(string message);
    }
}
