using MobileAppHowest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileAppHowest.ViewModels
{
    public class FloorVM
    {
        public FloorVM(INavigation navigation, Ticket ticket)
        {
            this._ticket = ticket;
        }

        private INavigation Navigation = null;
        private Ticket _ticket = null;


    }
}
