using ChaChaClub.Domains.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace ChaChaClub.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly BusinessLogic.BusinessLogic _bl;

        public AuthController(BusinessLogic.BusinessLogic bl)
        {
            _bl = bl;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            try
            {
                var token = await _bl.Auth().Login(dto.Email, dto.Password);
                return Ok(new { access_token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            try
            {
                await _bl.Auth().Register(dto.Username, dto.Email, dto.Password);
                return Ok(new { message = "User registered successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}