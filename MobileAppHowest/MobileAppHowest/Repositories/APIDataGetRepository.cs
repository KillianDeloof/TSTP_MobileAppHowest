using MobileAppHowest.Models;
using MobileAppHowest.Models.Filters;
using MobileAppHowest.Models.MobileSDK.AzureMobileClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppHowest.Repositories
{
    public class APIDataGetRepository
    {
        /// <summary>
        /// Ophalen van de lijst van gebouwen, aangeleverd door de API.
        /// </summary>
        /// <returns>Task<List<Building>></returns>
        public async Task<List<Building>> GetBuildingList()
        {
            List<Building> result = new List<Building>();
            String pagejson = await AzureMobileClient.DefaultClient.InvokeApiAsync<string>("/api/Building", System.Net.Http.HttpMethod.Get, null, System.Threading.CancellationToken.None);
            List<Building> page = JsonConvert.DeserializeObject<List<Building>>(pagejson);
            result.AddRange(page);

            return result;
        }

        /// <summary>
        /// Ophalen van de lijst van campussen, aangeleverd door de API.
        /// </summary>
        /// <returns>Task<List<Campus>></returns>
        public static async Task<List<Campus>> GetCampusList()
        {
            List<Campus> result = new List<Campus>();
            String pagejson = await AzureMobileClient.DefaultClient.InvokeApiAsync<string>("/api/Campus", System.Net.Http.HttpMethod.Get, null, System.Threading.CancellationToken.None);
            List<Campus> page = JsonConvert.DeserializeObject<List<Campus>>(pagejson);
            result.AddRange(page);

            foreach (Campus c in result)
            {
                Console.WriteLine("UCODE: " + c.UCODE + " - " + "Address: " + c.Address);
            }

            return result;
        }

        /// <summary>
        /// Ophalen van de lijst van verdiepen, aangeleverd door de API.
        /// Hierbij wordt gebruik gemaakt van een FloorFilter.
        /// </summary>
        /// <returns>Task<List<Floor>></returns>
        public async Task<List<Floor>> GetFloorList()
        {
            List<Floor> result = new List<Floor>();
            FloorFilter ff = new FloorFilter();
            String pagejson = await AzureMobileClient.DefaultClient.InvokeApiAsync<FloorFilter, string>("/api/FloorSearch", ff, System.Net.Http.HttpMethod.Post, null, System.Threading.CancellationToken.None);
            List<Floor> page = JsonConvert.DeserializeObject<List<Floor>>(pagejson);
            result.AddRange(page);

            while (page.Count == ff.EffectivePageSize)
            {
                ff.LastFloor = page[page.Count - 1];
                pagejson = await AzureMobileClient.DefaultClient.InvokeApiAsync<FloorFilter, string>("/api/FloorSearch", ff, System.Net.Http.HttpMethod.Post, null, System.Threading.CancellationToken.None);
                page = JsonConvert.DeserializeObject<List<Floor>>(pagejson);
                result.AddRange(page);
            }

            return result;
        }

        /// <summary>
        /// Opvragen van de lijst van rooms, aangeleverd door de API.
        /// </summary>
        /// <returns>Task<List<Room>></returns>
        public async Task<List<Room>> GetRoomList(RoomFilter rf)
        {
            List<Room> result = new List<Room>();
            String pagejson = await AzureMobileClient.DefaultClient.InvokeApiAsync<RoomFilter, string>("/api/RoomSearch", rf, System.Net.Http.HttpMethod.Post, null, System.Threading.CancellationToken.None);
            List<Room> page = JsonConvert.DeserializeObject<List<Room>>(pagejson);
            result.AddRange(page);

            while (page.Count == rf.EffectivePageSize)
            {
                rf.LastRoom = page[page.Count - 1];
                pagejson = await AzureMobileClient.DefaultClient.InvokeApiAsync<RoomFilter, string>("/api/RoomSearch", rf, System.Net.Http.HttpMethod.Post, null, System.Threading.CancellationToken.None);
                page = JsonConvert.DeserializeObject<List<Room>>(pagejson);
                result.AddRange(page);
            }

            return result;
        }

        /// <summary>
        /// Opvragen van de lijst van verschillende forums, aangeleverd door de API.
        /// </summary>
        /// <returns>Task<List<Forum>></returns>
        public async Task<List<Forum>> GetForumList()
        {
            List<Forum> result = new List<Forum>();
            String pagejson = await AzureMobileClient.DefaultClient.InvokeApiAsync<string>("/api/forum", System.Net.Http.HttpMethod.Get, null, System.Threading.CancellationToken.None);
            List<Forum> page = JsonConvert.DeserializeObject<List<Forum>>(pagejson);
            result.AddRange(page);

            return result;
        }

        /// <summary>
        /// Opvragen van de lijst van verschillende categorieën problemen, aangeleverd door de API.
        /// </summary>
        /// <returns>Task<List<Category>></returns>
        //public async Task<List<Category>> GetCategoryList()
        //{
        //    try
        //    {
        //        List<Category> result = new List<Category>();
        //        String pagejson = await AzureMobileClient.DefaultClient.InvokeApiAsync<string>("/api/category", System.Net.Http.HttpMethod.Get, null, System.Threading.CancellationToken.None);
        //        List<Category> page = JsonConvert.DeserializeObject<List<Category>>(pagejson);
        //        result.AddRange(page);

        //        //List<String> categoryList = new List<string>();
        //        //result.ForEach(c => Console.WriteLine(c.CategoryUCode));

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return null;
        //    }
        //}

        //public async Task<List<Category>> GetCategoryList()
        //{
        //    List<Category> categoryList = new List<Category>();

        //}
    }
}
