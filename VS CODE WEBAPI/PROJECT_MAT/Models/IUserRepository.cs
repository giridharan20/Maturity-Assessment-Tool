using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_MAT.Models
{
    public interface IUserRepository
    {
        Task<int> Create(Users user);
        Task<List<Users>> GetAll();
        
        Task<Users> checkpassword(string emailid, string password);

        Task<List<object>> getuserdetailsbyid(int id);
    }
}
