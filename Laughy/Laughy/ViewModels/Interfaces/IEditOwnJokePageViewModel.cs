using Laughy.Models.UiModels;
using System;

namespace Laughy.ViewModels.Interfaces
{
    public interface IEditOwnJokePageViewModel : IViewModelNavigationBase
    {
        //Properties
        JokeUiModel Joke { get; set; }


        //Events
        EventHandler<JokeUiModel> JokeDeleted { get; set; }
        EventHandler<JokeUiModel> JokeEdited { get; set; }
    }
}
