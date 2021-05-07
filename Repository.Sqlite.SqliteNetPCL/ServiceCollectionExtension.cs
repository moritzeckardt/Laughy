using Laughy.Data.Repository.Sqlite.SqliteNetPCL.Contracts;
using Laughy.Data.Repository.Sqlite.SqliteNetPCL.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterRepositoriesServices(this IServiceCollection serviceCollection, string dbPath)
        {
            serviceCollection.AddScoped<IDbContext, DbContext>((serviceProvider => { return new DbContext(dbPath); }));
            serviceCollection.AddScoped<IJokeRepository, JokeRepository>();

            return serviceCollection;
        }
    }
}
