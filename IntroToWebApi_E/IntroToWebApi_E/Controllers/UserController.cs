using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IntroToWebApi_E.EF;
using IntroToWebApi_E.Model;
using IntroToWebApi_E.Guard;

namespace IntroToWebApi_E.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        [SessionAuthorizer]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("{department}")]
        public IActionResult GetUsersByDepartment(string department)
        {
            var users = _context.Users.Where(u => u.department == department).ToList();
            return Ok(users);
        }

        [HttpPost("")]
        public IActionResult CreateUser(User user)
        {
            var exisitngUser = _context.Users.FirstOrDefault(u => u.email == user.email);
            if(user != null)
            {
                return StatusCode(409, new {message = "User with this email already exists",});
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUsers), new { id = user.id }, user);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateUser(Guid id, User updatedUser)
        {
            var user = _context.Users.FirstOrDefault(s => s.id == id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                user.email = updatedUser.email;
                user.password = updatedUser.password;
                user.department = updatedUser.department;
                user.CreditCompleted = updatedUser.CreditCompleted;
                _context.SaveChanges();
                return StatusCode(200, new { message = "User updated successfully" });
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            var user = _context.Users.FirstOrDefault(s=>s.id == id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User credentials)
        { 
            var user = _context.Users.FirstOrDefault(u => u.email == credentials.email && u.password == credentials.password);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }
            HttpContext.Session.SetString("email", user.email);
            return Ok(new { message = "Login successful", user = user });
        }
    }
}
