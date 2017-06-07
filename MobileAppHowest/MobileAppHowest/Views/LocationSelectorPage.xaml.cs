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
		public LocationSelectorPage ()
		{
			InitializeComponent ();
		}

        private void Handle_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.nuget.org/packages/Xamarin.CustomControls.AccordionView"));
        }
    }
}