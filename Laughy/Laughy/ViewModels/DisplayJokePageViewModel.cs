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
        public JokeUiModel Joke { get; set; }
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

            Category = "Dark";
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
