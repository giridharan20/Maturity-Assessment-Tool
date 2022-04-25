using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_MAT.Models
{
    public interface IprojectRepository
    {
        Task<int> Create(Project projects);
        Task<List<Project>> GetAll();

        Task<Users> checkpassword(string emailid, string password);
        Task<List<Project>> projectdetails(int id);
    }
}
