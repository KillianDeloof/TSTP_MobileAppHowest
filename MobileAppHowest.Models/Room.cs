using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MobileAppHowest.Models
{
    public class Room : BaseItem
    {
        [PrimaryKey, AutoIncrement]
        public int FloorID { get; set; }
        public string UCODE { get; set; }
        public string UDESC { get; set; }
        public string CCODE { get; set; }
        public string CDESC { get; set; }
        [Ignore]
        public string Number { get; set; }
        [Ignore]
        public String RoomInfo { get; set; }

        [Ignore]
        public int? RoomCategoryID { get; set; }

        [Ignore]
        public int? RoomFunctionID { get; set; }

        [Ignore]
        public double? Surface { get; set; }

        [Ignore]
        public int? UtilisationCapacity { get; set; }

        //number of chairs for students
        [Ignore]
        public int? OccupationCapacity { get; set; }        //1 or 0: 1 can be rostered, 0 cannot
        [Ignore]
        public String ConstructionPlanCode { get; set; }    //the id on the constructionplan
        [Ignore]
        public String IMKey { get; set; }
        [Ignore]
        public Boolean Rosterable { get; set; }
        [Ignore]
        public String OccupantName { get; set; }
        [Ignore]
        public String Telephone { get; set; }
        [Ignore]
        public String Department { get; set; }
        [Ignore]
        public String Projector { get; set; }
        [Ignore]
        public String Boards { get; set; }
        [Ignore]
        public String Equipment1 { get; set; }
        [Ignore]
        public String Equipment2 { get; set; }
        [Ignore]
        public String Curtains { get; set; }
        [Ignore]
        public String Furniture { get; set; }
        [Ignore]
        public String Facilities { get; set; }
        [Ignore]
        public String FloorMaterial { get; set; }

        [Ignore]
        public Floor Floor { get; set; }

        public override string ToString()
        {
            return UDESC + " / " + Number;
        }

    }
}
