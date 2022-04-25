using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PROJECT_MAT.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT_MAT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MaturityAssessmenttoolContext _context;
        private IUserRepository _repo;

        public UsersController(IUserRepository repo)
        {
            _repo = repo;
            _repo = new UserRepo(new MaturityAssessmenttoolContext());

        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _repo.GetAll();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            await _repo.Create(users);

            return users;
        }

        [HttpPost, Route("login")]
        //public  IActionResult<Users> Login([FromBody] Users user)
        public async Task<ActionResult<Users>> Login(Users user)
        {
            var user1 = await _repo.checkpassword(user.Emailid,user.Password);
            if (user1 == null)
            {
                return BadRequest("Invalid client request");
            }
            
            if (user.Emailid==user1.Emailid && user.Password ==user1.Password)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:22252",
                    audience: "http://localhost:22252",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddDays(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost, Route("getusertype")]
        public async Task<ActionResult<Users>> Getuserbyemail(Users user)
        {
            var user1 =await _repo.checkpassword(user.Emailid,user.Password);
            if (user1 == null)
            {
                return NotFound();
            }
            return user1;
        }



        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<object>>> GetUserdetails(int id)
        {
            return await _repo.getuserdetailsbyid(id);
        }


        //// PUT: api/Users/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUsers(int id, Users users)
        //{
        //    if (id != users.UserId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(users).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UsersExists(id))
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



        //// DELETE: api/Users/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Users>> DeleteUsers(int id)
        //{
        //    var users = await _context.Users.FindAsync(id);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Users.Remove(users);
        //    await _context.SaveChangesAsync();

        //    return users;
        //}

        //private bool UsersExists(int id)
        //{
        //    return _context.Users.Any(e => e.UserId == id);
        //}
    }
}
