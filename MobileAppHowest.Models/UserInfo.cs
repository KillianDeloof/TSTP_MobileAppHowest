using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MobileAppHowest.Models
{
    public class UserInfo
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(255)]
        public String FirstName { get; set; }
        [MaxLength(255)]
        public string LastName { get; set; }
        [MaxLength(255)]
        public string Email { get; set; }

        [Ignore]
        public List<String> Roles { get; set; } = new List<string>();
        [Ignore]
        public String KernelTeamCCode { get; set; }
        [Ignore]
        public List<String> EducationCodes { get; set; } = new List<string>();


        //public DateTime ExpireDate { get; set; }
        public override string ToString()
        {
            return FirstName;
        }
    }
}
