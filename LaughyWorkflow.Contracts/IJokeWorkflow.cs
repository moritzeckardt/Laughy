using Laughy.Models.UiModels;
using System;
using System.Collections.Generic;

namespace Laughy.Logic.Integration.LaughyWorkflow.Contracts
{
    public interface IJokeWorkflow
    {
        void CreateOwnJoke(JokeUiModel jokeUiModel);

        List<JokeUiModel> GetAllOwnJokes();

        void UpdateOwnJoke(JokeUiModel jokeUiModel);

        void DeleteOwnJoke(Guid jokeId);
    }
}
