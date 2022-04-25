using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PROJECT_MAT.Models
{
    public partial class Survey
    {
        public Survey()
        {
            UserSurvey = new HashSet<UserSurvey>();
        }

        public int SurveyId { get; set; }
        public string Surveyname { get; set; }
        public DateTime? SurveyStartDate { get; set; }
        public DateTime? SurveyEndDate { get; set; }
        public int? ProjectId { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<UserSurvey> UserSurvey { get; set; }
    }
}
