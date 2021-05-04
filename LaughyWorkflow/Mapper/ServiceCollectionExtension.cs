using Laughy.Logic.Integration.LaughyWorkflow.Mapper.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Laughy.Logic.Integration.LaughyWorkflow.Mapper
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterLogicMapperServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IJokeLogicMapper, JokeLogicMapper>();

            return serviceCollection;
        }
    }
}
