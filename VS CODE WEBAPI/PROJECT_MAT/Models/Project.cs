using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PROJECT_MAT.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectMembers = new HashSet<ProjectMembers>();
            Survey = new HashSet<Survey>();
        }

        public int ProjectId { get; set; }
        public string Projectname { get; set; }
        public string ProjectDescription { get; set; }
        public int? FunctionId { get; set; }

        public virtual ProjectFunction Function { get; set; }
        public virtual ICollection<ProjectMembers> ProjectMembers { get; set; }
        public virtual ICollection<Survey> Survey { get; set; }
    }
}
