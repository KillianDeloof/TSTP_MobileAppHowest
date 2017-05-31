using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileAppHowest.Models;

namespace MobileAppHowest.Models.Filters
{
    public class FloorFilter : BaseFilter
    {
        public Floor LastFloor { get; set; }
        public int? WingID { get; set; }
    }
}
