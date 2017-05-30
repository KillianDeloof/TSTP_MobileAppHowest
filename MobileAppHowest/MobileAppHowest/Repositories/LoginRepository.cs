using MobileAppHowest.Models;
using MobileAppHowest.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppHowest.Repositories
{
    public class LoginRepository
    {
        private static UserInfo ui;

        /// <summary>
        /// Opens a new screen and authenticates the user.
        /// </summary>
        /// <returns>Task<UserInfo></returns>
        public async Task<UserInfo> Login()
        {
            try
            {
                if (await App.Authenticator.Authenticate())
                {
                    String sui = await Models.MobileSDK.AzureMobileClient.AzureMobileClient.DefaultClient.InvokeApiAsync<string>("/api/userinfo", System.Net.Http.HttpMethod.Get, null, System.Threading.CancellationToken.None);
                    Console.WriteLine(sui);
                    return ui = JsonConvert.DeserializeObject<UserInfo>(sui);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
