using System.Security.Authentication;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RoomBookAPI.Dto;
using RoomBookAPI.Interfaces;
using RoomBookAPI.Models;

namespace RoomBookAPI.Controllers
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthController(IAuthService authService, IMapper mapper) : ControllerBase
    {
        private readonly IAuthService _authService = authService;
        private readonly IMapper _mapper = mapper;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = _mapper.Map<User>(registerDto);

                int result = await _authService.RegisterAsync(user);

                if (result != 1)
                {
                    throw new InvalidOperationException("Register failed due to unknown error");
                }
                return Ok(new { Message = "User register successful" });
            }
            catch (InvalidOperationException ex)
            {
                // Log the exception (optional, e.g., use ILogger)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "An unexpected error occurred" });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                string token = await _authService.LoginAsync(loginDto.Email, loginDto.Password);

                return Ok(new { Token = token });
            }
            catch (InvalidCredentialException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { Error = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "An unexpected error occurred" });
            }
        }
    }
}