using MobileAppHowest.Models;
using MobileAppHowest.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppHowest.ViewModels
{
    public class CategoryVM : INotifyPropertyChanged
    {
        public CategoryVM()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private APIDataGetRepository _dataRepo = new APIDataGetRepository();        

        private List<String> _categoryList = null;
        public ObservableCollection<String> CategoryList
        {
            get
            {
                if (_categoryList == null)
                    GetCategoryList();

                return new ObservableCollection<String>(_categoryList);
            }
        }

        private void GetCategoryList()
        {
            _categoryList = GetCategoryStringList();
        }

        private List<String> GetCategoryStringList()
        {
            return new List<String>
            {
                "Campus",
                "Faciliteiten & diensten",
                "Lesmateriaal",
                "Netwerk",
                "Software & hardware",
                "Overige"
            };
        }
    }
}
