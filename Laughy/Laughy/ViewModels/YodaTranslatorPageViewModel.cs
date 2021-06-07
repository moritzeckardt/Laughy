using Laughy.NavigationService.Interfaces;
using Laughy.ViewModels.Interfaces;

namespace Laughy.ViewModels
{
    public class YodaTranslatorPageViewModel : ViewModelBase, IYodaTranslatorPageViewModel
    {
        //Constructor
        public YodaTranslatorPageViewModel(INavigator navigator, ISettingsPageViewModel settingsPageViewModel) : base(navigator, settingsPageViewModel)
        {

        }
    }
}
