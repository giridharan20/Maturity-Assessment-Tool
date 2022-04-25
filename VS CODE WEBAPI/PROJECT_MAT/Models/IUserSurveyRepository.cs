using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_MAT.Models
{
    public interface IUserSurveyRepository
    {
        Task<UserSurvey> ADDQuestiontosurvey(UserSurvey userSurvey);
        Task<List<UserSurvey>> getusersurveydetails();
        Task<List<object>> getusersurveydetailsbyid(int id);
        Task<List<object>> GetAllQuestionandanswers();

       

    }
}
