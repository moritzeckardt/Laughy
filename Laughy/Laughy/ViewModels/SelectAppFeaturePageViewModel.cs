using Laughy.Models.UiModels;
using Laughy.ViewModels.Interfaces;
using System.Collections.ObjectModel;

namespace Laughy.ViewModels
{
    public class SelectAppFeaturePageViewModel : ViewModelBase, ISelectAppFeaturePageViewModel
    {
        //Fields


        //Properties
        public ObservableCollection<AppFeatureUiModel> AppFeatures { get; set; } = new ObservableCollection<AppFeatureUiModel>()
        {
            new AppFeatureUiModel() {Title = "Jokes", ImageSource = "jokesfeature.jpg", ButtonBgColor = "White", ButtonTextColor = "Black"},
            new AppFeatureUiModel() {Title = "YODA Translator", ImageSource = "editedyoda.jpg", ButtonBgColor = "#0d9b36", ButtonTextColor = "White"}
        };


        //Constructor
        public SelectAppFeaturePageViewModel()
        {

        }
    }
}
