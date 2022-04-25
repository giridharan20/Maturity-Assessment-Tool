using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_MAT.Models
{
    public class UserRepo : IUserRepository
    {

        private MaturityAssessmenttoolContext _dbcontext;
        public UserRepo()
        {
            _dbcontext = new MaturityAssessmenttoolContext();
        }
        public UserRepo(MaturityAssessmenttoolContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

       

        public async Task<Users> checkpassword(string emailid, string password)
        {
            try
            {
                var empgetbyid = await _dbcontext.Users.Where(x => x.Emailid == emailid).Where(x => x.Password == password).FirstOrDefaultAsync();
                return empgetbyid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    

        public async Task<int> Create(Users user)
        {
            try
            {
                _dbcontext.Users.Add(user);
                _dbcontext.SaveChanges();
                 return user.UserId;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Users>> GetAll()
        {
            try
            {
                var use = await _dbcontext.Users.ToListAsync<Users>();
                return use;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<object>> getuserdetailsbyid(int id)
        {
          var user = await _dbcontext.Users.Join(_dbcontext.ProjectMembers,user=>user.UserId,member=>member.UserId,(user, member)=>new { UserId = user.UserId, FirstName = user.FirstName, Emailid = user.Emailid, ProjectId = member.ProjectId})
                     .Join(_dbcontext.Project,member=>member.ProjectId,project=>project.ProjectId,(member,project)=>new { UserId = member.UserId, FirstName = member.FirstName, Emailid = member.Emailid, ProjectId = member.ProjectId, Projectname = project.Projectname, ProjectDescription = project.ProjectDescription }).Where(x => x.UserId==id).ToListAsync<object>();

            return user;

        }
    }
}
