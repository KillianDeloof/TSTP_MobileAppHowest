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
        Ticket t = new Ticket();
        Room r = new Room();

        public MessageVM()
        {
            SendCommand = new Command(SendClicked);
            AttachCommand = new Command(AttachClicked);
            PictureCommand = new Command(PictureClicked);
            CategoryCommand = new Command(CategoryClicked);
            LocationCommand = new Command(LocationClicked);
        }

        public event PropertyChangedEventHandler PropertyChanged;
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
            t.Name = "name: killian.deloof";
            t.Subject = "need koffie";
            t.PriorityId = new int?();
            t.TopicId = new int?();
            t.Email = "killian.deloof@student.howest.be";
            t.Message = "de koffie automaat werkt niet!, i need my koffie" + r;

            //t.forum = "what is this field?";
            t.Category = "automaten";

            String res = await AzureMobileClient.DefaultClient.InvokeApiAsync<Ticket, string>("/api/OSTicket", t, System.Net.Http.HttpMethod.Post, null, System.Threading.CancellationToken.None);
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
            t.Attachments.Add(at);
        }

        private async Task TakePhoto()
        {
            MediaFile photo = await MediaPicker.TakePhoto();
            Attachment at = new Attachment();
            at.Name = "photo";
            //at.Content = photo;
            at.Type = "jpg";
            t.Attachments.Add(at);
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
