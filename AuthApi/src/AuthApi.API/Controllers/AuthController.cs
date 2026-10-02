using AuthApi.Application.Auth.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;

        public AuthController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginCommand command, CancellationToken cancellationToken)
        {
            var token = await _sender.Send(command, cancellationToken);

            return Ok(token);
        }
    }
}
