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
    public class UserSurveysController : ControllerBase
    {
        private readonly MaturityAssessmenttoolContext _context;
        private IUserSurveyRepository _repo;

        public UserSurveysController(IUserSurveyRepository repo)
        {
            _repo = repo;
            _repo = new UserSurveyRepo(new MaturityAssessmenttoolContext());

        }

        // GET: api/UserSurveys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSurvey>>> GetUserSurvey()
        {
            return await _repo.getusersurveydetails();
        }

        // GET: api/UserSurveys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<object>>> GetUserSurvey(int id)
        {
            return await _repo.getusersurveydetailsbyid(id);
        }

        // PUT: api/UserSurveys/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserSurvey(int id, UserSurvey userSurvey)
        {
            if (id != userSurvey.UserSurveyId)
            {
                return BadRequest();
            }

            _context.Entry(userSurvey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSurveyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserSurveys
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserSurvey>> PostUserSurvey(UserSurvey userSurvey)
        {
            return await _repo.ADDQuestiontosurvey(userSurvey);
        }

        // DELETE: api/UserSurveys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserSurvey>> DeleteUserSurvey(int id)
        {
            var userSurvey = await _context.UserSurvey.FindAsync(id);
            if (userSurvey == null)
            {
                return NotFound();
            }

            _context.UserSurvey.Remove(userSurvey);
            await _context.SaveChangesAsync();

            return userSurvey;
        }

        private bool UserSurveyExists(int id)
        {
            return _context.UserSurvey.Any(e => e.UserSurveyId == id);
        }
    }
}
