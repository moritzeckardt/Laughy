using Laughy.Data.Repository.Sqlite.SqliteNetPCL.Mapper.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Laughy.Data.Repository.Sqlite.SqliteNetPCL.Mapper
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterDataMapperServices(this IServiceCollection servicCollection)
        {
            servicCollection.AddSingleton<IJokeDataMapper, JokeDataMapper>();
            servicCollection.AddSingleton<IYodaTranslationDataMapper, YodaTranslationDataMapper>();

            return servicCollection;
        }
    }
}
