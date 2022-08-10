using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Tracking.Backend.Models
{
    public class User : IdentityUser<int>
    {
        //public int u_id { get; set; }    //PK
        public string fullname { get; set; }
        //public string email { get; set; }
        //public string password { get; set; }
        public bool is_active { get; set; }
        public bool is_admin { get; set; }
        [DataType(DataType.Date)]
        public DateTime create_date { get; set; }
    }
}
