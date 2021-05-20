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
    public class DisplayFavouriteJokePageViewModel : ViewModelBase, IDisplayFavouriteJokePageViewModel
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
        public ObservableRangeCollection<JokeUiModel> FavouriteJokes { get; set; } = new ObservableRangeCollection<JokeUiModel>();
        public ICommand GetFavouriteJokeCommand { get; set; }
        public ICommand LikeJokeCommand { get; set; }
        public ICommand DislikeJokeCommand { get; set; }


        //Constructor
        public DisplayFavouriteJokePageViewModel(INavigator navigator, IJokeWorkflow jokeWorkflow) : base(navigator)
        {
            //Assignments
            _jokeWorkflow = jokeWorkflow;


            //Commands
            GetFavouriteJokeCommand = new Command(GetFavouriteJoke);
            LikeJokeCommand = new Command(LikeJoke);
            DislikeJokeCommand = new Command(DislikeJoke);


            //Other
            FavouriteJokes.AddRange(GetAllFavouriteJokes());
        }


        //Private methods
        private IEnumerable<JokeUiModel> GetAllFavouriteJokes()
        {
            var jokes = _jokeWorkflow.GetAllFavouriteJokes();

            var jokesAsEnumerable = jokes.AsEnumerable();

            return jokesAsEnumerable;
        }


        //Public methods
        public void GetFavouriteJoke()
        {           
            int randomIndex = RandomJokeManager.Next(FavouriteJokes.Count);

            Joke = FavouriteJokes[randomIndex];

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

        public void LikeJoke()
        {
            Joke.Favourite = true;

            _jokeWorkflow.CreateOrLikeJoke(Joke);

            FavouriteJokes.AddRange(GetAllFavouriteJokes());
        }

        public void DislikeJoke()
        {
            Joke.Favourite = false;

            _jokeWorkflow.DeleteFavouriteJoke(Joke);

            FavouriteJokes.AddRange(GetAllFavouriteJokes());

            GetFavouriteJoke();
        }


        //Tasks
        public override Task BeforeFirstShown()
        {
            FavouriteJokes.AddRange(GetAllFavouriteJokes());

            GetFavouriteJoke();

            return Task.CompletedTask;
        }
    }
}
