using Laughy.Logic.Integration.LaughyWorkflow.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Laughy.Logic.Integration.LaughyWorkflow
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterLaughyWorkflowServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IJokeWorkflow, JokeWorkflow>();

            return serviceCollection;
        }
    }
}
