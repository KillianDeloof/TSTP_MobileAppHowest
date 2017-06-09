using MobileAppHowest.Models;
using MobileAppHowest.Repositories;
using MobileAppHowest.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileAppHowest.ViewModels
{
    public class CampusVM : INotifyPropertyChanged
    {
        public CampusVM(INavigation navigation, Ticket ticket)
        {
            this.Navigation = navigation;
            this._ticket = ticket;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private APIDataGetRepository _dataRepo = new APIDataGetRepository();
        private INavigation Navigation = null;
        private Ticket _ticket = null;

        // lijst van campussen die wordt opgevuld wanneer de UI wordt aangesproken
        private ObservableCollection<Campus> _campusList = null;
        public ObservableCollection<Campus> CampusList
        {
            set
            {
                _campusList = value;

                if (_campusList != null)
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("CampusList"));
                    }
                }
            }
            get
            {
                if (_campusList == null)
                    GetCampusList();

                return _campusList;
            }
        }

        // opvangen van de geselecteerde campus
        private Campus _selectedCampus;
        public Campus SelectedCampus
        {
            get { return _selectedCampus; }
            set {
                _selectedCampus = value;
                // TO DO: meegeven van geslecteerde campus aan volgende pagina

                //ShowLocationSelectorPage();
                ShowMessagePage();
            }
        }

        /// <summary>
        /// Ophalen van de lijst van campussen.
        /// </summary>
        private async Task GetCampusList()
        {
            ObservableCollection<Campus> campusList = new ObservableCollection<Campus>
            {
                new Campus()
                {
                    Address = "Graaf Karel de Goedelaan 5, 8580 Kortrijk",
                    CDESC = "Campus GKG",
                    Picture = "campus_GKG.jpg"
                },
                new Campus()
                {
                    Address = "Sint-Jorisstraat 21, 8500 Brugge",
                    CDESC = "Campus SJS",
                    Picture = "campus_SJS.jpg"
                }
            };

            CampusList = campusList;

            //List<Campus> campusList = await APIDataGetRepository.GetCampusList();
            //CampusList = new ObservableCollection<Campus>(campusList);

            //foreach (Campus c in campusList)
            //{
            //    Console.WriteLine(c.ToString());
            //}
        }

        /// <summary>
        /// Tonen van de LocationPage.
        /// </summary>
        /// <returns></returns>
        //private async Task ShowLocationSelectorPage()
        //{
        //    await Navigation.PushAsync(new LocationSelectorPage());
        //}

        private async Task ShowMessagePage()
        {
            await Navigation.PushAsync(new FloorPage(_ticket));
        }
    }
}
