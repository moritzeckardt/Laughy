using Laughy.NavigationService.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Laughy.NavigationService
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterNavigationServiceServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<INavigator, Navigator>();
            serviceCollection.AddSingleton<IViewLocator, ViewLocator>();

            return serviceCollection;
        }
    }
}
