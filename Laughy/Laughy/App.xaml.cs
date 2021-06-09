using Laughy.Adapter.ApiService;
using Laughy.NavigationService;
using Laughy.NavigationService.Interfaces;
using Laughy.ViewModels;
using Laughy.ViewModels.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using Laughy.Logic.Integration.LaughyWorkflow;
using Laughy.Logic.Integration.LaughyWorkflow.Mapper;
using Laughy.Data.Repository.Sqlite.SqliteNetPCL;
using Laughy.Adapter.ApiService.Mapper;
using Laughy.Data.Repository.Sqlite.SqliteNetPCL.Mapper;
using Laughy.Logic.Operation.LaughyManagement;
using Laughy.Adapter.ApiService.Contracts;
using Laughy.IdentityService;
using Microsoft.Identity.Client;
using System;

namespace Laughy
{
    public partial class App : Application, IMainPage
    {
        //Properties
        public static IServiceProvider ServiceProvider { get; set; }
        public static IPublicClientApplication AuthenticationClient { get; private set; }     
        public static object UIParent { get; set; } = null;


        //Constructor
        public App(Configuration config)
        {
            //Syncfusion license (community version)
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDU3MjE1QDMxMzkyZTMxMmUzME9qV0g5Nm81b01jOHJpaktFenF4T3JrMFR4TFdiZ2lmOVc4YWE0TjloWEk9");


            //AuthenticationClient
            AuthenticationClient = PublicClientApplicationBuilder.Create(LoginConstants.ClientId)
            .WithIosKeychainSecurityGroup(LoginConstants.IosKeychainSecurityGroups)
            .WithB2CAuthority(LoginConstants.AuthoritySignIn)
            .WithRedirectUri($"msal{LoginConstants.ClientId}://auth")
            .Build();


            //Initializing
            InitializeComponent();
            ApiHelper.InitializeClient();
            var serviceCollection = new ServiceCollection();


            //ViewModel & Navigation registrations
            serviceCollection.RegisterViewModelServices();
            serviceCollection.RegisterNavigationServiceServices();


            //Logic registrations
            serviceCollection.RegisterLaughyWorkflowServices();
            serviceCollection.RegisterLogicMapperServices();
            serviceCollection.RegisterLaughyManagementServices();


            //Data registrations
            serviceCollection.RegisterRepositoriesServices(config.DatabasePath);
            serviceCollection.RegisterDataMapperServices();


            //Adapter registrations
            serviceCollection.RegisterApiServiceServcies();
            serviceCollection.RegisterAdapterMapperServices();


            //Azure AD B2C Login Registrations
            serviceCollection.AddSingleton<ILoginClaims, LoginClaims>();


            //Provider & instantiations
            ServiceProvider = serviceCollection.BuildServiceProvider();     
            var firstPage = ServiceProvider.GetService<ISelectAppFeaturePageViewModel>();
            var navigationService = ServiceProvider.GetService<INavigator>();
            var jokeProcessor = ServiceProvider.GetService<IJokeProcessor>();       


            //API call ("Increases performance later")
            jokeProcessor.GetJokeByCategory("any");


            //Navigation
            navigationService.PresentationRoot = this;
            navigationService.PresentAsNavigatableMainPage(firstPage);
        }


        //Methods
        //protected override void OnStart()
        //{

        //}

        //protected override void OnSleep()
        //{

        //}

        //protected override void OnResume()
        //{

        //}
    }
}
