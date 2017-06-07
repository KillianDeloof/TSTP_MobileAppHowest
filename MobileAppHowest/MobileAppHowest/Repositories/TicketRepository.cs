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
        /// Hier worden de tickets verzonden naar de API.
        /// Er wordt een ticket meegegeven.
        /// </summary>
        /// <returns>Task</returns>
        public async Task SendTicket(Ticket ticket)
        {

            Ticket t = new Ticket();
            t.Name = "name: jef.daels";
            t.Subject = "xamarin test";
            t.PriorityId = new int?();
            t.TopicId = new int?();
            t.Email = "jef.daels@howest.be";
            t.Message = "dit is een test msg op tijdstip " + DateTime.Now.ToString("yyyy MM dd HH:mm:ss");

            t.Forum = "campus participatie OHK";
            t.Category = "Afvalbeheer";




            //byte[] bytes = null;
            //MediaFile photo;



            //FileStream fs = File.OpenRead(photo);
            //bytes = new byte[fs.Length];
            //fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
            //fs.Close();

            //Attachment at = new Attachment();
            //at.Name = System.IO.Path.GetFileName(ofd.FileName);
            //at.Content = bytes;
            //at.Type = "jpg";

            // t.Attachments.Add(photo);


            String res = await AzureMobileClient.DefaultClient.InvokeApiAsync<Ticket, string>("/api/OSTicket", t, System.Net.Http.HttpMethod.Post, null, System.Threading.CancellationToken.None);


        }
    }
}
