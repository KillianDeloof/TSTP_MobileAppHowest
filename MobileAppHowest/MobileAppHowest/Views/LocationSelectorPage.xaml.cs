using MobileAppHowest.Models;
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
            BindingContext = new LocationSelectorVM(Navigation, ticket);
            CreateAccordion(GetFloorList());
		}

        private List<Floor> GetFloorList()
        {
            return new List<Floor>
            {
                new Floor()
                {
                    UDESC = "A"
                },
                new Floor()
                {
                    UDESC = "B"
                },
                new Floor()
                {
                    UDESC = "C"
                }
            };
        }

        private List<Room> GetRoomList()
        {
            return new List<Room>
            {
                new Room()
                {
                    UDESC = "GKG.A.A.0.0.7"
                },

                new Room()
                {
                    UDESC = "GKG.A.A.0.0.8"
                },

                new Room()
                {
                    UDESC = "GKG.A.A.0.0.9"
                }
            };
        }

        private void CreateAccordion(List<Floor> floorList)
        {
            foreach(Floor floor in floorList)
            {
                CreateAccordeonItemView(GetRoomList());
            }
        }

        private void CreateAccordeonItemView(List<Room> roomList)
        {
            var itemView = new Xamarin.CustomControls.AccordionItemView()
            {
                Text = "Floor x",
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
                Console.WriteLine();
                var label = new Label()
                {
                    Text = room.UDESC.Split('.')[2].ToString() + "." + room.UDESC.Split('.')[3].ToString() + "." + room.UDESC.Split('.')[4].ToString() + "." + room.UDESC.Split('.')[5].ToString(),
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