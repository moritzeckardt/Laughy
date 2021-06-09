using Laughy.Models.UiModels;
using Laughy.NavigationService.Interfaces;
using Laughy.ViewModels.Interfaces;
using Syncfusion.XForms.Chat;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Laughy.ViewModels
{
    public class YodaTranslatorPageViewModel : ViewModelBase, IYodaTranslatorPageViewModel
    {
        //Properties
        public ObservableCollection<MessageUiModel> Messages { get; set; } = new ObservableCollection<MessageUiModel>();
        public Author ActualUser { get; set; } = new Author() { Name = "You" };
        public Author YodaApi { get; set; } = new Author() { Name = "Yoda" };
        public ICommand SendMessageCommand { get; set; }


        //Constructor
        public YodaTranslatorPageViewModel(INavigator navigator, ISettingsPageViewModel settingsPageViewModel) : base(navigator, settingsPageViewModel)
        {
            //Commands
            SendMessageCommand = new AsyncCommand(SendMessage);
        }


        //Methods
        public async Task SendMessage()
        {

        }
    }
}
