using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Laughy.Droid.Utils
{
    public interface IPageController
    {
        //Fields
        Rectangle ContainerArea { get; set; }
        bool IgnoresContainerArea { get; set; }
        ObservableCollection<Element> InternalChildren { get; }


        //Methods
        void SendAppearing();

        void SendDisappearing();
    }
}