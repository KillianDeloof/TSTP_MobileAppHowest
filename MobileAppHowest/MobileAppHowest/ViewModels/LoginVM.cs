using Microsoft.WindowsAzure.MobileServices;
using MobileAppHowest.Models;
using MobileAppHowest.Repositories;
using MobileAppHowest.Views;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileAppHowest.ViewModels
{
    public partial class LoginVM : INotifyPropertyChanged
    {
        //private INavigationService _navigationService { get; }

        public LoginVM(LoginPage loginPage)
        {
            this.Navigation = loginPage.Navigation;
            this._btnLogin = loginPage.FindByName<Button>("btnLogin");

            LoginCommand = new Command(LoginClicked);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Command LoginCommand { get; }
        private LoginRepository _loginRepo = new LoginRepository();
        public INavigation Navigation { get; set; }
        private Button _btnLogin = null;
        private Ticket _newTicket;
        private DataBaseRepos _db = new DataBaseRepos("tstp");

        public async void LoginClicked()
        {
            ButtonModification();
            await StartLoginProcedure();
        }

        private async Task StartLoginProcedure()
        {
            // indien mogelijk user ophalen uit database
            // indien geslaagd -> tonen volgende pagina
            UserInfo ui = null;

            try
            {
                if (IsUserAuthenticated())
                {
                    ui = _db.GetUser(1);
                }
                else
                {
                    ui = await _loginRepo.Login();
                    //_db.CreateTable<UserInfo>();
                    //_db.SaveItem<UserInfo>(ui);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (ui != null)
            {
                _newTicket = new Ticket(ui);
                await ShowCategoryPage();
            }
            else
            {
                await Navigation.PushAsync(new LoginPage());
            }

            //UserInfo ui = _db.GetUser(1);

            //if (ui != null)
            //{
            //    ui = _db.GetUser(1);
            //    _newTicket = new Ticket(ui);
            //    await ShowCategoryPage();
            //    return;
            //}

            //ui = await _loginRepo.Login();

            //// indien login ok is -> naar CategoryPage()
            //if (ui != null)
            //{
            //    _newTicket = new Ticket(ui);

            //    _db.CreateTable<UserInfo>();
            //    _db.SaveItem<UserInfo>(ui);

            //    await ShowCategoryPage();
            //}
            //else
            //{
            //    // TO DO: opvangen wat er gebeurt als er login mislukte

            //}
        }

        private void ButtonModification()
        {
            // modify button when clicked
            _btnLogin.IsEnabled = false;
            _btnLogin.Text = "Loading ...";
            _btnLogin.TextColor = Xamarin.Forms.Color.White;

            // TO DO:
            // spinner gebruiken en knop disabelen
        }

        private bool IsUserAuthenticated()
        {
            bool isAuth = false;

            try
            {
                if (_db.GetAuthorization() == null)
                {
                    return true;
                }
                else
                {
                    isAuth = false;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        /// <summary>
        /// Tonen van de CategoryPage.
        /// </summary>
        private async Task ShowCategoryPage()
        {
            await Navigation.PushAsync(new CategoryPage(_newTicket));
        }
    }
}
