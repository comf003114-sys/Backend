using ChaChaClub.BusinessLogic.Core.Auth;
using ChaChaClub.BusinessLogic.Interface;
using ChaChaClub.DataAccess;
using ChaChaClub.Domains.Entities.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChaChaClub.BusinessLogic.Functions.Auth
{
    public class AuthFlow : AuthActions, IAuth
    {
        private readonly string _jwtSecret;

        public AuthFlow(DbSession session, string jwtSecret) : base(session)
        {
            _jwtSecret = jwtSecret;
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await GetUserByEmail(email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                throw new Exception("Invalid email or password");

            return GenerateToken(user);
        }

        public async Task Register(string username, string email, string password)
        {
            var existing = await GetUserByEmail(email);
            if (existing != null)
                throw new Exception("Email already in use");

            var user = new UserData
            {
                Username = username,
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(password)
            };

            await CreateUser(user);
        }

        private string GenerateToken(UserData user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}