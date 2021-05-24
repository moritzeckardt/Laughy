using Laughy.Logic.Integration.LaughyWorkflow.Contracts;
using Laughy.Models.UiModels;
using Laughy.NavigationService.Interfaces;
using Laughy.ViewModels.Interfaces;
using System;
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
        private int counter;


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
        
        public JokeUiModel PreviousJokeToBeSaved { get; set; }
        public JokeUiModel PreviousJokeToBeDisplayed { get; set; }

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
        public ICommand DislikeJokeCommand { get; set; }
        public ICommand DisplayPreviousJokeCommand { get; set; }


        //Constructor
        public DisplayFavouriteJokePageViewModel(INavigator navigator, IJokeWorkflow jokeWorkflow) : base(navigator)
        {
            //Assignments
            _jokeWorkflow = jokeWorkflow;


            //Commands
            GetFavouriteJokeCommand = new Command(GetFavouriteJoke);
            DislikeJokeCommand = new Command(DislikeJoke);
            DisplayPreviousJokeCommand = new Command(DisplayPreviousJoke);
        }


        //Private methods
        private void GetAllFavouriteJokes()
        {
            var jokeUiModels = _jokeWorkflow.GetAllFavouriteJokes().AsEnumerable();

            FavouriteJokes.Clear();

            FavouriteJokes.AddRange(jokeUiModels);
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
        public void GetFavouriteJoke()
        {
            if(FavouriteJokes.Count != 0)
            {
                int randomIndex = RandomJokeManager.Next(FavouriteJokes.Count);
                Joke = FavouriteJokes[randomIndex];
            }

            else
            {
                Joke = new JokeUiModel() { FirstPart = "You don't have any favourite jokes yet." };
            }

            ManageHeadlines();

            SavePreviousJoke();
        }

        public void DislikeJoke()
        {
            Joke.Favourite = false;

            _jokeWorkflow.DeleteFavouriteJoke(Joke);

            GetAllFavouriteJokes();

            GetFavouriteJoke();
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
            GetAllFavouriteJokes();

            GetFavouriteJoke();

            return Task.CompletedTask;  
        }
    }
}
