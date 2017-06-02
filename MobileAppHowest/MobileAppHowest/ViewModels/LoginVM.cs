using MobileAppHowest.Models;
using MobileAppHowest.Repositories;
using MobileAppHowest.Views;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileAppHowest.ViewModels
{
    public partial class LoginVM : INotifyPropertyChanged
    {
        public LoginVM()
        {
            LoginCommand = new Command(LoginClicked);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private Command LoginCommand { get; }
        private LoginRepository _loginRepo = new LoginRepository();
        


        //private async void LoginClicked()
        //{
        //    UserInfo ui = await _loginRepo.Login();

        //    // indien login ok is -> naar CapusPage()
        //    if (ui != null)
        //    {
        //        //await ShowCampusPage();
        //    }
        //    else
        //    {
        //        // TO DO: opvangen wat er gebeurt als er login mislukte

        //    }
        //}
    }
}
