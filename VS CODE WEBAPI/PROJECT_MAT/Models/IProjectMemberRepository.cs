using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT_MAT.Models
{
    public interface IProjectMemberRepository
    {
        Task<int> Create(ProjectMembers projectmember);
        Task<List<ProjectMembers>> GetAll();
        Task<List<object>> GetAllmembers(int id);
    }
}

