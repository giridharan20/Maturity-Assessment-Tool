using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PROJECT_MAT.Models
{
    public partial class Users
    {
        public Users()
        {
            ProjectMembers = new HashSet<ProjectMembers>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserType { get; set; }
        public string Emailid { get; set; }
        public string Password { get; set; }

        public virtual ICollection<ProjectMembers> ProjectMembers { get; set; }
    }
}
