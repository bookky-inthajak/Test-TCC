using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Models.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDBContext _context;

        public LoginController(AppDBContext context)
        {
            _context = context;
        }

        // GET api/<LoginController>/5
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           var user = _context.Users.Find(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("User not found");
        }

        // POST api/<LoginController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginViewModel model, [FromServices] JwtTokenService service)
        {
            var user = await _context.Users.Where(u => u.Username == model.Username )
                .FirstOrDefaultAsync();

            if (user == null)
                return Unauthorized("Invalid username or password");

            bool isValid = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);

            if (!isValid)
                return Unauthorized("Invalid username or password");

            var token = service.GenerateToken(user);

            return Ok(new
            {
                token,
                user
            });

        }



    }



}
