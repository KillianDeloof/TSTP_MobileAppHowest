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




        public static List<Category> GetHardCodedCategoryList()
        {
            List<Category> list = new List<Category>();

            Category campus = new Category();
            campus.CategoryUDesc = "Campus";
            list.Add(campus);

            Category faciliteiten = new Category();
            faciliteiten.CategoryUDesc = "Faciliteiten";
            list.Add(faciliteiten);

            Category lesmateriaal = new Category();
            lesmateriaal.CategoryUDesc = "Study Materials";
            list.Add(lesmateriaal);

            Category netwerk = new Category();
            netwerk.CategoryUDesc = "Network";
            list.Add(netwerk);

            Category sorftwareHardware = new Category();
            sorftwareHardware.CategoryUDesc = "Software AND Hardware";
            list.Add(sorftwareHardware);

            Category organisatie = new Category();
            organisatie.CategoryUDesc = "Organization";
            list.Add(organisatie);

            Category other = new Category();
            other.CategoryUDesc = "Other";
            list.Add(other);

            foreach (Category cat in list)
            {
                GetHardcodedSupCat(cat);
            }

            return list;
        }

        private static List<SubCategory> GetHardcodedSupCat(Category cat)
        {
            List<SubCategory> list = new List<SubCategory>();

            SubCategory bookSales = new SubCategory();
            bookSales.SubCategoryUDesc = "BookSales";

            SubCategory financial = new SubCategory();
            financial.SubCategoryUDesc = "Financial";

            switch (cat.CategoryUDesc)
            {
                case "Campus":
                    SubCategory cateringAndVending = new SubCategory();
                    cateringAndVending.SubCategoryUDesc = "Catering And Vending Machines";
                    cateringAndVending.IsLocationRequired = true;
                    list.Add(cateringAndVending);

                    SubCategory furniture = new SubCategory();
                    furniture.SubCategoryUDesc = "Furniture";
                    furniture.IsLocationRequired = true;
                    list.Add(furniture);

                    SubCategory wasteManegment = new SubCategory();
                    wasteManegment.SubCategoryUDesc = "Waste Manegment";
                    wasteManegment.IsLocationRequired = true;
                    list.Add(wasteManegment);

                    SubCategory sanitary = new SubCategory();
                    sanitary.SubCategoryUDesc = "Sanitary";
                    sanitary.IsLocationRequired = true;
                    list.Add(sanitary);

                    SubCategory classRooms = new SubCategory();
                    classRooms.SubCategoryUDesc = "ClassRooms and Maintenance";
                    classRooms.IsLocationRequired = true;
                    list.Add(classRooms);

                    break;

                case "Faciliteiten":
                    SubCategory mobility = new SubCategory();
                    mobility.SubCategoryUDesc = "Mobility";
                    list.Add(mobility);

                    list.Add(bookSales);

                    SubCategory sportOffers = new SubCategory();
                    sportOffers.SubCategoryUDesc = "Sport Offers";
                    list.Add(sportOffers);

                    SubCategory printing = new SubCategory();
                    printing.SubCategoryUDesc = "Printing";
                    list.Add(printing);

                    SubCategory studdySupport = new SubCategory();
                    studdySupport.SubCategoryUDesc = "Studdy Support";
                    list.Add(studdySupport);

                    list.Add(financial);

                    break;

                case "Study Materials":
                    SubCategory studyMaterials = new SubCategory();
                    studyMaterials.SubCategoryUDesc = "Studdy Materials";
                    list.Add(studyMaterials);

                    list.Add(bookSales);

                    SubCategory studyPlatform = new SubCategory();
                    studyPlatform.SubCategoryUDesc = "Studdy Platform";
                    list.Add(studyPlatform);

                    list.Add(financial);

                    break;

                case "Network":
                    SubCategory wifi = new SubCategory();
                    wifi.SubCategoryUDesc = "WiFi";
                    wifi.IsLocationRequired = true;
                    list.Add(wifi);

                    SubCategory networkAcces = new SubCategory();
                    networkAcces.SubCategoryUDesc = "Network Acces";
                    list.Add(networkAcces);

                    SubCategory netWorkMaintenance = new SubCategory();
                    netWorkMaintenance.SubCategoryUDesc = "Network Maintenance";
                    netWorkMaintenance.IsLocationRequired = true;
                    list.Add(netWorkMaintenance);

                    SubCategory generalNetwork = new SubCategory();
                    generalNetwork.SubCategoryUDesc = "General Network";
                    list.Add(generalNetwork);

                    break;

                case "Software AND Hardware":
                    SubCategory softWare = new SubCategory();
                    softWare.SubCategoryUDesc = "SoftWare";
                    list.Add(softWare);

                    SubCategory sharepointDocenten = new SubCategory();
                    sharepointDocenten.SubCategoryUDesc = "Sharepoint Docenten";
                    sharepointDocenten.IsStaffRequired = true;
                    list.Add(sharepointDocenten);

                    SubCategory helpdesk = new SubCategory();
                    helpdesk.SubCategoryUDesc = "HelpDesk AND Remote Helpdesk";
                    list.Add(helpdesk);

                    SubCategory macSupport = new SubCategory();
                    macSupport.SubCategoryUDesc = "Mac Support";
                    list.Add(macSupport);

                    SubCategory signPost = new SubCategory();
                    signPost.SubCategoryUDesc = "SignPost";
                    list.Add(signPost);

                    break;

                case "Organization":
                    SubCategory generalOrganization = new SubCategory();
                    generalOrganization.SubCategoryUDesc = "generalOrganization";
                    list.Add(generalOrganization);

                    SubCategory events = new SubCategory();
                    events.SubCategoryUDesc = "Events";
                    list.Add(events);

                    SubCategory onderwijsOrganizatie = new SubCategory();
                    onderwijsOrganizatie.SubCategoryUDesc = "Educational organization";
                    list.Add(onderwijsOrganizatie);

                    break;

                case "Other":
                    SubCategory energyManegment = new SubCategory();
                    energyManegment.SubCategoryUDesc = "Energy Manegment";
                    list.Add(energyManegment);

                    SubCategory other = new SubCategory();
                    other.SubCategoryUDesc = "Other";
                    list.Add(other);

                    break;

                default:
                    break;
            }


            return list;
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

    }
}
