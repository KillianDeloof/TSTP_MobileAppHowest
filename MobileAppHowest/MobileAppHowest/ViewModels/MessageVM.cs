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

namespace MobileAppHowest.ViewModels
{
    public class MessageVM : INotifyPropertyChanged
    {
        public MessageVM(INavigation navigation)
        {
            this.Navigation = navigation;

            SendCommand = new Command(SendClicked);
            AttachCommand = new Command(AttachClicked);
            PictureCommand = new Command(PictureClicked);
            CategoryCommand = new Command(CategoryClicked);
            LocationCommand = new Command(LocationClicked);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private INavigation Navigation = null;
        private Ticket _t = new Ticket();
        private Room _r = new Room();

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
            _t.Name = "name: killian.deloof";
            _t.Subject = "need koffie";
            _t.PriorityId = new int?();
            _t.TopicId = new int?();
            _t.Email = "killian.deloof@student.howest.be";
            _t.Message = "de koffie automaat werkt niet!, i need my koffie" + _r;

            //t.forum = "what is this field?";
            _t.Category = "automaten";

            String res = await AzureMobileClient.DefaultClient.InvokeApiAsync<Ticket, string>("/api/OSTicket", _t, System.Net.Http.HttpMethod.Post, null, System.Threading.CancellationToken.None);
        }

        private void AttachClicked(object obj)
        {
            GetAttachment();
        }

        private async Task GetAttachment()
        {
            MediaFile photo = await MediaPicker.PickPhoto();
            Attachment at = new Attachment();
            at.Name = "photo";
            //at.Content = photo;
            at.Type = "jpg";
            _t.Attachments.Add(at);
        }

        private async Task TakePhoto()
        {
            MediaFile photo = await MediaPicker.TakePhoto();
            Attachment at = new Attachment();
            at.Name = "photo";
            //at.Content = photo;
            at.Type = "jpg";
            _t.Attachments.Add(at);
        }

        private void PictureClicked(object obj)
        {
            TakePhoto();
        }

        private void LocationClicked(object obj)
        {
            throw new NotImplementedException();
        }

        private void CategoryClicked(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
