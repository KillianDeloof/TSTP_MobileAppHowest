﻿using MobileAppHowest.Models;
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
	public partial class MessagePage : ContentPage
	{
		public MessagePage(Ticket newTicket)
		{
			InitializeComponent();
            
            BindingContext = new MessageVM(this, newTicket, btnSend);
		}

    }
}