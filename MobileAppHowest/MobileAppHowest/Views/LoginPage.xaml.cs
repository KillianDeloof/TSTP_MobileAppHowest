using MobileAppHowest.Models;
using MobileAppHowest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppHowest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        private LoginRepository _loginRepo = new LoginRepository();

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            UserInfo ui = await _loginRepo.Login();

            // indien login ok is -> naar CapusPage()
            if (ui != null)
            {
                await ShowCampusPage();
            } else
            {
                // TO DO: opvangen wat er gebeurt als er login mislukte
                
            }
        }

        private async Task ShowCampusPage()
        {
            Page newPage = new CampusPage();
            await Navigation.PushAsync(newPage);
        }
    }
}