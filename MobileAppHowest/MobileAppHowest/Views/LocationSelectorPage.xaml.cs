using MobileAppHowest.Models;
using MobileAppHowest.Models.Filters;
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
	public partial class LocationSelectorPage : ContentPage
	{
		public LocationSelectorPage(Ticket ticket)
		{
            this._ticket = ticket;
            InitializeComponent();
            BindingContext = new LocationSelectorVM(Navigation, ticket);
            Start();
        }

        private APIRepository _apiRepo = new APIRepository();
        private Ticket _ticket = null;

        private async Task<List<Floor>> GetFloorList()
        {
            // TO DO:
            // mag niet als constante!
            //_ticket.Building.UDESC = "GKG.A";

            List<Floor> floorList = await _apiRepo.GetFloorList();
            List<Floor> filteredList = floorList.ToList().Where(f => f.UDESC.Split('.')[1] == _ticket.Building.UDESC.Split('.')[1]).ToList<Floor>();

            return filteredList;
            
            //-- dummy data --//
            
            //return new List<Floor>
            //{
            //    new Floor()
            //    {
            //        UDESC = "A"
            //    },
            //    new Floor()
            //    {
            //        UDESC = "B"
            //    },
            //    new Floor()
            //    {
            //        UDESC = "C"
            //    }
            //};
        }

        private async Task<List<Room>> GetRoomList()
        {
            List<Room> roomList = await _apiRepo.GetRoomList(new RoomFilter());
            return roomList;


            //-- dummy data --//

            //return new List<Room>
            //{
            //    new Room()
            //    {
            //        UDESC = "GKG.A.A.0.0.7"
            //    },

            //    new Room()
            //    {
            //        UDESC = "GKG.A.A.0.0.8"
            //    },

            //    new Room()
            //    {
            //        UDESC = "GKG.A.A.0.0.9"
            //    }
            //};
        }

        private void Start()
        {
            CreateAccordion();
        }

        private async Task CreateAccordion()
        {
            List<Floor> floorList = await GetFloorList();
            List<Room> roomList = await GetRoomList();

            foreach (Floor floor in floorList)
            {
                List<Room> filteredList = roomList
                    .Where(r => (r.UDESC.Split('.')[0] == floor.UDESC.Split('.')[0]) &&
                        (r.UDESC.Split('.')[1] == floor.UDESC.Split('.')[1]) &&
                        (r.UDESC.Split('.')[3] == floor.UDESC.Split('.')[3]))
                    .ToList<Room>();
                
                CreateAccordeonItemView(filteredList, floor.UDESC.Split('.')[3]);
            }
        }

        private void CreateAccordeonItemView(List<Room> roomList, String floorNumber)
        {
            if (roomList.Count == 0)
                return;

            var itemView = new Xamarin.CustomControls.AccordionItemView()
            {
                Text = "Floor " + floorNumber,
                ActiveTextColor = Xamarin.Forms.Color.White,
                TextColor = Xamarin.Forms.Color.White,
                BackgroundColor = new Xamarin.Forms.Color(
                    HexToRGB("45c8f5")[0],
                    HexToRGB("45c8f5")[1],
                    HexToRGB("45c8f5")[2], 1
                ),
                ButtonActiveBackgroundColor = new Xamarin.Forms.Color(HexToRGB("0067b7")[0], HexToRGB("0067b7")[1], HexToRGB("0067b7")[2], 1),
                TextPosition = Xamarin.CustomControls.TextPosition.Left,
                RightImage = "arrowRight",
                RotateImages = true,
            };
            
            var stackLayout = new StackLayout()
            {
                Padding = new Xamarin.Forms.Thickness(0.5, 0, 0.5, 0.5),
                BackgroundColor = Xamarin.Forms.Color.Black
            };

            var stackLayout2 = new StackLayout()
            {
                Padding = new Xamarin.Forms.Thickness(5, 15),
                BackgroundColor = Xamarin.Forms.Color.Silver,
                Orientation = Xamarin.Forms.StackOrientation.Vertical
            };

            foreach (Room room in roomList)
            {
                var label = new Label()
                {
                    Text = room.UDESC.ToString(),
                    HorizontalOptions = Xamarin.Forms.LayoutOptions.CenterAndExpand,
                    VerticalOptions = Xamarin.Forms.LayoutOptions.CenterAndExpand
                };

                stackLayout2.Children.Add(label);
            }
            
            stackLayout.Children.Add(stackLayout2);
            itemView.ItemContent = stackLayout;
            accordionView.Children.Add(itemView);
        }

        /// <summary>
        /// Omzetten van hexadecimaal naar een rgb-array.
        /// Merk op dat enkel kleine letters kunnen gebruikt worden.
        /// </summary>
        /// <returns>double[]</returns>
        private double[] HexToRGB(String hex)
        {
            String hex1 = hex.Substring(0, 2);
            String hex2 = hex.Substring(2, 2);
            String hex3 = hex.Substring(4, 2);

            List<double> doubleList = new List<double>
            {
                Convert.ToInt32(hex1, 16),
                Convert.ToInt32(hex2, 16),
                Convert.ToInt32(hex3, 16)
            };

            return doubleList.ToArray<double>();
        }

        private void Handle_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.nuget.org/packages/Xamarin.CustomControls.AccordionView"));
        }
    }
}