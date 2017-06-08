using MobileAppHowest.Models;
using MobileAppHowest.Models.Filters;
using MobileAppHowest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppHowest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoomPage : ContentPage
	{
		public RoomPage ()
		{
			InitializeComponent ();
		}

        public RoomPage(Campus myCampus)
        {
            // we krijgen de geselecteerde campus mee
            // aan de hand hiervan kunnen we een lijst met gebouwen ophalen
            _myCampus = myCampus;
            GetBuildingList();
        }

        private Campus _myCampus = null;

        private APIDataGetRepository _locationRepo = new APIDataGetRepository();

        //private async void CboBuilding_SelectItem(object sender, EventArgs e)
        //{
        //    GetFilteredFloorList();
        //}

        //private async void CboFloor_SelectItem(object sender, EventArgs e)
        //{
        //    GetFilteredRoomList();
        //}

        private async void GetBuildingList()
        {
            if (_myCampus == null)
                return;

            // 1. ophalen van building list
            List<Building> buildingList = await _locationRepo.GetBuildingList();
            Console.WriteLine(buildingList);

            // 2. enkel nodige buildings in lijst steken
            //buildingList.ForEach(b => b. == _myCampus.);

            // 3. sorteren van building list adhv gps-signaal
            //    -> TO DO

            // 4. weergeven van building list in combobox
            //    -> TO DO
        }

        private async void GetFilteredFloorList(Building myCampus)
        {
            // er kan pas een floor geselecteerd worden, als we een gebouw hebben
            
            // 1. ophalen floorList
            List<Floor> floorList = await _locationRepo.GetFloorList();

            // 2. filteren van floor adhv gebouw
            //    -> niet mogelijk om een floor te kiezen adhv gebouw
            //       zelf filtering te voorzien dus
            //    -> TO DO

            // 3. lijst weergeven in dropdown list
            //    -> TO DO

            // 4. ophalen van de roomList
            //    -> zie methode GetFilteredRoomList
        }

        private async void GetFilteredRoomList(Floor myFloor)
        {
            // 1. aanmaken FloorFilter
            RoomFilter rf = new RoomFilter()
            {
                // ...
            };

            // 2. opvragen van de lijst van rooms adhv de gekozen floor
            List<Room> roomList = await _locationRepo.GetRoomList(rf);

            // 3. weergeven van lijst in dropdown list
        }
    }
}