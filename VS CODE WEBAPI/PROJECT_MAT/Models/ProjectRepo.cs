using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_MAT.Models
{
    public class ProjectRepo:IprojectRepository
    {

        private MaturityAssessmenttoolContext _dbcontext;
        public ProjectRepo()
        {
            _dbcontext = new MaturityAssessmenttoolContext();
        }
        public ProjectRepo(MaturityAssessmenttoolContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public Task<Users> checkpassword(string emailid, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(Project projects)
        {
            try
            {
                _dbcontext.Project.Add(projects);
                _dbcontext.SaveChanges();
                return projects.ProjectId;
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Project>> GetAll()
        {
            try
            {
                var use = await _dbcontext.Project.ToListAsync<Project>();
                return use;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Project>> projectdetails(int id)
        {
            try
            {
                var projectdetails = await _dbcontext.Project.Where(x => x.ProjectId == id).ToListAsync<Project>();


                return projectdetails;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
