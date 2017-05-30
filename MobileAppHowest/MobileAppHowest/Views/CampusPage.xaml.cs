using MobileAppHowest.Models;
using MobileAppHowest.Repositories;
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
	public partial class CampusPage : ContentPage
	{
		public CampusPage()
		{
			InitializeComponent();
            GetCampusList();
		}

        private CampusRepository _campusRepo;
        
        private async void GetCampusList()
        {
            List<Campus> CampusList = await _campusRepo.GetCampusList();
        }
    }
}