using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RoomBookAPI.ApplicationDbContext;
using RoomBookAPI.Interfaces;
using RoomBookAPI.Models;

namespace RoomBookAPI.Services
{
    public class AuthService(AppDbContext appDbContext, IConfiguration configuration) : IAuthService
    {
        private readonly AppDbContext _dbContext = appDbContext;
        private readonly IConfiguration _config = configuration;

        public async Task<string> LoginAsync(string email, string password)
        {
            User user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            // Validate user credential
            if (user == null || BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new UnauthorizedAccessException("invalid credential");
            }

            return GenerateJwtToken(user);
        }

        public async Task<string> RegisterAsync(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            await _dbContext.Users.AddAsync(user);
            var result = await _dbContext.SaveChangesAsync();
            if (result != 1)
            {
                throw new Exception("invalid operation");
            }
            return "User registered successfully.";
        }

        // Method to generate JWT token
        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // Create a jwt claim
            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}