using MobileAppHowest.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

/* ------------------------------------------ how to use ---------------------------
 public MainPageViewModel() {
  ...
  var database = new Database("People"); // Creates (if does not exist) a database named People
  database.CreateTable<Person>(); // Creates (if does not exist) a table of type Person
  ...
}


    Classes that needs to be saved to database need to inherit from  "MobileAppHowest.Models.BaseItem"    !!!!!!!!!!!!!!!!!
     
     */

namespace MobileAppHowest.Repositories
{
    public class DataBaseRepos// : ISQLite
    {

        static object locker = new object();

        ISQLite SQLite
        {
            get
            {
                return DependencyService.Get<ISQLite>();
            }
        }
        readonly SQLiteConnection _connection;
        readonly string DatabaseName;




        public DataBaseRepos(string databaseName)
        {
            DatabaseName = databaseName;
            //connection = SQLite.GetConnection(DatabaseName);
            _connection = DependencyService.Get<ISQLite>().GetConnection(DatabaseName);//get a registered class that implements the ISQLite interface and call its GetConnection method.
        }


        public long GetSize()
        {
            return SQLite.GetSize(DatabaseName);
        }


        /// <summary>
        /// create a table in the databace, if it doesn't already exist
        /// </summary>
        /// <typeparam name="T">The ObjectType of the table</typeparam>
        public void CreateTable<T>()
        {
            lock (locker)
            {
                _connection.CreateTable<T>();
            }
        }



        public int SaveItem<T>(T item)
        {
            lock (locker)
            {
                var id = ((BaseItem)(object)item).ID;
                if (id != 0)
                {
                    _connection.Update(item);
                    return id;
                }
                else
                {
                    return _connection.Insert(item);
                }
            }
        }

        public void ExecuteQuery(string query, object[] args)
        {
            lock (locker)
            {
                _connection.Execute(query, args);
            }
        }

        public List<T> Query<T>(string query, object[] args) where T : new()
        {
            lock (locker)
            {
                return _connection.Query<T>(query, args);
            }
        }

        public IEnumerable<T> GetItems<T>() where T : new()
        {
            lock (locker)
            {
                return (from i in _connection.Table<T>() select i).ToList();
            }
        }

        public int DeleteItem<T>(int id)
        {
            lock (locker)
            {
                return _connection.Delete<T>(id);
            }
        }

        public int DeleteAll<T>()
        {
            lock (locker)
            {
                return _connection.DeleteAll<T>();
            }
        }






        

        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------




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
