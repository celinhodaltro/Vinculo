using Auth.Application.Interfaces;
using Auth.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly List<User> _users = new(); // Simulação (substitua com banco de dados)
    private readonly IConfiguration _config;
    private readonly PasswordHasher<User> _hasher = new();

    public AuthService(IConfiguration config)
    {
        _config = config;
    }

    public Task<bool> RegisterAsync(string username, string password)
    {
        if (_users.Any(u => u.Username == username))
            return Task.FromResult(false);

        var user = new User { Username = username };
        user.PasswordHash = _hasher.HashPassword(user, password);
        _users.Add(user);

        return Task.FromResult(true);
    }

    public Task<string?> AuthenticateAsync(string username, string password)
    {
        var user = _users.SingleOrDefault(u => u.Username == username);
        if (user == null) return Task.FromResult<string?>(null);

        var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, password);
        if (result == PasswordVerificationResult.Failed) return Task.FromResult<string?>(null);

        var token = GenerateJwtToken(user);
        return Task.FromResult<string?>(token);
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
