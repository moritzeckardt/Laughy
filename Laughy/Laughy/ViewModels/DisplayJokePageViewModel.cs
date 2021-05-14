using Laughy.NavigationService.Interfaces;
using Laughy.ViewModels.Interfaces;
using System.Windows.Input;
using Xamarin.Forms;

namespace Laughy.ViewModels
{
    public class DisplayJokePageViewModel : ViewModelBase, IDisplayJokePageViewModel
    {
        //Properties
        public string Category { get; set; }
        public ICommand RefreshJokeCommand { get; set; }


        //Constructor
        public DisplayJokePageViewModel(INavigator navigator) : base(navigator)
        {
            //Commands
            RefreshJokeCommand = new Command(RefreshJoke);
        }


        //Methods
        public void RefreshJoke()
        {

        }
    }
}
