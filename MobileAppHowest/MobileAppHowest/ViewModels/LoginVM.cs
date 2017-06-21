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
        public LoginVM(LoginPage loginPage)
        {
            this._loginPage = loginPage;
            this.Navigation = loginPage.Navigation;
            this._btnLogin = loginPage.FindByName<Button>("btnLogin");

            LoginCommand = new Command(LoginClicked);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Command LoginCommand { get; }
        private LoginRepository _loginRepo = new LoginRepository();
        private APIRepository _apiRepo = new APIRepository();
        public INavigation Navigation { get; set; }
        private Button _btnLogin = null;
        private Ticket _ticket;
        private DataBaseRepos _db = new DataBaseRepos("tstp");
        private LoginPage _loginPage = null;

        public async void LoginClicked()
        {
            ButtonModification();
            await StartLoginProcedure();
        }

        private async Task StartLoginProcedure()
        {
            // indien mogelijk user ophalen uit database
            // indien geslaagd -> tonen volgende pagina
            UserInfo ui = await _loginRepo.Login();

            /*try
            {
                if (IsKnownUser())
                {
                    ui = _db.GetUser(1);

                    if (ui == null)
                    {
                        ui = await _loginRepo.Login();
                        SaveUserInfo(ui);
                    }
                }
                else
                {
                    ui = await _loginRepo.Login();
                    SaveUserInfo(ui);
                }
                //else
                //{
                //    ui = await _loginRepo.Login();
                //    _db.CreateTable<UserInfo>();
                //    _db.SaveItem<UserInfo>(ui);
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ui = await _loginRepo.Login();
            }*/

            //if (!(await IsAuthenticated()))
            //{
            //    ui = await _loginRepo.Login();
            //}

            if (ui != null)
            {
                //_ticket = new Ticket(ui);
                //_ticket.UserID = ui.ID;

                AuthenticationDone();
            }
            else
            {
                await ShowLoginPage();
            }
        }

        private async Task<bool> IsAuthenticated()
        {
            bool success = false;
            try
            {
                List<Campus> campusList = new List<Campus>();
                campusList = await _apiRepo.GetCampusList();

                success = true;

                if (campusList.Count == 0 || campusList == null)
                    success = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                success = false;
            }

            return success;
        }

        /// <summary>
        /// Opslaan van data in SQLite database.
        /// </summary>
        /// <param name="ui">UserInfo</param>
        private void SaveUserInfo(UserInfo ui)
        {
            _db.CreateTable<UserInfo>();
            _db.SaveItem<UserInfo>(ui);
        }

        private void ButtonModification()
        {
            // modify button when clicked
            _btnLogin.IsEnabled = false;
            _btnLogin.Text = "Loading ...";
            _btnLogin.TextColor = Xamarin.Forms.Color.White;
            
            // spinner actief maken
            this._loginPage.FindByName<ActivityIndicator>("spSpinner").IsRunning = true;
        }

        /// <summary>
        /// Opvragen of er een token aanwezig is in de database.
        /// </summary>
        /// <returns>bool</returns>
        private bool IsKnownUser()
        {
            try
            {
                var auth = _db.GetAuthorization();

                if (auth == null)
                    return false;

                if (auth.Token != null)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        
        private async Task AuthenticationDone()
        {
            //String token = _db.GetAuthorization().Token;
            //int userId = _ticket.UserID;

            //var mobileServiceClient = new MobileServiceClient("/api/userinfo");
            //mobileServiceClient.CurrentUser = new MobileServiceUser(_ticket.UserID.ToString());
            //mobileServiceClient.CurrentUser.MobileServiceAuthenticationToken = token;
            
            await ShowCategoryPage();
        }

        //private async Task LoadRooms()
        //{
        //    List<Room> roomList = await GetRoomList();
        //    if (roomList == null)
        //    {
        //        UserInfo ui = await _loginRepo.Login();
        //        SaveUserInfo(ui);

        //        await StartLoginProcedure();

        //        return;
        //    }

        //    _db.CreateTable<Room>();
        //    //roomList.ForEach(r => _db.SaveItem<Room>(r));
        //    foreach(Room room in roomList)
        //    {
        //        _db.SaveItem<Room>(room);
        //    }

        //    //List<Room> list = (List<Room>)_db.GetItems<Room>();
        //    //List<Room> list = (List<Room>)_db.GetRooms();
        //}

        /// <summary>
        /// Ophalen van de lijst van Rooms vanaf de API.
        /// </summary>
        /// <returns>Task<List<Room>></returns>
        private async Task<List<Room>> GetRoomList()
        {
            List<Room> roomList = await _apiRepo.GetRoomList();
            return roomList;
        }

        /// <summary>
        /// Tonen van de CategoryPage.
        /// </summary>
        private async Task ShowCategoryPage()
        {
            await Navigation.PushAsync(new CategoryPage(_ticket));
        }

        /// <summary>
        /// De LoginPage opnieuw inladen.
        /// </summary>
        private async Task ShowLoginPage()
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}
