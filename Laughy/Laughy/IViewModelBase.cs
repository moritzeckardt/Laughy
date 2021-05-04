using System.Threading.Tasks;

namespace Laughy
{
    public interface IViewModelBase
    {
        //Tasks
        Task BeforeFirstShown();

        Task AfterDismissed();
    }
}
