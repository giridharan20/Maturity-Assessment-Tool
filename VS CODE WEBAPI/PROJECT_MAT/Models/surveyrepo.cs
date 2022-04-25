using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_MAT.Models
{
    public class surveyrepo: ISurveyRepository
    {

        private MaturityAssessmenttoolContext _dbcontext;
        public surveyrepo()
        {
            _dbcontext = new MaturityAssessmenttoolContext();
        }
        public surveyrepo(MaturityAssessmenttoolContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> Create(Survey survey)
        {
            try
            {
                _dbcontext.Survey.Add(survey);
                _dbcontext.SaveChanges();
                return survey.SurveyId;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Survey>> GetAll()
        {
            try
            {
                var use = await _dbcontext.Survey.ToListAsync<Survey>();
                return use;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Survey>> GetAllsurveybyid(int id)
        {
            try
            {
                var use = await _dbcontext.Survey.Where(x => x.ProjectId == id).ToListAsync<Survey>();


                return use;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
