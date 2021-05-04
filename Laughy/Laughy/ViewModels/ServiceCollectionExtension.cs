using Laughy.ViewModels.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Laughy.ViewModels
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterViewModelServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISelectJokeCategoryPageViewModel, SelectJokeCategoryPageViewModel>();
            serviceCollection.AddTransient<ISelectAppFeaturePageViewModel, SelectAppFeaturePageViewModel>();

            return serviceCollection;
        }
    }
}
