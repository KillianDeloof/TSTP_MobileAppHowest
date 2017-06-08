﻿using System;
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

namespace MobileAppHowest.ViewModels
{
    public class MessageVM : INotifyPropertyChanged
    {
        public MessageVM(INavigation navigation, Ticket newTicket)
        {
            this.Navigation = navigation;
            this._t = newTicket;

            SendCommand = new Command(SendClicked);
            AttachCommand = new Command(AttachClicked);
            PictureCommand = new Command(PictureClicked);
            CategoryCommand = new Command(CategoryClicked);
            LocationCommand = new Command(LocationClicked);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private INavigation Navigation = null;
        private Ticket _t;
        private Room _r = new Room();
        private Button _button;

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
            TicketRepository tRepos = new TicketRepository();
            SubCategory cat = new SubCategory();
            _t = tRepos.FormatTicket(_t, "Defect toestel", "Werkt niet, zie foto", cat);
            await tRepos.SendTicket(_t);

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

        private void AttachClicked(object obj)
        {
            GetAttachment();
        }

        private async Task GetAttachment()
        {
            MediaFile photo = await MediaPicker.PickPhoto();
            TicketRepository tRepos = new TicketRepository();
            tRepos.AddAtachment(_t, photo);
            //Attachment at = new Attachment();
            //at.Name = "photo.jpg";
            //byte[] bytearr = MediaPicker.MediaFileToByteArr(photo);
            //at.Content = bytearr;
            //at.Type = "jpg";
            //_t.Attachments.Add(at);
        }

        private async Task TakePhoto()
        {
            MediaFile photo = await MediaPicker.TakePhoto();
            TicketRepository tRepos = new TicketRepository();
            tRepos.AddAtachment(_t, photo);
            //Attachment at = new Attachment();
            //at.Name = "photo";
            //byte[] bytearr = MediaPicker.MediaFileToByteArr(photo);
            //at.Content = bytearr;
            //at.Type = "jpg";
            //_t.Attachments.Add(at);
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
    }
}
