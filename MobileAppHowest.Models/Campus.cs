﻿using System;
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

        /// <summary>
        /// ex : BUD
        /// </summary>
        public string UCODE { get; set; }

        /// <summary>
        /// ex : campus budda
        /// </summary>
        public string UDESC { get; set; }

        /// <summary>
        /// ex : BUD
        /// </summary>
        public string CCODE { get; set; }

        /// <summary>
        /// ex : campus budda
        /// </summary>
        public string CDESC { get; set; }
        // -- uit te zoeken --//
        public String IMKey { get; set; }


        // lat en long van de campus
        public double[] LatLong { get; set; }

        // afstand van huidig punt tot afstand
        // wordt opgevuld in gps-repository
        public double Distance { get; set; }

        public override string ToString()
        {
            return UCODE + " - " + UDESC.Substring(7);
        }
    }
}
