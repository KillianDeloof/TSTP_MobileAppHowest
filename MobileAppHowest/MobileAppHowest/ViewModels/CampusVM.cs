using MobileAppHowest.Models;
using MobileAppHowest.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace MobileAppHowest.ViewModels
{
    public class CampusVM : INotifyPropertyChanged
    {
        public CampusVM()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private APIDataGetRepository _dataRepo = new APIDataGetRepository();

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

        private async void GetCampusList()
        {
            List<Campus> campusList = await APIDataGetRepository.GetCampusList();
            _campusList = new ObservableCollection<Campus>(campusList);
        }
    }
}
