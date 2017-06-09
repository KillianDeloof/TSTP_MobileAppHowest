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
    public class CategoryVM : INotifyPropertyChanged
    {
        public CategoryVM(INavigation navigation, Ticket ticket)
        {
            this.Navigation = navigation;
            this._ticket = ticket;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private APIRepository _dataRepo = new APIRepository();
        INavigation Navigation = null;
        private Ticket _ticket;

        // wordt opgevuld met de geselecteerde Category
        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set {
                _selectedCategory = value;
                ShowCategoryPage(_selectedCategory.SubCategoryList);
            }
        }

        // lijst van categorieën die worden opgevraagd wanneer de lijst wordt geladen
        // inladen gebeurt in GetCategoryList()
        private ObservableCollection<Category> _categoryList = null;
        public ObservableCollection<Category> CategoryList
        {
            get
            {
                if (_categoryList == null)
                    GetCategoryList();

                return _categoryList;
            }
            set
            {
                _categoryList = value;
            }
        }

        private void GetCategoryList()
        {
            CategoryList = new ObservableCollection<Category>(_dataRepo.GetHardCodedCategoryList());

            List<String> catStringList = new List<String>
                {
                    "Campus",
                    "Faciliteiten & diensten",
                    "Lesmateriaal",
                    "Netwerk",
                    "Software & hardware",
                    "Organisatie",
                    "Overige"
                };

            List<String> categoryPictureList = new List<String>()
            {
                "ic_location_city_black_24dp.png",
                "ic_directions_bus_black_24dp.png",
                "ic_book_black_24dp.png",
                "ic_settings_input_hdmi_black_24dp.png",
                "ic_laptop_black_24dp.png",
                "ic_people_black_24dp.png",
                "ic_priority_high_black_24dp.png"
            };

            //for (int i = 0; i < catStringList.Count; i++)
            //{
            //    categoryList.Add(new Category()
            //    {
            //        CategoryUDesc = catStringList[i],
            //        Picture = categoryPictureList[i],
            //        Subtitle = "Subtitle test " + i
            //    });
            //}

            //CategoryList = new ObservableCollection<Category>(categoryList);
        }

        //private List<Category> GetCategoryStringList()
        //{
        //    List<Category> categoryList = new List<Category>();

        //    List<String> catStringList = new List<String>
        //    {
        //        "Campus",
        //        "Faciliteiten & diensten",
        //        "Lesmateriaal",
        //        "Netwerk",
        //        "Software & hardware",
        //        "Overige"
        //    };

        //    List<String> categoryPictureList = new List<String>()
        //    {
        //        "ic_location_city_black_24dp.png",
        //        "ic_directions_bus_black_24dp.png",
        //        "ic_book_black_24dp.png",
        //        "ic_settings_input_hdmi_black_24dp.png",
        //        "ic_laptop_black_24dp.png",
        //        "ic_priority_high_black_24dp.png"
        //    };

        //    List<Category> categoryList = new List<Category>()
        //    {

        //    };

        //    for (int i = 0; i < catStringList.Count; i++)
        //    {
        //        categoryList.Add(new Category()
        //        {
        //            CategoryUDesc = catStringList[i],
        //            Picture = categoryPictureList[i],
        //            Subtitle = "Subtitle test " + i
        //            //SubCategoryList
        //        });
        //    }

        //    return categoryList;
        //}

        /// <summary>
        /// Tonen van de SubCategoryPage als de geselecteerde Category niet null is.
        /// </summary>
        private async Task ShowCategoryPage(List<SubCategory> subCategoryList)
        {
            if (_selectedCategory != null)
                await Navigation.PushAsync(new SubCategoryPage(subCategoryList, _ticket));
        }
    }
}
