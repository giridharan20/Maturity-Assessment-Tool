using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PROJECT_MAT.Models
{
    public partial class Questions
    {
        public Questions()
        {
            Answers = new HashSet<Answers>();
            UserSurvey = new HashSet<UserSurvey>();
        }

        public int QuestionId { get; set; }
        public string Question { get; set; }
        public int? FunctionId { get; set; }

        public virtual ProjectFunction Function { get; set; }
        public virtual ICollection<Answers> Answers { get; set; }
        public virtual ICollection<UserSurvey> UserSurvey { get; set; }
    }
}
