using MobileAppHowest.Models;
using MobileAppHowest.Repositories;
using MobileAppHowest.Views;
using Prism.Navigation;
using System;
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
        private TicketRepository _ticketRepo = new TicketRepository();
        public INavigation Navigation { get; set; }
        private Button _btnLogin = null;
        private Ticket _newTicket;

        public async void LoginClicked()
        {
            _btnLogin.IsEnabled = false;
            UserInfo ui = await _loginRepo.Login();

            // indien login ok is -> naar CategoryPage()
            if (ui != null)
            {
                _newTicket = new Ticket(ui);
                await ShowCategoryPage();
            }
            else
            {
                // TO DO: opvangen wat er gebeurt als er login mislukte

            }
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
