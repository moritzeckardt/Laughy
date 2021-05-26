using Laughy.Models.UiModels;
using Laughy.NavigationService.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace Laughy
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        //Properties
        public string Category { get; set; }
        public string SearchText { get; set; }
        public JokeUiModel PreviousJokeToBeSaved { get; set; }
        public JokeUiModel PreviousJokeToBeDisplayed { get; set; }
        public JokeUiModel EmptyJoke { get; set; } = new JokeUiModel() { FirstPart = "Sadly we couldn't find any joke." };
        public Random RandomJokeManager { get; set; } = new Random();
        public INavigator Navigator { get; set; }
        public ICommand NavBackToHomeCommand { get; set; }
        public ICommand GetJokeCommand { get; set; }
        public ICommand LikeJokeCommand { get; set; }
        public ICommand DisplayPreviousJokeCommand { get; set; }
        public ICommand SearchJokeCommand { get; set; }


        //Constructors
        public ViewModelBase()
        {
            //Commands
            NavBackToHomeCommand = new AsyncCommand(NavBackToHome);
            LikeJokeCommand = new Command(LikeJoke);
            DisplayPreviousJokeCommand = new Command(DisplayPreviousJoke);            
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

        public virtual void LikeJoke()
        {

        }

        public virtual void DisplayPreviousJoke()
        {

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

        public async Task NavBackToHome()
        {
            await Navigator.NavigateBackToRoot();
        }
    }
}
