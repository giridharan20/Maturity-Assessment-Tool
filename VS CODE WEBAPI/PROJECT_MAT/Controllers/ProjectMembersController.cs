using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECT_MAT.Models;

namespace PROJECT_MAT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectMembersController : ControllerBase
    {
        private readonly MaturityAssessmenttoolContext _context;
        private IProjectMemberRepository _repo;

        public ProjectMembersController(IProjectMemberRepository repo)
        {
            _repo = repo;
            _repo = new projectmemberrepo(new MaturityAssessmenttoolContext());

        }

        // GET: api/ProjectMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectMembers>>> GetProjectMembers()
        {
            return await _repo.GetAll();
        }

        // GET: api/ProjectMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<object>>> GetProjectMembers(int id)
        {
            return await _repo.GetAllmembers(id);
        }

        //// PUT: api/ProjectMembers/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProjectMembers(int id, ProjectMembers projectMembers)
        //{
        //    if (id != projectMembers.ProjectMemberId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(projectMembers).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProjectMembersExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/ProjectMembers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProjectMembers>> PostProjectMembers(ProjectMembers projectMembers)
        {
            await _repo.Create(projectMembers);

            return projectMembers;
        }

        // DELETE: api/ProjectMembers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectMembers>> DeleteProjectMembers(int id)
        {
            var projectMembers = await _context.ProjectMembers.FindAsync(id);
            if (projectMembers == null)
            {
                return NotFound();
            }

            _context.ProjectMembers.Remove(projectMembers);
            await _context.SaveChangesAsync();

            return projectMembers;
        }

        private bool ProjectMembersExists(int id)
        {
            return _context.ProjectMembers.Any(e => e.ProjectMemberId == id);
        }
    }
}
