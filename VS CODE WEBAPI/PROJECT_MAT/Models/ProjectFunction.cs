using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PROJECT_MAT.Models
{
    public partial class ProjectFunction
    {
        public ProjectFunction()
        {
            Project = new HashSet<Project>();
            Questions = new HashSet<Questions>();
        }

        public int FunctionId { get; set; }
        public string FunctionName { get; set; }

        public virtual ICollection<Project> Project { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
    }
}
