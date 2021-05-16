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

namespace Laughy
{
    public partial class App : Application, IMainPage
    {
        public App(Configuration config)
        {
            //Syncfusion license (community version)
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
            serviceCollection.RegisterLaughyManagementServices();


            //Data registrations
            serviceCollection.RegisterRepositoriesServices(config.DatabasePath);
            serviceCollection.RegisterDataMapperServices();


            //Adapter registrations
            serviceCollection.RegisterApiServiceServcies();
            serviceCollection.RegisterAdapterMapperServices();


            //Provider & instantiations
            var provider = serviceCollection.BuildServiceProvider();
            var firstPage = provider.GetService<ISelectAppFeaturePageViewModel>();
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
