using MobileAppHowest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using XamarinForms.SQLite.SQLite;
using Xamarin.Forms;



namespace MobileAppHowest.Repositories
{
    public class DataBaseRepos// : ISQLite
    {
        private readonly SQLiteConnection _sqLiteConnection;


        public DataBaseRepos()
        {
            _sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

            _sqLiteConnection.CreateTable<UserInfo>();
            _sqLiteConnection.CreateTable<Ticket>();
            _sqLiteConnection.CreateTable<Campus>();
            _sqLiteConnection.CreateTable<Building>();
            _sqLiteConnection.CreateTable<Floor>();
            _sqLiteConnection.CreateTable<Room>();
        }

        public void InsertUser(UserInfo user)
        {
            // ADD
            _sqLiteConnection.InsertOrReplace(user);
        }

        public UserInfo GetUser()
        {
            UserInfo user = _sqLiteConnection.Table<UserInfo>().FirstOrDefault();           
            return user;
        }


        //---------------------------------------------------

        public void UpdateDatabase()
        {

        }
        public DateTime GetLastUpdate()
        {
            return DateTime.Now;
        }
        public void SafeLastUpdated()
        {

        }

        //-----------------------------------------data------------------------------------------
        public UserInfo GetUserInfo()
        {
            return null;
        }
        public List<Campus> GetCampusList()
        {
            return null;
        }
        public List<Building> GetBuildingList()
        {
            return null;
        }
        public List<Building> GetBuildingList(Campus campusFilter)
        {
            return null;
        }
        public List<Floor> GetFloorList()
        {
            return null;
        }
        public List<Floor> GetFloorList(Building buildingFilter)
        {
            return null;
        }
        public List<Room> GetRoomList()
        {
            return null;
        }
        public List<Room> GetRoomList(Floor floorFilter)
        {
            return null;
        }
        public List<MainCategory> GetMainCategorys()
        {
            return null;
        }
        public List<Category> GetCategorys(MainCategory mainCat)
        {
            return null;
        }
        public void SafeUserInfo(UserInfo user)
        {

        }
        public void SafeCampusList(List<Campus> campusList)
        {

        }
        public void SafeBuildingList(List<Building> buildingList)
        {

        }
        public void SafeFloorList(List<Floor> floorList)
        {

        }
        public void SafeRoomList(List<Room> roomList)
        {

        }
        public void SafeMainCatList(List<MainCategory> mainCatList)
        {

        }
        public void SafeCatList(List<Category> catList)
        {

        }


    }
}
