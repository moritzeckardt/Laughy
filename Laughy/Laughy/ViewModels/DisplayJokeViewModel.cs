using Laughy.NavigationService.Interfaces;
using Laughy.ViewModels.Interfaces;
using System.Windows.Input;
using Xamarin.Forms;

namespace Laughy.ViewModels
{
    public class DisplayJokeViewModel : ViewModelBase, IDisplayJokeViewModel
    {
        //Properties
        public string Category { get; set; }
        public ICommand RefreshJokeCommand { get; set; }


        //Constructor
        public DisplayJokeViewModel(INavigator navigator) : base(navigator)
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
