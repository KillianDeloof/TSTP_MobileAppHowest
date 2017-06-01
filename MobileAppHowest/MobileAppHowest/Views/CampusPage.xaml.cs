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

            GetCampusList();
		}

        private APIDataGetRepository _campusRepo = new APIDataGetRepository();
        private GPSRepository _gpsRepo = new GPSRepository();
        
        private async void GetCampusList()
        {
            List<Campus> campusList = await _campusRepo.GetCampusList();

            // TO DO:
            // sorteren van lijst adhv GPS-signaal

            lvCampus.ItemsSource = campusList.ToList<Campus>();
        }

        // hier terechtkomen wanneer een campus geselecteerd is
        private async Task Campus_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            Campus selectedCampus = (Campus)lvCampus.SelectedItem;
            ShowRoomPage(selectedCampus);
        }

        // doorverwijzen naar RoomPage wanneer campus werd geselecteerd
        private async void ShowRoomPage(Campus myCampus)
        {
            Page newPage = new RoomPage(myCampus);
            await Navigation.PushAsync(newPage);
        }


    }
}