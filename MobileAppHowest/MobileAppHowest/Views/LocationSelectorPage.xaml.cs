using MobileAppHowest.Models;
using MobileAppHowest.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
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
		}

        private void CreateAccordeonItemView()
        {
            //var itemView = new Xamarin.CustomControls.AccordionItemView()
            //{

            //    Text = "Floor 0",
            //    ActiveTextColor = Xamarin.Forms.Color.White,
            //    TextColor = Xamarin.Forms.Color.White,
            //    ButtonBackgroundColor = new Xamarin.Forms.Color(HexToRGB("45c8f5")[0], HexToRGB("45c8f5")[1], HexToRGB("45c8f5")[2]),
            //    ButtonActiveBackgroundColor = new Xamarin.Forms.Color(HexToRGB("0067B7")[0], HexToRGB("0067B7")[1], HexToRGB("0067B7")[2]),
            //    TextPosition = 
            //    RightImage = "arrowRight",
            //    RotateImages = true
            //};

            

            //var children = new Xamarin.CustomControls.AccordionView()
            //{

            //}
        }

        private double[] HexToRGB(String rgb)
        {
            double[] arrInt = new double[3];
            arrInt[0] = Convert.ToInt32(rgb.Substring(0, 2));
            arrInt[1] = Convert.ToInt32(rgb.Substring(2, 2));
            arrInt[2] = Convert.ToInt32(rgb.Substring(4, 2));

            return arrInt;
        }

        private void Handle_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.nuget.org/packages/Xamarin.CustomControls.AccordionView"));
        }
    }
}