using System.Threading.Tasks;

namespace Laughy
{
    public interface IViewModelNavigationBase
    {
        //Tasks
        Task BeforeFirstShown();

        Task AfterDismissed();
    }
}
