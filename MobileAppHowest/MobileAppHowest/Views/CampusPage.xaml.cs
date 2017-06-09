using MobileAppHowest.Models;
using MobileAppHowest.Repositories;
using MobileAppHowest.ViewModels;
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
		public CampusPage(Ticket newTicket)
		{
			InitializeComponent();
            BindingContext = new CampusVM(Navigation, newTicket);
		}

        //private APIRepository _APIDataGetRepository = new APIRepository();
        //private GPSRepository _gpsRepo = new GPSRepository();
        
        //private async void GetCampusList()
        //{
        //    List<Campus> campusList = await _APIDataGetRepository.GetCampusList();

        //    // TO DO:
        //    // sorteren van lijst adhv GPS-signaal
        //    SortCampusByGPS(campusList);

        //    lvCampus.ItemsSource = campusList.ToList<Campus>();
        //}

        //private void SortCampusByGPS(List<Campus> campusList)
        //{
        //    //campusList.Sort(c => c.Distance);
        //}

        //// hier terechtkomen wanneer een campus geselecteerd is
        //private async Task Campus_Selected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    Campus selectedCampus = (Campus)lvCampus.SelectedItem;
        //    ShowRoomPage(selectedCampus);
        //}

        //// doorverwijzen naar RoomPage wanneer campus werd geselecteerd
        //private async void ShowRoomPage(Campus myCampus)
        //{
        //    Page newPage = new RoomPage(myCampus);
        //    await Navigation.PushAsync(newPage);
        //}
    }
}