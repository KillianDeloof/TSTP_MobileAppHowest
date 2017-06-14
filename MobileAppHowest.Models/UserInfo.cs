﻿using System;
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
        public String FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        public List<String> Roles { get; set; } = new List<string>();
        public String KernelTeamCCode { get; set; }
        public List<String> EducationCodes { get; set; } = new List<string>();


        //public DateTime ExpireDate { get; set; }
        public override string ToString()
        {
            return FirstName;
        }
    }
}
