using Laughy.Logic.Integration.LaughyWorkflow.Contracts;
using Laughy.Models.UiModels;
using Laughy.NavigationService.Interfaces;
using Laughy.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace Laughy.ViewModels
{
    public class DisplayJokePageViewModel : ViewModelBase, IDisplayJokePageViewModel
    {
        //Fields
        private readonly IJokeWorkflow _jokeWorkflow;


        //Properties
        private JokeUiModel _joke;
        public JokeUiModel Joke
        {
            get { return _joke; }
            set
            {
                _joke = value;               
                OnPropertyChanged(nameof(Joke));
            }
        }
        public string Category { get; set; }

        private string _firstHeadline;
        public string FirstHeadline
        {
            get { return _firstHeadline; }
            set
            {
                _firstHeadline = value;
                OnPropertyChanged(nameof(FirstHeadline));
            }
        }

        private string _secondHeadline;
        public string SecondHeadline
        {
            get { return _secondHeadline; }
            set
            {
                _secondHeadline = value;
                OnPropertyChanged(nameof(SecondHeadline));
            }
        }

        public JokeUiModel PreviousJokeToBeSaved { get; set; }
        public JokeUiModel PreviousJokeToBeDisplayed { get; set; }
        public ICommand GetJokeCommand { get; set; }
        public ICommand LikeJokeCommand { get; set; }
        public ICommand DisplayPreviousJokeCommand { get; set; }


        //Constructor
        public DisplayJokePageViewModel(INavigator navigator, IJokeWorkflow jokeWorkflow) : base(navigator)
        {
            //Assignments
            _jokeWorkflow = jokeWorkflow;


            //Commands
            GetJokeCommand = new AsyncCommand(GetJoke);
            LikeJokeCommand = new Command(LikeJoke);
            DisplayPreviousJokeCommand = new Command(DisplayPreviousJoke);
        }


        //Private methods
        private void ManageHeadlines()
        {
            if (String.IsNullOrWhiteSpace(Joke.SecondPart))
            {
                FirstHeadline = "Joke:";
                SecondHeadline = "";
            }

            else
            {
                FirstHeadline = "First part:";
                SecondHeadline = "Second part:";
            }
        }

        private void SavePreviousJoke()
        {
            PreviousJokeToBeDisplayed = PreviousJokeToBeSaved;

            PreviousJokeToBeSaved = Joke;
        }


        //Public methods
        public async Task GetJoke()
        {
            Joke = await _jokeWorkflow.GetJokeByCategory(Category);

            ManageHeadlines();

            SavePreviousJoke();
        }

        public void LikeJoke()
        {
            if(!Joke.Favourite)
            {
                Joke.Favourite = true;

                _jokeWorkflow.CreateOrLikeJoke(Joke);
            }        
        }

        public void DisplayPreviousJoke()
        {
            PreviousJokeToBeSaved = PreviousJokeToBeDisplayed;

            Joke = PreviousJokeToBeDisplayed;

            ManageHeadlines();
        }


        //Tasks
        public override Task BeforeFirstShown()
        {
            GetJoke().ConfigureAwait(false);

            return Task.CompletedTask;
        }

    }
}
