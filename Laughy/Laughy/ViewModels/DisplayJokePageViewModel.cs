using Laughy.Logic.Integration.LaughyWorkflow.Contracts;
using Laughy.Models.UiModels;
using Laughy.NavigationService.Interfaces;
using Laughy.ViewModels.Interfaces;
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
        public ICommand GetJokeCommand { get; set; }
        public ICommand LikeJokeCommand { get; set; }


        //Constructor
        public DisplayJokePageViewModel(INavigator navigator, IJokeWorkflow jokeWorkflow) : base(navigator)
        {
            //Assignments
            _jokeWorkflow = jokeWorkflow;


            //Commands
            GetJokeCommand = new AsyncCommand(GetJoke);
            LikeJokeCommand = new Command(LikeJoke);
        }


        //Methods
        public async Task GetJoke()
        {
            Joke = await _jokeWorkflow.GetJokeByCategory(Category);
        }

        public void LikeJoke()
        {

        }

    }
}
