using Laughy.Models.UiModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Laughy.Logic.Integration.LaughyWorkflow.Contracts
{
    public interface IJokeWorkflow
    {
        void CreateOrLikeJoke(JokeUiModel jokeUiModel);

        Task<JokeUiModel> GetJokeByCategory(string category);

        List<JokeUiModel> GetAllOwnJokes();

        List<JokeUiModel> GetAllFavouriteJokes();

        void UpdateOwnJoke(JokeUiModel jokeUiModel);

        void DeleteOwnOrFavJoke(JokeUiModel jokeUiModel);
    }
}
