using Laughy.Logic.Integration.LaughyWorkflow.Contracts;
using Laughy.Models.UiModels;
using Laughy.NavigationService.Interfaces;
using Laughy.ViewModels.Interfaces;
using System;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IEditOwnJokePageViewModel _editOwnJokePageViewModel;
        private readonly IServiceProvider _serviceProvider;


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

        public ObservableRangeCollection<JokeUiModel> OwnJokes { get; set; } = new ObservableRangeCollection<JokeUiModel>();
        public ObservableRangeCollection<JokeUiModel> OwnJokesToBeSearched { get; set; } = new ObservableRangeCollection<JokeUiModel>();
        public ICommand GetJokeCommand { get; set; }
        public ICommand CreateJokeCommand { get; set; }
        public ICommand SearchJokeCommand { get; set; }       
        public ICommand TapJokeCommand { get; set; }


        //Constructor
        public DisplayOwnJokePageViewModel(INavigator navigator, IJokeWorkflow jokeWorkflow, IEditOwnJokePageViewModel editOwnJokePageViewModel, 
            IServiceProvider serviceProvider) : base(navigator)
        {
            //Assignments
            _jokeWorkflow = jokeWorkflow;
            _editOwnJokePageViewModel = editOwnJokePageViewModel;
            _serviceProvider = serviceProvider;


            //Commands
            GetJokeCommand = new Command(GetJoke);
            CreateJokeCommand = new Command(CreateJoke);
            SearchJokeCommand = new Command(SearchJoke);
            TapJokeCommand = new Command(TapJoke);
        }


        //Private methods
        private void GetAllOwnJokes()
        {
            var jokeUiModels = _jokeWorkflow.GetAllOwnJokes().AsEnumerable();

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
        
        private void RecieveCreatedJoke(object obj, JokeUiModel createdJoke)
        {
            Joke = createdJoke;

            GetAllOwnJokes();

            ManageHeadlines();

            SavePreviousJoke();
        }

        private void RecieveDeletedJoke(object obj, JokeUiModel deletedJoke)
        {
            GetAllOwnJokes();

            GetJoke();
        }

        private void RecieveEditedJoke(object obj, JokeUiModel editedJoke)
        {
            Joke = editedJoke;

            GetAllOwnJokes();
        }


        //Public methods
        public void GetJoke()
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

        public void CreateJoke()
        {
            var createOwnJokePageViewModel = _serviceProvider.GetService<ICreateOwnJokePageViewModel>();

            createOwnJokePageViewModel.JokeSaved += RecieveCreatedJoke;

            Navigator.NavigateModalTo(createOwnJokePageViewModel); 
        }

        public override void LikeJoke()
        {
            if (Joke != EmptyJoke && !Joke.Favourite)
            {
                Joke.Favourite = true;

                _jokeWorkflow.UpdateOwnJoke(Joke);
            }
        }

        public override void DisplayPreviousJoke()
        {
            if (PreviousJokeToBeDisplayed != null)
            {
                PreviousJokeToBeSaved = PreviousJokeToBeDisplayed;

                Joke = PreviousJokeToBeDisplayed;
            }

            else
            {
                Joke = PreviousJokeToBeSaved;
            }

            ManageHeadlines();
        }

        public void SearchJoke()
        {
            OwnJokesToBeSearched.Clear();

            OwnJokesToBeSearched.AddRange(_jokeWorkflow.GetAllOwnJokes().AsEnumerable());

            if (!string.IsNullOrWhiteSpace(SearchText))
            {                           
                var firstPartResult = OwnJokesToBeSearched.Where(x => x.FirstPart.ToLower().Contains(SearchText.ToLower().Trim()));

                var secondPartResult = OwnJokesToBeSearched.Where(x => x.SecondPart != null).Where(x => x.SecondPart.ToLower().Contains(SearchText.ToLower().Trim()));

                OwnJokes.Clear();

                OwnJokes.AddRange(firstPartResult);

                OwnJokes.AddRange(secondPartResult);

                GetJoke();

                GetAllOwnJokes();

                SavePreviousJoke();
            }         
        }

        public void TapJoke()
        {
            if(Joke != EmptyJoke)
            {
                _editOwnJokePageViewModel.Joke = Joke;

                _editOwnJokePageViewModel.JokeDeleted += RecieveDeletedJoke;

                _editOwnJokePageViewModel.JokeEdited += RecieveEditedJoke;

                Navigator.NavigateModalTo(_editOwnJokePageViewModel);
            }         
        }


        //Tasks
        public override Task BeforeFirstShown()
        {
            GetAllOwnJokes();

            GetJoke();

            return Task.CompletedTask;
        }
    }
}
