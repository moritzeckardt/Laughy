using Foundation;
using Syncfusion.SfCarousel.XForms.iOS;
using System.IO;
using UIKit;
using Xamarin.Essentials;

namespace Laughy.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            //Init
            global::Xamarin.Forms.Forms.Init();
            SQLitePCL.Batteries_V2.Init();
            new SfCarouselRenderer();


            // Configuration with database path
            var config = new Configuration { DatabasePath = Path.Combine(FileSystem.AppDataDirectory, "LaughyDb.db") };


            LoadApplication(new App(config));


            return base.FinishedLaunching(app, options);
        }
    }
}
