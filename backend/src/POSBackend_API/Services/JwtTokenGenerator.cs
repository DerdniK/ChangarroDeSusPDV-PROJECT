using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using POSBackend_API.Models;

namespace POSBackend_API.Services;

public class JwtTokenGenerator
{
    private readonly IConfiguration _config;

    public JwtTokenGenerator(IConfiguration config)
    {
        _config = config;
    }

    public string GenerateToken(User user)
    {
        var jwtSettings = _config.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"]!;

        var claims = new[] //? Son datos que viajan en el JWT sin necesidad de claves
        {
            new Claim(JwtRegisteredClaimNames.Sub, User.UserId.ToString()), //? A quien le pertenece el token
            new Claim("User_FirstName", User.First_name),
            new Claim("User_LastName", User.Last_name),
            new Claim("roleId", User.RoleID) //? Guarda el identificador de rol
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"], //? Emisor de los Tokens 
            audience: jwtSettings["Audience"], //? A quien esta destinado el token generado
            claims: claims,
            expires: DateTime.UtcNow.AddHours(double.Parse(jwtSettings["ExpirationInHours"] ?? "2")), //* Tiempo de vida del token
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}