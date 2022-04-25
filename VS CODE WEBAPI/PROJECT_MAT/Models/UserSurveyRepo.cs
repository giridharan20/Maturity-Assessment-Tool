using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_MAT.Models
{
    public class UserSurveyRepo : IUserSurveyRepository
    {
        private MaturityAssessmenttoolContext _dbcontext;
        public UserSurveyRepo()
        {
            _dbcontext = new MaturityAssessmenttoolContext();
        }
        public UserSurveyRepo(MaturityAssessmenttoolContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<UserSurvey> ADDQuestiontosurvey(UserSurvey userSurvey)
        {
            try
            {
                _dbcontext.UserSurvey.Add(userSurvey);
                _dbcontext.SaveChanges();
                return userSurvey;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<object>> GetAllQuestionandanswers()
        {
            try
            {
                var QNA = await _dbcontext.Answers.Join(_dbcontext.Questions, answer => answer.QuestionId, question => question.QuestionId, (answer, question) => new { AnswerId= answer.AnswerId, Answer = answer.Answer, AnswerWightage = answer.AnswerWeightage,
                    QuestionId=question.QuestionId, Question = question.Question }).ToListAsync<object>();


                return QNA;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<UserSurvey>> getusersurveydetails()
        {
            try
            {
                var use = await _dbcontext.UserSurvey.ToListAsync<UserSurvey>();
                return use;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<object>> getusersurveydetailsbyid(int id)
        {
            try
            {
                var use = await _dbcontext.UserSurvey.Join
                    (_dbcontext.Questions, 
                    survey => survey.QuestionId,
                    question => question.QuestionId,
                    (survey, question) => new 
                    {surveyid=survey.SurveyId,QuestionId=question.QuestionId, Question=question.Question}
                    
                    ).

                    Join(_dbcontext.Answers,
                    survey=>survey.QuestionId,
                    answers=>answers.QuestionId,
                    (survey, answers) => new 
                    {Surveyid=survey.surveyid , Question=survey.Question,Answer=answers.Answer,answerwightage=answers.AnswerWeightage}
                    ).
                    Join(_dbcontext.Survey,
                    usersurvey => usersurvey.Surveyid,
                    survey=>survey.SurveyId,
                    (usersurvey, survey) => new
                    { Surveyid = usersurvey.Surveyid,Surveyname=survey.Surveyname,surveystartdate=survey.SurveyStartDate,surveyenddate=survey.SurveyEndDate, Question = usersurvey.Question, Answer = usersurvey.Answer, answerwightage = usersurvey.answerwightage}
                    )
                    .
                    Where(x=> x.Surveyid==id)
                    .
                    
                    
                    ToListAsync<object>();
                return use;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
