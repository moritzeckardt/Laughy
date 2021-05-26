using Laughy.Logic.Operation.LaughyManagement.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Laughy.Logic.Operation.LaughyManagement
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterLaughyManagementServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IJokeManager, JokeManager>();

            return serviceCollection;
        }
    }
}
