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

        /// <summary>
        /// get the closest campus from a list of campusses or returns null if no campus is closer then minDistance
        /// </summary>
        /// <param name="campuslist">list of campusses to look</param>
        /// <param name="minDistance">minnimum distance te user needs to be to a campus </param>
        /// <returns>returns closest campusObject or returns null if no campus is closer then minDistance</returns>
        public static Campus GetClosestCampus(List<Campus> campuslist, double minDistance)
        {
            foreach (Campus camp in campuslist)
            {

            }
            return null;
        }



    }
}
