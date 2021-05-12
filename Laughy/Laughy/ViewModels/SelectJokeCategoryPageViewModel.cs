using Laughy.Models.UiModels;
using Laughy.ViewModels.Interfaces;
using System.Collections.ObjectModel;

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


        //Constructor
        public SelectJokeCategoryPageViewModel()
        {

        }
    }
}
