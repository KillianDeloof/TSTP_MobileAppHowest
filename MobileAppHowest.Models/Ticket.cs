using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppHowest.Models
{
    /// <summary>
    /// Represents a Ticket in the OsTicket system
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// Constructs a new Ticket
        /// </summary>
        public Ticket(UserInfo user)
        {
            Attachments = new List<Attachment>();
            ExtraFields = new Dictionary<string, object>();
            Name = "name: " + user.FirstName + "." + user.LastName;
            PriorityId = new int?();
            TopicId = new int?();
            Email = user.Email;
        }




        /// <summary>
        /// adds the required fields to the ticket
        /// </summary>
        /// <param name="subject">title of the ticket</param>
        /// <param name="message">the message of the ticket</param>
        /// <param name="cat">the subcategory of the ticket</param>
        public void FormatTicket(string subject, string message, Category cat)
        {

            Subject = subject;
            Message = message;
            Forum = "No Location";
            Category = cat.ToString();
            if (String.IsNullOrEmpty(cat.SubCategoryUDesc))
            {
                Category = "No MainCategory";
            }
        }

        public void FormatTicket(string subject, string message, Category cat, Room location)
        {
            FormatTicket(subject, message, cat);
            Location = location;
            Forum = "Location: " + location.UDESC;      
        }


        public void AddAtachment(byte[] byteArray)
        {
            if (byteArray.Length >= 3000000)
            {
                Attachment at = new Attachment();
                at.Name = DateTime.Now.ToString() + ".jpg";
                at.Content = byteArray;
                at.Type = "jpg";
                Attachments.Add(at);
            }
            else
            {
                //photo to big
            }
        }

        public void AddAtachment(MediaFile mediaFile)
        {
            byte[] byteArr;
            using (var memoryStream = new MemoryStream())
            {
                mediaFile.GetStream().CopyTo(memoryStream);
                mediaFile.Dispose();
                byteArr = memoryStream.ToArray();
            }
            AddAtachment(byteArr);
        }

        /// <summary>
        /// The e-mail address of the user submitting the ticket. This
        /// value must parse into an e-mail address otherwise OsTicket will
        /// throw an exception on submission
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// The name of the user submitting the ticket.
        /// </summary>
        public string Name { get; private set; }

        public string Forum { get; set; }
        public string Category { get; private set; }
        public string Source { get; set; }

        public Room Location { get; private set; }

        /// <summary>
        /// A summary of the issue that the user is facing
        /// </summary>
        public string Subject { get; private set; }

        /// <summary>
        /// A description of the issue that the user is facing.
        /// If IsMessageHtml is true, then this field is treated as HTML
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Whether or not to treat the Message property as an HTML fragment or plain text.
        /// By default, it is treated as Plain Text.
        /// </summary>
        public bool IsMessageHtml { get; set; }

        /// <summary>
        /// The IP Address of the user sending the message.
        /// While this is not a required property, OsTicket can be configured to blacklist
        /// users based on their IP Address.
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// The Help Topic Id of the Ticket.
        /// </summary>
        /// <remarks>
        /// OsTicket does not expose this value by default, but it can be found via inspection of the HTML
        /// or via the API extensions provided by this library.
        /// </remarks>
        public int? TopicId { get; private set; }

        /// <summary>
        /// The Priority Id of the Ticket
        /// </summary>
        /// <remarks>
        /// OsTicket does not expose this value by default, but it can be found via inspection of the HTML
        /// or via the API extensions provided by this library.
        /// </remarks>
        public int? PriorityId { get; private set; }

        /// <summary>
        /// The list of attachments to add to this Ticket
        /// </summary>
        public List<Attachment> Attachments { get; set; }//has to be public set to be able to sent to api

        /// <summary>
        /// The list of extra fields to populate with this ticket. The keys are specified in the OsTicket UI
        /// </summary>
        public Dictionary<string, object> ExtraFields { get; private set; }












    }
}
