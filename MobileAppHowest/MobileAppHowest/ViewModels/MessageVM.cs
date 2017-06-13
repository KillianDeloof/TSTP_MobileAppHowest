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
using MobileAppHowest.Views;

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
            AttachmentListCommand = new Command(AttachmentButtonClicked);
        }

        private void AttachmentButtonClicked(object obj)
        {
            // methode aanroepen die iets doet wanneer er op een item in de attachmentlist geklikt wordt
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private INavigation Navigation = null;
        private Ticket _ticket;
        private Room _r = new Room();
        private Button _button;

        public Command SendCommand { get; }
        public Command AttachCommand { get; }
        public Command PictureCommand { get; }
        public Command CategoryCommand { get; }
        public Command LocationCommand { get; }
        public Command AttachmentListCommand { get; }

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
                //_ticket.Message = _message;
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
                //_ticket.Subject = _subject;
            }
        }

        private void SendClicked(object obj)
        {
            SendTicket();
        }

        private void AttachClicked(object obj)
        {
            PickPhoto();
        }

        private async Task PickPhoto()
        {
            MediaFile photo = await MediaPicker.PickPhoto();
            _ticket.AddAtachment(photo);

        }

        private void PictureClicked(object obj)
        {
            TakePhoto();
        }

        private async void AttachmentClick()
        {
            string action = await App.Current.MainPage.DisplayActionSheet("Photo Name", "Edit", "Delete");
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
            _ticket.AddAtachment(photo);

        }

        private async Task ShowCampusPage()
        {
            //await Navigation.PushAsync(new CampusPage(_ticket));
        }

        private async Task ShowCategoryPage()
        {
           // await Navigation.PushAsync(new CategoryPage(_ticket));
        }

        private async Task SendTicket()
        {
            if (!String.IsNullOrEmpty(_subject) && !String.IsNullOrEmpty(_message))
            {
                Category cat = new Category();
                _ticket.FormatTicket(_subject, _message, cat);

                APIRepository apirepos = new APIRepository();
                await apirepos.SendTicket(_ticket);
                //DisplayAlert
                await App.Current.MainPage.DisplayAlert("Ticket Send!", "The ticket has been send!", "OK");

            }
            else
            {
                // TO DO: wat te doen indien subject of message leeg is
                Console.WriteLine("Subject of message is leeg.");
            }
        }

        private List<String> _pictureNameList;

        public List<String> PictureNameList
        {
            get
            {
                GetAttachmentNameList();
                return _pictureNameList;
            }
            set
            {
                _pictureNameList = value;
            }
        }


        private void GetAttachmentNameList()
        {
            //List<String> AttachmentNameList = new List<String>();
            //_ticket.Attachments.ForEach(a => AttachmentNameList.Add(a.Name));

            //PictureNameList = AttachmentNameList;
            PictureNameList = new List<String>
            {
                "photo01.jpg",
                "photo02.jpg",
                "photo03.jpg"
            };
        }

        // opvragen van locatie
        //private async Task GetPosition()
        //{
        //    double[] latlong = await GPSRepository.GetLocation();
        //    string location = "lat: " + latlong[0] + " / long: " + latlong[1];
        //}
    }
}
