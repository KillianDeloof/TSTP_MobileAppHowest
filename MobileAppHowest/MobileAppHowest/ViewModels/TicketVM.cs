using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileAppHowest.ViewModels
{
    public class TicketVM
    {
        public TicketVM(INavigation navigation)
        {
            Navigation = navigation;
        }

        public INavigation Navigation = null;
    }
}
