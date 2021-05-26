using System.Threading.Tasks;

namespace Laughy.ViewModels.Interfaces
{
    public interface IDisplayJokePageViewModel : IViewModelNavigationBase
    {
        //Properties
        string Category { get; set; }


        //Methods
        Task GetJoke();
    }
}
