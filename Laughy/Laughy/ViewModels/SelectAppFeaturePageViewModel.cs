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
            new AppFeatureUiModel() {Title = "Jokes", Caption = "", Image = ""},
            new AppFeatureUiModel() {Title = "Yoda Translator", Caption = "", Image = ""}
        };


        //Constructor
        public SelectAppFeaturePageViewModel()
        {

        }
    }
}
