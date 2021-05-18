using Laughy.Logic.Integration.LaughyWorkflow.Contracts;
using Laughy.Models.UiModels;
using Laughy.NavigationService.Interfaces;
using Laughy.ViewModels.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

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

        public ICommand GetJokeCommand { get; set; }
        public ICommand LikeJokeCommand { get; set; }


        //Constructor
        public DisplayJokePageViewModel(INavigator navigator, IJokeWorkflow jokeWorkflow) : base(navigator)
        {
            //Assignments
            _jokeWorkflow = jokeWorkflow;


            //Commands
            GetJokeCommand = new AsyncCommand(GetJoke);
            LikeJokeCommand = new AsyncCommand(LikeJoke);
        }


        //Methods
        public async Task GetJoke()
        {
            Joke = await _jokeWorkflow.GetJokeByCategory(Category);            

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

        public async Task LikeJoke()
        {

        }


        //Tasks
        public override Task BeforeFirstShown()
        {
            GetJoke().ConfigureAwait(false);

            return Task.CompletedTask;
        }

    }
}
