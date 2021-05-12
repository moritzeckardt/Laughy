using Laughy.NavigationService.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Laughy
{
    public class ViewModelBase : INotifyPropertyChanged
    { 
        //Properties
        public INavigator Navigator { get; }
  

        //Constructors
        public ViewModelBase()
        {

        }

        public ViewModelBase(INavigator navigator)
        {
            Navigator = navigator;
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


        //Tasks
        public Task BeforeFirstShown()
        {
            return Task.CompletedTask;
        }

        public Task AfterDismissed()
        {
            return Task.CompletedTask;
        }
    }
}
