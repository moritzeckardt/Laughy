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

        public string Category { get; set; }
        public string SearchText { get; set; }
        public JokeUiModel PreviousJokeToBeSaved { get; set; }
        public JokeUiModel PreviousJokeToBeDisplayed { get; set; }
        public JokeUiModel EmptyJoke { get; set; } = new JokeUiModel() { FirstPart = "Sadly we couldn't find any joke." };
        public Random RandomJokeManager { get; set; } = new Random();
        public ObservableRangeCollection<JokeUiModel> OwnJokes { get; set; } = new ObservableRangeCollection<JokeUiModel>();
        public ObservableRangeCollection<JokeUiModel> OwnJokesToBeSearched { get; set; } = new ObservableRangeCollection<JokeUiModel>();
        public ICommand GetOwnJokeCommand { get; set; }
        public ICommand CreateOwnJokeCommand { get; set; }
        public ICommand DeleteOwnJokeCommand { get; set; }
        public ICommand LikeJokeCommand { get; set; }
        public ICommand DislikeJokeCommand { get; set; }
        public ICommand DisplayPreviousJokeCommand { get; set; }
        public ICommand SearchJokeCommand { get; set; }


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
            DisplayPreviousJokeCommand = new Command(DisplayPreviousJoke);
            SearchJokeCommand = new Command(SearchJoke);
        }


        //Private methods
        private void GetAllOwnJokes()
        {
            var jokeUiModels = _jokeWorkflow.GetAllFavouriteJokes().AsEnumerable();

            OwnJokes.Clear();

            OwnJokes.AddRange(jokeUiModels);
        }

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
        public void GetOwnJoke()
        {
            if (OwnJokes.Count != 0)
            {
                int randomIndex = RandomJokeManager.Next(OwnJokes.Count);
                Joke = OwnJokes[randomIndex];
            }

            else
            {
                Joke = EmptyJoke;
            }

            ManageHeadlines();

            SavePreviousJoke();
        }

        public void CreateOwnJoke()
        {
            if(Joke != EmptyJoke)
            {
                Joke.Selfcreated = true;

                _jokeWorkflow.CreateOrLikeJoke(Joke);
            }      
        }

        public void DeleteOwnJoke()
        {
            Joke.Selfcreated = false;

            _jokeWorkflow.DeleteOwnJoke(Joke);

            GetAllOwnJokes();

            GetOwnJoke();
        }

        public void LikeJoke()
        {
            if (Joke != EmptyJoke)
            {
                Joke.Favourite = true;

                _jokeWorkflow.CreateOrLikeJoke(Joke);
            }               
        }

        public void DislikeJoke()
        {
            Joke.Favourite = false;

            _jokeWorkflow.DeleteFavouriteJoke(Joke);
        }


        public void DisplayPreviousJoke()
        {
            PreviousJokeToBeSaved = PreviousJokeToBeDisplayed;

            Joke = PreviousJokeToBeDisplayed;

            ManageHeadlines();
        }

        public void SearchJoke()
        {
            OwnJokesToBeSearched.Clear();

            if (!string.IsNullOrWhiteSpace(SearchText))
            {             
                OwnJokesToBeSearched.AddRange(_jokeWorkflow.GetAllFavouriteJokes().AsEnumerable());

                var firstPartResult = OwnJokesToBeSearched.Where(x => x.FirstPart.ToLower().Contains(SearchText.ToLower().Trim()));

                var secondPartResult = OwnJokesToBeSearched.Where(x => x.SecondPart != null).Where(x => x.SecondPart.ToLower().Contains(SearchText.ToLower().Trim()));

                OwnJokes.Clear();

                OwnJokes.AddRange(firstPartResult);

                OwnJokes.AddRange(secondPartResult);

                GetOwnJoke();

                GetAllOwnJokes();
            }         
        }


        //Tasks
        public override Task BeforeFirstShown()
        {
            GetAllOwnJokes();

            GetOwnJoke();

            return Task.CompletedTask;
        }
    }
}
