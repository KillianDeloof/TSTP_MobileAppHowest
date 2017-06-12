using MobileAppHowest.Models;
using MobileAppHowest.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileAppHowest.ViewModels
{
    public class SubCategoryVM : INotifyPropertyChanged
    {
        public SubCategoryVM(INavigation navigation, List<Category> subCategoryList, Ticket ticket)
        {
            this.Navigation = navigation;
            this._subCategoryList = subCategoryList;
            this._ticket = ticket;
        }

        private INavigation Navigation = null;
        private Ticket _ticket;

        // Category die geselecteerd wordt in de view
        private Category _selectedSubCategory;
        public Category SelectedSubCategory
        {
            get { return _selectedSubCategory; }
            set
            {
                _selectedSubCategory = value;
                _ticket.FormatTicket("", "", _selectedSubCategory);
                ShowCampusPage();
            }
        }

        // lijst met SubCategorieën
        public event PropertyChangedEventHandler PropertyChanged;

        private List<Category> _subCategoryList = null;
        public List<Category> SubCategoryList
        {
            get
            {
                return _subCategoryList;
            }
        }

        /// <summary>
        /// Opvullen van de subcategorieën.Voorlopig is dit dummy data.
        /// </summary>
        /// <returns>List<SubCategory></returns>
        //private List<Category> GetSubCategoryList()
        //{
        //    _subCategoryList = new List<Category>();
        //    List<String> descriptionList = new List<string>()
        //    {
        //        "Catering",
        //        "Meubilair",
        //        "vuilnisbakken",
        //        "sanitair",
        //        "lokalen"
        //    };

        //    for (int i = 0; i < descriptionList.Count; i++)
        //    {
        //        _subCategoryList.Add(new Category()
        //        {
        //            SubCategoryUDesc = descriptionList[i],
        //            Subtitle = "Subtitle test " + i,
        //            IsLocationRequired = true
        //        });
        //    }

        //    return _subCategoryList;

        //}

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
                    await Navigation.PushAsync(new CampusPage(_ticket));
                else
                    await Navigation.PushAsync(new MessagePage(_ticket));
            }
        }
    }
}
