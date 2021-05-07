using System;
using Xamarin.Forms;

namespace Laughy.NavigationService.Interfaces
{
    public interface IViewLocator
    {
        Page CreateAndBindPageFor<T>(T viewModel) where T : INavigationBase;
    }
}
