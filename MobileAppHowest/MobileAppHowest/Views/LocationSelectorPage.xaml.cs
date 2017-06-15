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
            InitializeComponent();

            //this._ticket = ticket;
            BindingContext = new LocationSelectorVM(Navigation, ticket, this);
            //Start();
        }

        //private APIRepository _apiRepo = new APIRepository();
        //private Ticket _ticket = null;

        //private async Task<List<Floor>> GetFloorList()
        //{
        //    List<Floor> floorList = await _apiRepo.GetFloorList();
        //    List<Floor> filteredList = floorList.ToList().Where(f => f.UDESC.Split('.')[1] == _ticket.Building.UDESC.Split('.')[1]).ToList<Floor>();

        //    return filteredList;
            
        //    //-- dummy data --//
            
        //    //return new List<Floor>
        //    //{
        //    //    new Floor()
        //    //    {
        //    //        UDESC = "A"
        //    //    },
        //    //    new Floor()
        //    //    {
        //    //        UDESC = "B"
        //    //    },
        //    //    new Floor()
        //    //    {
        //    //        UDESC = "C"
        //    //    }
        //    //};
        //}

        //public List<Room> _roomList { get; set; }

        //private async Task<List<Room>> FillRoomList()
        //{
        //    _roomList = await _apiRepo.GetRoomList(new RoomFilter());
        //    return _roomList;


        //    //-- dummy data --//

        //    //return new List<Room>
        //    //{
        //    //    new Room()
        //    //    {
        //    //        UDESC = "GKG.A.A.0.0.7"
        //    //    },

        //    //    new Room()
        //    //    {
        //    //        UDESC = "GKG.A.A.0.0.8"
        //    //    },

        //    //    new Room()
        //    //    {
        //    //        UDESC = "GKG.A.A.0.0.9"
        //    //    }
        //    //};
        //}

        //private void Start()
        //{
        //    CreateAccordion();
        //}

        //private async Task CreateAccordion()
        //{
        //    List<Floor> floorList = await GetFloorList();
        //    List<Room> roomList = await FillRoomList();

        //    foreach (Floor floor in floorList)
        //    {
        //        List<Room> filteredList = roomList
        //            .Where(r => (r.UDESC.Split('.')[0] == floor.UDESC.Split('.')[0]) &&
        //                (r.UDESC.Split('.')[1] == floor.UDESC.Split('.')[1]) &&
        //                (r.UDESC.Split('.')[3] == floor.UDESC.Split('.')[3]))
        //            .ToList<Room>();
                
        //        CreateAccordeonItemView(filteredList, floor.UDESC.Split('.')[3]);
        //    }
        //}

        //private void CreateAccordeonItemView(List<Room> roomList, String floorNumber)
        //{
        //    if (roomList.Count == 0)
        //        return;

        //    var itemView = new Xamarin.CustomControls.AccordionItemView()
        //    {
        //        Text = "Floor " + floorNumber,
        //        ActiveTextColor = Xamarin.Forms.Color.White,
        //        TextColor = Xamarin.Forms.Color.White,
        //        BackgroundColor = new Xamarin.Forms.Color(
        //            HexToRGB("45c8f5")[0],
        //            HexToRGB("45c8f5")[1],
        //            HexToRGB("45c8f5")[2], 1
        //        ),
        //        ButtonActiveBackgroundColor = new Xamarin.Forms.Color(HexToRGB("0067b7")[0], HexToRGB("0067b7")[1], HexToRGB("0067b7")[2], 1),
        //        TextPosition = Xamarin.CustomControls.TextPosition.Left,
        //        RightImage = "arrowRight",
        //        RotateImages = true
        //    };

        //    var stackLayout = new StackLayout()
        //    {
        //        Padding = new Xamarin.Forms.Thickness(0.5, 0, 0.5, 0.5),
        //        BackgroundColor = Xamarin.Forms.Color.Black
        //    };

        //    var stackLayout2 = new StackLayout()
        //    {
        //        Padding = new Xamarin.Forms.Thickness(5, 15),
        //        BackgroundColor = Xamarin.Forms.Color.Silver,
        //        Orientation = Xamarin.Forms.StackOrientation.Vertical
        //    };

        //    foreach (Room room in roomList)
        //    {
        //        var button = new Button()
        //        {
        //            Text = room.UDESC.ToString(),
        //            HorizontalOptions = Xamarin.Forms.LayoutOptions.CenterAndExpand,
        //            VerticalOptions = Xamarin.Forms.LayoutOptions.CenterAndExpand,
        //            BorderWidth = 0
        //        };

        //        button.Clicked += ShowNextPage;

        //        stackLayout2.Children.Add(button);
        //    }
            
        //    stackLayout.Children.Add(stackLayout2);
        //    itemView.ItemContent = stackLayout;
        //    accordionView.Children.Add(itemView);
        //}

        //private void ShowNextPage(object sender, EventArgs e)
        //{
        //    //_ticket.Building = 
        //    Console.WriteLine("sender text: " + ((Button)sender).Text);
        //    _ticket.Location = _roomList.ToList<Room>().Where(r => r.UCODE.ToLower() == ((Button)sender).Text.ToLower()).FirstOrDefault();
        //    ShowMessagePage();
        //}

        //private async Task ShowMessagePage()
        //{
        //    await Navigation.PushAsync(new MessagePage(_ticket));
        //}

        ///// <summary>
        ///// Omzetten van hexadecimaal naar een rgb-array.
        ///// Merk op dat enkel kleine letters kunnen gebruikt worden.
        ///// </summary>
        ///// <returns>double[]</returns>
        //private double[] HexToRGB(String hex)
        //{
        //    String hex1 = hex.Substring(0, 2);
        //    String hex2 = hex.Substring(2, 2);
        //    String hex3 = hex.Substring(4, 2);

        //    List<double> doubleList = new List<double>
        //    {
        //        Convert.ToInt32(hex1, 16),
        //        Convert.ToInt32(hex2, 16),
        //        Convert.ToInt32(hex3, 16)
        //    };

        //    return doubleList.ToArray<double>();
        //}
    }
}