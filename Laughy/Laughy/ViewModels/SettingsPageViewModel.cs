using Laughy.IdentityService;
using Laughy.Models.UiModels;
using Laughy.NavigationService.Interfaces;
using Laughy.ViewModels.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
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
            new SettingsUiModel() { NameOfSetting = "Sign out", NameOfMethod = "SignOu" },
            new SettingsUiModel() { NameOfSetting = "About Laughy" }
        };
        public ILoginClaims LoginClaims { get; set; }
        public ICommand ItemTappedCommand { get; set; }
        public ICommand NavBackToLastPageCommand { get; set; }
        public ICommand SignInCommand { get; set; }
        


        //Constructor
        public SettingsPageViewModel(INavigator navigator) : base(navigator)
        {
            //Commands
            ItemTappedCommand = new Command<object>(ItemTapped);
            NavBackToLastPageCommand = new Command(NavBackToLastPage);
            SignInCommand = new AsyncCommand(SignIn);
        }


        //Methods
        public void ItemTapped(object obj)
        {
            var setting = (obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData as SettingsUiModel;

            //if (setting.NameOfMethod == (nameof(SignOut)))
            //{
            //    Navigator.DisplaySignOutAlert(HandleDisplaySignOutAlertResponse);
            //}
        }

        public void NavBackToLastPage()
        {
            Navigator.NavigateBack();
        }

        public async Task SignIn()
        {
            LoginClaims = App.ServiceProvider.GetService<ILoginClaims>();

            AuthenticationResult result;

            if (String.IsNullOrWhiteSpace(LoginClaims.FullName))
            {
                try
                {
                    result = await App.AuthenticationClient
                        .AcquireTokenInteractive(LoginConstants.Scopes)
                        .WithPrompt(Prompt.ForceLogin)
                        .WithParentActivityOrWindow(App.UIParent)
                        .ExecuteAsync();

                    LoginClaims.GetClaimsFromLogin(result);

                    await Navigator.NavigateBack();

                    //Navigator.DisplayToast("Du hast dich erfolgreich angemeldet");
                }

                catch (MsalClientException ex)
                {
                    //
                }
            }

            else
            {
                await Navigator.NavigateBack();
            }
        }
    }
}
