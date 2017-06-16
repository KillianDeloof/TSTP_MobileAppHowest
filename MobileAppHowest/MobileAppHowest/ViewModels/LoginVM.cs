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

        public LoginVM(INavigation navigation, Button btn)
        {
            this.Navigation = navigation;
            this._btnLogin = btn;
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
            _btnLogin.IsEnabled = false;
            _btnLogin.Text = "Loading...";
            UserInfo ui = await _loginRepo.Login();
            ui.FirstRole = ui.Roles[0]; //added this prop to save it to database

            // indien login ok is -> naar CategoryPage()
            if (ui != null)
            {
                _newTicket = new Ticket(ui);
                _db.CreateTable<UserInfo>();
                _db.SaveItem<UserInfo>(ui);
                await ShowCategoryPage();
            }
            else
            {
                // TO DO: opvangen wat er gebeurt als er login mislukte

            }

            //_db.GetItems<UserInfo>()
            //List<UserInfo> uiList = _db.Query<UserInfo>("select * from UserInfo", null);
            //foreach(UserInfo usi in uiList)
            //{
            //    Console.WriteLine(usi.FirstName + " " + usi.LastName);
            //}
            UserInfo usi = _db.GetUser(1);
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
