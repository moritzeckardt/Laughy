using Laughy.Models.DomainModels;
using System.Threading.Tasks;

namespace Laughy.Adapter.ApiService.Contracts
{
    public interface IJokeProcessor
    {
        Task<JokeDomainModel> GetJokeByCategory(string category);

        Task<JokeDomainModel> GetJokeBySearch(string searchText);
    }
}
