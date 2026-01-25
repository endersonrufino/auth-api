using AuthApi.Application.DTOs;
using AuthApi.Domain.Entities;
using AuthApi.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthDbContext _context;
        private readonly IConfiguration _config;

        public AuthController(AuthDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            if (await _context.Users.AnyAsync(x => x.Email.Equals(request.Email)))
            {
                return BadRequest("Email já cadastradol!");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                ProfileId = request.Profile
            };

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            var user = await _context.Users
                .Include(x => x.Profile)
                .FirstOrDefaultAsync(x => x.Email == request.Email);

            if (user != null && !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return Unauthorized();
            }

            // var token = JwtTokenGenerator.Generate(user, _config);
            //return Ok(new { token });

            return Ok();
        }

    }
}
