using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_MAT.Models
{
   public interface ISurveyRepository
    {
        Task<int> Create(Survey survey);
        Task<List<Survey>> GetAll();
        Task<List<Survey>> GetAllsurveybyid(int id);

    }
}
