using Laughy.Models.UiModels;
using System;

namespace Laughy.ViewModels.Interfaces
{
    public interface ICreateOwnJokePageViewModel : IViewModelNavigationBase
    {
        //Events
        EventHandler<JokeUiModel> JokeSaved { get; set; }
    }
}
