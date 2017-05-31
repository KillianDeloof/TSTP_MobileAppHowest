using MobileAppHowest.Models;
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
	public partial class CampusPage : ContentPage
	{
		public CampusPage()
		{
			InitializeComponent();

            //ShowRoomPage(new Campus() {  });

            GetCampusList();
		}

        private LocationRepository _campusRepo = new LocationRepository();
        private GPSRepository _gpsRepo = new GPSRepository();
        
        private async void GetCampusList()
        {
            List<Campus> campusList = await _campusRepo.GetCampusList();
            //List<Campus> sortedCampusList = await SortListByLocation(campusList);

            // weergeven van campussen in lijst(?)

        }

        //private async Task<List<Campus>> SortListByLocation(List<Campus> campusList)
        //{
        //    double[] latLng = await _gpsRepo.GetLocation();
        //    double latCurrent = latLng[0];
        //    double lngCurrent = latLng[1];

        //    // berekenen afstand tot verschillende campussen
        //    //foreach (Campus c in campusList)
        //    //{
        //    //    c.
        //    //    CalcDistance(latCurrent, lngCurrent, latCampus, lngCampus);
        //    //}
        //}

        //private async void ShowRoomPage(myCampus)
        //{
        //    Page newPage = new RoomPage(myCampus);
        //    await Navigation.PushAsync(newPage);
        //}


    }
}