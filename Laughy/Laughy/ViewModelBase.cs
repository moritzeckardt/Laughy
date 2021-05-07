using System.Threading.Tasks;

namespace Laughy
{
    public class ViewModelBase
    {
        //Tasks
        public Task BeforeFirstShown()
        {
            return Task.CompletedTask;
        }

        public Task AfterDismissed()
        {
            return Task.CompletedTask;
        }
    }
}
