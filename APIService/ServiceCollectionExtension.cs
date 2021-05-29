using Laughy.Adapter.ApiService.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Laughy.Adapter.ApiService
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterApiServiceServcies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IJokeProcessor, JokeProcessor>();

            return serviceCollection;
        }
    }
}
