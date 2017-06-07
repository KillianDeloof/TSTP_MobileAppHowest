﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileAppHowest.Models
{
    public class Category
    {
        //public int CategoryId { get; set; }
        //public string CategoryUCode { get; set; }
        public string CategoryUDesc { get; set; }
        public string Picture { get; set; }
        public string Subtitle { get; set; }
        public List<SubCategory> SubCategoryList { get; set; }

        public override string ToString()
        {
            return CategoryUDesc;
        }
    }
}
