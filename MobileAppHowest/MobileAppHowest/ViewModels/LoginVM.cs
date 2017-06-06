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

        public LoginVM(INavigation navigation)
        {
            this.Navigation = navigation;
            LoginCommand = new Command(LoginClicked);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Command LoginCommand { get; }
        private LoginRepository _loginRepo = new LoginRepository();
        public INavigation Navigation { get; set; }



        public async void LoginClicked()
        {
            UserInfo ui = await _loginRepo.Login();

            // indien login ok is -> naar CategoryPage()
            if (ui != null)
            {
                await ShowCategoryPage();
            }
            else
            {
                // TO DO: opvangen wat er gebeurt als er login mislukte

            }
        }

        private async Task ShowCategoryPage()
        {
            await Navigation.PushAsync(new CategoryPage());
        }
    }
}
