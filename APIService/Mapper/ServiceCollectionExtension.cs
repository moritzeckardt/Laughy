using Laughy.Adapter.ApiService.Mapper.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Laughy.Adapter.ApiService.Mapper
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterAdapterMapperServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IJokeAdapterMapper, JokeAdapterMapper>();

            return serviceCollection;
        }
    }
}
