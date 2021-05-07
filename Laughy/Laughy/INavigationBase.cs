using System.Threading.Tasks;

namespace Laughy
{
    public interface INavigationBase
    {
        //Tasks
        Task BeforeFirstShown();

        Task AfterDismissed();
    }
}
