using System.Threading.Tasks;

namespace Laughy.NavigationService.Interfaces
{
    public interface INavigator
    {
        //Properties
        IMainPage PresentationRoot { get; set; }


        //Methods
        void PresentAsMainPage(IViewModelBase viewModel);

        void PresentAsNavigatableMainPage(IViewModelBase viewModel);

        Task NavigateTo(IViewModelBase viewModel);

        Task NavigateBack();

        Task NavigateModalTo(IViewModelBase viewModel);

        Task NavigateModalBack();

        Task NavigateBackToRoot();

        //void DisplaySignOutAlert(Action<Task<bool>> executeAction);

        //void DisplayDeleteAlert(Action<Task<bool>> executeAction, string qdExplanation);

        void DisplayToast(string message);
        void DisplayErrorToast(string message);
        void DisplaySuccessToast(string message);
    }
}
