using Laughy.Logic.Integration.LaughyWorkflow.Contracts;
using Laughy.Models.UiModels;
using Laughy.NavigationService.Interfaces;
using Laughy.ViewModels.Interfaces;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Laughy.ViewModels
{
    public class CreateOwnJokePageViewModel : ViewModelBase, ICreateOwnJokePageViewModel
    {      
        //Fields
        private readonly IJokeWorkflow _jokeWorkflow;


        //Properties
        public JokeUiModel Joke { get; set; } = new JokeUiModel() { DbId = Guid.NewGuid() };
        public ICommand CreateJokeCommand { get; set; }
        public ICommand CancelJokeCommand { get; set; }


        //Constructor
        public CreateOwnJokePageViewModel(INavigator navigator, IJokeWorkflow jokeWorkflow) : base(navigator)
        {
            //Assignments
            _jokeWorkflow = jokeWorkflow;


            //Commands
            CreateJokeCommand = new Command(CreateJoke);
            CancelJokeCommand = new Command(CancelJoke);
        }


        //Events
        public EventHandler<JokeUiModel> JokeSaved { get; set; }
        public void OnJokeSaved()
        {
            JokeSaved.Invoke(this, Joke);
        }


        //Methods
        public void CreateJoke()
        {
            Joke.Selfcreated = true;

            _jokeWorkflow.CreateOrLikeJoke(Joke);

            OnJokeSaved();

            Navigator.NavigateModalBack();
        }

        public void CancelJoke()
        {
            Navigator.NavigateModalBack();
        }
    }
}
