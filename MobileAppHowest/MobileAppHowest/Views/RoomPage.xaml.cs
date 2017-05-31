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
            //GetBuildingList();
		}

        //private LocationRepository _locationRepo = new LocationRepository();

        //private async void GetBuildingList()
        //{
        //    List<Building> buildingList = await _locationRepo.GetBuildingList();
        //    //cboBuildings.ItemsSource = buildingList.ToList();
        //}

        //private async void CboBuilding_SelectItem(object sender, EventArgs e)
        //{
        //    GetFilteredFloorList();
        //}

        //private async void CboFloor_SelectItem(object sender, EventArgs e)
        //{
            

        //    GetFilteredRoomList();
        //}

        //private async void GetFilteredFloorList()
        //{
        //    // niet mogelijk om een floor te kiezen adhv gebouw
        //    // zelf filtering te voorzien dus
        //    List<Floor> floorList = await _locationRepo.GetFloorList();
        //    // 1. filteren
        //    // 2. lijst weergeven
        //}

        //private async void GetFilteredRoomList(RoomFilter rf)
        //{
        //    // opvragen van de lijst van rooms adhv de gekozen floor
        //    List<Room> roomList = await _locationRepo.GetRoomList(rf);
            
            
        //}
    }
}