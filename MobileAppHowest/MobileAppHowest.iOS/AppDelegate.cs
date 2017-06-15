using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using MobileAppHowest.Models.MobileSDK.AzureMobileClient;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using MobileAppHowest.Models.MobileSDK;

namespace MobileAppHowest.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate,IAuthenticate
	{
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.

        //

        // Define a authenticated user.
        private MobileServiceUser user;
        public string LoginMessage { get; set; } = string.Empty;
        public async Task<bool> Authenticate()
        {
            Boolean success = false;
            try
            {
                user = await AzureMobileClient.DefaultClient.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController, MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory);
                if (user != null)
                {
                    LoginMessage = string.Format("you are now signed-in as {0}.", user.UserId);
                    success = true;
                }
            }
            catch (Exception ex)
            {
                LoginMessage = ex.Message;
            }
            return success;
        }
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();
			
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            App.Init((IAuthenticate)this);

            LoadApplication(new MobileAppHowest.App());
            return base.FinishedLaunching (app, options);
		}
	}
}
