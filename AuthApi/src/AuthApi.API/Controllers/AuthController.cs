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

        [HttpGet]
        

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            //var user = await _context.Users
            //    .Include(x => x.Perfis)
            //    .FirstOrDefaultAsync(x => x.Email == request.Email);

            //if (user != null && !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            //{
            //    return Unauthorized();
            //}

            // var token = JwtTokenGenerator.Generate(user, _config);
            //return Ok(new { token });

            return Ok();
        }

    }
}
