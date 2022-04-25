using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PROJECT_MAT.Models
{
    public partial class Answers
    {
        public Answers()
        {
            UserSurvey = new HashSet<UserSurvey>();
        }

        public int? QuestionId { get; set; }
        public int AnswerId { get; set; }
        public string Answer { get; set; }
        public int? AnswerWeightage { get; set; }

        public virtual Questions Question { get; set; }
        public virtual ICollection<UserSurvey> UserSurvey { get; set; }
    }
}
