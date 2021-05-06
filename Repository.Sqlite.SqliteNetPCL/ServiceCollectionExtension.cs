using Microsoft.Extensions.DependencyInjection;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterRepositoriesServices(this IServiceCollection serviceCollection, string dbPath)
        {
            serviceCollection.AddScoped<IDbContext, DbContext>((serviceProvider => { return new DbContext(dbPath); }));

            return serviceCollection;
        }
    }
}
