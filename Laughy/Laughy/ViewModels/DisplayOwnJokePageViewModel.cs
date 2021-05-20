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
    public class DisplayOwnJokePageViewModel : ViewModelBase, IDisplayOwnJokePageViewModel
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

        public Random RandomJokeManager { get; set; } = new Random();
        public ObservableRangeCollection<JokeUiModel> OwnJokes { get; set; } = new ObservableRangeCollection<JokeUiModel>();
        public ICommand GetOwnJokeCommand { get; set; }
        public ICommand CreateOwnJokeCommand { get; set; }
        public ICommand DeleteOwnJokeCommand { get; set; }
        public ICommand LikeJokeCommand { get; set; }
        public ICommand DislikeJokeCommand { get; set; }


        //Constructor
        public DisplayOwnJokePageViewModel(INavigator navigator, IJokeWorkflow jokeWorkflow) : base(navigator)
        {
            //Assignments
            _jokeWorkflow = jokeWorkflow;


            //Commands
            GetOwnJokeCommand = new Command(GetOwnJoke);
            CreateOwnJokeCommand = new Command(CreateOwnJoke);
            DeleteOwnJokeCommand = new Command(DeleteOwnJoke);
            LikeJokeCommand = new Command(LikeJoke);
            DislikeJokeCommand = new Command(DislikeJoke);
        }


        //Private methods
        private IEnumerable<JokeUiModel> GetAllOwnJokes()
        {
            var jokeUiModels = _jokeWorkflow.GetAllOwnJokes();

            return jokeUiModels;
        }


        //Public methods
        public void GetOwnJoke()
        {
            OwnJokes.AddRange(GetAllOwnJokes());

            int randomIndex = RandomJokeManager.Next(OwnJokes.Count);

            Joke = OwnJokes[randomIndex];

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

        public void CreateOwnJoke()
        {
            Joke.Selfcreated = true;

            _jokeWorkflow.CreateOrLikeJoke(Joke);
        }

        public void DeleteOwnJoke()
        {
            Joke.Selfcreated = false;

            _jokeWorkflow.DeleteOwnJoke(Joke);
        }

        public void LikeJoke()
        {
            Joke.Favourite = true;

            _jokeWorkflow.CreateOrLikeJoke(Joke);
        }

        public void DislikeJoke()
        {
            Joke.Favourite = false;

            _jokeWorkflow.DeleteFavouriteJoke(Joke);
        }


        //Tasks
        public override Task BeforeFirstShown()
        {
            GetOwnJoke();

            return Task.CompletedTask;
        }
    }
}
