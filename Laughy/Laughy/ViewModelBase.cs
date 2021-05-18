using Laughy.NavigationService.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Laughy
{
    public class ViewModelBase : INotifyPropertyChanged
    { 
        //Properties
        public INavigator Navigator { get; set; }
        public ICommand NavBackToHomeCommand { get; set; }
  

        //Constructors
        public ViewModelBase()
        {
            //Commands
            NavBackToHomeCommand = new AsyncCommand(NavBackToHome);
        }

        public ViewModelBase(INavigator navigator)
        {
            //Assignments
            Navigator = navigator;


            //Commands
            NavBackToHomeCommand = new AsyncCommand(NavBackToHome);
        }


        //Events
        public event PropertyChangedEventHandler PropertyChanged;


        //Private methods
        private protected void RaiseAllPropertiesChanged()
        {
            OnPropertyChanged(string.Empty);
        }

        protected bool SetPropertyAndRaise<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return false;
            }

            field = newValue;

            OnPropertyChanged(propertyName);

            return true;
        }


        //Public methods
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task NavBackToHome()
        {
            await Navigator.NavigateBackToRoot();
        }


        //Tasks
        public virtual Task BeforeFirstShown()
        {
            return Task.CompletedTask;
        }

        public virtual Task AfterDismissed()
        {
            return Task.CompletedTask;
        }
    }
}
