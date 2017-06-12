using MobileAppHowest.Models;
using MobileAppHowest.Repositories;
using MobileAppHowest.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
        private APIRepository _apiRepo = new APIRepository();
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
                
                CampusSelected();
            }
        }


        /// <summary>
        /// Ophalen van de lijst van campussen.
        /// </summary>
        private async Task GetCampusList()
        {
            List<Campus> list = new List<Campus>
            {
                new Campus()
                {
                    Address = "Graaf Karel de Goedelaan 5 8580 Kortrijk",
                    UCODE = "Campus GKG",
                    Picture = "Campus_GKG.jpg"
                },
                new Campus()
                {
                    Address = "Graaf Karel de Goedelaan 5 8580 Kortrijk",
                    UCODE = "Campus GKG",
                    Picture = "Campus_GKG.jpg"
                },
                new Campus()
                {
                    Address = "Graaf Karel de Goedelaan 5 8580 Kortrijk",
                    UCODE = "Campus GKG",
                    Picture = "Campus_GKG.jpg"
                },
                new Campus()
                {
                    Address = "Graaf Karel de Goedelaan 5 8580 Kortrijk",
                    UCODE = "Campus GKG",
                    Picture = "Campus_GKG.jpg"
                },
                new Campus()
                {
                    Address = "Graaf Karel de Goedelaan 5 8580 Kortrijk",
                    UCODE = "Campus GKG",
                    Picture = "Campus_GKG.jpg"
                },
                new Campus()
                {
                    Address = "Graaf Karel de Goedelaan 5 8580 Kortrijk",
                    UCODE = "Campus GKG",
                    Picture = "Campus_GKG.jpg"
                },
                new Campus()
                {
                    Address = "Graaf Karel de Goedelaan 5 8580 Kortrijk",
                    UCODE = "Campus GKG",
                    Picture = "Campus_GKG.jpg"
                },
                new Campus()
                {
                    Address = "Graaf Karel de Goedelaan 5 8580 Kortrijk",
                    UCODE = "Campus GKG",
                    Picture = "Campus_GKG.jpg"
                }
            };

            return list;

            //List<Campus> campusList = await APIRepository.GetCampusList();
            //CampusList = new ObservableCollection<Campus>(campusList);
        }

        private void CampusSelected()
        {
            ShowBuildingPopUp();
        }
        
        private async Task ShowBuildingPopUp()
        {
            List<Building> filteredList = (await _apiRepo.GetBuildingList()).Where(b => b.Campus.UCODE.Split('.')[0] == _selectedCampus.UCODE.Split('.')[0]).ToList<Building>();
            String[] buildingArray = new String[filteredList.Count];

            for (int i = 0; i < filteredList.Count; i++)
            {
                buildingArray[i] = "Building " + filteredList[i].UCODE.Substring(filteredList[i].UCODE.IndexOf('.'));
            }
            
            string action = await App.Current.MainPage.DisplayActionSheet("Select Building", null, null, buildingArray);
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
            await Navigation.PushAsync(new LocationSelectorPage(_ticket));
        }
    }
}
