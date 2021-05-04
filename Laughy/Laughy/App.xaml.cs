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

namespace Laughy
{
    public partial class App : Application, IMainPage
    {
        public App(Configuration config)
        {
            //Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDQwMzg3QDMxMzkyZTMxMmUzMGxBY1FCTmFVMUU2aG5QVFpBd3VnZUVqVEtmUC9kOG5UYmZUNzRVekFualE9");


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


            //Data registrations
            serviceCollection.RegisterRepositoriesServices(config.DatabasePath);


            //Provider & instantiations
            var provider = serviceCollection.BuildServiceProvider();
            var firstPage = provider.GetService<ISelectJokeCategoryPageViewModel>();
            var navigationService = provider.GetService<INavigator>();


            //Navigation
            navigationService.PresentationRoot = this;
            navigationService.PresentAsNavigatableMainPage(firstPage);
        }

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
