using ECommerce.AuthAPI.Data;
using ECommerce.AuthAPI.DTOs;
using ECommerce.AuthAPI.Models;
using ECommerce.AuthAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.AuthAPI.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly AuthDbContext _context;
        private readonly JwtTokenService _jwtService;

        public AuthController(AuthDbContext context, JwtTokenService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                return BadRequest("Email already exists.");

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = PasswordHasher.Hash(dto.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("Registration successful.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || !PasswordHasher.Verify(dto.Password, user.PasswordHash))
                return Unauthorized("Invalid credentials.");

            var token = _jwtService.CreateToken(user);
            return Ok(new { Token = token });
        }
    }
}
