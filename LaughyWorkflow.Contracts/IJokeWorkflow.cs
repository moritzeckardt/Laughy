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

        void DeleteOwnJoke(JokeUiModel jokeUiModel);

        void DeleteFavouriteJoke(JokeUiModel jokeUiModel);

        string ShortenCategory(string category);
    }
}
