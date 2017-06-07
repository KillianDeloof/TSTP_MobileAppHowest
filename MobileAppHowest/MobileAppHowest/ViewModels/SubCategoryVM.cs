using MobileAppHowest.Models;
using MobileAppHowest.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileAppHowest.ViewModels
{
    public class SubCategoryVM
    {
        public SubCategoryVM(INavigation navigation)
        {
            Navigation = navigation;
        }

        INavigation Navigation = null;

        // SubCategory die geselecteerd wordt in de view
        private SubCategory _selectedSubCategory;
        public SubCategory SelectedSubCategory
        {
            get { return _selectedSubCategory; }
            set {
                _selectedSubCategory = value;
                ShowCampusPage();
            }
        }

        // lijst met SubCategorieën
        private List<SubCategory> _subCategoryList = null;
        public List<SubCategory> SubCategoryList
        {
            get
            {
                if (_subCategoryList == null)
                    GetSubCategoryList();

                return _subCategoryList;
            }
        }

        /// <summary>
        /// Opvullen van de subcategorieën. Voorlopig is dit dummy data.
        /// </summary>
        /// <returns>List<SubCategory></returns>
        private List<SubCategory> GetSubCategoryList()
        {
            _subCategoryList = new List<SubCategory>();

            List<String> descriptionList = new List<string>()
            {
                "Catering",
                "Meubilair",
                "vuilnisbakken",
                "sanitair",
                "lokalen"
            };

            for (int i = 0; i < descriptionList.Count; i++)
            {
                _subCategoryList.Add(new SubCategory()
                {
                    SubCategoryUDesc = descriptionList[i],
                    Subtitle = "Subtitle test " + i
                });
            }

            return _subCategoryList;
        }

        /// <summary>
        /// Tonen van de CampusPage indien _selectedSubCategory reeds opgevuld is.
        /// </summary>
        private async Task ShowCampusPage()
        {
            if (_selectedSubCategory != null)
            {
                // indien een locatie meegegeven moet worden, moet men op de CampusPage terechtkomen
                // anders naar de MessagePage
                if (_selectedSubCategory.IsLocationRequired)
                    await Navigation.PushAsync(new CampusPage());
                else
                    await Navigation.PushAsync(new MessagePage());
            }
        }
    }
}
