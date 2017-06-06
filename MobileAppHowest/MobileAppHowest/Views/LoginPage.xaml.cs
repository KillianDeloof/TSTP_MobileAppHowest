using MobileAppHowest.Models;
using MobileAppHowest.Repositories;
using MobileAppHowest.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppHowest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public LoginPage()
        {
            InitializeComponent();
            //BindingContext = new LoginVM();
            BindingContext = new LoginVM(Navigation);
        }

        //public void BtnLogin_Clicked()
        //{
        //    (new LoginVM()).Login();
        //}

        //public async Task ShowCategoryPage()
        //{
        //    //Page newPage = new CategoryPage();
        //    //await Navigation.PushAsync(newPage);
        //}
    }
}