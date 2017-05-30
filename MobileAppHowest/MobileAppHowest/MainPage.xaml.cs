using MobileAppHowest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileAppHowest
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        //private UserInfo ui;

        //private async void BtnLogin_Clicked(object sender, EventArgs e)
        //{
        //    if (await App.Authenticator.Authenticate())
        //    {
        //        String sui = await Models.MobileSDK.AzureMobileClient.AzureMobileClient.DefaultClient.InvokeApiAsync<string>("/api/userinfo", System.Net.Http.HttpMethod.Get, null, System.Threading.CancellationToken.None);
        //        Console.WriteLine(sui);
        //        ui = JsonConvert.DeserializeObject<UserInfo>(sui);
        //        btnLogin.Text = $"Hallo {ui.FirstName}!";
        //    }
        //}
    }
}
