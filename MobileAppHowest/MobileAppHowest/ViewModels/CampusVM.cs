﻿using MobileAppHowest.Models;
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
                        PropertyChanged(this, new PropertyChangedEventArgs("CampusList"));
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
                CampusSelected();
            }
        }

        // lijst met buildings
        private List<Building> _buildingList;
        public List<Building> BuildingList
        {
            get { return _buildingList; }
            set { _buildingList = value; }
        }

        /// <summary>
        /// Ophalen van de lijst van campussen.
        /// </summary>
        private async Task GetCampusList()
        {
            List<Campus> campusList = await APIRepository.GetCampusList();
            campusList.ForEach(c => c.Picture = "Campus_" + c.UCODE + ".jpg");
            CampusList = new ObservableCollection<Campus>(campusList);

            //-- dummy data --//

            //List<Campus> list = new List<Campus>
            //{
            //    new Campus()
            //    {
            //        Address = "Graaf Karel de Goedelaan 5 8580 Kortrijk",
            //        UCODE = "Campus GKG",
            //        Picture = "Campus_GKG.jpg"
            //    },
            //    new Campus()
            //    {
            //        Address = "Graaf Karel de Goedelaan 5 8580 Kortrijk",
            //        UCODE = "Campus GKG",
            //        Picture = "Campus_GKG.jpg"
            //    },
            //    new Campus()
            //    {
            //        Address = "Graaf Karel de Goedelaan 5 8580 Kortrijk",
            //        UCODE = "Campus GKG",
            //        Picture = "Campus_GKG.jpg"
            //    },
            //    new Campus()
            //    {
            //        Address = "Graaf Karel de Goedelaan 5 8580 Kortrijk",
            //        UCODE = "Campus GKG",
            //        Picture = "Campus_GKG.jpg"
            //    },
            //    new Campus()
            //    {
            //        Address = "Graaf Karel de Goedelaan 5 8580 Kortrijk",
            //        UCODE = "Campus GKG",
            //        Picture = "Campus_GKG.jpg"
            //    },
            //    new Campus()
            //    {
            //        Address = "Graaf Karel de Goedelaan 5 8580 Kortrijk",
            //        UCODE = "Campus GKG",
            //        Picture = "Campus_GKG.jpg"
            //    },
            //    new Campus()
            //    {
            //        Address = "Graaf Karel de Goedelaan 5 8580 Kortrijk",
            //        UCODE = "Campus GKG",
            //        Picture = "Campus_GKG.jpg"
            //    },
            //    new Campus()
            //    {
            //        Address = "Graaf Karel de Goedelaan 5 8580 Kortrijk",
            //        UCODE = "Campus GKG",
            //        Picture = "Campus_GKG.jpg"
            //    }
            //};

            //CampusList = new ObservableCollection<Campus>(list);
        }

        private void CampusSelected()
        {
            if (_selectedCampus != null)
                ShowBuildingPopUp();
        }

        private async Task ShowBuildingPopUp()
        {
            BuildingList = await _apiRepo.GetBuildingList();
            List<Building> filteredList = _buildingList.Where(b => b.Campus.UCODE.Split('.')[0].ToLower() == _selectedCampus.UCODE.Split('.')[0].ToLower()).ToList<Building>();
            String[] buildingArray = new String[filteredList.Count];

            for (int i = 0; i < filteredList.Count; i++)
            {
                buildingArray[i] = "Building " + filteredList[i].UCODE.Substring(filteredList[i].UCODE.IndexOf('.')).Replace(".", "");
            }
            
            // tonen van de pop-up & opvragen/verwerken gekozen waarde
            String buildingAction = await App.Current.MainPage.DisplayActionSheet("Select Building", null, null, buildingArray);
            buildingAction = buildingAction.Remove(0, buildingAction.Length - 1);

            HandleSelectedBuilding(buildingAction);
        }

        private void HandleSelectedBuilding(String building)
        {
            // building is het gekozen gebouw, bv "A"
            _ticket.Building = _buildingList.ToList<Building>().Where(b => b.UCODE.ToLower() == (_selectedCampus.UCODE + "." + building).ToLower()).FirstOrDefault();

            ShowLocationSelectorPage();
        }

        /// <summary>
        /// Tonen van de ShowLocationSelectorPage en meegeven van ticket.
        /// </summary>
        /// <returns>Task</returns>
        private async Task ShowLocationSelectorPage()
        {
            await Navigation.PushAsync(new LocationSelectorPage(_ticket));
        }
    }
}
