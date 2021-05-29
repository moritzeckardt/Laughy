using System.Windows.Input;

namespace Laughy.Models.UiModels
{
    public class AppFeatureUiModel
    {
        //Properties
        public string ImageSource { get; set; }
        public string ButtonTextColor { get; set; }
        public string ButtonBgColor { get; set; }
        public ICommand DisplayNextPageCommand { get; set; }
    }
}
