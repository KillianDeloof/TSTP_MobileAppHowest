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
        public CategoryVM(INavigation navigation)
        {
            this.Navigation = navigation;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private APIDataGetRepository _dataRepo = new APIDataGetRepository();
        INavigation Navigation = null;

        // wordt opgevuld met de geselecteerde Category
        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set {
                _selectedCategory = value;
                ShowSubCategoryPage();
            }
        }

        // lijst van categorieën die worden opgevraagd wanneer de lijst wordt geladen
        // inladen gebeurt in GetCategoryList()
        private List<Category> _categoryList = null;
        public ObservableCollection<Category> CategoryList
        {
            get
            {
                if (_categoryList == null)
                    GetCategoryList();

                return new ObservableCollection<Category>(_categoryList);
            }
        }

        private void GetCategoryList()
        {
            _categoryList = GetCategoryStringList();
        }

        private List<Category> GetCategoryStringList()
        {
            List<Category> categoryList = new List<Category>();

            List<String> catStringList = new List<String>
            {
                "Campus",
                "Faciliteiten & diensten",
                "Lesmateriaal",
                "Netwerk",
                "Software & hardware",
                "organisatie",
                "Overige"
            };
            
            List<String> categoryPictureList = new List<String>()
            {
                "Assets/BG_howest.png",
                "Assets/HOWEST_Logo.png",
                "Assets/HOWEST_Logo.png",
                "Assets/HOWEST_Logo.png",
                "Assets/HOWEST_Logo.png",
                "Assets/HOWEST_Logo.png",
                "Assets/HOWEST_Logo.png"
            };

            for (int i = 0; i < catStringList.Count; i++)
            {
                categoryList.Add(new Category()
                {
                    CategoryUDesc = catStringList[i],
                    Picture = categoryPictureList[i],
                    Subtitle = "Subtitle test " + i
                });
            }

            return categoryList;
        }

        /// <summary>
        /// Tonen van de SubCategoryPage als de geselecteerde Category niet null is.
        /// </summary>
        private async Task ShowSubCategoryPage()
        {
            if (_selectedCategory != null)
                await Navigation.PushAsync(new SubCategoryPage());
        }
    }
}
