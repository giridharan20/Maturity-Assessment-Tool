using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PROJECT_MAT.Models
{
    public partial class ProjectMembers
    {
        public int ProjectMemberId { get; set; }
        public int? ProjectId { get; set; }
        public int? UserId { get; set; }

        public virtual Project Project { get; set; }
        public virtual Users User { get; set; }
    }
}
