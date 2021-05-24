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
        public ObservableRangeCollection<JokeUiModel> FavouriteJokes { get; set; } = new ObservableRangeCollection<JokeUiModel>();
        public ObservableRangeCollection<JokeUiModel> FavouriteJokesToBeSearched { get; set; } = new ObservableRangeCollection<JokeUiModel>();
        public ICommand GetFavouriteJokeCommand { get; set; }
        public ICommand DislikeJokeCommand { get; set; }
        public ICommand DisplayPreviousJokeCommand { get; set; }
        public ICommand SearchJokeCommand { get; set; }


        //Constructor
        public DisplayFavouriteJokePageViewModel(INavigator navigator, IJokeWorkflow jokeWorkflow) : base(navigator)
        {
            //Assignments
            _jokeWorkflow = jokeWorkflow;


            //Commands
            GetFavouriteJokeCommand = new Command(GetFavouriteJoke);
            DislikeJokeCommand = new Command(DislikeJoke);
            DisplayPreviousJokeCommand = new Command(DisplayPreviousJoke);
            SearchJokeCommand = new Command(SearchJoke);
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
                Joke = EmptyJoke;            
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

        public void SearchJoke()
        {
            FavouriteJokesToBeSearched.Clear();

            FavouriteJokesToBeSearched.AddRange(_jokeWorkflow.GetAllFavouriteJokes().AsEnumerable());

            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                var firstPartResult = FavouriteJokesToBeSearched.Where(x => x.FirstPart.ToLower().Contains(SearchText.ToLower().Trim()));

                var secondPartResult = FavouriteJokesToBeSearched.Where(x => x.SecondPart != null).Where(x => x.SecondPart.ToLower().Contains(SearchText.ToLower().Trim()));

                FavouriteJokes.Clear();

                FavouriteJokes.AddRange(firstPartResult);

                FavouriteJokes.AddRange(secondPartResult);

                GetFavouriteJoke();
            }
            
            GetAllFavouriteJokes();
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
