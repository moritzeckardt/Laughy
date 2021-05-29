using Laughy.NavigationService.Interfaces;
using Plugin.Toast;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Laughy.NavigationService
{
    public class Navigator : INavigator
    {
        //Fields
        private readonly IViewLocator _viewLocator;
        private INavigation XamarinNavigator => PresentationRoot.MainPage.Navigation;


        //Properties
        public IMainPage PresentationRoot { get; set; }


        //Constructor
        public Navigator(IViewLocator viewLocator)
        {
            _viewLocator = viewLocator;
        }


        //Private methods
        private IEnumerable<IViewModelNavigationBase> FindViewModelsToDismiss(Page dismissingPage)
        {
            var viewmodels = new List<IViewModelNavigationBase>();

            if (dismissingPage is NavigationPage)
            {
                viewmodels.AddRange(XamarinNavigator.NavigationStack.Select(p => p.BindingContext).OfType<IViewModelNavigationBase>());
            }
            else
            {
                var viewModel = dismissingPage?.BindingContext as IViewModelNavigationBase;

                if (viewModel != null) viewmodels.Add(viewModel);
            }

            return viewmodels;
        }

        private void NavPagePopRequested(object sender, NavigationRequestedEventArgs e)
        {
            if (XamarinNavigator.NavigationStack.LastOrDefault()?.BindingContext is IViewModelNavigationBase poppingPage)
            {
                poppingPage.AfterDismissed();
            }
        }


        //Public methods
        public void PresentAsMainPage(IViewModelNavigationBase viewModel)
        {
            if (PresentationRoot.MainPage is NavigationPage navPage)
            {
                navPage.PopRequested -= NavPagePopRequested;
            }

            viewModel.BeforeFirstShown();

            var page = _viewLocator.CreateAndBindPageFor(viewModel);

            PresentationRoot.MainPage = page;

            IEnumerable<IViewModelNavigationBase> viewModelsToDismiss = FindViewModelsToDismiss(PresentationRoot.MainPage);

            foreach (var toDismiss in viewModelsToDismiss)
            {
                toDismiss.AfterDismissed();
            }
        }

        public void PresentAsNavigatableMainPage(IViewModelNavigationBase viewModel)
        {
            if (PresentationRoot.MainPage is NavigationPage navPage)
            {
                navPage.PopRequested -= NavPagePopRequested;
            }

            viewModel.BeforeFirstShown();

            var page = _viewLocator.CreateAndBindPageFor(viewModel);

            NavigationPage newNavigationPage = new NavigationPage(page);

            newNavigationPage.PopRequested += NavPagePopRequested;

            PresentationRoot.MainPage = newNavigationPage;

            IEnumerable<IViewModelNavigationBase> viewModelsToDismiss = FindViewModelsToDismiss(PresentationRoot.MainPage);

            foreach (var toDismiss in viewModelsToDismiss)
            {
                toDismiss.AfterDismissed();
            }
        }
      

        public async Task NavigateTo(IViewModelNavigationBase viewModel)
        {
            var page = _viewLocator.CreateAndBindPageFor(viewModel);

            await viewModel.BeforeFirstShown();

            await XamarinNavigator.PushAsync(page);
        }

        public async Task NavigateBack()
        {
            var dismissing = XamarinNavigator.NavigationStack.Last().BindingContext as IViewModelNavigationBase;

            await XamarinNavigator.PopAsync();

            dismissing?.AfterDismissed();
        }

        public async Task NavigateModalTo(IViewModelNavigationBase viewModel)
        {
            var page = _viewLocator.CreateAndBindPageFor(viewModel);

            await viewModel.BeforeFirstShown();

            await XamarinNavigator.PushModalAsync(page);
        }

        public async Task NavigateModalBack()
        {
            var dismissing = XamarinNavigator.NavigationStack.Last().BindingContext as IViewModelNavigationBase;

            await XamarinNavigator.PopModalAsync();

            dismissing?.AfterDismissed();
        }

        public async Task NavigateBackToRoot()
        {
            var toDismiss = XamarinNavigator.NavigationStack.Skip(1).Select(vw => vw.BindingContext).OfType<IViewModelNavigationBase>().ToArray();

            await XamarinNavigator.PopToRootAsync();

            foreach (var viewModel in toDismiss)
            {
                _ = viewModel.AfterDismissed();
            }
        }

        //public void DisplaySignOutAlert(Action<Task<bool>> executeAction)
        //{
        //    XamarinNavigator.NavigationStack.Last().DisplayAlert("Hinweis", "Möchtest du dich wirklich abmelden?", "Abmelden", "Abbrechen").ContinueWith(executeAction);
        //}

        //public void DisplayDeleteAlert(Action<Task<bool>> executeAction, string qdExplanation)
        //{
        //    if (qdExplanation.Length > 20)
        //    {
        //        string shortedQDExplanation = qdExplanation.Substring(0, 21) + "...";
        //        qdExplanation = shortedQDExplanation;
        //    }

        //    XamarinNavigator.NavigationStack.Last().DisplayAlert("Hinweis", $"Möchten sie das Mengendetail '{qdExplanation}' wirklich löschen?", "Löschen", "Abbrechen").ContinueWith(executeAction);
        //}

        public void DisplayToast(string message)
        {
            CrossToastPopUp.Current.ShowToastMessage(message);
        }

        public void DisplayErrorToast(string message)
        {
            CrossToastPopUp.Current.ShowToastError(message);
        }

        public void DisplaySuccessToast(string message)
        {
            CrossToastPopUp.Current.ShowToastSuccess(message);
        }
    }
}
