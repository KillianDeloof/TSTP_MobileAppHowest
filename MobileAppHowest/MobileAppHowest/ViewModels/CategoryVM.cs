﻿using MobileAppHowest.Models;
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
    public class CategoryVM : INotifyPropertyChanged
    {
        public CategoryVM()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private APIDataGetRepository _dataRepo = new APIDataGetRepository();        

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
    }
}
