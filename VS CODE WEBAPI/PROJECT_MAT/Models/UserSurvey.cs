using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PROJECT_MAT.Models
{
    public partial class UserSurvey
    {
        public int UserSurveyId { get; set; }
        public int? QuestionId { get; set; }
        public int? AnswerId { get; set; }
        public int? SurveyId { get; set; }

        public virtual Answers Answer { get; set; }
        public virtual Questions Question { get; set; }
        public virtual Survey Survey { get; set; }
    }
}
