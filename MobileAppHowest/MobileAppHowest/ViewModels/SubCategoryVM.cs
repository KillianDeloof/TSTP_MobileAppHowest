using MobileAppHowest.Models;
using System;
using System.Collections.Generic;
using System.Text;
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

        // hierna campus selecteren
    }
}
