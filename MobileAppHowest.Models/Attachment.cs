using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MobileAppHowest.Models
{
    /// <summary>
    /// Represents an Attachment in the OsTicket system
    /// </summary>
    public class Attachment
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }


        /// <summary>
        /// The Filename of the Attachment
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The Content MIME Type of the Attachment
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// The actual byte content of the Attachment
        /// </summary>
        public byte[] Content { get; set; }



        public override string ToString()
        {
            return Name; 
        }
    }
}
