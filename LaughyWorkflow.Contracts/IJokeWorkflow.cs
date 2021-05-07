using Laughy.Models.UiModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Laughy.Logic.Integration.LaughyWorkflow.Contracts
{
    public interface IJokeWorkflow
    {
        Task CreateOwnJoke(JokeUiModel jokeUiModel);

        Task<JokeUiModel> GetRandomJoke();

        Task<List<JokeUiModel>> GetAllOwnJokes();

        Task UpdateOwnJoke(JokeUiModel jokeUiModel);

        Task DeleteOwnJoke(Guid jokeId);
    }
}
