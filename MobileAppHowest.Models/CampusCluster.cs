using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MobileAppHowest.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CampusCluster 
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string UCODE { get; set; }
        public string UDESC { get; set; }
        public string CCODE { get; set; }
        public string CDESC { get; set; }
        public String IMKey { get; set; }
    }
}
