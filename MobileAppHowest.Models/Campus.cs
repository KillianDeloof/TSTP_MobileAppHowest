using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppHowest.Models
{
    public partial class Campus
    {
        public int? CampusClusterID { get; set; }
        public string Address { get; set; }
        public string UCODE { get; set; }
        public string UDESC { get; set; }
        public string CCODE { get; set; }
        public string CDESC { get; set; }
        public String IMKey { get; set; }
        public double[] LatLong { get; set; }
        public double Distance { get; set; }


    }
}
