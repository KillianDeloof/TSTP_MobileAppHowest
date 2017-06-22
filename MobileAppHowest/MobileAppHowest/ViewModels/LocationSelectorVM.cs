using MobileAppHowest.Models;
using MobileAppHowest.Models.Filters;
using MobileAppHowest.Repositories;
using MobileAppHowest.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace MobileAppHowest.ViewModels
{
    public class LocationSelectorVM : INotifyPropertyChanged
    {
        public LocationSelectorVM(INavigation navigation, Ticket ticket, LocationSelectorPage lsPage)
        {
            _locationSelectorPage = lsPage;

            this.Navigation = navigation;
            this._ticket = ticket;
            lsPage.Title = _ticket.Building.UCODE.Replace(',', '.').ToUpper().ToString();

            Start();
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private LocationSelectorPage _locationSelectorPage = null;
        private INavigation Navigation = null;
        private APIRepository _apiRepo = new APIRepository();
        private DataBaseRepos _db = new DataBaseRepos("tstp");
        private Ticket _ticket = null;

        private async Task<List<Floor>> GetFloorList()
        {
            List<Floor> floorList = new List<Floor>();

            floorList = await _apiRepo.GetFloorList();

            return floorList;

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

        public List<Room> _roomList { get; set; }

        private async Task<List<Room>> FillRoomList()
        {
            _roomList = await _apiRepo.GetRoomList();

            return _roomList;


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
            // ophalen van de gefilterde lijst
            // hierna wordt de accordion meteen ingeladen
            GetFilteredList();
        }

        private async Task GetFilteredList()
        {
            List<Floor> floorList = await GetFloorList();
            List<Room> roomList = await FillRoomList();

            List<Floor> filteredFloorList = new List<Floor>();

            try
            {
                filteredFloorList = floorList.ToList()
                    .Where(f => f.UCODE.Split('.')[0].ToLower() == _ticket.Building.UCODE.Split('.')[0].ToLower() &&
                           f.UCODE.Split('.')[1].ToLower() == _ticket.Building.UCODE.Split('.')[1].ToLower())
                    .ToList<Floor>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            foreach (Floor floor in filteredFloorList)
            {
                List<Room> filteredRoomList = new List<Room>();

                try
                {
                    filteredRoomList = roomList
                        .Where(r => (r.UCODE.Split('.')[0] != null) &&
                            (r.UCODE.Split('.')[0].ToLower() == floor.UCODE.Split('.')[0].ToLower()) &&
                            (r.UCODE.Split('.')[1].ToLower() == floor.UCODE.Split('.')[1].ToLower()) &&
                            (r.UCODE.Replace(',', '.').Split('.')[3].ToLower() == floor.UCODE.Replace(',', '.').Split('.')[3].ToLower()))
                        .ToList<Room>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                CreateAccordeonItemView(filteredRoomList, floor.UCODE.Replace(',', '.').Split('.')[3]);
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
                FontFamily= "VAG_Rounded_Bold",
                ButtonBackgroundColor = Color.FromRgb(69,200,245),
                ButtonActiveBackgroundColor = Color.FromRgb(52, 150, 184),
                TextPosition = Xamarin.CustomControls.TextPosition.Left,
                RightImage = "arrowRight",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                RotateImages = true
            };

            var stackLayout = new StackLayout()
            {
                BackgroundColor = Xamarin.Forms.Color.Black
            };

            var stackLayout2 = new StackLayout()
            {
                BackgroundColor = Color.FromRgb(224, 224, 224),
                Orientation = Xamarin.Forms.StackOrientation.Vertical
            };

            for (int i = 0; i < roomList.Count; i++)
            {
                var label = new Label()
                {
                    Text = roomList[i].UDESC.ToString(),
                    HorizontalOptions = Xamarin.Forms.LayoutOptions.Fill,
                    VerticalOptions = Xamarin.Forms.LayoutOptions.FillAndExpand,
                    BackgroundColor = Xamarin.Forms.Color.Transparent,
                    HeightRequest = 25,
                    Margin = new Thickness(0, 10, 0, 10),
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                };
                
                label.GestureRecognizers.Add(new TapGestureRecognizer((view) => ShowNextPage(view)));
                stackLayout2.Children.Add(label);
            }

            stackLayout.Children.Add(stackLayout2);
            itemView.ItemContent = stackLayout;
            _locationSelectorPage.FindByName<AccordionView>("accordionView").Children.Add(itemView);
        }

        private void ShowNextPage(object sender)
        {
            Console.WriteLine("sender text: " + ((Label)sender).Text);
            _ticket.Location = _roomList.ToList<Room>().Where(r => r.UCODE.ToLower() == ((Label)sender).Text.ToLower()).FirstOrDefault();
            ShowMessagePage();
        }

        private async Task ShowMessagePage()
        {
            await Navigation.PushAsync(new MessagePage(_ticket));
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
    }
}
