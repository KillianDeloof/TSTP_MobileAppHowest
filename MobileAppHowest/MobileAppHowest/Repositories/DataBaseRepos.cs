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


        public UserInfo GetUser(int id)
        {
            return _connection.Table<UserInfo>().FirstOrDefault(t => t.ID == id);
        }




    }
}
