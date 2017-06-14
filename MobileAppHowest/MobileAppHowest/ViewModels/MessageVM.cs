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
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MobileAppHowest.ViewModels
{
    public class MessageVM : INotifyPropertyChanged
    {
        public MessageVM(INavigation navigation, Ticket newTicket, Button btnSend)
        {
            this.Navigation = navigation;
            this._ticket = newTicket;
            this._buttonSend = btnSend;

            MessageClickedCommand = new Command(MessageClicked);
            SendCommand = new Command(SendClicked);
            AttachCommand = new Command(AttachClicked);
            PictureCommand = new Command(PictureClicked);
            CategoryCommand = new Command(CategoryClicked);
            LocationCommand = new Command(LocationClicked);
            //MessageClickedCommand = new Command(MessageClicked);
        }

        private void MessageClicked()
        {
            Message = "";
        }

        private void AttachmentClicked()
        {
            if (_selectedAttachment == null)
                return;

            // methode aanroepen die iets doet wanneer er op een item in de attachmentlist geklikt wordt
            DeleteAtach();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private INavigation Navigation = null;
        private Ticket _ticket;
        private Room _r = new Room();
        private Button _buttonSend;

        public Command SendCommand { get; }
        public Command AttachCommand { get; }
        public Command PictureCommand { get; }
        public Command CategoryCommand { get; }
        public Command LocationCommand { get; }
        public Command AttachmentListCommand { get; }
        public Command MessageClickedCommand { get; }

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

        private Attachment _selectedAttachment;
        public Attachment SelectedAttachment
        {
            get { return _selectedAttachment; }
            set {
                _selectedAttachment = value;
                AttachmentClicked();
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
            _ticket.AddAttachment(photo);

            PictureNameList = new ObservableCollection<Attachment>(_ticket.Attachments);
        }

        private void PictureClicked(object obj)
        {
            TakePhoto();
        }

        private async void DeleteAtach()
        {
            string action = await App.Current.MainPage.DisplayActionSheet("Photo Name", "Cancel", "Delete");
            if (action == "Delete")
            {
                _ticket.Attachments.Remove(_selectedAttachment);
            }
        }

        private void LocationClicked(object obj)
        {
            ShowCampusPage();
        }

        private void CategoryClicked(object obj)
        {
            ShowCategoryPage();
        }

        //private void MessageClicked(object obj)
        //{
        //    Console.WriteLine(obj.ToString());
        //}

        private async Task TakePhoto()
        {
            MediaFile photo = await MediaPicker.TakePhoto();
            _ticket.AddAttachment(photo);

            PictureNameList = new ObservableCollection<Attachment>(_ticket.Attachments);
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
                bool answer = await App.Current.MainPage.DisplayAlert("Send Ticket?", "Send Ticket?", "yes", "no");
                if (answer == true)
                {
                    _buttonSend.IsEnabled = false;
                    _ticket.FormatTicket(_subject, _message, _ticket.CatObj);
                    APIRepository apirepos = new APIRepository();
                    await apirepos.SendTicket(_ticket);
                    // displayAlert
                    await App.Current.MainPage.DisplayAlert("Ticket Send!", "The ticket has been send!", "OK");
                    _buttonSend.IsEnabled = true;

                    // refresh ticket
                    _ticket = new Ticket(_ticket.UserInfo);
                    // return to catogoryselector with the new ticket
                    await Navigation.PushAsync(new CategoryPage(_ticket));
                }
            }
            else
            {
                // wat te doen indien subject of message leeg is
                await App.Current.MainPage.DisplayAlert("No Subject", "Please fill in subject and message", "Ok");
                Console.WriteLine("Subject of message is leeg.");
            }
        }

        private ObservableCollection<Attachment> _pictureNameList;
        public ObservableCollection<Attachment> PictureNameList
        {
            get
            {
                _pictureNameList = new ObservableCollection<Attachment>(_ticket.Attachments);
                return _pictureNameList;
            }
            set
            {
                if (_pictureNameList.Count != value.Count)
                {
                    _pictureNameList = value;

                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("PictureNameList"));
                }
            }
        }

        //private void MessageClicked(object obj)
        //{
        //    Message = "";
        //}

        private void GetAttachmentNameList()
        {
            //List<Attachment> attachmentNameList = new List<Attachment>();
            //_ticket.Attachments.ForEach(a => attachmentNameList.Add(a));

            //PictureNameList = attachmentNameList;


            //PictureNameList = new List<String>
            //{
            //    "photo01.jpg",
            //    "photo02.jpg",
            //    "photo03.jpg"
            //};
        }

        // opvragen van locatie
        //private async Task GetPosition()
        //{
        //    double[] latlong = await GPSRepository.GetLocation();
        //    string location = "lat: " + latlong[0] + " / long: " + latlong[1];
        //}
    }
}
