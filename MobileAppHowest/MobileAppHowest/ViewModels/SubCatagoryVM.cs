using MobileAppHowest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace MobileAppHowest.ViewModels
{
   public class SubCatagoryVM : INotifyPropertyChanged
    {
        public SubCatagoryVM()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;


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
                "catering", "meubilair","afvalbeheer", "sanitair", "cashless campus","lokalen"
            };

            // wordt voorlopig niet gebruikt
            List<String> categoryPictureList = new List<String>()
            {
                "../Assets/HOWEST_Logo.png",
                "../Assets/HOWEST_Logo.png",
                "../Assets/HOWEST_Logo.png",
                "../Assets/HOWEST_Logo.png",
                "../Assets/HOWEST_Logo.png",
                "../Assets/HOWEST_Logo.png",
                "../Assets/HOWEST_Logo.png"
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
    }
}
