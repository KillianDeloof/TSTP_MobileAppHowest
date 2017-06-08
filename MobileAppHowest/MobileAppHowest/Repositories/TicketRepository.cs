using MobileAppHowest.Models;
using MobileAppHowest.Models.MobileSDK.AzureMobileClient;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
namespace MobileAppHowest.Repositories
{
    public class TicketRepository
    {

        /// <summary>
        /// call this when opening
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Ticket MakeTicket(UserInfo user)
        {
            Ticket t = new Ticket();

            //t.Name = "name: killian.deloof";
            t.Name = "name: " + user.FirstName + "." + user.LastName;
            t.PriorityId = new int?();
            t.TopicId = new int?();
            //t.Email = "killian.deloof@student.howest.be";
            t.Email = user.Email;

            return t;
        }

        public Ticket FormatTicket(Ticket t, string subject, string message, SubCategory cat)
        {
            //t.Subject = "need koffie";
            t.Subject = subject;
            //t.Message = "de koffie automaat werkt niet!, i need my koffie" + _r;
            t.Message = message;
            t.Forum = "what is this field?";
            //t.Category = "automaten";
            t.Category = cat.ToString();
            t.Category = "automaten";//temp hardcoded


            return t;
        }

        public async Task SendTicket(Ticket t)
        {
            String res = await AzureMobileClient.DefaultClient.InvokeApiAsync<Ticket, string>("/api/OSTicket", t, System.Net.Http.HttpMethod.Post, null, System.Threading.CancellationToken.None);
        }

        public Ticket AddAtachment(Ticket t, MediaFile file)
        {
            Attachment at = new Attachment();
            //at.Name = "photo.jpg";
            at.Name = DateTime.Now.ToString() + ".jpg";
            byte[] bytearr = MediaPicker.MediaFileToByteArr(file);
            at.Content = bytearr;
            at.Type = "jpg";
            t.Attachments.Add(at);
            return t;
        }


    }
}
