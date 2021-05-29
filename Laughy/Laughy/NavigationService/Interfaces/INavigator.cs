using System.Threading.Tasks;

namespace Laughy.NavigationService.Interfaces
{
    public interface INavigator
    {
        //Properties
        IMainPage PresentationRoot { get; set; }


        //Methods
        void PresentAsMainPage(IViewModelNavigationBase viewModel);

        void PresentAsNavigatableMainPage(IViewModelNavigationBase viewModel);

        Task NavigateTo(IViewModelNavigationBase viewModel);

        Task NavigateBack();

        Task NavigateModalTo(IViewModelNavigationBase viewModel);

        Task NavigateModalBack();

        Task NavigateBackToRoot();

        //void DisplaySignOutAlert(Action<Task<bool>> executeAction);

        //void DisplayDeleteAlert(Action<Task<bool>> executeAction, string qdExplanation);

        void DisplayToast(string message);
        void DisplayErrorToast(string message);
        void DisplaySuccessToast(string message);
    }
}
