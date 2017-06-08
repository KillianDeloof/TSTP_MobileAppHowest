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


        public static Ticket MakeTicket()
        {
            Ticket t = new Ticket();
            t.Name = "name: killian.deloof";
            t.Subject = "need koffie";
            t.PriorityId = new int?();
            t.TopicId = new int?();
            t.Email = "killian.deloof@student.howest.be";
            t.Message = "de koffie automaat werkt niet!, i need my koffie" + _r;

            t.Forum = "what is this field?";
            t.Category = "automaten";

            return t;
        }

        public static Ticket FormatTicket()
        {
            return null;
        }

        public static async Task SendTicket(Ticket t)
        {
            String res = await AzureMobileClient.DefaultClient.InvokeApiAsync<Ticket, string>("/api/OSTicket", t, System.Net.Http.HttpMethod.Post, null, System.Threading.CancellationToken.None);
        }

        public static Ticket AddAtachment(Ticket t, MediaFile file)
        {
            Attachment at = new Attachment();
            at.Name = "photo.jpg";
            byte[] bytearr = MediaPicker.MediaFileToByteArr(file);
            at.Content = bytearr;
            at.Type = "jpg";
            t.Attachments.Add(at);
            return t;
        }


    }
}
