using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppHowest.Models
{
    public class Room
    {
        /// <summary>
        /// id of the room
        /// </summary>
        public int ID { get; set; }

        public int FloorID { get; set; }
        public string UCODE { get; set; }
        public string UDESC { get; set; }
        public string CCODE { get; set; }
        public string CDESC { get; set; }      
        public string Number { get; set; }
        public String RoomInfo { get; set; }
        public int? RoomCategoryID { get; set; }
        public int? RoomFunctionID { get; set; }
        public double? Surface { get; set; }
        public int? UtilisationCapacity { get; set; }    //number of chairs for students
        public int? OccupationCapacity { get; set; }     //1 or 0: 1 can be rostered, 0 cannot
        public String ConstructionPlanCode { get; set; }    //the id on the constructionplan
        public String IMKey { get; set; }
        public Boolean Rosterable { get; set; }
        public String OccupantName { get; set; }
        public String Telephone { get; set; }
        public String Department { get; set; }
        public String Projector { get; set; }
        public String Boards { get; set; }
        public String Equipment1 { get; set; }
        public String Equipment2 { get; set; }
        public String Curtains { get; set; }
        public String Furniture { get; set; }
        public String Facilities { get; set; }
        public String FloorMaterial { get; set; }

        public override string ToString()
        {
            return UDESC + " / " + Number;
        }

    }
}
