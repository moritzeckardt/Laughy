using Laughy.Models.UiModels;
using Laughy.NavigationService.Interfaces;
using Laughy.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Laughy.ViewModels
{
    public class SelectAppFeaturePageViewModel : ViewModelBase, ISelectAppFeaturePageViewModel
    {
        //Fields
        private readonly ISelectJokeCategoryPageViewModel _selectJokeCategoryPageViewModel;


        //Properties
        public ObservableCollection<AppFeatureUiModel> AppFeatures { get; set; } = new ObservableCollection<AppFeatureUiModel>();
        public AppFeatureUiModel Jokes { get; set; } = new AppFeatureUiModel() { ImageSource = "jokesfeature.jpg", ButtonBgColor = "White", ButtonTextColor = "Black" };
        public AppFeatureUiModel YodaTranslator { get; set; } = new AppFeatureUiModel() { ImageSource = "editedyoda.jpg", ButtonBgColor = "#0d9b36", ButtonTextColor = "White" };
  

        //Constructor
        public SelectAppFeaturePageViewModel(INavigator navigator, ISelectJokeCategoryPageViewModel selectJokeCategoryPageViewModel) : base(navigator)
        {
            //Assignments
            _selectJokeCategoryPageViewModel = selectJokeCategoryPageViewModel;
            

            //Commands
            Jokes.DisplayNextPageCommand = new Command(DisplayJokeCategories);
            YodaTranslator.DisplayNextPageCommand = new Command(DisplayYodaTranslator);


            AppFeatures.Add(Jokes);
            AppFeatures.Add(YodaTranslator);
        }


        //Methods
        public void DisplayJokeCategories()
        {
            Navigator.NavigateTo(_selectJokeCategoryPageViewModel);
        }

        public void DisplayYodaTranslator()
        {
            //
        }

    }
}
