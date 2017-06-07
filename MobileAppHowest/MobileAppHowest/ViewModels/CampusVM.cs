using MobileAppHowest.Models;
using MobileAppHowest.Repositories;
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
        public CampusVM(INavigation navigation)
        {
            this.Navigation = navigation;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private APIDataGetRepository _dataRepo = new APIDataGetRepository();
        private INavigation Navigation = null;

        // lijst van campussen die wordt opgevuld wanneer de UI wordt aangesproken
        private ObservableCollection<Campus> _campusList = null;
        public ObservableCollection<Campus> CampusList
        {
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
                ShowLocationPage();
            }
        }

        /// <summary>
        /// Ophalen van de lijst van campussen.
        /// </summary>
        private async void GetCampusList()
        {
            List<Campus> campusList = await APIDataGetRepository.GetCampusList();
            _campusList = new ObservableCollection<Campus>(campusList);
        }

        /// <summary>
        /// Tonen van de LocationPage.
        /// </summary>
        /// <returns></returns>
        private async Task ShowLocationPage()
        {
            
        }
    }
}
