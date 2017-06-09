using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Plugin.Media.Abstractions;
using MobileAppHowest.Models;
using MobileAppHowest.Repositories;
using System.Threading.Tasks;
using MobileAppHowest.Models.MobileSDK.AzureMobileClient;
using System.IO;
using Plugin.Media;

namespace MobileAppHowest.ViewModels
{
    public class MessageVM : INotifyPropertyChanged
    {
        public MessageVM(INavigation navigation, Ticket newTicket)
        {
            this.Navigation = navigation;
            this._ticket = newTicket;

            SendCommand = new Command(SendClicked);
            AttachCommand = new Command(AttachClicked);
            PictureCommand = new Command(PictureClicked);
            CategoryCommand = new Command(CategoryClicked);
            LocationCommand = new Command(LocationClicked);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private INavigation Navigation = null;
        private Ticket _ticket;
        private Room _r = new Room();
        private Button _button;
        TicketRepository _tRepos = new TicketRepository();

        public Command SendCommand { get; }
        public Command AttachCommand { get; }
        public Command PictureCommand { get; }
        public Command CategoryCommand { get; }
        public Command LocationCommand { get; }

        private void SendClicked(object obj)
        {
            SendTicket();
        }

        private async Task SendTicket()
        {
            SubCategory cat = new SubCategory();
            _ticket.FormatTicket("Defect toestel", "Werkt niet, zie foto", cat);

            APIRepository apiRepos = new APIRepository();
            await apiRepos.SendTicket(_ticket);
        }

        private void AttachClicked(object obj)
        {
            GetAttachment();
        }

        private async Task GetAttachment()
        {
            MediaFile photo = await MediaPicker.PickPhoto();
            _ticket.AddAtachment(photo);

        }

        private async Task TakePhoto()
        {

            MediaFile photo = await MediaPicker.TakePhoto();
            _ticket.AddAtachment(photo);

        }

        private async Task GetPosition()
        {
            double[] latlong = await GPSRepository.GetLocation();
            string location = "lat: " + latlong[0] + " / long: " + latlong[1];
            _button.Text = location.ToString();
        }

        private void PictureClicked(object obj)
        {
            TakePhoto();
        }

        private void LocationClicked(object obj)
        {
            GetPosition();
        }

        private void CategoryClicked(object obj)
        {
            throw new NotImplementedException();
        }

        private String _message = "Type your message ...";
        public String Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                _ticket.Message = _message;
            }
        }

        private String _subject = "Subject";
        public String Subject
        {
            get {
                return _subject;
            }
            set {
                _subject = value;
                _ticket.Subject = _subject;
            }
        }
    }
}
