using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileAppHowest.Models;

namespace MobileAppHowest.Models.Filters
{
    public class RoomFilter : BaseFilter
    {
        public Room LastRoom { get; set; }
        public int? FloorID { get; set; }
    }
}
