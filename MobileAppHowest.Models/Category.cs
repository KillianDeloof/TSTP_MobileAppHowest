using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppHowest.Models
{
    public class Category
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryUCode { get; set; }
        public string SubCategoryUDesc { get; set; }
        public string Subtitle { get; set; }
        public bool IsLocationRequired { get; set; }

        public bool IsStaffRequired { get; set; }

        public override string ToString()
        {
            return SubCategoryUDesc;
        }
    }
}
