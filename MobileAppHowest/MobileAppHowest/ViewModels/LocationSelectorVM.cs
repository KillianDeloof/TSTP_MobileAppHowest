using MobileAppHowest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace MobileAppHowest.ViewModels
{
    public class LocationSelectorVM : INotifyPropertyChanged
    {
        public LocationSelectorVM(INavigation navigation, Ticket ticket)
        {
            this.Navigation = navigation;
            this._ticket = ticket;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private INavigation Navigation = null;
        private Ticket _ticket = null;

        /* TO DO:
         * =======
         * - opvragen lijst met floors adhv geselecteerde campus & building
         * - gebruik van FloorFilter
         */
    }
}
