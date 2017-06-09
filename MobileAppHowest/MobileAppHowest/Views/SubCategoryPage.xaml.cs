using MobileAppHowest.Models;
using MobileAppHowest.Repositories;
using MobileAppHowest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppHowest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SubCategoryPage : ContentPage
	{
        public SubCategoryPage(List<Category> subCategoryList, Ticket ticket)
        {
            InitializeComponent();
            BindingContext = new SubCategoryVM(Navigation, subCategoryList, ticket);
        }
    }
}