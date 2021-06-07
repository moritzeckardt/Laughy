using Laughy.ViewModels.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Laughy.ViewModels
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterViewModelServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISelectAppFeaturePageViewModel, SelectAppFeaturePageViewModel>();
            serviceCollection.AddTransient<ISelectJokeCategoryPageViewModel, SelectJokeCategoryPageViewModel>();
            serviceCollection.AddTransient<IDisplayJokePageViewModel, DisplayJokePageViewModel>();
            serviceCollection.AddTransient<IDisplayFavouriteJokePageViewModel, DisplayFavouriteJokePageViewModel>();
            serviceCollection.AddTransient<IDisplayOwnJokePageViewModel, DisplayOwnJokePageViewModel>();
            serviceCollection.AddTransient<ICreateOwnJokePageViewModel, CreateOwnJokePageViewModel>();
            serviceCollection.AddTransient<IEditOwnJokePageViewModel, EditOwnJokePageViewModel>();
            serviceCollection.AddTransient<ISettingsPageViewModel, SettingsPageViewModel>();
            serviceCollection.AddTransient<IYodaTranslatorPageViewModel, YodaTranslatorPageViewModel>();

            return serviceCollection;
        }
    }
}
