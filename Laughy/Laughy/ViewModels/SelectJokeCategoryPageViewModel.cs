using Laughy.Models.UiModels;
using Laughy.NavigationService.Interfaces;
using Laughy.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Laughy.ViewModels
{
    public class SelectJokeCategoryPageViewModel : ViewModelBase, ISelectJokeCategoryPageViewModel
    {
        //Fields
        private readonly IDisplayJokePageViewModel _displayJokePageViewModel;
        private readonly IDisplayFavouriteJokePageViewModel _displayFavouriteJokePageViewModel;
        private readonly IDisplayOwnJokePageViewModel _displayOwnJokePageViewModel;


        //Properties
        public ObservableCollection<JokeCategoryUiModel> JokeCategories { get; set; } = new ObservableCollection<JokeCategoryUiModel>()
        {   
            new JokeCategoryUiModel() { Title = "Own jokes"},
            new JokeCategoryUiModel() { Title = "Favourite jokes"},           
            new JokeCategoryUiModel() { Title = "Any jokes (recommended)", Abbreviation = "any"},
            new JokeCategoryUiModel() { Title = "Dark" },
            new JokeCategoryUiModel() { Title = "Pun" },
            new JokeCategoryUiModel() { Title = "Miscellaneous" },
            new JokeCategoryUiModel() { Title = "Coding"},      
            new JokeCategoryUiModel() { Title = "Spooky" },
            new JokeCategoryUiModel() { Title = "Christmas" }
        };
        public ICommand SelectCategoryCommand { get; set; }


        //Constructor
        public SelectJokeCategoryPageViewModel(INavigator navigator, ISettingsPageViewModel settingsPageViewModel, IDisplayJokePageViewModel displayJokePageViewModel, IDisplayFavouriteJokePageViewModel displayFavouriteJokePageViewModel, 
            IDisplayOwnJokePageViewModel displayOwnJokePageViewModel) : base(navigator, settingsPageViewModel)
        {
            //Assignments
            _displayJokePageViewModel = displayJokePageViewModel;
            _displayFavouriteJokePageViewModel = displayFavouriteJokePageViewModel;
            _displayOwnJokePageViewModel = displayOwnJokePageViewModel;


            //Commands
            SelectCategoryCommand = new Command<object>(SelectCategory);            
        }


        //Methods
        public void SelectCategory(object obj)
        {
            var category = (obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData as JokeCategoryUiModel;

            if(category.Title == "Own jokes")
            {
                Navigator.NavigateTo(_displayOwnJokePageViewModel);
            }

            else if(category.Title == "Favourite jokes")
            {
                Navigator.NavigateTo(_displayFavouriteJokePageViewModel);
            }

            else
            {
                _displayJokePageViewModel.Category = category.Title;

                if (category.Title == "Any jokes (recommended)")
                    _displayJokePageViewModel.Category = category.Abbreviation;

                Navigator.NavigateTo(_displayJokePageViewModel);
            }       
        }
    }
}
