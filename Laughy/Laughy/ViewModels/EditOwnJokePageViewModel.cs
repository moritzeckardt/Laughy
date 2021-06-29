using Laughy.Logic.Integration.LaughyWorkflow.Contracts;
using Laughy.Models.UiModels;
using Laughy.NavigationService.Interfaces;
using Laughy.ViewModels.Interfaces;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Laughy.ViewModels
{
    public class EditOwnJokePageViewModel : ViewModelBase, IEditOwnJokePageViewModel
    {
        //Fields       
        private readonly IJokeWorkflow _jokeWorkflow;


        //Properties
        public JokeUiModel Joke { get; set; } = new JokeUiModel();
        public ICommand DeleteJokeCommand { get; set; }
        public ICommand UpdateJokeCommand { get; set; }


        //Constructor
        public EditOwnJokePageViewModel(INavigator navigator, ISettingsPageViewModel settingsPageViewModel, IJokeWorkflow jokeWorkflow) : base(navigator, settingsPageViewModel)
        {
            //Assignments
            _jokeWorkflow = jokeWorkflow;


            //Commands
            DeleteJokeCommand = new Command(DeleteJoke);
            UpdateJokeCommand = new Command(UpdateJoke);
        }


        //Events
        public EventHandler<JokeUiModel> JokeDeleted { get; set; }
        public void OnJokeDeleted()
        {
            JokeDeleted.Invoke(this, Joke);
        }

        public EventHandler<JokeUiModel> JokeEdited { get; set; }
        public void OnJokedEdited()
        {
            JokeDeleted.Invoke(this, Joke);
        }


        //Methods
        public void DeleteJoke()
        {
            Joke.Selfcreated = false;

            if(!Joke.Favourite)
            {
                _jokeWorkflow.DeleteOwnOrFavJoke(Joke);
            }

            OnJokeDeleted();

            Navigator.NavigateModalBack();
        }

        public void UpdateJoke()
        {
            _jokeWorkflow.UpdateOwnJoke(Joke);

            OnJokedEdited();

            Navigator.NavigateModalBack();
        }
    }
}
