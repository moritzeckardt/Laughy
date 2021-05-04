using Laughy.ViewModels.Interfaces;
using System.Threading.Tasks;

namespace Laughy.ViewModels
{
    public class SelectJokeCategoryPageViewModel : ISelectJokeCategoryPageViewModel
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
