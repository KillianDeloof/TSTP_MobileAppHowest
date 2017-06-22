using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MobileAppHowest.Models.MobileSDK;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using MobileAppHowest.Models.MobileSDK.AzureMobileClient;
using Plugin.Media;
using MobileAppHowest.Repositories;
using MobileAppHowest.Models;

namespace MobileAppHowest.Droid
{
    [Activity(Label = "TSTP", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IAuthenticate
    {
        private DataBaseRepos _db;

        #region microsoftazuremobileclientsdk1
        // Define a authenticated user.
        private MobileServiceUser user;
        public string LoginMessage { get; set; } = string.Empty;
        public async Task<bool> Authenticate()
        {
            _db = new DataBaseRepos("tstp");
            Boolean success = false;

            try
            {
                // ophalen van token
                user = await AzureMobileClient.DefaultClient.LoginAsync(this, MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory);

                if (user != null)
                {
                    LoginMessage = string.Format("you are now signed-in as {0}.", user.UserId);

                    // wegschrijven van token naar db
                    AuthenticatedUser au = new AuthenticatedUser()
                    {
                        Token = user.MobileServiceAuthenticationToken
                    };

                    _db.CreateTable<AuthenticatedUser>();
                    _db.SaveItem<AuthenticatedUser>(au);

                    success = true;
                }
            }
            catch (Exception ex)
            {
                LoginMessage = ex.Message;
            }

            return success;
        }
        #endregion


        protected async override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            #region microsoftazuremobileclientsdk2
            // Initialize Azure Mobile Apps
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            #endregion

            global::Xamarin.Forms.Forms.Init(this, bundle);

            #region microsoftazuremobileclientsdk3
            // Initialize the authenticator before loading the app.
            App.Init((IAuthenticate)this);
            #endregion

            LoadApplication(new App());
        }
    }
}

