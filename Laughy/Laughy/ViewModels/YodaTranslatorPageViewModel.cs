using Laughy.Models.UiModels;
using Laughy.NavigationService.Interfaces;
using Laughy.ViewModels.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace Laughy.ViewModels
{
    public class YodaTranslatorPageViewModel : ViewModelBase, IYodaTranslatorPageViewModel
    {
        //Properties
        public ObservableRangeCollection<YodaTranslationUiModel> YodaMessages { get; set; } = new ObservableRangeCollection<YodaTranslationUiModel>();

        public YodaTranslationUiModel Message { get; set; }
        public string MessageToBeEdited { get; set; }
        public ICommand SendMessageCommand { get; set; }
        public ICommand DeleteMessageCommand { get; set; }

        //Constructor
        public YodaTranslatorPageViewModel(INavigator navigator, ISettingsPageViewModel settingsPageViewModel) : base(navigator, settingsPageViewModel)
        {
            //Commands
            SendMessageCommand = new AsyncCommand(SendMessage);
            DeleteMessageCommand = new Command(DeleteMessage);

            //Test
            YodaMessages.Add(new YodaTranslationUiModel() { Yoda = "Yoda", Translated = "This is just an example." });
        }

        //Methods
        public async Task SendMessage()
        {
            var messageToBeSent = MessageToBeEdited.Replace(" ", "%20");
        }

        public void DeleteMessage()
        {
        }
    }
}