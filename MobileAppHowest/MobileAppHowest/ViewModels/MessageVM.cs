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
            get
            {
                return _subject;
            }
            set
            {
                _subject = value;
                _ticket.Subject = _subject;
            }
        }

        private void SendClicked(object obj)
        {
            SendTicket();
        }

        private void AttachClicked(object obj)
        {
            GetAttachment();
        }

        private async Task GetAttachment()
        {
            MediaFile photo = await MediaPicker.PickPhoto();
            _tRepos.AddAtachment(_ticket, photo);

        }

        private void PictureClicked(object obj)
        {
            TakePhoto();
        }

        private void LocationClicked(object obj)
        {
            ShowCampusPage();
        }

        private void CategoryClicked(object obj)
        {
            ShowCategoryPage();
        }

        private async Task TakePhoto()
        {

            MediaFile photo = await MediaPicker.TakePhoto();
            _tRepos.AddAtachment(_ticket, photo);

        }

        private async Task ShowCampusPage()
        {
            await Navigation.PushAsync(new CampusPage(_ticket));
        }

        private async Task ShowCategoryPage()
        {
            await Navigation.PushAsync(new CategoryPage(_ticket));
        }

        private async Task SendTicket()
        {
            if (String.IsNullOrEmpty(_subject) && String.IsNullOrEmpty(_message))
            {
                TicketRepository _ticketRepo = new TicketRepository();
                SubCategory cat = new SubCategory();
                _ticket = _ticketRepo.FormatTicket(_ticket, _subject, _message, cat);
                //_t.Name = "name: killian.deloof";
                //_t.Subject = "need koffie";
                //_t.PriorityId = new int?();
                //_t.TopicId = new int?();
                //_t.Email = "killian.deloof@student.howest.be";
                //_t.Message = "de koffie automaat werkt niet!, i need my koffie" + _r;

                //_t.Forum = "what is this field?";
                //_t.Category = "automaten";

                //String res = await AzureMobileClient.DefaultClient.InvokeApiAsync<Ticket, string>("/api/OSTicket", _t, System.Net.Http.HttpMethod.Post, null, System.Threading.CancellationToken.None);
            }
            else
            {
                // TO DO: wat te doen indien subject of message leeg is
                Console.WriteLine("Subject of message is leeg.");
            }
        }

        // opvragen van locatie
        //private async Task GetPosition()
        //{
        //    double[] latlong = await GPSRepository.GetLocation();
        //    string location = "lat: " + latlong[0] + " / long: " + latlong[1];
        //}
    }
}
