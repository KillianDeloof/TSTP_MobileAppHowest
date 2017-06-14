using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MobileAppHowest.Models
{
    public partial class Floor
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int FloorID { get; set; }
        public int BuildingID { get; set; }
        public int WingID { get; set; }
        public string UCODE { get; set; }
        public string UDESC { get; set; }
        public string CCODE { get; set; }
        public string CDESC { get; set; }
        public virtual Wing Wing { get; set; }
        public String IMKey { get; set; }

        public override string ToString()
        {
            return UDESC;
        }
    }
}
