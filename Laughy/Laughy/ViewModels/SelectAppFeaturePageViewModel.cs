using Laughy.ViewModels.Interfaces;
using System.Threading.Tasks;

namespace Laughy.ViewModels
{
    public class SelectAppFeaturePageViewModel : ISelectAppFeaturePageViewModel
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
