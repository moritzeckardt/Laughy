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
        //Properties
        public ObservableCollection<JokeCategoryUiModel> JokeCategories { get; set; } = new ObservableCollection<JokeCategoryUiModel>()
        {
            new JokeCategoryUiModel() { NameOfCategory = "Own" },
            new JokeCategoryUiModel() { NameOfCategory = "Favourites" },
            new JokeCategoryUiModel() { NameOfCategory = "Miscellaneous" },
            new JokeCategoryUiModel() { NameOfCategory = "Dark" },
            new JokeCategoryUiModel() { NameOfCategory = "Pun" },
            new JokeCategoryUiModel() { NameOfCategory = "Coding", Icon= "x:Static laughy:IconStore.Laptop"},      
            new JokeCategoryUiModel() { NameOfCategory = "Spooky" },
            new JokeCategoryUiModel() { NameOfCategory = "Christmas" }
        };
        public ICommand SelectCategoryCommand { get; set; }


        //Constructor
        public SelectJokeCategoryPageViewModel(INavigator navigator) : base(navigator)
        {
            //Commands
            SelectCategoryCommand = new Command(SelectCategory);
        }


        //Methods
        public void SelectCategory()
        {
            //Navigator.NavigateTo();
        }
    }
}
