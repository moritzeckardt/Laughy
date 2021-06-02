using Laughy.Models.UiModels;
using Laughy.NavigationService.Interfaces;
using Laughy.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Laughy.ViewModels
{   
    public class SettingsPageViewModel : ViewModelBase, ISettingsPageViewModel
    {
        //Properties
        public ObservableCollection<SettingsUiModel> Settings { get; set; } = new ObservableCollection<SettingsUiModel>()
        {
            new SettingsUiModel() { NameOfSetting = "Privacy and safety" },
            new SettingsUiModel() { NameOfSetting = "Notifications" },
            new SettingsUiModel() { NameOfSetting = "Display and sound" },
            new SettingsUiModel() { NameOfSetting = "Language" },
            new SettingsUiModel() { NameOfSetting = "Help" },
            new SettingsUiModel() { NameOfSetting = "Sign out", NameOfMethod = "SignOutFromAzureADB2C" },
            new SettingsUiModel() { NameOfSetting = "About Laughy" }
        };
        public ICommand ItemTappedCommand { get; set; }
        public ICommand NavBackToLastPageCommand { get; set; }


        //Constructor
        public SettingsPageViewModel(INavigator navigator) : base(navigator)
        {
            ItemTappedCommand = new Command<object>(ItemTapped);
            NavBackToLastPageCommand = new Command(NavBackToLastPage);
        }


        //Methods
        public void ItemTapped(object obj)
        {
            var setting = (obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData as SettingsUiModel;

            //if (setting.NameOfMethod == (nameof(SignOutFromAzureADB2C)))
            //{
            //    Navigator.DisplaySignOutAlert(HandleDisplaySignOutAlertResponse);
            //}
        }

        public void NavBackToLastPage()
        {
            Navigator.NavigateBack();
        }
    }
}
