//using Android;
//using Android.App;
//using Android.Widget;
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
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = new LoginVM(Navigation, btnLogin);
        }
    }
}