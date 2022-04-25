using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_MAT.Models
{
    public class projectmemberrepo : IProjectMemberRepository

    {
        private MaturityAssessmenttoolContext _dbcontext;
        public projectmemberrepo()
        {
            _dbcontext = new MaturityAssessmenttoolContext();
        }
        public projectmemberrepo(MaturityAssessmenttoolContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<int> Create(ProjectMembers projectmember)
        {
            try
            {
                _dbcontext.ProjectMembers.Add(projectmember);
                _dbcontext.SaveChanges();
                return projectmember.ProjectMemberId;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ProjectMembers>> GetAll()
        {
            try
            {

                var use = await _dbcontext.ProjectMembers.ToListAsync<ProjectMembers>();
                return use;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<object>> GetAllmembers(int id)
        {
            try
            {
                var use = await _dbcontext.ProjectMembers.Join(_dbcontext.Users, c => c.UserId, cm => cm.UserId, (c, cm) => new {ProjectMemberId = c.ProjectMemberId,ProjectId = c.ProjectId,UserId = c.UserId,FirstName = cm.FirstName,LastName =cm.LastName,Emailid=cm.Emailid}).Where(x => x.ProjectId == id).ToListAsync<object>();


                return use;
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
