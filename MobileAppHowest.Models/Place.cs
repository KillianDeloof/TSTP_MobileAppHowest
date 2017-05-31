using MobileAppHowest.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppHowest.Models
{
    public class Place : BaseFilter
    {
        // kan zowel een lokaal, verdiep, als een forum zijn
        public string UCode { get; set; }
        public string UDesc { get; set; }
    }
}
