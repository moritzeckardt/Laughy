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
        public ICommand DislikeJokeCommand { get; set; }


        //Constructor
        public DisplayFavouriteJokePageViewModel(INavigator navigator, IJokeWorkflow jokeWorkflow) : base(navigator)
        {
            //Assignments
            _jokeWorkflow = jokeWorkflow;


            //Commands
            GetFavouriteJokeCommand = new Command(GetFavouriteJoke);
            DislikeJokeCommand = new Command(DislikeJoke);
        }


        //Private methods
        public void GetAllFavouriteJokes()
        {
            var jokeUiModels = _jokeWorkflow.GetAllFavouriteJokes().AsEnumerable();

            FavouriteJokes.Clear();

            FavouriteJokes.AddRange(jokeUiModels);
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

        public void DislikeJoke()
        {
            Joke.Favourite = false;

            _jokeWorkflow.DeleteFavouriteJoke(Joke);

            GetAllFavouriteJokes();

            GetFavouriteJoke();
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
