using Laughy.NavigationService.Interfaces;
using System;
using Xamarin.Forms;

namespace Laughy.NavigationService
{
    public class ViewLocator : IViewLocator
    {
        //Methods      
        private Type FindPageForViewLogic(Type viewModelType)
        {
            var assemblyQualifiedName = viewModelType.AssemblyQualifiedName;
            // "Laughy.ViewModels.DisplayAllJokesPageViewModel"

            var replacedNamespace = assemblyQualifiedName.Replace("Laughy.ViewModels", "Laughy.Views");
            // "Laughy.Views.DisplayAllJokesPageViewModel"

            var pageTypeName = replacedNamespace.Replace("ViewModel", "");
            // "Laughy.Views.DisplayAllJokesPage

            var pageType = Type.GetType(pageTypeName);

            if (pageType == null)
                throw new ArgumentException(pageTypeName + " type does not exist");

            return pageType;
        }

        public Page CreateAndBindPageFor<T>(T viewModel) where T : INavigationBase
        {
            var pageType = FindPageForViewLogic(viewModel.GetType());

            var page = (Page)Activator.CreateInstance(pageType);

            page.BindingContext = viewModel;

            return page;
        }
    }
}
