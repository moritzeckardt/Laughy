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


        //Properties
        public ObservableCollection<JokeCategoryUiModel> JokeCategories { get; set; } = new ObservableCollection<JokeCategoryUiModel>()
        {
            new JokeCategoryUiModel() { Title = "Any joke (recommended)" },
            new JokeCategoryUiModel() { Title = "Favourite jokes" },
            new JokeCategoryUiModel() { Title = "Own jokes" },
            new JokeCategoryUiModel() { Title = "Dark" },
            new JokeCategoryUiModel() { Title = "Pun" },
            new JokeCategoryUiModel() { Title = "Miscellaneous" },
            new JokeCategoryUiModel() { Title = "Coding"},      
            new JokeCategoryUiModel() { Title = "Spooky" },
            new JokeCategoryUiModel() { Title = "Christmas" }
        };
        public ICommand SelectCategoryCommand { get; set; }


        //Constructor
        public SelectJokeCategoryPageViewModel(INavigator navigator, IDisplayJokePageViewModel displayJokePageViewModel) : base(navigator)
        {
            //Assignments
            _displayJokePageViewModel = displayJokePageViewModel;


            //Commands
            SelectCategoryCommand = new Command<object>(SelectCategory);            
        }


        //Methods
        public void SelectCategory(object obj)
        {
            var category = (obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData as JokeCategoryUiModel;

            _displayJokePageViewModel.Category = category.Title;

            Navigator.NavigateTo(_displayJokePageViewModel);
        }
    }
}
