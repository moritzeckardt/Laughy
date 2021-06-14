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
        private readonly IYodaTranslatorPageViewModel _yodaTranslatorPageViewModel;


        //Properties
        public ObservableCollection<AppFeatureUiModel> AppFeatures { get; set; } = new ObservableCollection<AppFeatureUiModel>();
        public AppFeatureUiModel JokesFeature { get; set; } = new AppFeatureUiModel() { ImageSource = "jokesfeature.jpg", ButtonBgColor = "White", ButtonTextColor = "Black" };
        public AppFeatureUiModel YodaTranslatorFeature { get; set; } = new AppFeatureUiModel() { ImageSource = "editedyoda.jpg", ButtonBgColor = "#0d9b36", ButtonTextColor = "White" };
  

        //Constructor
        public SelectAppFeaturePageViewModel(INavigator navigator, ISettingsPageViewModel settingsPageViewModel, ISelectJokeCategoryPageViewModel selectJokeCategoryPageViewModel,
            IYodaTranslatorPageViewModel yodaTranslatorPageViewModel) : base(navigator, settingsPageViewModel)
        {
            //Assignments
            _selectJokeCategoryPageViewModel = selectJokeCategoryPageViewModel;
            _yodaTranslatorPageViewModel = yodaTranslatorPageViewModel;


            //Commands
            JokesFeature.DisplayNextPageCommand = new Command(DisplayJokeCategories);
            YodaTranslatorFeature.DisplayNextPageCommand = new Command(DisplayYodaTranslator);


            //Additional
            AppFeatures.Add(JokesFeature);
            AppFeatures.Add(YodaTranslatorFeature);
        }


        //Methods
        public void DisplayJokeCategories()
        {
            Navigator.NavigateTo(_selectJokeCategoryPageViewModel);
        }

        public void DisplayYodaTranslator()
        {
            Navigator.NavigateTo(_yodaTranslatorPageViewModel);
        }
    }
}
