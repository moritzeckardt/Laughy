using Android.Content;
using Android.Views;
using Laughy.Droid.CustomRenderers;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(Button), typeof(SingleTapButtonRenderer))]
namespace Laughy.Droid.CustomRenderers
{
    public class SingleTapButtonRenderer : ButtonRenderer
    {
        //Fields
        private bool justClicked = false;


        //Constructor
        public SingleTapButtonRenderer(Context context) : base(Android.App.Application.Context)
        {

        }


        //Methods
        public override bool OnFilterTouchEventForSecurity(MotionEvent e)
        {
            if (e.Action == MotionEventActions.Up)
            {
                if (justClicked)
                {
                    return false;
                }

                else
                {
                    justClicked = true;

                    Task.Run(async () => { await Task.Delay(300); justClicked = false; }); // Reset after a timeout
                }

                return true;
            }

            return base.OnFilterTouchEventForSecurity(e);
        }
    }
}