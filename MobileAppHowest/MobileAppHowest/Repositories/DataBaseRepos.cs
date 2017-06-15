using MobileAppHowest.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;



namespace MobileAppHowest.Repositories
{
    public class DataBaseRepos// : ISQLite
    {
        readonly string DatabaseName;


        private SQLiteConnection _connection;

        public DataBaseRepos(string databaseName)
        {
            DatabaseName = databaseName;
            //connection = SQLite.GetConnection(DatabaseName);
            _connection = DependencyService.Get<ISQLite>().GetConnection(DatabaseName);//get a registered class that implements the ISQLite interface and call its GetConnection method.
            _connection.CreateTable<UserInfo>();//create the table, if it doesn't already exist
        }

        public IEnumerable<UserInfo> GetUsers()
        {
            return (from t in _connection.Table<UserInfo>()
                    select t).ToList();
        }

        public UserInfo GetUser(int id)
        {
            return _connection.Table<UserInfo>().FirstOrDefault(t => t.ID == id);
        }

        public void DeleteUser(int id)
        {
            _connection.Delete<UserInfo>(id);
        }

        public void AddUser(string thought)
        {
            var newThought = new UserInfo
            {
                FirstName = thought,
                LastName = "lastName"
            };

            _connection.Insert(newThought);
        }


        //---------------------------------------------------


        //private async Task<string> insertUpdateData(UserInfo data, string path)
        //{
        //    try
        //    {
        //        var db = new SQLiteAsyncConnection(path);
        //        if (await db.InsertAsync(data) != 0)
        //            await db.UpdateAsync(data);
        //        return "Single data file inserted or updated";
        //    }
        //    catch (SQLiteException ex)
        //    {
        //        return ex.Message;
        //    }
        //}












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
