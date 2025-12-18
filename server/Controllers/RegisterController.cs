using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Models.ViewModels;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly AppDBContext _context;
        public RegisterController(AppDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginViewModel model)
        {
            
            var exists = await _context.Users
                .AnyAsync(u => u.Username == model.Username);

            if (exists)
                return BadRequest("User already exists");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

            var user = new User { Username = model.Username , Password = passwordHash };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
    }
}
